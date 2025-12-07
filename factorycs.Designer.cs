namespace _2025_CS_Project
{
    partial class factorycs
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFinalRegister = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.StaffeS = new System.Windows.Forms.Button();
            this.txtGood = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numDefect = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpProdDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.numMatQty = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboMaterial = new System.Windows.Forms.ComboBox();
            this.Factory = new System.Windows.Forms.Label();
            this.ProductionDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMatQty)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(658, 354);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 50);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.Location = new System.Drawing.Point(748, 354);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 50);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvHistory
            // 
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(15, 27);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 27;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(978, 212);
            this.dgvHistory.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvHistory);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(38, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1013, 257);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "생산 이력 현황";
            // 
            // btnFinalRegister
            // 
            this.btnFinalRegister.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFinalRegister.Location = new System.Drawing.Point(838, 354);
            this.btnFinalRegister.Name = "btnFinalRegister";
            this.btnFinalRegister.Size = new System.Drawing.Size(213, 50);
            this.btnFinalRegister.TabIndex = 27;
            this.btnFinalRegister.Text = "생산 실적 최종 등록";
            this.btnFinalRegister.UseVisualStyleBackColor = true;
            this.btnFinalRegister.Click += new System.EventHandler(this.btnFinalRegister_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboProduct);
            this.groupBox1.Controls.Add(this.StaffeS);
            this.groupBox1.Controls.Add(this.txtGood);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numDefect);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpProdDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtManager);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(38, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 284);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "완제품 생산 정보";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(102, 34);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(152, 26);
            this.cboProduct.TabIndex = 13;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.CboProduct_SelectedIndexChanged);
            // 
            // StaffeS
            // 
            this.StaffeS.Location = new System.Drawing.Point(260, 75);
            this.StaffeS.Name = "StaffeS";
            this.StaffeS.Size = new System.Drawing.Size(121, 32);
            this.StaffeS.TabIndex = 12;
            this.StaffeS.Text = "담당자등록";
            this.StaffeS.UseVisualStyleBackColor = true;
            this.StaffeS.Click += new System.EventHandler(this.StaffeS_Click);
            // 
            // txtGood
            // 
            this.txtGood.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtGood.Location = new System.Drawing.Point(135, 242);
            this.txtGood.Name = "txtGood";
            this.txtGood.ReadOnly = true;
            this.txtGood.Size = new System.Drawing.Size(152, 28);
            this.txtGood.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "양품(완제품)";
            // 
            // numDefect
            // 
            this.numDefect.Location = new System.Drawing.Point(354, 193);
            this.numDefect.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDefect.Name = "numDefect";
            this.numDefect.Size = new System.Drawing.Size(120, 28);
            this.numDefect.TabIndex = 9;
            this.numDefect.ValueChanged += new System.EventHandler(this.RecalculateMaterials);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "- 불량 수량";
            // 
            // numTotal
            // 
            this.numTotal.Location = new System.Drawing.Point(109, 193);
            this.numTotal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTotal.Name = "numTotal";
            this.numTotal.Size = new System.Drawing.Size(120, 28);
            this.numTotal.TabIndex = 7;
            this.numTotal.ValueChanged += new System.EventHandler(this.RecalculateMaterials);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "총 생산량";
            // 
            // dtpProdDate
            // 
            this.dtpProdDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpProdDate.Location = new System.Drawing.Point(102, 116);
            this.dtpProdDate.Name = "dtpProdDate";
            this.dtpProdDate.Size = new System.Drawing.Size(152, 28);
            this.dtpProdDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "생산일자";
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(102, 75);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(152, 28);
            this.txtManager.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "담당자";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "완제품명";
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.AllowUserToAddRows = false;
            this.dgvMaterials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(15, 118);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.RowHeadersWidth = 51;
            this.dgvMaterials.RowTemplate.Height = 27;
            this.dgvMaterials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterials.Size = new System.Drawing.Size(417, 150);
            this.dgvMaterials.TabIndex = 16;
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(260, 86);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(105, 26);
            this.btnAddMaterial.TabIndex = 15;
            this.btnAddMaterial.Text = "자재 추가";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // numMatQty
            // 
            this.numMatQty.Location = new System.Drawing.Point(102, 84);
            this.numMatQty.Name = "numMatQty";
            this.numMatQty.Size = new System.Drawing.Size(152, 28);
            this.numMatQty.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "투입수량";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "원자재명";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(568, 354);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 50);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboMaterial);
            this.groupBox2.Controls.Add(this.dgvMaterials);
            this.groupBox2.Controls.Add(this.btnAddMaterial);
            this.groupBox2.Controls.Add(this.numMatQty);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(599, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 284);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "투입 원자재 목록";
            // 
            // cboMaterial
            // 
            this.cboMaterial.FormattingEnabled = true;
            this.cboMaterial.Location = new System.Drawing.Point(102, 39);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(152, 26);
            this.cboMaterial.TabIndex = 17;
            // 
            // Factory
            // 
            this.Factory.AutoSize = true;
            this.Factory.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Factory.Location = new System.Drawing.Point(33, -8);
            this.Factory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Factory.Name = "Factory";
            this.Factory.Size = new System.Drawing.Size(101, 30);
            this.Factory.TabIndex = 24;
            this.Factory.Text = "생산관리";
            // 
            // ProductionDetail
            // 
            this.ProductionDetail.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ProductionDetail.Location = new System.Drawing.Point(38, 360);
            this.ProductionDetail.Name = "ProductionDetail";
            this.ProductionDetail.Size = new System.Drawing.Size(145, 39);
            this.ProductionDetail.TabIndex = 32;
            this.ProductionDetail.Text = "기록생산보기";
            this.ProductionDetail.UseVisualStyleBackColor = true;
            this.ProductionDetail.Click += new System.EventHandler(this.ProductionDetail_Click);
            // 
            // factorycs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ProductionDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnFinalRegister);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Factory);
            this.Name = "factorycs";
            this.Size = new System.Drawing.Size(1043, 633);
            this.Load += new System.EventHandler(this.Production_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMatQty)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFinalRegister;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StaffeS;
        private System.Windows.Forms.TextBox txtGood;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numDefect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpProdDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.NumericUpDown numMatQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Factory;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.ComboBox cboMaterial;
        private System.Windows.Forms.Button ProductionDetail;
    }
}
