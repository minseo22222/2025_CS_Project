namespace _2025_CS_Project
{
    partial class TradeStatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotalPurchase = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblNetProfit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblProdQty = new System.Windows.Forms.Label();
            this.lblProdAmount = new System.Windows.Forms.Label();
            this.lblCustCount = new System.Windows.Forms.Label();
            this.lblCustAmount = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTypeFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalPurchase
            // 
            this.lblTotalPurchase.AutoSize = true;
            this.lblTotalPurchase.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalPurchase.Location = new System.Drawing.Point(158, 49);
            this.lblTotalPurchase.Name = "lblTotalPurchase";
            this.lblTotalPurchase.Size = new System.Drawing.Size(22, 24);
            this.lblTotalPurchase.TabIndex = 0;
            this.lblTotalPurchase.Text = "-";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalSales.Location = new System.Drawing.Point(158, 82);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(22, 24);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "-";
            // 
            // lblNetProfit
            // 
            this.lblNetProfit.AutoSize = true;
            this.lblNetProfit.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNetProfit.Location = new System.Drawing.Point(158, 115);
            this.lblNetProfit.Name = "lblNetProfit";
            this.lblNetProfit.Size = new System.Drawing.Size(22, 24);
            this.lblNetProfit.TabIndex = 2;
            this.lblNetProfit.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(35, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "상품";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(35, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "거래처";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(35, 92);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(121, 27);
            this.cboProduct.TabIndex = 5;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(35, 92);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(121, 27);
            this.cboCustomer.TabIndex = 6;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // lblProdQty
            // 
            this.lblProdQty.AutoSize = true;
            this.lblProdQty.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProdQty.Location = new System.Drawing.Point(158, 137);
            this.lblProdQty.Name = "lblProdQty";
            this.lblProdQty.Size = new System.Drawing.Size(22, 24);
            this.lblProdQty.TabIndex = 7;
            this.lblProdQty.Text = "-";
            // 
            // lblProdAmount
            // 
            this.lblProdAmount.AutoSize = true;
            this.lblProdAmount.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProdAmount.Location = new System.Drawing.Point(158, 179);
            this.lblProdAmount.Name = "lblProdAmount";
            this.lblProdAmount.Size = new System.Drawing.Size(22, 24);
            this.lblProdAmount.TabIndex = 8;
            this.lblProdAmount.Text = "-";
            // 
            // lblCustCount
            // 
            this.lblCustCount.AutoSize = true;
            this.lblCustCount.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCustCount.Location = new System.Drawing.Point(176, 137);
            this.lblCustCount.Name = "lblCustCount";
            this.lblCustCount.Size = new System.Drawing.Size(22, 24);
            this.lblCustCount.TabIndex = 9;
            this.lblCustCount.Text = "-";
            // 
            // lblCustAmount
            // 
            this.lblCustAmount.AutoSize = true;
            this.lblCustAmount.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCustAmount.Location = new System.Drawing.Point(176, 179);
            this.lblCustAmount.Name = "lblCustAmount";
            this.lblCustAmount.Size = new System.Drawing.Size(22, 24);
            this.lblCustAmount.TabIndex = 10;
            this.lblCustAmount.Text = "-";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(92, 31);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 21);
            this.dtpFrom.TabIndex = 11;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(326, 31);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 21);
            this.dtpTo.TabIndex = 12;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(298, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "~";
            // 
            // cboTypeFilter
            // 
            this.cboTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFilter.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboTypeFilter.FormattingEnabled = true;
            this.cboTypeFilter.Location = new System.Drawing.Point(647, 28);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new System.Drawing.Size(121, 27);
            this.cboTypeFilter.TabIndex = 14;
            this.cboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cboTypeFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(559, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "거래유형";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTotalPurchase);
            this.groupBox1.Controls.Add(this.lblTotalSales);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblNetProfit);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(79, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 168);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "전체 통계";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "총 매입금액";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(31, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "총 매출금액";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(31, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "순이익";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboProduct);
            this.groupBox2.Controls.Add(this.lblProdQty);
            this.groupBox2.Controls.Add(this.lblProdAmount);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(79, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 238);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상품통계";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(31, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "수량";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(31, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 24);
            this.label9.TabIndex = 10;
            this.label9.Text = "금액";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboCustomer);
            this.groupBox3.Controls.Add(this.lblCustCount);
            this.groupBox3.Controls.Add(this.lblCustAmount);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(445, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 238);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "거래처통계";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(31, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 24);
            this.label10.TabIndex = 11;
            this.label10.Text = "거래 횟수";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(31, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 24);
            this.label11.TabIndex = 12;
            this.label11.Text = "총 거래금액";
            // 
            // TradeStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 590);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTypeFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Name = "TradeStatisticsForm";
            this.Text = "TradeStatisticsForm";
            this.Load += new System.EventHandler(this.TradeStatisticsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalPurchase;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblNetProfit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblProdQty;
        private System.Windows.Forms.Label lblProdAmount;
        private System.Windows.Forms.Label lblCustCount;
        private System.Windows.Forms.Label lblCustAmount;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTypeFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}