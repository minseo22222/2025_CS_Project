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
    public partial class InventoryProduct : Form
    {
        public InventoryProduct()
        {
            InitializeComponent();
        }

        public InventoryProduct(string prodID, string warehouseName, string qty, string price, string date)
        {
            InitializeComponent();

            txtProdID.Text = prodID;         // 상품번호
            txtWarehouse.Text = warehouseName; // 보관창고
            txtQty.Text = qty;               // 재고수량
            txtPrice.Text = price;           // 단가

            if (DateTime.TryParse(date, out DateTime parsedDate))
            {
                dtpDate.Value = parsedDate;
            }
            else
            {
                dtpDate.Value = DateTime.Now;
            }
            dtpDate.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
