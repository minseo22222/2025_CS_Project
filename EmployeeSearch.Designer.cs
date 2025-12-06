namespace _2025_CS_Project
{
    partial class EmployeeSearch
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
            this.DBGrids = new System.Windows.Forms.DataGridView();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.employee = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.chkResigned = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrids)).BeginInit();
            this.SuspendLayout();
            // 
            // DBGrids
            // 
            this.DBGrids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGrids.Location = new System.Drawing.Point(35, 90);
            this.DBGrids.Name = "DBGrids";
            this.DBGrids.RowHeadersWidth = 51;
            this.DBGrids.RowTemplate.Height = 27;
            this.DBGrids.Size = new System.Drawing.Size(893, 451);
            this.DBGrids.TabIndex = 1;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "이름",
            "직급",
            "부서",
            "사원번호"});
            this.cboCategory.Location = new System.Drawing.Point(509, 51);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 23);
            this.cboCategory.TabIndex = 2;
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Location = new System.Drawing.Point(636, 49);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(199, 25);
            this.txtSearchKeyword.TabIndex = 3;
            this.txtSearchKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchKeyword_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(861, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 38);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // employee
            // 
            this.employee.AutoSize = true;
            this.employee.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.employee.Location = new System.Drawing.Point(30, 29);
            this.employee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(145, 30);
            this.employee.TabIndex = 11;
            this.employee.Text = "직원관리상세";
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFind.Location = new System.Drawing.Point(841, 39);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(87, 45);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "검색";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.Location = new System.Drawing.Point(416, 39);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 45);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalCount.Location = new System.Drawing.Point(32, 568);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(116, 17);
            this.lblTotalCount.TabIndex = 14;
            this.lblTotalCount.Text = "검색된 인원 :";
            // 
            // chkResigned
            // 
            this.chkResigned.AutoSize = true;
            this.chkResigned.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkResigned.Location = new System.Drawing.Point(259, 51);
            this.chkResigned.Name = "chkResigned";
            this.chkResigned.Size = new System.Drawing.Size(151, 22);
            this.chkResigned.TabIndex = 15;
            this.chkResigned.Text = "퇴사자만 보기";
            this.chkResigned.UseVisualStyleBackColor = true;
            // 
            // EmployeeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 609);
            this.Controls.Add(this.chkResigned);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.employee);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSearchKeyword);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.DBGrids);
            this.Name = "EmployeeSearch";
            this.Text = "EmployeeSearch";
            this.Load += new System.EventHandler(this.EmployeeSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBGrids)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DBGrids;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label employee;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.CheckBox chkResigned;
    }
}