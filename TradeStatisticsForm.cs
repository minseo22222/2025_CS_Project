using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class TradeStatisticsForm : Form
    {
        // DB 접속 문자열
        private readonly string _connectionString;

        public TradeStatisticsForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        // ─────────────────────────────────────
        // Form Load : 요약 통계 + 콤보박스 로드 + 필터 초기화
        // ─────────────────────────────────────
        private void TradeStatisticsForm_Load(object sender, EventArgs e)
        {
            // 날짜 필터 기본값 : 올해 1월 1일 ~ 오늘
            dtpFrom.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpTo.Value = DateTime.Today;

            // 거래유형 필터 : 전체 / 매입 / 매출
            cboTypeFilter.Items.Clear();
            cboTypeFilter.Items.Add("전체");
            cboTypeFilter.Items.Add("매입");
            cboTypeFilter.Items.Add("매출");
            cboTypeFilter.SelectedIndex = 0;   // 전체

            LoadSummaryTotals();   // 총 매입 / 매출 / 순이익
            LoadProductCombo();    // 상품 목록
            LoadCustomerCombo();   // 거래처 목록
        }

        // ─────────────────────────────────────
        // 현재 화면의 날짜 범위
        // ─────────────────────────────────────
        private DateTime FromDate => dtpFrom.Value.Date;
        private DateTime ToDate => dtpTo.Value.Date;

        // ─────────────────────────────────────
        // 현재 선택된 거래유형 필터 (전체일 경우 null 리턴)
        // ─────────────────────────────────────
        private string GetSelectedTradeTypeFilter()
        {
            if (cboTypeFilter.SelectedItem == null) return null;

            string txt = cboTypeFilter.SelectedItem.ToString();
            if (txt == "매입") { label8.Text = "총 구입 수량";label9.Text = "총 구입 금액"; }
            if (txt == "매출") { label8.Text = "총 매출 수량"; label9.Text = "총 매출 금액"; }
            if (txt == "매입" || txt == "매출")
                return txt;

            return null; // "전체"
        }

        // ─────────────────────────────────────
        // 날짜/유형 필터가 바뀔 때마다 전체 통계 다시 계산
        // ─────────────────────────────────────
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            ReloadAllStatistics();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            ReloadAllStatistics();
        }

        private void cboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 거래유형 바뀌면 상품 리스트도 다시 필터링해서 로드
            LoadProductCombo();

            // 날짜/유형 바뀔 때 전체 통계 다시 계산
            ReloadAllStatistics();
        }

        // 화면의 모든 통계(요약 + 상품 + 거래처)를 다시 로드
        private void ReloadAllStatistics()
        {
            LoadSummaryTotals();

            // 현재 선택된 상품이 있으면 그 상품 통계 다시 조회
            if (cboProduct.SelectedValue != null &&
                cboProduct.SelectedValue != DBNull.Value &&
                int.TryParse(cboProduct.SelectedValue.ToString(), out int pid))
            {
                LoadProductStatistics(pid);
            }
            else
            {
                lblProdQty.Text = "-";
                lblProdAmount.Text = "-";
            }

            // 현재 선택된 거래처가 있으면 그 거래처 통계 다시 조회
            if (cboCustomer.SelectedValue != null &&
                cboCustomer.SelectedValue != DBNull.Value &&
                int.TryParse(cboCustomer.SelectedValue.ToString(), out int cid))
            {
                LoadCustomerStatistics(cid);
            }
            else
            {
                lblCustCount.Text = "-";
                lblCustAmount.Text = "-";
            }
        }

        // ─────────────────────────────────────
        // 전체 매입/매출/순이익 계산
        //   Trade 테이블의 TotalAmount 사용
        //   → 날짜 범위는 적용, 거래유형 필터는 전체 기준(매입/매출 둘 다 보여줌)
        // ─────────────────────────────────────
        private void LoadSummaryTotals()
        {
            string sql = @"
                SELECT
                    NVL(SUM(DECODE(TradeType, '매입', TotalAmount, 0)), 0) AS TotalPurchase,
                    NVL(SUM(DECODE(TradeType, '매출', TotalAmount, 0)), 0) AS TotalSales
                FROM Trade
                WHERE TradeDate >= :fromDate
                  AND TradeDate <= :toDate";

            try
            {
                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("fromDate", OracleDbType.Date).Value = FromDate;
                    cmd.Parameters.Add("toDate", OracleDbType.Date).Value = ToDate;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            decimal totalPurchase = Convert.ToDecimal(rdr["TotalPurchase"]);
                            decimal totalSales = Convert.ToDecimal(rdr["TotalSales"]);
                            decimal netProfit = totalSales - totalPurchase;

                            lblTotalPurchase.Text = totalPurchase.ToString("N0");
                            lblTotalSales.Text = totalSales.ToString("N0");
                            lblNetProfit.Text = netProfit.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("전체 통계 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────
        // 상품 콤보박스 로드 (거래유형에 따라 카테고리 필터링)
        //   - 전체 : 모든 상품
        //   - 매입 : CATEGORY = '원재료'
        //   - 매출 : CATEGORY = '완제품'
        // ─────────────────────────────────────
        private void LoadProductCombo()
        {
            // 현재 선택된 거래유형 (전체일 경우 null)
            string tradeTypeFilter = GetSelectedTradeTypeFilter();

            string sql = @"
                SELECT ProductID, ProductName
                FROM Product";

            // TradeType 에 따라 카테고리를 나눔
            if (tradeTypeFilter == "매입")
            {
                // 매입이면 원재료만
                sql += " WHERE Category = '원재료'";
            }
            else if (tradeTypeFilter == "매출")
            {
                // 매출이면 완제품만
                sql += " WHERE Category = '완제품'";
            }

            sql += " ORDER BY ProductName";

            try
            {
                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sql, conn))
                using (var da = new OracleDataAdapter(cmd))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 맨 앞에 "상품 선택" 더미 행 추가
                    DataRow row = dt.NewRow();
                    row["ProductID"] = DBNull.Value;
                    row["ProductName"] = "상품 선택";
                    dt.Rows.InsertAt(row, 0);

                    cboProduct.DataSource = dt;
                    cboProduct.DisplayMember = "ProductName";
                    cboProduct.ValueMember = "ProductID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("상품 목록 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────
        // 거래처 콤보박스 로드
        // ─────────────────────────────────────
        private void LoadCustomerCombo()
        {
            string sql = @"
                SELECT CustomerID, CustomerName
                  FROM Customer
                 ORDER BY CustomerName";

            try
            {
                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sql, conn))
                using (var da = new OracleDataAdapter(cmd))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow row = dt.NewRow();
                    row["CustomerID"] = DBNull.Value;
                    row["CustomerName"] = "거래처 선택";
                    dt.Rows.InsertAt(row, 0);

                    cboCustomer.DataSource = dt;
                    cboCustomer.DisplayMember = "CustomerName";
                    cboCustomer.ValueMember = "CustomerID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("거래처 목록 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────
        // 상품 선택 변경 시 : 해당 상품의 통계
        //   - 날짜 범위 + (선택 시) 거래유형 필터 적용
        // ─────────────────────────────────────
        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedValue == null ||
                cboProduct.SelectedValue == DBNull.Value)
            {
                lblProdQty.Text = "-";
                lblProdAmount.Text = "-";
                return;
            }

            if (!int.TryParse(cboProduct.SelectedValue.ToString(), out int productId))
            {
                lblProdQty.Text = "-";
                lblProdAmount.Text = "-";
                return;
            }

            LoadProductStatistics(productId);
        }

        private void LoadProductStatistics(int productId)
        {
            // 선택된 거래유형 필터
            string tradeTypeFilter = GetSelectedTradeTypeFilter();

            string sql = @"
                SELECT
                    NVL(SUM(td.Quantity), 0) AS TotalQty,
                    NVL(SUM(td.Amount),   0) AS TotalAmount
                  FROM TradeDetail td
                  JOIN Trade t ON td.TradeID = t.TradeID
                 WHERE td.ProductID = :pid
                   AND t.TradeDate >= :fromDate
                   AND t.TradeDate <= :toDate";

            // 매입 / 매출 필터가 선택된 경우에만 조건 추가
            if (!string.IsNullOrEmpty(tradeTypeFilter))
            {
                sql += " AND t.TradeType = :ttype";
            }

            try
            {
                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("pid", OracleDbType.Int32).Value = productId;
                    cmd.Parameters.Add("fromDate", OracleDbType.Date).Value = FromDate;
                    cmd.Parameters.Add("toDate", OracleDbType.Date).Value = ToDate;

                    if (!string.IsNullOrEmpty(tradeTypeFilter))
                    {
                        cmd.Parameters.Add("ttype", OracleDbType.Varchar2).Value = tradeTypeFilter;
                    }

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            decimal totalQty = Convert.ToDecimal(rdr["TotalQty"]);
                            decimal totalAmount = Convert.ToDecimal(rdr["TotalAmount"]);

                            lblProdQty.Text = totalQty.ToString("N0");
                            lblProdAmount.Text = totalAmount.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("상품 통계 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────
        // 거래처 선택 변경 시 : 해당 거래처의 통계
        //   - 날짜 범위 + (선택 시) 거래유형 필터 적용
        // ─────────────────────────────────────
        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null ||
                cboCustomer.SelectedValue == DBNull.Value)
            {
                lblCustCount.Text = "-";
                lblCustAmount.Text = "-";
                return;
            }

            if (!int.TryParse(cboCustomer.SelectedValue.ToString(), out int customerId))
            {
                lblCustCount.Text = "-";
                lblCustAmount.Text = "-";
                return;
            }

            LoadCustomerStatistics(customerId);
        }

        private void LoadCustomerStatistics(int customerId)
        {
            string tradeTypeFilter = GetSelectedTradeTypeFilter();

            string sql = @"
                SELECT
                    NVL(COUNT(*), 0)         AS TradeCount,
                    NVL(SUM(TotalAmount), 0) AS TotalAmount
                  FROM Trade
                 WHERE CustomerID = :cid
                   AND TradeDate >= :fromDate
                   AND TradeDate <= :toDate";

            if (!string.IsNullOrEmpty(tradeTypeFilter))
            {
                sql += " AND TradeType = :ttype";
            }

            try
            {
                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("cid", OracleDbType.Int32).Value = customerId;
                    cmd.Parameters.Add("fromDate", OracleDbType.Date).Value = FromDate;
                    cmd.Parameters.Add("toDate", OracleDbType.Date).Value = ToDate;

                    if (!string.IsNullOrEmpty(tradeTypeFilter))
                    {
                        cmd.Parameters.Add("ttype", OracleDbType.Varchar2).Value = tradeTypeFilter;
                    }

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            decimal tradeCount = Convert.ToDecimal(rdr["TradeCount"]);
                            decimal totalAmount = Convert.ToDecimal(rdr["TotalAmount"]);

                            lblCustCount.Text = tradeCount.ToString("N0");
                            lblCustAmount.Text = totalAmount.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("거래처 통계 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
