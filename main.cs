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
        factorycs Factorycs = new factorycs();
        ProductPage productPage = new ProductPage();
        TradePage tradePage = new TradePage();
        InventoryPage inventoryPage = new InventoryPage();
        Customer customer = new Customer();
        employee emp = new employee();
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

        private void MenuTrader_Click(object sender, EventArgs e)
        {
            ShowPage(customer);
        }

        private void MenuEmployee_Click(object sender, EventArgs e)
        {
            ShowPage(emp);
        }

        private void MenuProduce_Click(object sender, EventArgs e)
        {
            ShowPage(Factorycs);
        }
<<<<<<< Updated upstream
=======

        private void 거래내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeManageForm form = new TradeManageForm();
            form.Show();
        }

        private void 거래통계ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeStatisticsForm form = new TradeStatisticsForm();
            form.Show();
        }
>>>>>>> Stashed changes
    }
}
