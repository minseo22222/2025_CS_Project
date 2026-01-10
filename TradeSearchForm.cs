using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace _2025_CS_Project
{
    public partial class TradeSearchForm : Form
    {
        // 부모 Form 에서 넘겨받는 접속 문자열
        private readonly string _connectionString;

        // 선택된 거래번호를 부모에게 돌려줄 프로퍼티
        public int SelectedTradeId { get; private set; } = -1;

        // ─────────────────────────────
        // 생성자 : 접속 문자열을 매개변수로 받음
        // ─────────────────────────────
        public TradeSearchForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        // ─────────────────────────────
        // Form Load : 기본 날짜 세팅
        // ─────────────────────────────
        private void TradeSearchForm_Load(object sender, EventArgs e)
        {
            // 기본값 : 오늘 기준 한 달 전 ~ 오늘
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today.AddMonths(-1);

            // 그리드 기본 설정
            dgvTrade.ReadOnly = true;
            dgvTrade.AllowUserToAddRows = false;
            dgvTrade.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrade.MultiSelect = false;

            // ★ 창고 / 거래처 콤보박스 채우기
            LoadWarehouseCombo();
            LoadCustomerCombo();
        }

        // ★ 거래처 콤보박스 로드
        private void LoadCustomerCombo()
        {
            string sql = @"SELECT CustomerID, CustomerName
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

                    // 맨 위에 '전체' 용 더미 행 추가
                    DataRow row = dt.NewRow();
                    row["CustomerID"] = DBNull.Value;
                    row["CustomerName"] = "전체";
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


        // ★ 창고 콤보박스 로드
        private void LoadWarehouseCombo()
        {
            string sql = @"SELECT WarehouseID, WarehouseName
                     FROM Warehouse
                     ORDER BY WarehouseName";

            try
            {
                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sql, conn))
                using (var da = new OracleDataAdapter(cmd))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 맨 위에 '전체' 용 더미 행 추가
                    DataRow row = dt.NewRow();
                    row["WarehouseID"] = DBNull.Value;
                    row["WarehouseName"] = "전체";
                    dt.Rows.InsertAt(row, 0);

                    cboWarehouse.DataSource = dt;
                    cboWarehouse.DisplayMember = "WarehouseName";
                    cboWarehouse.ValueMember = "WarehouseID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("창고 목록 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ─────────────────────────────
        // 검색 버튼 클릭
        // ─────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTradeList();
        }

        // ─────────────────────────────
        // 날짜 범위로 거래 목록 조회
        // ─────────────────────────────
        private void LoadTradeList()
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDateNext = dtpTo.Value.Date.AddDays(1);

            // ★ 선택된 창고 / 거래처 값 읽기 (없으면 null)
            int? whId = null;
            if (cboWarehouse.SelectedValue != null &&
                cboWarehouse.SelectedValue != DBNull.Value)
            {
                whId = Convert.ToInt32(cboWarehouse.SelectedValue);
            }

            int? custId = null;
            if (cboCustomer.SelectedValue != null &&
                cboCustomer.SelectedValue != DBNull.Value)
            {
                custId = Convert.ToInt32(cboCustomer.SelectedValue);
            }

            // 기본 SQL
            string sql = @"
            SELECT  t.TradeID,
                t.TradeDate,
                t.TradeType,
                c.CustomerName,
                w.WarehouseName,
                t.TotalAmount
            FROM Trade t
            LEFT JOIN Customer  c ON t.CustomerID  = c.CustomerID
            LEFT JOIN Warehouse w ON t.DefaultWhID = w.WarehouseID
            WHERE t.TradeDate >= :fromDate
            AND t.TradeDate <  :toDateNext";

            // ★ 창고 / 거래처 선택시 조건 추가
            if (whId.HasValue)
            {
                sql += " AND t.DefaultWhID = :whId";
            }
            if (custId.HasValue)
            {
                sql += " AND t.CustomerID = :custId";
            }

            sql += " ORDER BY t.TradeDate, t.TradeID";

            try
            {
                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();

                    cmd.Parameters.Add("fromDate", OracleDbType.Date).Value = fromDate;
                    cmd.Parameters.Add("toDateNext", OracleDbType.Date).Value = toDateNext;

                    if (whId.HasValue)
                        cmd.Parameters.Add("whId", OracleDbType.Int32).Value = whId.Value;

                    if (custId.HasValue)
                        cmd.Parameters.Add("custId", OracleDbType.Int32).Value = custId.Value;

                    using (var da = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvTrade.DataSource = dt;

                        if (dt.Columns.Contains("TRADEID"))
                            dgvTrade.Columns["TRADEID"].HeaderText = "거래번호";
                        if (dt.Columns.Contains("TRADEDATE"))
                            dgvTrade.Columns["TRADEDATE"].HeaderText = "거래일자";
                        if (dt.Columns.Contains("TRADETYPE"))
                            dgvTrade.Columns["TRADETYPE"].HeaderText = "매매유형";
                        if (dt.Columns.Contains("CUSTOMERNAME"))
                            dgvTrade.Columns["CUSTOMERNAME"].HeaderText = "거래처";
                        if (dt.Columns.Contains("WAREHOUSENAME"))
                            dgvTrade.Columns["WAREHOUSENAME"].HeaderText = "창고";
                        if (dt.Columns.Contains("TOTALAMOUNT"))
                            dgvTrade.Columns["TOTALAMOUNT"].HeaderText = "총금액";

                        dgvTrade.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("거래 검색 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ─────────────────────────────
        // 그리드 더블클릭 → 거래 선택
        // ─────────────────────────────
        private void dgvTrade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvTrade.Rows[e.RowIndex];
            if (row.Cells["TRADEID"].Value == null) return;

            int tradeId;
            if (!int.TryParse(row.Cells["TRADEID"].Value.ToString(), out tradeId))
                return;

            SelectedTradeId = tradeId;
            this.DialogResult = DialogResult.OK;   // 부모에게 OK 신호
            this.Close();
        }

        // ─────────────────────────────
        // Cancel 버튼 (있다면)
        // ─────────────────────────────
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
