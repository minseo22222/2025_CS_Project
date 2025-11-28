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
    public partial class ProductSearchPage : Form
    {
        public ProductSearchPage(DataTable dt)
        {
            InitializeComponent();
            DBGrid.DataSource = dt.Copy();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            DataTable searchedTable = (DataTable)DBGrid.DataSource;

            if (string.IsNullOrWhiteSpace(SearchText.Text))
            {
                searchedTable.DefaultView.RowFilter = "";
                return;
            }

            string searchText = SearchText.Text.Replace("'", "''");
            searchedTable.DefaultView.RowFilter = $"상품명 LIKE '%{searchText}%'";
        }
        public event Action<int> CellValueSelected;

        private void OnCellValueSelected(int value)
        {
            CellValueSelected?.Invoke(value);
        }

        private void DBGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // 선택한 셀 값 가져오기 (상품번호 int)
            if (DBGrid.Rows[e.RowIndex].Cells["상품코드"].Value is int selectedProductID)
            {
                OnCellValueSelected(selectedProductID);
                this.Close();
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
