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

            // 상세 그리드 편집 관련 이벤트(안전하게 한 번 더 연결)
            dgvTradeDetail.CellValueChanged += dgvTradeDetail_CellValueChanged;
            dgvTradeDetail.CurrentCellDirtyStateChanged += dgvTradeDetail_CurrentCellDirtyStateChanged;
            dgvTradeDetail.CellEndEdit += dgvTradeDetail_CellEndEdit;
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
            // 수량은 수정해야 하므로 ReadOnly = false (컬럼별로 ReadOnly 다시 설정)
            dgvTradeDetail.ReadOnly = false;

            // Form2 에서는 창고/매매유형은 읽기 전용(조회용)
            txtWarehouse.ReadOnly = true;
            btnWarehouseSearch.Enabled = false;

            cboTradeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTradeType.Enabled = false;
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

                        // 매매유형 (Form2 에서는 보여주기만)
                        string tradeType = r["TRADETYPE"]?.ToString();
                        cboTradeType.Items.Clear();
                        if (!string.IsNullOrEmpty(tradeType))
                        {
                            cboTradeType.Items.Add(tradeType);
                            cboTradeType.SelectedIndex = 0;
                        }

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
                        if (!string.IsNullOrEmpty(pay))
                        {
                            // 콤보박스에 값이 없으면 추가 후 선택
                            if (cboPayment.Items.IndexOf(pay) < 0)
                                cboPayment.Items.Add(pay);
                            cboPayment.SelectedItem = pay;
                        }
                        else
                        {
                            cboPayment.SelectedIndex = -1;
                        }

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

        // 창고 검색 버튼 (Form2 에서는 사실상 사용 안 함)
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
    string tradeType,      // "매입" / "매출"
    int warehouseId,
    out decimal totalAmount)
        {
            totalAmount = 0;

            // 0) 이전 거래상세를 읽어서, 재고에서 먼저 "되돌리기"
            var oldDetails = new System.Collections.Generic.List<(int ProdId, int Qty)>();

            using (var cmdSel = new OracleCommand(
                "SELECT ProductID, Quantity FROM TradeDetail WHERE TradeID = :tid", conn))
            {
                cmdSel.Transaction = tran;
                cmdSel.Parameters.Add("tid", OracleDbType.Int32).Value = tradeId;

                using (var rd = cmdSel.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int p = rd.GetInt32(0);
                        int q = rd.GetInt32(1);
                        oldDetails.Add((p, q));
                    }
                }
            }

            // 매입이면 기존 수량을 빼고, 매출이면 기존 수량을 더한다(역연산).
            int revertSign = (tradeType == "매입") ? -1 : +1;

            foreach (var od in oldDetails)
            {
                using (var cmdInv = new OracleCommand(
                    @"UPDATE Inventory
                 SET Quantity = Quantity + :delta
               WHERE WarehouseID = :wid
                 AND ProductID   = :pid", conn))
                {
                    cmdInv.Transaction = tran;
                    cmdInv.Parameters.Add("delta", OracleDbType.Int32).Value = revertSign * od.Qty;
                    cmdInv.Parameters.Add("wid", OracleDbType.Int32).Value = warehouseId;
                    cmdInv.Parameters.Add("pid", OracleDbType.Int32).Value = od.ProdId;
                    cmdInv.ExecuteNonQuery();
                }
            }

            // 1) 기존 상세 삭제
            using (var cmdDel = new OracleCommand(
                "DELETE FROM TradeDetail WHERE TradeID = :tid", conn))
            {
                cmdDel.Transaction = tran;
                cmdDel.Parameters.Add("tid", OracleDbType.Int32).Value = tradeId;
                cmdDel.ExecuteNonQuery();
            }

            // 2) 현재 그리드 내용을 다시 INSERT + 재고 반영
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

                int applySign = (tradeType == "매입") ? +1 : -1;   // 매입=+, 매출=-

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

                    // 2-1) TradeDetail INSERT
                    cmdIns.Parameters["TradeID"].Value = tradeId;
                    cmdIns.Parameters["LineNo"].Value = lineNo++;
                    cmdIns.Parameters["ProductID"].Value = productId;
                    cmdIns.Parameters["Quantity"].Value = qty;
                    cmdIns.Parameters["UnitPrice"].Value = unitPrice;
                    cmdIns.Parameters["Amount"].Value = amount;

                    cmdIns.ExecuteNonQuery();

                    totalAmount += amount;

                    // 2-2) Inventory 반영 (UPDATE 후 없으면 INSERT)
                    int delta = applySign * qty;

                    using (var cmdUpdInv = new OracleCommand(
                        @"UPDATE Inventory
                     SET Quantity = Quantity + :delta
                   WHERE WarehouseID = :wid
                     AND ProductID   = :pid", conn))
                    {
                        cmdUpdInv.Transaction = tran;
                        cmdUpdInv.Parameters.Add("delta", OracleDbType.Int32).Value = delta;
                        cmdUpdInv.Parameters.Add("wid", OracleDbType.Int32).Value = warehouseId;
                        cmdUpdInv.Parameters.Add("pid", OracleDbType.Int32).Value = productId;

                        int updated = cmdUpdInv.ExecuteNonQuery();

                        if (updated == 0)
                        {
                            // 해당 (창고,상품) 재고가 없으면 새로 INSERT
                            using (var cmdInsInv = new OracleCommand(
                                @"INSERT INTO Inventory (WarehouseID, ProductID, Quantity)
                          VALUES (:wid, :pid, :qty)", conn))
                            {
                                cmdInsInv.Transaction = tran;
                                cmdInsInv.Parameters.Add("wid", OracleDbType.Int32).Value = warehouseId;
                                cmdInsInv.Parameters.Add("pid", OracleDbType.Int32).Value = productId;
                                cmdInsInv.Parameters.Add("qty", OracleDbType.Int32).Value = delta;
                                cmdInsInv.ExecuteNonQuery();
                            }
                        }
                    }
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

                        // 거래유형 / 창고ID 체크
                        string tradeType = cboTradeType.SelectedItem?.ToString();
                        if (string.IsNullOrEmpty(tradeType))
                        {
                            throw new Exception("매매유형 정보가 없습니다.");
                        }
                        if (!selectedWarehouseId.HasValue)
                        {
                            throw new Exception("창고 정보가 없습니다.(DefaultWhID)");
                        }

                        SaveTradeDetailWithCurrentGrid(
                            conn,
                            tran,
                            tradeId,
                            tradeType,
                            selectedWarehouseId.Value,
                            out total);

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
        // Add 버튼 (새 거래 등록 필요 시 구현)
        // ─────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO : 새 거래 등록 기능이 필요하면 여기서 구현
        }

        // ★ 아래쪽 "매매관리" 입력 컨트롤 초기화
        private void ClearTradeEditControls()
        {
            txtTradeNo.Clear();
            dtpTradeDate.Value = DateTime.Today;

            // 매매유형 콤보박스 (인덱스 초기화)
            if (cboTradeType.Items.Count > 0)
                cboTradeType.SelectedIndex = -1;

            txtCustomer.Clear();
            txtStaff.Clear();
            txtWarehouse.Clear();

            // 결제수단 콤보박스
            if (cboPayment.Items.Count > 0)
                cboPayment.SelectedIndex = -1;

            txtTotalAmount.Clear();
        }

        // ★ Del 버튼 클릭 : 선택된 거래 + 거래상세 모두 삭제
        private void btnDel_Click(object sender, EventArgs e)
        {
            // 1) 삭제할 거래번호 확인
            if (string.IsNullOrWhiteSpace(txtTradeNo.Text))
            {
                MessageBox.Show("삭제할 거래를 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(txtTradeNo.Text, out int tradeId))
            {
                MessageBox.Show("거래번호 형식이 올바르지 않습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2) 사용자 확인
            var result = MessageBox.Show(
                "선택한 거래와 해당 거래의 모든 거래상세를 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            string conStr = GetConnectionString();

            try
            {
                using (var conn = new OracleConnection(conStr))
                {
                    conn.Open();

                    // 트랜잭션 사용 : 둘 다 성공해야 커밋
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // 3-1) 거래상세 먼저 삭제 (FK 때문에 순서 중요)
                            using (var cmdDetail = new OracleCommand(
                                "DELETE FROM TradeDetail WHERE TradeID = :tradeId", conn))
                            {
                                cmdDetail.Transaction = tran;
                                cmdDetail.Parameters.Add("tradeId", OracleDbType.Int32).Value = tradeId;
                                cmdDetail.ExecuteNonQuery();
                            }

                            // 3-2) 거래 헤더(Trade) 삭제
                            using (var cmdHeader = new OracleCommand(
                                "DELETE FROM Trade WHERE TradeID = :tradeId", conn))
                            {
                                cmdHeader.Transaction = tran;
                                cmdHeader.Parameters.Add("tradeId", OracleDbType.Int32).Value = tradeId;
                                int affected = cmdHeader.ExecuteNonQuery();

                                if (affected == 0)
                                {
                                    throw new Exception("해당 거래가 존재하지 않습니다.");
                                }
                            }

                            // 3-3) 문제 없으면 커밋
                            tran.Commit();
                        }
                        catch (Exception exInner)
                        {
                            tran.Rollback();
                            MessageBox.Show("삭제 중 오류가 발생했습니다.\n" + exInner.Message,
                                "삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // 4) 화면 갱신
                MessageBox.Show("거래가 삭제되었습니다.", "완료",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 거래목록 다시 로드
                LoadTradeList();

                // 선택 해제 + 아래쪽 컨트롤 초기화
                dgvTradeDetail.DataSource = null;
                ClearTradeEditControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 연결 또는 삭제 처리 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ★ 상세 그리드의 순번(LINENO) 다시 매기기
        private void ReindexDetailLineNo()
        {
            var dt = dgvTradeDetail.DataSource as DataTable;
            if (dt == null || !dt.Columns.Contains("LINENO"))
                return;

            int lineNo = 1;

            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                row["LINENO"] = lineNo++;
            }
        }

        // ─────────────────────────────────────
        // 우클릭 메뉴 : 상품추가
        // ─────────────────────────────────────
        private void 상품추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1) 거래가 선택되어 있지 않으면 추가 불가
            if (SelectedTradeId == null)
            {
                MessageBox.Show("먼저 거래를 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2) 현재 상세 그리드의 DataTable 얻기
            var dt = dgvTradeDetail.DataSource as DataTable;
            if (dt == null)
            {
                MessageBox.Show("거래상세를 먼저 불러온 후 사용하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3) 상품 선택 폼 호출
            using (var frm = new ProductSelectForm())
            {
                // 필요하면 매매유형 / 창고 정보를 넘겨서 필터링에 사용할 수 있음
                frm.TradeType = cboTradeType.SelectedItem?.ToString();
                frm.WarehouseName = txtWarehouse.Text.Trim();

            again_select:
                if (frm.ShowDialog() != DialogResult.OK)
                    return;

                // 수량 / 가격 등 선택 결과가 정상인지 확인
                if (frm.SelectedProductId <= 0)
                {
                    MessageBox.Show("상품이 선택되지 않았습니다.");
                    goto again_select;
                }

                // 4) 새 DataRow 생성
                DataRow newRow = dt.NewRow();

                // 거래번호
                newRow["TRADEID"] = SelectedTradeId.Value;

                // 순번 = 기존 최대값 + 1
                int nextLineNo = 1;
                foreach (DataRow r in dt.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;
                    int tmp;
                    if (int.TryParse(r["LINENO"].ToString(), out tmp) && tmp >= nextLineNo)
                        nextLineNo = tmp + 1;
                }
                newRow["LINENO"] = nextLineNo;

                // 상품 정보
                newRow["PRODUCTID"] = frm.SelectedProductId;
                newRow["PRODUCTNAME"] = frm.SelectedProductName;
                newRow["QUANTITY"] = frm.SelectedQuantity;
                newRow["UNITPRICE"] = frm.SelectedUnitPrice;
                newRow["AMOUNT"] = frm.SelectedUnitPrice * frm.SelectedQuantity;

                // 5) 테이블에 추가 → 그리드에 바로 반영됨
                dt.Rows.Add(newRow);

                // 6) 총금액 재계산
                RecalcTotalAmount();
            }
        }

        // ─────────────────────────────────────
        // 우클릭 메뉴 : 상품삭제
        // ─────────────────────────────────────
        private void 상품삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTradeDetail.CurrentRow == null ||
                dgvTradeDetail.CurrentRow.IsNewRow)
                return;

            if (MessageBox.Show("선택한 상품을 삭제하시겠습니까?",
                    "삭제 확인", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // DataGridView 가 DataTable 에 바인딩되어 있으므로
            // DataRowView 를 삭제해 주면 됨
            var drv = dgvTradeDetail.CurrentRow.DataBoundItem as DataRowView;
            if (drv != null)
                drv.Row.Delete();
            else
                dgvTradeDetail.Rows.RemoveAt(dgvTradeDetail.CurrentRow.Index);

            // 순번 다시 매기고 총금액 재계산
            ReindexDetailLineNo();
            RecalcTotalAmount();
        }

        // ─────────────────────────────────────
        // 우클릭 메뉴 : 수량수정  → 현재 행의 수량 셀로 포커스 이동
        // ─────────────────────────────────────
        private void 수량수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTradeDetail.CurrentRow == null)
                return;

            if (!dgvTradeDetail.Columns.Contains("QUANTITY"))
                return;

            int qtyColIndex = dgvTradeDetail.Columns["QUANTITY"].Index;

            dgvTradeDetail.CurrentCell = dgvTradeDetail.CurrentRow.Cells[qtyColIndex];
            dgvTradeDetail.BeginEdit(true);   // 바로 편집 모드 진입
        }

        // ─────────────────────────────────────
        // 셀 편집 종료 시(특히 수량) 금액/총금액 재계산 (백업용)
        // ─────────────────────────────────────
        private void dgvTradeDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 수량 컬럼일 때만 처리
            if (!dgvTradeDetail.Columns.Contains("QUANTITY") ||
                dgvTradeDetail.Columns[e.ColumnIndex].Name != "QUANTITY")
                return;

            var row = dgvTradeDetail.Rows[e.RowIndex];

            int qty;
            decimal unitPrice;

            if (!int.TryParse(Convert.ToString(row.Cells["QUANTITY"].Value), out qty))
                return;
            if (!decimal.TryParse(Convert.ToString(row.Cells["UNITPRICE"].Value), out unitPrice))
                return;

            row.Cells["AMOUNT"].Value = unitPrice * qty;

            RecalcTotalAmount();
        }

        // ─────────────────────────────
        // 거래목록 그리드에서 특정 거래번호 행 선택
        // ─────────────────────────────
        private void SelectTradeRowInList(int tradeId)
        {
            foreach (DataGridViewRow row in dgvTradeList.Rows)
            {
                if (row.Cells["TRADEID"].Value == null)
                    continue;

                int id;
                if (!int.TryParse(row.Cells["TRADEID"].Value.ToString(), out id))
                    continue;

                if (id == tradeId)
                {
                    row.Selected = true;
                    // 첫 번째 셀을 CurrentCell 로 잡아주면 스크롤도 따라감
                    if (row.Cells.Count > 0)
                        dgvTradeList.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }


        // ─────────────────────────────
        // 거래검색 버튼 클릭
        // ─────────────────────────────
        private void btnTradeSearch_Click(object sender, EventArgs e)
        {
            // 현재 Form 에서 사용 중인 접속 문자열 재사용
            string conStr = GetConnectionString();

            using (var frm = new TradeSearchForm(conStr))
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.SelectedTradeId > 0)
                {
                    int tradeId = frm.SelectedTradeId;
                    SelectedTradeId = tradeId;

                    // 오른쪽 매매관리 / 거래상세 모두 로드
                    LoadTradeHeader(tradeId);
                    LoadTradeDetail(tradeId);

                    // 위쪽 거래목록 그리드에서도 해당 거래 행을 선택해 주기
                    SelectTradeRowInList(tradeId);
                }
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            // 현재 사용 중인 접속 문자열 재사용
            using (var frm = new TradeStatisticsForm(GetConnectionString()))
            {
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
