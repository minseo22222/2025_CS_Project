using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        private TradePage tradePage;
        private void ShowPage(UserControl page)
        {
            panelMain.Controls.Clear();   
            page.Dock = DockStyle.Fill;   
            panelMain.Controls.Add(page); 
        }
        public Form1()
        {
            InitializeComponent();
            tradePage = new TradePage();

            
            tradePage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(tradePage);
        }
    }
}
