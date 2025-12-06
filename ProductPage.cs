using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2025_CS_Project
{
    public partial class ProductPage : UserControl
    {
        DBCLASS db = new DBCLASS();
        DataTable table;
        public ProductPage()
        {
            InitializeComponent();
            ProductType.SelectedIndex = 0;
            db.DB_ObjCreate();
            db.DB_Open("SELECT * FROM product");

            DBGrid.ContextMenuStrip = contextMenuStrip1;
            
        }
        void ShowTable()
        {
            try
            {
                db.DS.Clear();
                db.DBAdapter.Fill(db.DS, "product");
                table = new DataTable();
                
                table.Columns.Add("상품코드", typeof(int));
                table.Columns.Add("상품명", typeof(string));
                table.Columns.Add("단가" , typeof(int));
                table.Columns.Add("최소수량", typeof(int));
                table.Columns.Add("구분", typeof(string));
                foreach (DataRow row in db.DS.Tables["Product"].Rows)
                {
                    var newRow = table.NewRow();
                    newRow["상품코드"] = row["ProductID"]; 
                    newRow["상품명"] = row["ProductName"];
                    newRow["단가"] = row["UnitPrice"];

                    if (row["MinStock"] != DBNull.Value)
                        newRow["최소수량"] = row["MinStock"];
                    else
                        newRow["최소수량"] = 0;

                    newRow["구분"] = row["category"];
                    table.Rows.Add(newRow);
                }
                DBGrid.DataSource = table;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        bool isNum(string str,string err_msg)
        {
            int num;
            if (!int.TryParse(str, out num))
            {
                MessageBox.Show(err_msg);
                return false;
            }
            return true;
        }

        bool isDBLoaded()
        {
            if (db.DS == null || db.DS.Tables["Product"] == null)
            {
                MessageBox.Show("DB가 로드되지 않았습니다.");
                return false;
            }
            return true;
        }

        void AddProduct()
        {
            try
            {
                if (!isDBLoaded())
                {
                    return;
                }

                DataRow pRow = db.DS.Tables["Product"].NewRow();
                /***입력값이 숫자인지 판별***/
                if(!isNum(txtProductNum.Text,"상품번호를 숫자로 입력하세요."))
                {
                    return;
                }
                if (!isNum(txtPrice.Text, "가격을 숫자로 입력하세요."))
                {
                    return;
                }

                int minStock = 5;
                if (!string.IsNullOrEmpty(txtMinStock.Text))
                {
                    if (!isNum(txtMinStock.Text, "최소수량을 숫자로 입력하세요.")) return;
                    minStock = Convert.ToInt32(txtMinStock.Text);
                }

                // 기존 행 찾기
                DataTable table = db.DS.Tables["Product"];
                table.PrimaryKey = new DataColumn[] { table.Columns["ProductID"] }; // Primary Key 설정
                DataRow existingRow = table.Rows.Find(Convert.ToInt32(txtProductNum.Text)); // PK로 찾기 위해 DataTable.PrimaryKey 설정 필요

                if (existingRow != null)
                {
                    // 이미 존재하면 수정
                    UpdateProduct(table.Rows.IndexOf(existingRow));
                    return;
                }

                pRow["ProductID"] = Convert.ToInt32(txtProductNum.Text);
                pRow["ProductName"] = txtProductName.Text;
                pRow["UnitPrice"] = Convert.ToInt32(txtPrice.Text);

                pRow["MinStock"] = minStock;

                if (ProductType.SelectedIndex==0)
                    pRow["category"] = "원재료";
                else
                    pRow["category"] = "완제품";

                db.DS.Tables["Product"].Rows.Add(pRow);
                db.DBAdapter.Update(db.DS, "Product");
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            
        }

        void UpdateProduct(int? rowIndex)
        {
            try
            {
                if (!isDBLoaded())
                    return;

                if (DBGrid.CurrentRow == null)
                {
                    MessageBox.Show("수정할 행을 선택하세요.");
                    return;
                }

                //  DataGridView에서 "상품코드(PK)" 값 가져오기
                int productID = Convert.ToInt32(
                    DBGrid.CurrentRow.Cells["상품코드"].Value
                );

                // 원본 DataTable에서 PK로 정확한 Row 찾기
                DataTable table = db.DS.Tables["Product"];
                table.PrimaryKey = new DataColumn[] { table.Columns["ProductID"] };

                DataRow pRow = table.Rows.Find(productID);

                if (pRow == null)
                {
                    MessageBox.Show("원본 데이터를 찾을 수 없습니다.");
                    return;
                }

                /***입력값이 숫자인지 판별***/
                if (!isNum(txtProductNum.Text, "상품번호를 숫자로 입력하세요."))
                    return;
                if (!isNum(txtPrice.Text, "가격을 숫자로 입력하세요."))
                    return;

                int minStock = 5;
                if (!string.IsNullOrEmpty(txtMinStock.Text))
                {
                    if (!isNum(txtMinStock.Text, "최소수량을 숫자로 입력하세요.")) return;
                    minStock = Convert.ToInt32(txtMinStock.Text);
                }

                // 안전하게 실제 DB Row 수정
                pRow["ProductName"] = txtProductName.Text;
                pRow["UnitPrice"] = Convert.ToInt32(txtPrice.Text);

                pRow["MinStock"] = minStock;

                if (ProductType.SelectedIndex == 0)
                    pRow["category"] = "원재료";
                else
                    pRow["category"] = "완제품";

                db.DBAdapter.Update(db.DS, "Product");
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        void DeleteProduct()
        {
            try
            {
                if(!isDBLoaded())
                {
                    return;
                }

                if (DBGrid.CurrentRow == null)
                {
                    MessageBox.Show("삭제할 행을 선택하세요.");
                    return;
                }

                int rowIndex = DBGrid.CurrentRow.Index;
                DataRow pRow = db.DS.Tables["Product"].Rows[rowIndex];
                pRow.Delete();
                db.DBAdapter.Update(db.DS, "Product");
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
           
        }

        private void OpenDBBtn_Click(object sender, EventArgs e)
        {
            ShowTable();
            DBGrid.Sort(DBGrid.Columns["상품코드"], ListSortDirection.Ascending);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateProduct(null);
            ShowTable();
        }

        private void AppendBtn_Click(object sender, EventArgs e)
        {
            AddProduct();
            ShowTable();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteProduct();
            ShowTable();
        }

        void SelectCell(int index)
        {
            DataGridViewRow row = DBGrid.Rows[index];

            // 공통 컬럼 (Product 테이블)
            txtProductNum.Text = row.Cells["상품코드"].Value?.ToString();
            txtProductName.Text = row.Cells["상품명"].Value?.ToString();
            txtPrice.Text = row.Cells["단가"].Value?.ToString();

            txtMinStock.Text = row.Cells["최소수량"].Value?.ToString();

            if (row.Cells["구분"].Value?.ToString() == "원재료")
                ProductType.SelectedIndex = 0;
            else
                ProductType.SelectedIndex = 1;
        }

        private void DBGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SelectCell(e.RowIndex);
        }

        private void SortNum_CheckedChanged(object sender, EventArgs e)
        {
            if (SortNum.Checked)
                DBGrid.Sort(DBGrid.Columns["상품코드"], ListSortDirection.Ascending);
        }

        private void SortName_CheckedChanged(object sender, EventArgs e)
        {
            if(SortName.Checked)
                DBGrid.Sort(DBGrid.Columns["상품명"], ListSortDirection.Ascending);
        }

        private void SortHigh_CheckedChanged(object sender, EventArgs e)
        {
            if(SortHigh.Checked)
                DBGrid.Sort(DBGrid.Columns["단가"], ListSortDirection.Descending);
        }

        private void SortLow_CheckedChanged(object sender, EventArgs e)
        {
            if(SortLow.Checked)
                DBGrid.Sort(DBGrid.Columns["단가"], ListSortDirection.Ascending);
        }

        void getSelectRow(int productID)
        {
            foreach (DataGridViewRow row in DBGrid.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["상품코드"].Value is int id && id == productID)
                {
                    row.Selected = true;
                    DBGrid.FirstDisplayedScrollingRowIndex = row.Index; // 스크롤 이동
                    SelectCell(row.Index);
                    break;
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (table == null)
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
                return;
            }

            string keyword = txtProductName.Text.Trim();

            DataView dv = table.DefaultView;

            // 상품명 LIKE 검색
            dv.RowFilter = $"상품명 LIKE '%{SearchText.Text}%'";
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowInventoryInfo_Click(object sender, EventArgs e)
        {
            // 선택된 셀 확인
            if (DBGrid.SelectedCells.Count > 0)
            {
                var selectedCell = DBGrid.SelectedCells[0];
                var row = DBGrid.Rows[selectedCell.RowIndex];

                // 상품코드(int) 가져오기
                if (int.TryParse(row.Cells["상품코드"].Value.ToString(), out int productNum))
                {
                    // InventoryInfo 폼 생성 + 값 전달
                    InventoryInfo inventoryForm = new InventoryInfo
                    {
                        ProductId = productNum
                    };
                    inventoryForm.WarehouseSelected += warehouseID =>
                    {
                        // 이 곳에서 MessageBox 또는 다른 처리
                        MessageBox.Show($"선택된 창고번호: {warehouseID}");
                    };


                    inventoryForm.Show();
                }
                else
                {
                    MessageBox.Show("상품코드가 올바르지 않습니다.");
                }
            }
            else
            {
                MessageBox.Show("올바른 셀을 선택해주세요.");
            }
        }

        private void DBGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = DBGrid.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    DBGrid.ClearSelection();
                    DBGrid.Rows[hit.RowIndex].Selected = true;
                    DBGrid.CurrentCell = DBGrid.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                }
            }
        }
    }
}
