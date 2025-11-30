using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class TradePage : UserControl
    {

        DBCLASS dbTrade = new DBCLASS();      // Trade 헤더용
        DBCLASS dbDetail = new DBCLASS();     // TradeDetail 상세용
        DBCLASS dbCommon = new DBCLASS();     // 공통(창고, 상품 목록 등)

        DataTable productTable;               // 상품 목록(콤보박스용)
        int selectedDetailRowIndex = -1;
        private const String id = "HONG1";
        private const String ps = "1111";


        // 창고 목록
        private void LoadWarehouseList()
        {
            try
            {
                dbCommon.DB_Open(
                    "SELECT WarehouseID, WarehouseName FROM Warehouse ORDER BY WarehouseID");
                dbCommon.DB_ObjCreate();
                dbCommon.DBAdapter.Fill(dbCommon.DS, "Warehouse");

                DataTable whTable = dbCommon.DS.Tables["Warehouse"];

                cboWarehouse.DataSource = whTable;
                cboWarehouse.DisplayMember = "WAREHOUSENAME";
                cboWarehouse.ValueMember = "WAREHOUSEID";
                cboWarehouse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 상품 목록 (dgvDetail 콤보박스)
        private void LoadProductList()
        {
            try
            {
                dbCommon.DB_Open(
                    "SELECT ProductID, ProductName, UnitPrice FROM Product ORDER BY ProductID");
                dbCommon.DB_ObjCreate();
                dbCommon.DBAdapter.Fill(dbCommon.DS, "Product");

                productTable = dbCommon.DS.Tables["Product"];

                var colProduct = (DataGridViewComboBoxColumn)dgvDetail.Columns["colProduct"];
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



        public TradePage()
        {
            InitializeComponent();
            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (!this.DesignMode)
            {
                LoadWarehouseList();
                LoadProductList();
            }
        }


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            TradeManageForm frm = new TradeManageForm();
            frm.ShowDialog();
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedDetailRowIndex = e.RowIndex;
        }

        private void ProductDel_Click(object sender, EventArgs e)
        {
            if (selectedDetailRowIndex < 0 ||selectedDetailRowIndex >= dgvDetail.Rows.Count)
                return;

            if (dgvDetail.Rows[selectedDetailRowIndex].IsNewRow)
                return;

            dgvDetail.Rows.RemoveAt(selectedDetailRowIndex);

        }

        private void ProductAdd_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Add();
        }

        private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 헤더 행이면 무시

            var grid = dgvDetail;
            var row = grid.Rows[e.RowIndex];
            string col = grid.Columns[e.ColumnIndex].Name;

            // ---------- 경우 1 : 상품(콤보박스) 컬럼이 변경된 경우 ----------
            if (col == "colProduct")
            {
                var cell = row.Cells["colProduct"];

                if (cell.Value == null || cell.Value == DBNull.Value)
                    return;

                // ComboBox 의 ValueMember = PRODUCTID 이므로
                int productId = Convert.ToInt32(cell.Value);

                // ① 상품ID 자동 채우기
                row.Cells["colProductID"].Value = productId;

                // ② productTable 에서 해당 상품을 찾아 단가 가져오기
                if (productTable == null) return;

                DataRow[] found = productTable.Select("PRODUCTID = " + productId);
                if (found.Length == 0) return;

                decimal unitPrice = Convert.ToDecimal(found[0]["UNITPRICE"]);

                // ③ 단가 자동 채우기
                row.Cells["colUnitPrice"].Value = unitPrice;

                // ④ 수량이 비어 있으면 기본값 1로 설정
                if (row.Cells["colQty"].Value == null ||
                    row.Cells["colQty"].Value == DBNull.Value ||
                    row.Cells["colQty"].Value.ToString() == "")
                {
                    row.Cells["colQty"].Value = 1;
                }

                int qty = Convert.ToInt32(row.Cells["colQty"].Value);

                // ⑤ 금액 = 수량 × 단가 자동 계산
                row.Cells["colAmount"].Value = unitPrice * qty;
            }

            // ---------- 경우 2 : 수량(colQty) 컬럼이 변경된 경우 ----------
            if (col == "colQty")
            {
                // 수량 또는 단가가 비어 있으면 계산하지 않음
                if (row.Cells["colQty"].Value == null ||
                    row.Cells["colUnitPrice"].Value == null)
                    return;

                int qty = 0;
                decimal unitPrice = 0;

                int.TryParse(row.Cells["colQty"].Value.ToString(), out qty);
                decimal.TryParse(row.Cells["colUnitPrice"].Value.ToString(), out unitPrice);

                // 금액 = 수량 × 단가 재계산
                row.Cells["colAmount"].Value = unitPrice * qty;
            }
        }

        private void dgvDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetail.IsCurrentCellDirty)
            {
                // 현재 셀의 편집 결과를 강제로 "확정(Commit)" 시킨다
                dgvDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
