namespace _2025_CS_Project
{
    partial class TradeSearchForm
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
            this.dgvTrade = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrade)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrade
            // 
            this.dgvTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< Updated upstream
            this.dgvTrade.Location = new System.Drawing.Point(93, 224);
            this.dgvTrade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvTrade.Name = "dgvTrade";
            this.dgvTrade.RowHeadersWidth = 62;
            this.dgvTrade.RowTemplate.Height = 23;
            this.dgvTrade.Size = new System.Drawing.Size(800, 387);
=======
            this.dgvTrade.Location = new System.Drawing.Point(74, 187);
            this.dgvTrade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvTrade.Name = "dgvTrade";
            this.dgvTrade.RowHeadersWidth = 62;
            this.dgvTrade.RowTemplate.Height = 23;
            this.dgvTrade.Size = new System.Drawing.Size(640, 322);
>>>>>>> Stashed changes
            this.dgvTrade.TabIndex = 0;
            this.dgvTrade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrade_CellDoubleClick);
            // 
            // dtpFrom
            // 
<<<<<<< Updated upstream
            this.dtpFrom.Location = new System.Drawing.Point(163, 68);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(331, 28);
=======
            this.dtpFrom.Location = new System.Drawing.Point(130, 57);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(266, 25);
>>>>>>> Stashed changes
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
<<<<<<< Updated upstream
            this.dtpTo.Location = new System.Drawing.Point(553, 68);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(331, 28);
=======
            this.dtpTo.Location = new System.Drawing.Point(442, 57);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(266, 25);
>>>>>>> Stashed changes
            this.dtpTo.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.btnSearch.Location = new System.Drawing.Point(1162, 18);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(151, 74);
=======
            this.btnSearch.Location = new System.Drawing.Point(733, 58);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 62);
>>>>>>> Stashed changes
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.btnClose.Location = new System.Drawing.Point(1180, 609);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 48);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
=======
            this.btnClose.Location = new System.Drawing.Point(733, 469);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "닫기";
>>>>>>> Stashed changes
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label1.Location = new System.Drawing.Point(88, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
=======
            this.label1.Location = new System.Drawing.Point(70, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
>>>>>>> Stashed changes
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label2.Location = new System.Drawing.Point(507, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
=======
            this.label2.Location = new System.Drawing.Point(406, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
>>>>>>> Stashed changes
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboWarehouse.FormattingEnabled = true;
<<<<<<< Updated upstream
            this.cboWarehouse.Location = new System.Drawing.Point(150, 150);
            this.cboWarehouse.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(199, 32);
=======
            this.cboWarehouse.Location = new System.Drawing.Point(120, 125);
            this.cboWarehouse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(160, 28);
>>>>>>> Stashed changes
            this.cboWarehouse.TabIndex = 7;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboCustomer.FormattingEnabled = true;
<<<<<<< Updated upstream
            this.cboCustomer.Location = new System.Drawing.Point(540, 150);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(199, 32);
=======
            this.cboCustomer.Location = new System.Drawing.Point(432, 125);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(160, 28);
>>>>>>> Stashed changes
            this.cboCustomer.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label3.Location = new System.Drawing.Point(88, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
=======
            this.label3.Location = new System.Drawing.Point(70, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
>>>>>>> Stashed changes
            this.label3.TabIndex = 9;
            this.label3.Text = "창고";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label4.Location = new System.Drawing.Point(458, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
=======
            this.label4.Location = new System.Drawing.Point(366, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
>>>>>>> Stashed changes
            this.label4.TabIndex = 10;
            this.label4.Text = "거래처";
            // 
            // TradeSearchForm
            // 
<<<<<<< Updated upstream
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 675);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 537);
>>>>>>> Stashed changes
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dgvTrade);
<<<<<<< Updated upstream
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
=======
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
>>>>>>> Stashed changes
            this.Name = "TradeSearchForm";
            this.Text = "TradeSearchForm";
            this.Load += new System.EventHandler(this.TradeSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrade;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}