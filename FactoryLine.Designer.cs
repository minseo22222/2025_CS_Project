namespace _2025_CS_Project
{
    partial class FactoryLine
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
            this.Production = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvFinishedGoods = new System.Windows.Forms.DataGridView();
            this.dgvBOM = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRawMaterials = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinishedGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).BeginInit();
            this.SuspendLayout();
            // 
            // Production
            // 
            this.Production.AutoSize = true;
            this.Production.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Production.Location = new System.Drawing.Point(42, 33);
            this.Production.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Production.Name = "Production";
            this.Production.Size = new System.Drawing.Size(101, 30);
            this.Production.TabIndex = 11;
            this.Production.Text = "생산관리";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(47, 81);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvFinishedGoods);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvBOM);
            this.splitContainer1.Size = new System.Drawing.Size(995, 547);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 12;
            // 
            // dgvFinishedGoods
            // 
            this.dgvFinishedGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinishedGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFinishedGoods.Location = new System.Drawing.Point(0, 0);
            this.dgvFinishedGoods.Name = "dgvFinishedGoods";
            this.dgvFinishedGoods.RowHeadersWidth = 51;
            this.dgvFinishedGoods.RowTemplate.Height = 27;
            this.dgvFinishedGoods.Size = new System.Drawing.Size(331, 547);
            this.dgvFinishedGoods.TabIndex = 0;
            this.dgvFinishedGoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFinishedGoods_CellClick);
            // 
            // dgvBOM
            // 
            this.dgvBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM.Location = new System.Drawing.Point(0, 0);
            this.dgvBOM.Name = "dgvBOM";
            this.dgvBOM.RowHeadersWidth = 51;
            this.dgvBOM.RowTemplate.Height = 27;
            this.dgvBOM.Size = new System.Drawing.Size(660, 547);
            this.dgvBOM.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(410, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "자재선택";
            // 
            // cboRawMaterials
            // 
            this.cboRawMaterials.FormattingEnabled = true;
            this.cboRawMaterials.Location = new System.Drawing.Point(517, 43);
            this.cboRawMaterials.Name = "cboRawMaterials";
            this.cboRawMaterials.Size = new System.Drawing.Size(121, 23);
            this.cboRawMaterials.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(644, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "필요수량";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(750, 41);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 25);
            this.txtQty.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(860, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 33);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(955, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FactoryLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Production);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRawMaterials);
            this.Name = "FactoryLine";
            this.Size = new System.Drawing.Size(1085, 695);
            this.Load += new System.EventHandler(this.ProductionPage_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinishedGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Production;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvFinishedGoods;
        private System.Windows.Forms.DataGridView dgvBOM;
        private System.Windows.Forms.ComboBox cboRawMaterials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtQty;
    }
}
