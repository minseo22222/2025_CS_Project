using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class TradePage : UserControl
    {
        private const string DbUser = "HONG1";
        private const string DbPw = "1111";

        DBCLASS dbTrade = new DBCLASS();      // Trade 헤더용
        DBCLASS dbDetail = new DBCLASS();     // TradeDetail 상세용
        DBCLASS dbCommon = new DBCLASS();     // 공통(상품 목록 등)
        DBCLASS dbInventory = new DBCLASS();  // 재고 조회용

        private string GetConnectionString()
        {
            return
                "User Id=" + DbUser + "; Password=" + DbPw + "; " +
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";
        }

        DataTable productTable;               // 상품 목록(콤보박스용)
        int selectedDetailRowIndex = -1;

        // 헤더에서 선택된 ID 저장용
        private int? selectedCustomerId;      // 거래처번호
        private int? selectedStaffId;         // 담당자번호
        private int? selectedWarehouseId;     // 창고코드

        // 매입/매출 문자열
        private const string TRADE_TYPE_BUY = "매입";
        private const string TRADE_TYPE_SELL = "매출";

        // Product.category 값
        private const string CATEGORY_RAW = "원재료";   // DB 에 따라 "원재료"면 여기만 바꾸면 됨
        private const string CATEGORY_FINISH = "완제품";

        private bool _isUpdatingQty = false;   // 수량 검증 중 재귀 호출 방지용


        private string CurrentTradeType
        {
            get
            {
                if (cboTradeType == null || cboTradeType.SelectedItem == null)
                    return null;
                return cboTradeType.SelectedItem.ToString();
            }
        }

        // ================= 생성자 =================
        public TradePage()
        {
            InitializeComponent();

            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!this.DesignMode)
            {
                InitEmptyProductList();  // 처음에는 유형/창고 선택 전이므로 상품콤보 비움
            }

            // 안전용 이벤트 연결 (디자이너에서 이미 연결돼 있어도 중복 호출만 될 뿐 문제 없음)
            dgvDetail.DataError += dgvDetail_DataError;
            dgvDetail.CellBeginEdit += dgvDetail_CellBeginEdit;
            dgvDetail.CellClick += dgvDetail_CellClick;
            dgvDetail.CurrentCellDirtyStateChanged += dgvDetail_CurrentCellDirtyStateChanged;
            dgvDetail.CellValueChanged += dgvDetail_CellValueChanged;

            cboTradeType.SelectedIndexChanged += cboTradeType_SelectedIndexChanged;
        }

        // =============================================================
        // 공통 유틸 / 데이터 로딩
        // =============================================================

        // 상품콤보를 완전히 빈 목록으로 초기화
        private void InitEmptyProductList()
        {
            productTable = new DataTable();
            productTable.Columns.Add("PRODUCTID", typeof(int));
            productTable.Columns.Add("PRODUCTNAME", typeof(string));
            productTable.Columns.Add("UNITPRICE", typeof(decimal));

            var colProduct =
                (DataGridViewComboBoxColumn)dgvDetail.Columns["colProduct"];

            colProduct.DataSource = productTable;
            colProduct.DisplayMember = "PRODUCTNAME";
            colProduct.ValueMember = "PRODUCTID";
            colProduct.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colProduct.FlatStyle = FlatStyle.Standard;
        }

        // ================= 매입용 : 전체 '원재료' 상품 (재고와 무관) =================
        private void LoadProductListForBuy()
        {
            try
            {
                string sql =
                    "SELECT ProductID, ProductName, UnitPrice " +
                    "FROM Product " +
                    "WHERE category = '" + CATEGORY_RAW + "' " +
                    "ORDER BY ProductID";

                dbCommon.DB_ObjCreate();
                dbCommon.DB_Open(sql);

                if (dbCommon.DS != null)
                    dbCommon.DS.Clear();

                dbCommon.DBAdapter.Fill(dbCommon.DS, "Product");

                productTable = dbCommon.DS.Tables["Product"];

                var colProduct =
                    (DataGridViewComboBoxColumn)dgvDetail.Columns["colProduct"];

                colProduct.DataSource = productTable;
                colProduct.DisplayMember = "PRODUCTNAME";
                colProduct.ValueMember = "PRODUCTID";
                colProduct.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                colProduct.FlatStyle = FlatStyle.Standard;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= 매출용 : 해당 창고 + '완제품' + 재고 있는 상품만 =================
        private void LoadProductListForSell(int warehouseId)
        {
            try
            {
                string sql =
                    "SELECT p.ProductID, p.ProductName, p.UnitPrice " +
                    "FROM Product p " +
                    "JOIN Inventory i ON p.ProductID = i.ProductID " +
                    "WHERE i.WarehouseID = " + warehouseId + " " +
                    "  AND p.category = '" + CATEGORY_FINISH + "' " +
                    "ORDER BY p.ProductID";

                dbCommon.DB_ObjCreate();
                dbCommon.DB_Open(sql);

                if (dbCommon.DS != null)
                    dbCommon.DS.Clear();

                dbCommon.DBAdapter.Fill(dbCommon.DS, "Product");

                productTable = dbCommon.DS.Tables["Product"];

                var colProduct =
                    (DataGridViewComboBoxColumn)dgvDetail.Columns["colProduct"];

                colProduct.DataSource = productTable;
                colProduct.DisplayMember = "PRODUCTNAME";
                colProduct.ValueMember = "PRODUCTID";
                colProduct.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                colProduct.FlatStyle = FlatStyle.Standard;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // 실제 DB에서 상품 목록 로딩 (창고 + category 사용)
        private void LoadProductList(int warehouseId, string category)
        {
            try
            {
                string sql =
                    "SELECT p.ProductID, p.ProductName, p.UnitPrice " +
                    "FROM Product p " +
                    "JOIN Inventory i ON p.ProductID = i.ProductID " +
                    "WHERE i.WarehouseID = " + warehouseId + " " +
                    "  AND p.category = '" + category + "' " +
                    "ORDER BY p.ProductID";

                dbCommon.DB_ObjCreate();
                dbCommon.DB_Open(sql);

                if (dbCommon.DS != null)
                    dbCommon.DS.Clear();

                dbCommon.DBAdapter.Fill(dbCommon.DS, "Product");

                productTable = dbCommon.DS.Tables["Product"];

                var colProduct =
                    (DataGridViewComboBoxColumn)dgvDetail.Columns["colProduct"];

                colProduct.DataSource = productTable;
                colProduct.DisplayMember = "PRODUCTNAME";
                colProduct.ValueMember = "PRODUCTID";
                colProduct.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                colProduct.FlatStyle = FlatStyle.Standard;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 현재 매매유형 + 창고에 맞춰 상품 콤보 새로 고침
        private void RefreshProductList()
        {
            // 还没选매매유형 → 商品先清空
            if (string.IsNullOrEmpty(CurrentTradeType))
            {
                InitEmptyProductList();
                return;
            }

            // 매출 的情况下必须知道仓库才能按库存过滤
            if (CurrentTradeType == TRADE_TYPE_SELL && !selectedWarehouseId.HasValue)
            {
                InitEmptyProductList();
                return;
            }

            // 매입 : category = 원재료, 不看库存
            if (CurrentTradeType == TRADE_TYPE_BUY)
            {
                LoadProductListForBuy();
            }
            // 매출 : category = 완제품, 还要 join Inventory 过滤当前仓库有库存的商品
            else if (CurrentTradeType == TRADE_TYPE_SELL)
            {
                LoadProductListForSell(selectedWarehouseId.Value);
            }
            else
            {
                InitEmptyProductList();
            }
        }


        // 재고 조회 함수
        private int GetInventoryQty(int warehouseId, int productId)
        {
            try
            {
                string sql =
                    $"SELECT Quantity FROM Inventory " +
                    $"WHERE WarehouseID = {warehouseId} AND ProductID = {productId}";

                dbInventory.DB_ObjCreate();
                dbInventory.DB_Open(sql);

                if (dbInventory.DS != null)
                    dbInventory.DS.Clear();

                dbInventory.DBAdapter.Fill(dbInventory.DS, "InventoryQty");

                DataTable t = dbInventory.DS.Tables["InventoryQty"];
                if (t.Rows.Count == 0)
                    return 0;

                return Convert.ToInt32(t.Rows[0]["QUANTITY"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        // ================= 행 하나에 대해 재고 컬럼(거래 후 예상 재고) 채우기 =================
        private void UpdateStockForRow(DataGridViewRow row)
        {
            try
            {
                // 창고 미선택이면 표시 안 함
                if (!selectedWarehouseId.HasValue)
                {
                    row.Cells["colStockQty"].Value = null;
                    return;
                }

                // 상품ID 없으면 표시 안 함
                if (row.Cells["colProductID"].Value == null)
                {
                    row.Cells["colStockQty"].Value = null;
                    return;
                }

                int productId;
                if (!int.TryParse(row.Cells["colProductID"].Value.ToString(), out productId))
                {
                    row.Cells["colStockQty"].Value = null;
                    return;
                }

                // DB 기준 현재 재고
                int baseQty = GetInventoryQty(selectedWarehouseId.Value, productId);

                // 그리드에서 입력한 수량
                int qty = 0;
                if (row.Cells["colQty"].Value != null &&
                    row.Cells["colQty"].Value != DBNull.Value)
                {
                    int.TryParse(row.Cells["colQty"].Value.ToString(), out qty);
                }

                int displayQty = baseQty;

                // 매출이면  현재재고 - 수량
                if (CurrentTradeType == TRADE_TYPE_SELL)
                {
                    displayQty = baseQty - qty;
                }
                // 매입이면  현재재고 + 수량  (원하면 baseQty 그대로 두어도 됨)
                else if (CurrentTradeType == TRADE_TYPE_BUY)
                {
                    displayQty = baseQty + qty;
                }

                row.Cells["colStockQty"].Value = displayQty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UpdateAllStock()
        {
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (row.IsNewRow) continue;
                UpdateStockForRow(row);
            }
        }

        // ================== 총금액 재계산 ==================
        private void RecalcTotalAmount()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (row.IsNewRow) continue;

                object val = row.Cells["colAmount"].Value;
                if (val == null || val == DBNull.Value) continue;

                decimal d;
                if (decimal.TryParse(val.ToString(), out d))
                {
                    total += d;
                }
            }

            // 표시 형식은 취향에 따라 바꿔도 됨 ("N0", "N2" 등)
            txtTotalAmount.Text = total.ToString("0.##");
        }


        private bool HasDetailRows()
        {
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (!row.IsNewRow) return true;
            }
            return false;
        }

        // =============================================================
        // 상단 영역 이벤트(매매유형, 거래처/담당자/창고 선택, 조회 버튼 등)
        // =============================================================

        // 매매유형 변경
        private void cboTradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasDetailRows())
            {
                MessageBox.Show(
                    "매매유형을 변경했기 때문에 현재 매매상세를 초기화합니다.",
                    "매매유형 변경",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                dgvDetail.Rows.Clear();
            }

            RefreshProductList();
        }

        // 상단 "조회" 버튼
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            using (TradeManageForm frm = new TradeManageForm())
            {
                frm.ShowDialog();
            }
        }

        // 거래처 선택
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

        // 담당자 선택
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

        // 창고 선택
        private void btnWarehouseSearch_Click(object sender, EventArgs e)
        {
            int? oldWhId = selectedWarehouseId;

            using (var frm = new WarehouseSelectForm())
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return;

                int newWhId = frm.SelectedWarehouseId;
                string newWhName = frm.SelectedWarehouseName;

                if (oldWhId.HasValue && oldWhId.Value != newWhId && HasDetailRows())
                {
                    var r = MessageBox.Show(
                        "창고를 변경하면 현재 매매상세 내용이 모두 초기화됩니다.\n계속하시겠습니까?",
                        "창고 변경",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (r == DialogResult.No)
                        return;

                    dgvDetail.Rows.Clear();
                }

                selectedWarehouseId = newWhId;
                txtWarehouse.Text = newWhName;

                RefreshProductList();
                UpdateAllStock();
            }
        }

        // =============================================================
        // 하단 매매상세 그리드 / 버튼
        // =============================================================

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedDetailRowIndex = e.RowIndex;
        }

        private void ProductAdd_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Add();
        }

        private void ProductDel_Click(object sender, EventArgs e)
        {
            if (selectedDetailRowIndex < 0 ||
                selectedDetailRowIndex >= dgvDetail.Rows.Count)
                return;

            if (dgvDetail.Rows[selectedDetailRowIndex].IsNewRow)
                return;

            dgvDetail.Rows.RemoveAt(selectedDetailRowIndex);

            // ★ 행 삭제 후 총금액 재계산
            RecalcTotalAmount();
        }

        // 셀 편집 시작 시(상품 선택 전에 매매유형 + 창고 체크)
        private void dgvDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvDetail.Columns[e.ColumnIndex].Name;

            // 상품 콤보박스를 편집하려 할 때만 체크
            if (colName == "colProduct")
            {
                // 1) 먼저 매매유형 선택 여부 확인
                if (string.IsNullOrEmpty(CurrentTradeType))
                {
                    MessageBox.Show("먼저 매매유형을 선택하세요.",
                                    "안내",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }

                // 2) 먼저 창고 선택 여부 확인 (매입/매출 모두 창고 필수)
                if (!selectedWarehouseId.HasValue)
                {
                    MessageBox.Show("먼저 창고를 선택하세요.",
                                    "안내",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }

                // 3) ★ 매번 콤보박스를 열기 전에 상품 목록을 DB에서 다시 읽어온다
                RefreshProductList();
            }
        }


        // 값 변경 시(상품/수량)
        private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = dgvDetail;
            var row = grid.Rows[e.RowIndex];
            string col = grid.Columns[e.ColumnIndex].Name;

            // 상품 선택 시
            if (col == "colProduct")
            {
                var cell = row.Cells["colProduct"];

                if (cell.Value == null || cell.Value == DBNull.Value)
                    return;

                int productId = Convert.ToInt32(cell.Value);

                // 상품ID 자동 세팅
                row.Cells["colProductID"].Value = productId;

                // 단가 가져오기
                if (productTable == null) return;

                DataRow[] found = productTable.Select("PRODUCTID = " + productId);
                if (found.Length == 0) return;

                decimal unitPrice = Convert.ToDecimal(found[0]["UNITPRICE"]);

                row.Cells["colUnitPrice"].Value = unitPrice;

                // 수량 기본값 1
                if (row.Cells["colQty"].Value == null ||
                    row.Cells["colQty"].Value == DBNull.Value ||
                    row.Cells["colQty"].Value.ToString() == "")
                {
                    row.Cells["colQty"].Value = 1;
                }

                int qty = Convert.ToInt32(row.Cells["colQty"].Value);

                // 금액 = 수량 × 단가
                row.Cells["colAmount"].Value = unitPrice * qty;

                // 재고수량 갱신
                UpdateStockForRow(row);

                // ★ 총금액 재계산
                RecalcTotalAmount();
            }

            // 수량 변경 시
            if (col == "colQty")
            {
                if (_isUpdatingQty) return;   // 재귀 방지

                if (row.Cells["colQty"].Value == null ||
                    row.Cells["colUnitPrice"].Value == null)
                    return;

                int qty;
                decimal unitPrice;

                int.TryParse(row.Cells["colQty"].Value.ToString(), out qty);
                decimal.TryParse(row.Cells["colUnitPrice"].Value.ToString(), out unitPrice);

                // ===== 매출일 때 재고 초과 체크 =====
                if (CurrentTradeType == TRADE_TYPE_SELL &&
                    selectedWarehouseId.HasValue &&
                    row.Cells["colProductID"].Value != null)
                {
                    int productId;
                    if (int.TryParse(row.Cells["colProductID"].Value.ToString(), out productId))
                    {
                        int baseQty = GetInventoryQty(selectedWarehouseId.Value, productId);

                        if (qty > baseQty)
                        {
                            MessageBox.Show(
                                $"재고수량({baseQty})보다 많이 판매할 수 없습니다.\n" +
                                "수량을 재고 이하로 다시 입력하세요.",
                                "수량 오류",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            // 수량을 재고 최대치로 맞추고 다시 계산
                            _isUpdatingQty = true;

                            row.Cells["colQty"].Value = baseQty;
                            row.Cells["colAmount"].Value = unitPrice * baseQty;

                            UpdateStockForRow(row);
                            RecalcTotalAmount();

                            _isUpdatingQty = false;

                            // 다시 입력할 수 있도록 포커스 유지
                            dgvDetail.CurrentCell = row.Cells["colQty"];
                            dgvDetail.BeginEdit(true);

                            return;
                        }
                    }
                }

                // ===== 정상 범위일 때의 일반 처리 =====
                row.Cells["colAmount"].Value = unitPrice * qty;

                UpdateStockForRow(row);
                RecalcTotalAmount();
            }
        }


        // 콤보박스 셀 편집 확정 강제
        private void dgvDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetail.IsCurrentCellDirty)
            {
                dgvDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // DataError 처리 (상품콤보 값이 DataSource에 없을 때 등)
        private void dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvDetail.Columns[e.ColumnIndex].Name == "colProduct" &&
                e.Exception is ArgumentException)
            {
                MessageBox.Show(
                    "현재 설정된 매매유형/창고에서는 이 상품을 사용할 수 없습니다.\n해당 행의 상품 정보를 초기화합니다.",
                    "상품 없음",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                var row = dgvDetail.Rows[e.RowIndex];

                row.Cells["colProduct"].Value = null;
                row.Cells["colProductID"].Value = null;
                row.Cells["colUnitPrice"].Value = null;
                row.Cells["colQty"].Value = null;
                row.Cells["colAmount"].Value = null;
                row.Cells["colStockQty"].Value = null;

                e.ThrowException = false;
            }
            else
            {
                e.ThrowException = false;
            }
        }

        // ================== 화면 전체 초기화 ==================
        private void ResetTradePage()
        {
            // 1) 헤더 영역 초기화
            try
            {
                // 거래번호
                if (txtTradeNo != null)
                    txtTradeNo.Clear();

                // 거래일자 : 오늘 날짜로
                if (dtpTradeDate != null)
                    dtpTradeDate.Value = DateTime.Today;

                // 매매유형
                if (cboTradeType != null)
                    cboTradeType.SelectedIndex = -1;

                // 거래처 / 담당자 / 창고
                if (txtCustomer != null)
                    txtCustomer.Clear();
                if (txtStaff != null)
                    txtStaff.Clear();
                if (txtWarehouse != null)
                    txtWarehouse.Clear();

                // 결제수단
                if (cboPayment != null)
                    cboPayment.SelectedIndex = -1;

                // 총금액
                if (txtTotalAmount != null)
                    txtTotalAmount.Text = string.Empty;
            }
            catch { }  // 컨트롤 이름이 조금 다르더라도 프로그램 죽지 않게

            // 2) 내부 상태 변수 초기화
            selectedCustomerId = null;
            selectedStaffId = null;
            selectedWarehouseId = null;

            // 3) 매매상세 그리드 초기화
            if (dgvDetail != null)
            {
                dgvDetail.Rows.Clear();
            }

            // 4) 상품콤보도 비워 주기
            InitEmptyProductList();

            // 5) 총금액 재계산(=0으로 맞추기)
            RecalcTotalAmount();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResetTradePage();
        }

        // ================== 새 거래번호 생성 ==================
        private int GetNextTradeId()
        {
            int nextId = 1;

            try
            {
                DBCLASS db = new DBCLASS();
                db.DB_ObjCreate();
                db.DB_Open("SELECT TradeID FROM Trade");   // 모든 거래번호 조회
                db.DBAdapter.Fill(db.DS, "Trade");

                DataTable t = db.DS.Tables["Trade"];
                int max = 0;

                foreach (DataRow row in t.Rows)
                {
                    int v;
                    if (int.TryParse(row["TRADEID"].ToString(), out v))
                    {
                        if (v > max) max = v;
                    }
                }

                nextId = max + 1;
                db.DB_Close();
            }
            catch
            {
                // 조회 실패하면 그냥 1 사용 (초기 개발용)
                nextId = 1;
            }

            return nextId;
        }


        // ================== 재고 한 행에 대한 증감 적용 ==================
        private void ApplyInventoryChange(DataTable invTable,
                                          int warehouseId,
                                          int productId,
                                          int qtyDelta)   // 매입: +수량, 매출: -수량
        {
            // PK: (WarehouseID, ProductID)
            if (invTable.PrimaryKey == null || invTable.PrimaryKey.Length == 0)
            {
                invTable.PrimaryKey = new DataColumn[]
                {
            invTable.Columns["WAREHOUSEID"],
            invTable.Columns["PRODUCTID"]
                };
            }

            object[] key = new object[] { warehouseId, productId };
            DataRow invRow = invTable.Rows.Find(key);

            if (invRow == null)
            {
                // 기존 재고 행이 없음
                if (qtyDelta < 0)
                {
                    // 재고가 0인데 매출하려고 하면 에러
                    throw new InvalidOperationException(
                        $"창고 {warehouseId}, 상품 {productId} 의 재고가 부족합니다.");
                }

                invRow = invTable.NewRow();
                invRow["WAREHOUSEID"] = warehouseId;
                invRow["PRODUCTID"] = productId;
                invRow["QUANTITY"] = qtyDelta;   // 새로 생성되는 재고 수량
                invTable.Rows.Add(invRow);
            }
            else
            {
                int curQty = 0;
                int.TryParse(invRow["QUANTITY"].ToString(), out curQty);

                int newQty = curQty + qtyDelta;
                if (newQty < 0)
                {
                    throw new InvalidOperationException(
                        $"창고 {warehouseId}, 상품 {productId} 의 재고가 부족합니다.");
                }

                invRow["QUANTITY"] = newQty;
            }
        }




        // ================== [저장] 버튼 ==================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1) 헤더 기본 검증
            if (string.IsNullOrEmpty(CurrentTradeType))
            {
                MessageBox.Show("매매유형을 선택하세요.", "오류",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!selectedWarehouseId.HasValue)
            {
                MessageBox.Show("창고를 선택하세요.", "오류",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 상세에 한 줄도 없으면 저장 불가
            bool hasDetail = false;
            foreach (DataGridViewRow r in dgvDetail.Rows)
            {
                if (!r.IsNewRow)
                {
                    hasDetail = true;
                    break;
                }
            }
            if (!hasDetail)
            {
                MessageBox.Show("매매상세에 최소 1개 이상의 상품을 입력하세요.",
                                "오류",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 총금액 다시 한번 계산해서 동기화
            RecalcTotalAmount();

            decimal totalAmount = 0;
            decimal.TryParse(txtTotalAmount.Text, out totalAmount);

            try
            {
                // 2) 새 거래번호 생성
                int newTradeId = GetNextTradeId();
                txtTradeNo.Text = newTradeId.ToString();   // 화면에도 표시

                // 3) Trade 헤더 저장 준비
                dbTrade.DB_ObjCreate();
                dbTrade.DB_Open("SELECT * FROM Trade");
                dbTrade.DBAdapter.Fill(dbTrade.DS, "Trade");

                DataTable tradeTable = dbTrade.DS.Tables["Trade"];

                DataRow header = tradeTable.NewRow();
                header["TRADEID"] = newTradeId;
                header["TRADEDATE"] = dtpTradeDate.Value.Date;
                header["TRADETYPE"] = CurrentTradeType;

                if (selectedCustomerId.HasValue)
                    header["CUSTOMERID"] = selectedCustomerId.Value;
                else
                    header["CUSTOMERID"] = DBNull.Value;

                if (selectedStaffId.HasValue)
                    header["STAFFID"] = selectedStaffId.Value;
                else
                    header["STAFFID"] = DBNull.Value;

                header["DEFAULTWHID"] = selectedWarehouseId.Value;

                if (cboPayment.SelectedItem != null)
                    header["PAYMENTMETHOD"] = cboPayment.SelectedItem.ToString();
                else
                    header["PAYMENTMETHOD"] = DBNull.Value;

                header["TOTALAMOUNT"] = totalAmount;

                tradeTable.Rows.Add(header);

                // 4) TradeDetail + Inventory 저장 준비 =====================
                dbDetail.DB_ObjCreate();
                dbDetail.DB_Open("SELECT * FROM TradeDetail");
                dbDetail.DBAdapter.Fill(dbDetail.DS, "TradeDetail");
                DataTable detailTable = dbDetail.DS.Tables["TradeDetail"];

                // 재고 테이블 로딩
                dbInventory.DB_ObjCreate();
                dbInventory.DB_Open("SELECT * FROM Inventory");
                dbInventory.DBAdapter.Fill(dbInventory.DS, "Inventory");
                DataTable invTable = dbInventory.DS.Tables["Inventory"];

                int lineNo = 1;
                int whId = selectedWarehouseId.Value;

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["colProductID"].Value == null) continue;

                    int productId;
                    int qty;
                    decimal unitPrice;
                    decimal amount;

                    if (!int.TryParse(Convert.ToString(row.Cells["colProductID"].Value), out productId))
                        continue;
                    if (!int.TryParse(Convert.ToString(row.Cells["colQty"].Value), out qty))
                        continue;

                    decimal.TryParse(Convert.ToString(row.Cells["colUnitPrice"].Value), out unitPrice);
                    decimal.TryParse(Convert.ToString(row.Cells["colAmount"].Value), out amount);

                    // ---- 4-1) TradeDetail 행 생성
                    DataRow d = detailTable.NewRow();
                    d["TRADEID"] = newTradeId;
                    d["LINENO"] = lineNo++;
                    d["PRODUCTID"] = productId;
                    d["QUANTITY"] = qty;
                    d["UNITPRICE"] = unitPrice;
                    d["AMOUNT"] = amount;
                    detailTable.Rows.Add(d);

                    // ---- 4-2) 재고 증감 적용
                    int delta = 0;
                    if (CurrentTradeType == "매입")
                        delta = qty;       // 매입: 재고 증가
                    else if (CurrentTradeType == "매출")
                        delta = -qty;      // 매출: 재고 감소

                    if (delta != 0)
                    {
                        ApplyInventoryChange(invTable, whId, productId, delta);
                    }
                }

                // 5) 실제 DB 반영 (헤더 + 상세 + 재고)
                dbTrade.DBAdapter.Update(dbTrade.DS, "Trade");
                dbTrade.DB_Close();

                dbDetail.DBAdapter.Update(dbDetail.DS, "TradeDetail");
                dbDetail.DB_Close();

                dbInventory.DBAdapter.Update(dbInventory.DS, "Inventory");
                dbInventory.DB_Close();

                MessageBox.Show("거래 및 재고가 정상적으로 저장되었습니다.",
                                "저장 완료",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // 6) 저장 후 화면 초기화
                ResetTradePage();
            }
            catch (InvalidOperationException ex)   // 재고 부족 등 논리 오류
            {
                MessageBox.Show(ex.Message,
                                "재고 오류",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장 중 오류가 발생했습니다.\n" + ex.Message,
                                "오류",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void statistics_Click(object sender, EventArgs e)
        {
            TradeStatisticsForm statistics = new TradeStatisticsForm(GetConnectionString());
            statistics.ShowDialog();
        }
    }
}
