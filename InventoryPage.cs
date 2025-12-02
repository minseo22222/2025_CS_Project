using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2025_CS_Project
{
    public partial class InventoryPage : UserControl
    {
        DBCLASS db = new DBCLASS();   // Warehouse 전용
        DBCLASS db2 = new DBCLASS();  // Inventory 전용

        public InventoryPage()
        {
            InitializeComponent();
            db.DB_ObjCreate();
            db.DB_Open("SELECT * FROM Warehouse");
            db2.DB_ObjCreate();
            dataGridViewInventory.ContextMenuStrip = contextMenuStrip1;
        }

        void ShowList()
        {
            try
            {
                db.DS.Clear();
                db.DBAdapter.Fill(db.DS, "Warehouse");
                WarehouseList.Items.Clear();
                foreach (DataRow row in db.DS.Tables["Warehouse"].Rows)
                {
                    string name = row["WarehouseName"].ToString();
                    WarehouseList.Items.Add(name);
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        void InventoryPage_Load(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            ShowList();
        }

        bool isNum(string str, string err_msg)
        {
            int num;
            if (!int.TryParse(str, out num))
            {
                MessageBox.Show(err_msg);
                return false;
            }
            return true;
        }

        void AddWarehouse()
        {
            try
            {
                if (!isNum(txtWarehouseNum.Text, "창고번호를 숫자로 입력하세요."))
                    return;

                int warehouseID = Convert.ToInt32(txtWarehouseNum.Text);
                string warehouseName = txtWarehouseName.Text;

                DataTable table = db.DS.Tables["Warehouse"];
                table.PrimaryKey = new DataColumn[] { table.Columns["WarehouseID"] };

                DataRow existingRow = table.Rows.Find(warehouseID);

                if (existingRow != null)
                {
                    existingRow["WarehouseName"] = warehouseName;
                    MessageBox.Show("기존 창고 정보를 수정했습니다.");
                }
                else
                {
                    DataRow newRow = table.NewRow();
                    newRow["WarehouseID"] = warehouseID;
                    newRow["WarehouseName"] = warehouseName;
                    table.Rows.Add(newRow);
                    MessageBox.Show("새 창고를 추가했습니다.");
                }

                db.DBAdapter.Update(db.DS, "Warehouse");
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        void DeleteWarehouse()
        {
            try
            {
                if (WarehouseList.SelectedItem == null)
                {
                    MessageBox.Show("삭제할 창고를 선택하세요.");
                    return;
                }

                string selectedName = WarehouseList.SelectedItem.ToString();
                DataTable table = db.DS.Tables["Warehouse"];

                DataRow[] rows = table.Select($"WarehouseName = '{selectedName.Replace("'", "''")}'");

                if (rows.Length > 0)
                {
                    if (MessageBox.Show("선택한 창고를 정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        rows[0].Delete();
                        db.DBAdapter.Update(db.DS, "Warehouse");

                        ShowList();
                        txtWarehouseNum.Clear();
                        txtWarehouseName.Clear();

                        MessageBox.Show("창고가 삭제되었습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("삭제할 창고를 찾을 수 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 중 오류: " + ex.Message);
            }
        }

        private void AppendBtn_Click(object sender, EventArgs e)
        {
            AddWarehouse();
            ShowList();
        }

        private void WarehouseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WarehouseList.SelectedItem == null) return;

            string selectedName = WarehouseList.SelectedItem.ToString();
            DataTable table = db.DS.Tables["Warehouse"];

            DataRow[] rows = table.Select($"WarehouseName = '{selectedName.Replace("'", "''")}'");

            if (rows.Length > 0)
            {
                int warehouseID = Convert.ToInt32(rows[0]["WarehouseID"]);

                txtWarehouseNum.Text = warehouseID.ToString();
                txtWarehouseName.Text = rows[0]["WarehouseName"].ToString();
                ShowInventoryByWarehouse(warehouseID);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteWarehouse();
            ShowList();
        }

        // ✅ Inventory 관련은 모두 db2 사용
        void ShowInventoryByWarehouse(int warehouseID)
        {
            try
            {
                db2.DB_Close();
                db2.DB_Open(
                     "SELECT p.ProductID AS \"상품번호\", " +
            "p.ProductName AS \"상품명\", " +
            "i.Quantity AS \"재고수\" " +
            "FROM Inventory i " +
            "JOIN Product p ON i.ProductID = p.ProductID " +
            "WHERE i.WarehouseID = :WarehouseID"
                );

                db2.DBAdapter.SelectCommand.Parameters.Clear();
                db2.DBAdapter.SelectCommand.Parameters.Add("WarehouseID", warehouseID);

                if (db2.DS.Tables.Contains("InventoryView"))
                    db2.DS.Tables["InventoryView"].Clear();

                db2.DBAdapter.Fill(db2.DS, "InventoryView");

                dataGridViewInventory.DataSource = db2.DS.Tables["InventoryView"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("재고 조회 오류: " + ex.Message);
            }
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int warehouseID;
            if (!int.TryParse(txtWarehouseNum.Text, out warehouseID))
            {
                MessageBox.Show("창고를 먼저 선택하세요.");
                return;
            }

            InventroyUpdate frm = new InventroyUpdate(warehouseID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ShowInventoryByWarehouse(warehouseID);
            }
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewInventory.CurrentRow == null)
            {
                MessageBox.Show("수정할 상품을 선택하세요.");
                return;
            }

            int warehouseID = Convert.ToInt32(txtWarehouseNum.Text);
            int productID = Convert.ToInt32(dataGridViewInventory.CurrentRow.Cells["상품번호"].Value);
            string productName = dataGridViewInventory.CurrentRow.Cells["상품명"].Value.ToString();
            int currentQty = Convert.ToInt32(dataGridViewInventory.CurrentRow.Cells["재고수"].Value);

            InventroyUpdate frm = new InventroyUpdate(warehouseID);
            frm.SetProduct(productID, productName, currentQty);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ShowInventoryByWarehouse(warehouseID);
            }
        }

        private void deleteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewInventory.CurrentRow == null || dataGridViewInventory.CurrentRow.Index < 0)
                {
                    MessageBox.Show("삭제할 재고를 선택하세요.");
                    return;
                }

                int warehouseID = Convert.ToInt32(txtWarehouseNum.Text);

                // 안전하게 컬럼명 또는 인덱스로 접근
                int productID = Convert.ToInt32(dataGridViewInventory.CurrentRow.Cells["상품번호"].Value);

                db2.DB_Open("SELECT * FROM Inventory");
                db2.DBAdapter.Fill(db2.DS, "Inventory");

                DataTable table = db2.DS.Tables["Inventory"];
                table.PrimaryKey = new DataColumn[] { table.Columns["WarehouseID"], table.Columns["ProductID"] };

                DataRow row = table.Rows.Find(new object[] { warehouseID, productID });

                if (row != null)
                {
                    if (MessageBox.Show("선택한 재고를 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        row.Delete();
                        db2.DBAdapter.Update(db2.DS, "Inventory");
                        MessageBox.Show("재고가 삭제되었습니다.");
                        ShowInventoryByWarehouse(warehouseID);
                    }
                }
                else
                {
                    MessageBox.Show("삭제할 재고를 찾을 수 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("재고 삭제 중 오류: " + ex.Message);
            }
        }


        private void invSearchBtn_Click(object sender, EventArgs e)
        {
            if (db2.DS.Tables.Contains("InventoryView") == false)
                return; // 테이블이 없으면 종료

            string keyword = txtInvSearch.Text.Trim(); // 검색어
            DataTable dt = db2.DS.Tables["InventoryView"];
            DataView dv = dt.DefaultView;

            if (string.IsNullOrEmpty(keyword))
            {
                // 검색어 없으면 필터 초기화
                dv.RowFilter = "";
            }
            else
            {
                // 상품명 LIKE 검색
                dv.RowFilter = $"상품명 LIKE '%{keyword.Replace("'", "''")}%'";
            }

            dataGridViewInventory.DataSource = dv;
        }
    }
}
