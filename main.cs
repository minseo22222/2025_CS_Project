using _2025_CS_Project;
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
    public partial class Form1 : Form
    {
        ProductPage productPage = new ProductPage();
        TradePage tradePage = new TradePage();
        InventoryPage inventoryPage = new InventoryPage();
        private void ShowPage(UserControl page)
        {
            panelMain.Controls.Clear();   
            page.Dock = DockStyle.Fill;   
            panelMain.Controls.Add(page); 
        }
        public Form1()
        {
            InitializeComponent(); 
            ShowPage(tradePage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MenuProduct_Click(object sender, EventArgs e)
        {
            ShowPage(productPage);
        }

        private void MenuTrade_Click(object sender, EventArgs e)
        {
            ShowPage(tradePage);
        }

        private void MenuStock_Click(object sender, EventArgs e)
        {
            ShowPage(inventoryPage);
        }
    }
}
