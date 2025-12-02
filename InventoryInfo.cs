using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace _2025_CS_Project
{
    public partial class InventoryInfo : Form
    {
        private int _productNum;
        private DBCLASS db = new DBCLASS();

        public event Action<int> WarehouseSelected;
        public int ProductId
        {
            get => _productNum;
            set
            {
                _productNum = value;  // 내부 변수에 저장
                LoadProductInfo();
            }
        }

        public InventoryInfo()
        {
            InitializeComponent();
            db.DB_ObjCreate(); // DB 객체 생성
        }

        private void LoadProductInfo()
        {
            try
            {
                // 1. 상품명 가져오기
                txtProductNum.Text =_productNum.ToString();
                string sqlProduct = $"SELECT ProductName FROM Product WHERE ProductID = {_productNum}";
                db.DB_Open(sqlProduct);

                DataTable dtProduct = new DataTable();
                db.DBAdapter.Fill(dtProduct);

                if (dtProduct.Rows.Count > 0)
                {
                    txtProductName.Text = dtProduct.Rows[0]["ProductName"].ToString();
                }
                else
                {
                    txtProductName.Text = "존재하지 않는 상품";
                    db.DB_Close();
                    return;
                }

                db.DB_Close();

                // 2. 재고 정보 가져오기 (WarehouseID, WarehouseName, Quantity)
                string sqlInventory = $@"
                SELECT i.WarehouseID, w.WarehouseName, i.Quantity
                FROM Inventory i
                JOIN Warehouse w ON i.WarehouseID = w.WarehouseID
                WHERE i.ProductID = {_productNum}
                ORDER BY i.WarehouseID";

                db.DB_Open(sqlInventory);

                DataTable dtInventory = new DataTable();
                db.DBAdapter.Fill(dtInventory);

                DBGrid.DataSource = dtInventory;

                // 컬럼 헤더 이름 변경
                DBGrid.Columns["WarehouseID"].HeaderText = "창고번호";
                DBGrid.Columns["WarehouseName"].HeaderText = "창고이름";
                DBGrid.Columns["Quantity"].HeaderText = "재고량";

                db.DB_Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 로드 오류: " + ex.Message);
                db.DB_Close();
            }
        }

        private void DBGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int warehouseID = Convert.ToInt32(DBGrid.Rows[e.RowIndex].Cells["WarehouseID"].Value);

                // 이벤트 발생
                WarehouseSelected?.Invoke(warehouseID);
                this.Close();
            }
        }
    }
}