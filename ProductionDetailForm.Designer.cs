namespace _2025_CS_Project
{
    partial class ProductionDetailForm
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
            this.txtDetailProdID = new System.Windows.Forms.TextBox();
            this.txtDetailProductName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDetailTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetailDefect = new System.Windows.Forms.TextBox();
            this.txtDetailManager = new System.Windows.Forms.TextBox();
            this.dgvDetailMaterials = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetailGood = new System.Windows.Forms.TextBox();
            this.txtDetailDate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAllProductions = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearchField = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailMaterials)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProductions)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDetailProdID
            // 
            this.txtDetailProdID.Location = new System.Drawing.Point(102, 36);
            this.txtDetailProdID.Name = "txtDetailProdID";
            this.txtDetailProdID.ReadOnly = true;
            this.txtDetailProdID.Size = new System.Drawing.Size(154, 28);
            this.txtDetailProdID.TabIndex = 1;
            // 
            // txtDetailProductName
            // 
            this.txtDetailProductName.Location = new System.Drawing.Point(102, 76);
            this.txtDetailProductName.Name = "txtDetailProductName";
            this.txtDetailProductName.ReadOnly = true;
            this.txtDetailProductName.Size = new System.Drawing.Size(154, 28);
            this.txtDetailProductName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(355, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "불량";
            // 
            // txtDetailTotal
            // 
            this.txtDetailTotal.Location = new System.Drawing.Point(407, 36);
            this.txtDetailTotal.Name = "txtDetailTotal";
            this.txtDetailTotal.ReadOnly = true;
            this.txtDetailTotal.Size = new System.Drawing.Size(154, 28);
            this.txtDetailTotal.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "생산번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "완제품명";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(317, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "양품수량";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(336, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "총생산";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(30, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "담당자";
            // 
            // txtDetailDefect
            // 
            this.txtDetailDefect.Location = new System.Drawing.Point(407, 76);
            this.txtDetailDefect.Name = "txtDetailDefect";
            this.txtDetailDefect.ReadOnly = true;
            this.txtDetailDefect.Size = new System.Drawing.Size(154, 28);
            this.txtDetailDefect.TabIndex = 12;
            // 
            // txtDetailManager
            // 
            this.txtDetailManager.Location = new System.Drawing.Point(101, 118);
            this.txtDetailManager.Name = "txtDetailManager";
            this.txtDetailManager.ReadOnly = true;
            this.txtDetailManager.Size = new System.Drawing.Size(154, 28);
            this.txtDetailManager.TabIndex = 5;
            // 
            // dgvDetailMaterials
            // 
            this.dgvDetailMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailMaterials.Location = new System.Drawing.Point(15, 203);
            this.dgvDetailMaterials.Name = "dgvDetailMaterials";
            this.dgvDetailMaterials.ReadOnly = true;
            this.dgvDetailMaterials.RowHeadersWidth = 51;
            this.dgvDetailMaterials.RowTemplate.Height = 27;
            this.dgvDetailMaterials.Size = new System.Drawing.Size(721, 201);
            this.dgvDetailMaterials.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(12, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "생산일자";
            // 
            // txtDetailGood
            // 
            this.txtDetailGood.Location = new System.Drawing.Point(407, 118);
            this.txtDetailGood.Name = "txtDetailGood";
            this.txtDetailGood.ReadOnly = true;
            this.txtDetailGood.Size = new System.Drawing.Size(154, 28);
            this.txtDetailGood.TabIndex = 13;
            // 
            // txtDetailDate
            // 
            this.txtDetailDate.Location = new System.Drawing.Point(101, 163);
            this.txtDetailDate.Name = "txtDetailDate";
            this.txtDetailDate.ReadOnly = true;
            this.txtDetailDate.Size = new System.Drawing.Size(154, 28);
            this.txtDetailDate.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDetailDate);
            this.groupBox1.Controls.Add(this.txtDetailProductName);
            this.groupBox1.Controls.Add(this.txtDetailGood);
            this.groupBox1.Controls.Add(this.txtDetailProdID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvDetailMaterials);
            this.groupBox1.Controls.Add(this.txtDetailManager);
            this.groupBox1.Controls.Add(this.txtDetailDefect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDetailTotal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(33, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 427);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "생산상세기록";
            // 
            // dgvAllProductions
            // 
            this.dgvAllProductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllProductions.Location = new System.Drawing.Point(33, 96);
            this.dgvAllProductions.Name = "dgvAllProductions";
            this.dgvAllProductions.RowHeadersWidth = 51;
            this.dgvAllProductions.RowTemplate.Height = 27;
            this.dgvAllProductions.Size = new System.Drawing.Size(757, 150);
            this.dgvAllProductions.TabIndex = 15;
            this.dgvAllProductions.SelectionChanged += new System.EventHandler(this.DgvAllProductions_SelectionChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(693, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 33);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(488, 63);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(199, 25);
            this.txtSearch.TabIndex = 18;
            // 
            // cboSearchField
            // 
            this.cboSearchField.FormattingEnabled = true;
            this.cboSearchField.Items.AddRange(new object[] {
            "이름",
            "직급",
            "부서",
            "사원번호"});
            this.cboSearchField.Location = new System.Drawing.Point(361, 65);
            this.cboSearchField.Name = "cboSearchField";
            this.cboSearchField.Size = new System.Drawing.Size(121, 23);
            this.cboSearchField.TabIndex = 17;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.Location = new System.Drawing.Point(268, 57);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 33);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ProductionDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 720);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cboSearchField);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAllProductions);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductionDetailForm";
            this.Text = "ProductionDetailForm";
            this.Load += new System.EventHandler(this.ProdDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailMaterials)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProductions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDetailProdID;
        private System.Windows.Forms.TextBox txtDetailProductName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDetailTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetailDefect;
        private System.Windows.Forms.TextBox txtDetailManager;
        private System.Windows.Forms.DataGridView dgvDetailMaterials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetailGood;
        private System.Windows.Forms.TextBox txtDetailDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAllProductions;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearchField;
        private System.Windows.Forms.Button btnReset;
    }
}