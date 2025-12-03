using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class TradeManageForm : Form
    {
        // 공통 DB 클래스
        DBCLASS dbc = new DBCLASS();

        // Form1 과 연동할 때 사용할 선택된 거래번호
        public int? SelectedTradeId { get; private set; }

        // DB 접속 계정 (필요하면 나중에 공통 상수로 분리)
        private const string DbUser = "HONG1";
        private const string DbPw = "1111";

        // 선택된 거래처/담당자/창고 ID (오른쪽 TextBox 는 이름만 표시)
        private int? selectedCustomerId;
        private int? selectedStaffId;
        private int? selectedWarehouseId;

        // ─────────────────────────────────────
        // 생성자
        // ─────────────────────────────────────
        public TradeManageForm()
        {
            InitializeComponent();

            // DB 어댑터용 객체 생성
            dbc.DB_ObjCreate();

            // 거래 헤더 기본 쿼리 등록 (DBAdapter.SelectCommand 에 들어감)
            dbc.DB_Open(
                "SELECT TradeID, TradeDate, TradeType, TotalAmount " +
                "FROM Trade ORDER BY TradeID"
            );

            // 상세 그리드 편집 관련 이벤트 연결
            dgvTradeDetail.CellValueChanged += dgvTradeDetail_CellValueChanged;
            dgvTradeDetail.CurrentCellDirtyStateChanged += dgvTradeDetail_CurrentCellDirtyStateChanged;
        }

        // ─────────────────────────────────────
        // Oracle 접속 문자열
        // ─────────────────────────────────────
        private string GetConnectionString()
        {
            return
                "User Id=" + DbUser + "; Password=" + DbPw + "; " +
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";
        }

        // ─────────────────────────────────────
        // Form Load : 그리드 기본 설정 + 거래목록 로드
        // ─────────────────────────────────────
        private void TradeManageForm_Load(object sender, EventArgs e)
        {
            // 거래헤더 목록 로드
            LoadTradeList();

            // 헤더 그리드 설정
            dgvTradeList.ReadOnly = true;
            dgvTradeList.AllowUserToAddRows = false;
            dgvTradeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTradeList.MultiSelect = false;

            // 상세 그리드 설정
            dgvTradeDetail.AllowUserToAddRows = false;
            dgvTradeDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTradeDetail.MultiSelect = false;
            // 수량은 수정해야 하므로 ReadOnly = false (나머지 컬럼은 아래에서 개별로 조정)
            dgvTradeDetail.ReadOnly = false;

            txtWarehouse.ReadOnly = true;
            btnWarehouseSearch.Enabled = false;  // 검색 버튼 비활성화

            // 매매유형은 조회용, 수정 불가
            cboTradeType.DropDownStyle = ComboBoxStyle.DropDownList; // 입력창 막기
            cboTradeType.Enabled = false;                            // 선택도 못 하게
        }

        // ─────────────────────────────────────
        // 거래 헤더 목록 로드
        // ─────────────────────────────────────
        private void LoadTradeList()
        {
            try
            {
                dbc.DS.Clear();
                dbc.DBAdapter.Fill(dbc.DS, "Trade");

                dgvTradeList.DataSource = dbc.DS.Tables["Trade"];

                // 컬럼 한글 헤더명
                dgvTradeList.Columns["TRADEID"].HeaderText = "거래번호";
                dgvTradeList.Columns["TRADEDATE"].HeaderText = "거래일자";
                dgvTradeList.Columns["TRADETYPE"].HeaderText = "매매유형";
                dgvTradeList.Columns["TOTALAMOUNT"].HeaderText = "총금액";

                dgvTradeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "거래목록 로드 오류");
            }
        }

        // ─────────────────────────────────────
        // 거래헤더 그리드 클릭 → 상세/오른쪽 정보 로드
        // ─────────────────────────────────────
        private void dgvTradeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // 헤더 클릭 방지

            try
            {
                var row = dgvTradeList.Rows[e.RowIndex];
                if (row.Cells["TRADEID"].Value == null ||
                    row.Cells["TRADEID"].Value == DBNull.Value)
                    return;

                int tradeId = Convert.ToInt32(row.Cells["TRADEID"].Value);

                SelectedTradeId = tradeId;

                // 오른쪽 거래헤더 정보 로드
                LoadTradeHeader(tradeId);

                // 거래상세 로드
                LoadTradeDetail(tradeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "거래 선택 오류");
            }
        }

        // ─────────────────────────────────────
        // 특정 거래에 대한 헤더 정보 로드 (오른쪽 TextBox/ComboBox 세팅)
        // ─────────────────────────────────────
        private void LoadTradeHeader(int tradeId)
        {
            string conStr = GetConnectionString();

            
            string sql = @"
                SELECT t.TradeID,
                t.TradeDate,
                t.TradeType,
                t.CustomerID,
                c.CustomerName,
                t.StaffID,
                e.Name AS StaffName,
                t.DefaultWhID AS WarehouseID,   
                w.WarehouseName,
                t.PaymentMethod,
                t.TotalAmount
                FROM Trade t
                LEFT JOIN Customer  c ON t.CustomerID   = c.CustomerID
                LEFT JOIN Employee  e ON t.StaffID      = e.EmployeeID
                LEFT JOIN Warehouse w ON t.DefaultWhID  = w.WarehouseID  
                WHERE t.TradeID = :tid";


            try
            {
                using (var conn = new OracleConnection(conStr))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("tid", tradeId);

                    using (var da = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0) return;

                        DataRow r = dt.Rows[0];

                        // 거래번호
                        txtTradeNo.Text = r["TRADEID"].ToString();

                        // 거래일자
                        if (r["TRADEDATE"] != DBNull.Value)
                            dtpTradeDate.Value = Convert.ToDateTime(r["TRADEDATE"]);
                        else
                            dtpTradeDate.Value = DateTime.Today;

                        // 매매유형
                        string tradeType = r["TRADETYPE"]?.ToString();
                        cboTradeType.SelectedItem = tradeType;

                        // 거래처
                        selectedCustomerId = r["CUSTOMERID"] == DBNull.Value
                            ? (int?)null
                            : Convert.ToInt32(r["CUSTOMERID"]);
                        txtCustomer.Text = r["CUSTOMERNAME"]?.ToString();

                        // 담당자
                        selectedStaffId = r["STAFFID"] == DBNull.Value
                            ? (int?)null
                            : Convert.ToInt32(r["STAFFID"]);
                        txtStaff.Text = r["STAFFNAME"]?.ToString();

                        // 창고
                        selectedWarehouseId = r["WAREHOUSEID"] == DBNull.Value
                            ? (int?)null
                            : Convert.ToInt32(r["WAREHOUSEID"]);
                        txtWarehouse.Text = r["WAREHOUSENAME"]?.ToString();

                        // 결제수단
                        string pay = r["PAYMENTMETHOD"]?.ToString();
                        cboPayment.SelectedItem = pay;

                        // 총금액
                        txtTotalAmount.Text = r["TOTALAMOUNT"]?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "거래헤더 로드 오류");
            }
        }

        // ─────────────────────────────────────
        // 특정 거래의 상세 내역 로드
        // ─────────────────────────────────────
        private void LoadTradeDetail(int tradeId)
        {
            string conStr = GetConnectionString();

            string sql = @"
                SELECT td.TradeID,
                       td.LineNo,
                       td.ProductID,
                       p.ProductName,
                       td.Quantity,
                       td.UnitPrice,
                       td.Amount
                  FROM TradeDetail td
                  JOIN Product p
                    ON td.ProductID = p.ProductID
                 WHERE td.TradeID = :tradeId
                 ORDER BY td.LineNo";

            try
            {
                using (var conn = new OracleConnection(conStr))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("tradeId", tradeId);

                    using (var da = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvTradeDetail.DataSource = dt;

                        // 한글 컬럼 헤더
                        dgvTradeDetail.Columns["TRADEID"].HeaderText = "거래번호";
                        dgvTradeDetail.Columns["LINENO"].HeaderText = "순번";
                        dgvTradeDetail.Columns["PRODUCTID"].HeaderText = "상품코드";
                        dgvTradeDetail.Columns["PRODUCTNAME"].HeaderText = "상품명";
                        dgvTradeDetail.Columns["QUANTITY"].HeaderText = "수량";
                        dgvTradeDetail.Columns["UNITPRICE"].HeaderText = "단가";
                        dgvTradeDetail.Columns["AMOUNT"].HeaderText = "금액";

                        dgvTradeDetail.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        // 편집 가능 컬럼/불가 컬럼 지정
                        dgvTradeDetail.Columns["TRADEID"].ReadOnly = true;
                        dgvTradeDetail.Columns["LINENO"].ReadOnly = true;
                        dgvTradeDetail.Columns["PRODUCTNAME"].ReadOnly = true;
                        dgvTradeDetail.Columns["UNITPRICE"].ReadOnly = true;
                        dgvTradeDetail.Columns["AMOUNT"].ReadOnly = true;

                        // 수량은 수정 가능
                        dgvTradeDetail.Columns["QUANTITY"].ReadOnly = false;

                        // 금액 기준으로 총금액 다시 계산해서 표시
                        RecalcTotalAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "거래상세 로드 오류");
            }
        }

        // ─────────────────────────────────────
        // 거래처 검색 버튼 (Form1 과 동일 패턴)
        // ─────────────────────────────────────
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            using (var frm = new CustomerSelectForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    selectedCustomerId = frm.SelectedCustomerId;
                    txtCustomer.Text = frm.SelectedCustomerName;
                }
            }
        }

        // 담당자 검색 버튼
        private void btnStaffSearch_Click(object sender, EventArgs e)
        {
            using (var frm = new StaffSelectForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    selectedStaffId = frm.SelectedStaffId;
                    txtStaff.Text = frm.SelectedStaffName;
                }
            }
        }

        // 창고 검색 버튼
        private void btnWarehouseSearch_Click(object sender, EventArgs e)
        {
            using (var frm = new WarehouseSelectForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    selectedWarehouseId = frm.SelectedWarehouseId;
                    txtWarehouse.Text = frm.SelectedWarehouseName;
                }
            }
        }

        // ─────────────────────────────────────
        // 상세 그리드 : 편집 확정(콤보/수량) 강제 반영
        // ─────────────────────────────────────
        private void dgvTradeDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTradeDetail.IsCurrentCellDirty)
            {
                dgvTradeDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // ─────────────────────────────────────
        // 상세 그리드 : 수량 변경 시 금액/총금액 재계산
        // ─────────────────────────────────────
        private void dgvTradeDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 수량 컬럼만 처리
            if (dgvTradeDetail.Columns[e.ColumnIndex].Name != "QUANTITY")
                return;

            var row = dgvTradeDetail.Rows[e.RowIndex];

            int qty;
            decimal unitPrice;

            if (!int.TryParse(Convert.ToString(row.Cells["QUANTITY"].Value), out qty))
                return;
            if (!decimal.TryParse(Convert.ToString(row.Cells["UNITPRICE"].Value), out unitPrice))
                return;

            decimal amount = unitPrice * qty;
            row.Cells["AMOUNT"].Value = amount;

            RecalcTotalAmount();
        }

        // ─────────────────────────────────────
        // 현재 상세 그리드 기준으로 총금액 다시 계산
        // ─────────────────────────────────────
        private void RecalcTotalAmount()
        {
            decimal total = 0;

            foreach (DataGridViewRow r in dgvTradeDetail.Rows)
            {
                if (r.IsNewRow) continue;
                if (r.Cells["AMOUNT"].Value == null) continue;

                decimal amt;
                if (decimal.TryParse(r.Cells["AMOUNT"].Value.ToString(), out amt))
                {
                    total += amt;
                }
            }

            txtTotalAmount.Text = total.ToString();
        }

        // ─────────────────────────────────────
        // 상세 저장 함수
        //   - 같은 Connection / Transaction 을 사용
        //   - 기존 TradeDetail 모두 삭제 후, 그리드 기준으로 INSERT
        //   - out 매개변수로 총금액 반환
        // ─────────────────────────────────────
        private void SaveTradeDetailWithCurrentGrid(
            OracleConnection conn,
            OracleTransaction tran,
            int tradeId,
            out decimal totalAmount)
        {
            totalAmount = 0;

            // 1) 기존 상세 삭제
            using (var cmdDel = new OracleCommand(
                "DELETE FROM TradeDetail WHERE TradeID = :tid", conn))
            {
                cmdDel.Transaction = tran;
                cmdDel.Parameters.Add("tid", OracleDbType.Int32).Value = tradeId;
                cmdDel.ExecuteNonQuery();
            }

            // 2) 현재 그리드 내용을 다시 INSERT
            string insertSql = @"
                INSERT INTO TradeDetail
                    (TradeID, LineNo, ProductID, Quantity, UnitPrice, Amount)
                VALUES
                    (:TradeID, :LineNo, :ProductID, :Quantity, :UnitPrice, :Amount)";

            using (var cmdIns = new OracleCommand(insertSql, conn))
            {
                cmdIns.Transaction = tran;

                cmdIns.Parameters.Add("TradeID", OracleDbType.Int32);
                cmdIns.Parameters.Add("LineNo", OracleDbType.Int32);
                cmdIns.Parameters.Add("ProductID", OracleDbType.Int32);
                cmdIns.Parameters.Add("Quantity", OracleDbType.Int32);
                cmdIns.Parameters.Add("UnitPrice", OracleDbType.Decimal);
                cmdIns.Parameters.Add("Amount", OracleDbType.Decimal);

                int lineNo = 1;

                foreach (DataGridViewRow r in dgvTradeDetail.Rows)
                {
                    if (r.IsNewRow) continue;
                    if (r.Cells["PRODUCTID"].Value == null) continue;

                    int productId;
                    int qty;
                    decimal unitPrice;

                    if (!int.TryParse(r.Cells["PRODUCTID"].Value.ToString(), out productId))
                        continue;

                    int.TryParse(Convert.ToString(r.Cells["QUANTITY"].Value), out qty);
                    decimal.TryParse(Convert.ToString(r.Cells["UNITPRICE"].Value), out unitPrice);

                    decimal amount = unitPrice * qty;

                    cmdIns.Parameters["TradeID"].Value = tradeId;
                    cmdIns.Parameters["LineNo"].Value = lineNo++;
                    cmdIns.Parameters["ProductID"].Value = productId;
                    cmdIns.Parameters["Quantity"].Value = qty;
                    cmdIns.Parameters["UnitPrice"].Value = unitPrice;
                    cmdIns.Parameters["Amount"].Value = amount;

                    cmdIns.ExecuteNonQuery();

                    totalAmount += amount;
                }
            }
        }

        // ─────────────────────────────────────
        // Updata 버튼 클릭 : 헤더 + 상세 모두 저장
        // ─────────────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedTradeId == null)
            {
                MessageBox.Show("먼저 수정할 거래를 선택하세요.");
                return;
            }

            int tradeId = SelectedTradeId.Value;

            string conStr = GetConnectionString();

            using (var conn = new OracleConnection(conStr))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) 거래헤더 UPDATE
                        string updateSql = @"
                            UPDATE Trade
                               SET TradeDate     = :TradeDate,
                                   TradeType     = :TradeType,
                                   CustomerID    = :CustomerID,
                                   StaffID       = :StaffID,
                                   DefaultWhID   = :WarehouseID,
                                   PaymentMethod = :PaymentMethod
                             WHERE TradeID      = :TradeID";

                        using (var cmd = new OracleCommand(updateSql, conn))
                        {
                            cmd.Transaction = tran;

                            cmd.Parameters.Add("TradeDate", OracleDbType.Date)
                                .Value = dtpTradeDate.Value.Date;

                            cmd.Parameters.Add("TradeType", OracleDbType.Varchar2)
                                .Value = cboTradeType.SelectedItem?.ToString() ?? "";

                            var pCust = cmd.Parameters.Add("CustomerID", OracleDbType.Int32);
                            pCust.Value = selectedCustomerId.HasValue
                                ? (object)selectedCustomerId.Value
                                : DBNull.Value;

                            var pStaff = cmd.Parameters.Add("StaffID", OracleDbType.Int32);
                            pStaff.Value = selectedStaffId.HasValue
                                ? (object)selectedStaffId.Value
                                : DBNull.Value;

                            var pWh = cmd.Parameters.Add("WarehouseID", OracleDbType.Int32);
                            pWh.Value = selectedWarehouseId.HasValue
                                ? (object)selectedWarehouseId.Value
                                : DBNull.Value;

                            cmd.Parameters.Add("PaymentMethod", OracleDbType.Varchar2)
                                .Value = cboPayment.SelectedItem?.ToString() ?? "";

                            cmd.Parameters.Add("TradeID", OracleDbType.Int32)
                                .Value = tradeId;

                            cmd.ExecuteNonQuery();
                        }

                        // 2) 상세 다시 저장 & 총금액 계산
                        decimal total;
                        SaveTradeDetailWithCurrentGrid(conn, tran, tradeId, out total);

                        // 3) 헤더의 총금액 반영
                        using (var cmdTotal = new OracleCommand(
                            "UPDATE Trade SET TotalAmount = :Total WHERE TradeID = :TradeID", conn))
                        {
                            cmdTotal.Transaction = tran;
                            cmdTotal.Parameters.Add("Total", OracleDbType.Decimal).Value = total;
                            cmdTotal.Parameters.Add("TradeID", OracleDbType.Int32).Value = tradeId;
                            cmdTotal.ExecuteNonQuery();
                        }

                        tran.Commit();

                        txtTotalAmount.Text = total.ToString();
                        MessageBox.Show("거래 정보가 수정되었습니다.");

                        // 화면 갱신
                        LoadTradeList();
                        LoadTradeDetail(tradeId);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("수정 중 오류 : " + ex.Message);
                    }
                }
            }
        }

        // ─────────────────────────────────────
        // Add / Del 버튼은 나중에 구현하려면 여기서 작성
        // (디자이너에서 클릭 이벤트만 연결하면 됨)
        // ─────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO : 새 거래 등록 기능이 필요하면 여기서 구현
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // TODO : 선택한 거래 삭제 기능이 필요하면 여기서 구현
        }
    }
}
