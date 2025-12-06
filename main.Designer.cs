namespace _2025_CS_Project
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuTrade = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProduce = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStock = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTrader = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTrade,
            this.MenuProduct,
            this.MenuProduce,
            this.MenuStock,
            this.MenuEmployee,
            this.MenuTrader});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuTrade
            // 
            this.MenuTrade.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTrade.Name = "MenuTrade";
            this.MenuTrade.Size = new System.Drawing.Size(102, 31);
            this.MenuTrade.Text = "거래관리";
            this.MenuTrade.Click += new System.EventHandler(this.MenuTrade_Click);
            // 
            // MenuProduct
            // 
            this.MenuProduct.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuProduct.Name = "MenuProduct";
            this.MenuProduct.Size = new System.Drawing.Size(102, 31);
            this.MenuProduct.Text = "상품관리";
            this.MenuProduct.Click += new System.EventHandler(this.MenuProduct_Click);
            // 
            // MenuProduce
            // 
            this.MenuProduce.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuProduce.Name = "MenuProduce";
            this.MenuProduce.Size = new System.Drawing.Size(102, 31);
            this.MenuProduce.Text = "생산관리";
            this.MenuProduce.Click += new System.EventHandler(this.MenuProduce_Click);
            // 
            // MenuStock
            // 
            this.MenuStock.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStock.Name = "MenuStock";
            this.MenuStock.Size = new System.Drawing.Size(102, 31);
            this.MenuStock.Text = "재고관리";
            this.MenuStock.Click += new System.EventHandler(this.MenuStock_Click);
            // 
            // MenuEmployee
            // 
            this.MenuEmployee.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuEmployee.Name = "MenuEmployee";
            this.MenuEmployee.Size = new System.Drawing.Size(102, 31);
            this.MenuEmployee.Text = "직원관리";
            this.MenuEmployee.Click += new System.EventHandler(this.MenuEmployee_Click);
            // 
            // MenuTrader
            // 
            this.MenuTrader.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTrader.Name = "MenuTrader";
            this.MenuTrader.Size = new System.Drawing.Size(121, 31);
            this.MenuTrader.Text = "거래처관리";
            this.MenuTrader.Click += new System.EventHandler(this.MenuTrader_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 35);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1125, 614);
            this.panelMain.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1125, 649);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuTrade;
        private System.Windows.Forms.ToolStripMenuItem MenuProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuProduce;
        private System.Windows.Forms.ToolStripMenuItem MenuStock;
        private System.Windows.Forms.ToolStripMenuItem MenuEmployee;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuTrader;
        private System.Windows.Forms.Panel panelMain;
    }
}

