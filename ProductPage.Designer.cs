namespace _2025_CS_Project
{
    partial class ProductPage
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SortLow = new System.Windows.Forms.RadioButton();
            this.SortHigh = new System.Windows.Forms.RadioButton();
            this.SortName = new System.Windows.Forms.RadioButton();
            this.SortNum = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.ProductType = new System.Windows.Forms.ComboBox();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DBGrid = new System.Windows.Forms.DataGridView();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenDBBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AppendBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ProductType);
            this.groupBox2.Controls.Add(this.UpdateBtn);
            this.groupBox2.Controls.Add(this.DBGrid);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtProductNum);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.OpenDBBtn);
            this.groupBox2.Controls.Add(this.DeleteBtn);
            this.groupBox2.Controls.Add(this.AppendBtn);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(51, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(1262, 926);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상품등록";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchText);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Controls.Add(this.SortLow);
            this.groupBox1.Controls.Add(this.SortHigh);
            this.groupBox1.Controls.Add(this.SortName);
            this.groupBox1.Controls.Add(this.SortNum);
            this.groupBox1.Location = new System.Drawing.Point(58, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1121, 144);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "정렬";
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(36, 92);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(616, 40);
            this.SearchText.TabIndex = 5;
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_TextChanged);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(686, 86);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(161, 46);
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "검색";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SortLow
            // 
            this.SortLow.AutoSize = true;
            this.SortLow.Location = new System.Drawing.Point(386, 48);
            this.SortLow.Name = "SortLow";
            this.SortLow.Size = new System.Drawing.Size(80, 33);
            this.SortLow.TabIndex = 3;
            this.SortLow.Text = "저가";
            this.SortLow.UseVisualStyleBackColor = true;
            this.SortLow.CheckedChanged += new System.EventHandler(this.SortLow_CheckedChanged);
            // 
            // SortHigh
            // 
            this.SortHigh.AutoSize = true;
            this.SortHigh.Location = new System.Drawing.Point(271, 48);
            this.SortHigh.Name = "SortHigh";
            this.SortHigh.Size = new System.Drawing.Size(80, 33);
            this.SortHigh.TabIndex = 2;
            this.SortHigh.Text = "고가";
            this.SortHigh.UseVisualStyleBackColor = true;
            this.SortHigh.CheckedChanged += new System.EventHandler(this.SortHigh_CheckedChanged);
            // 
            // SortName
            // 
            this.SortName.AutoSize = true;
            this.SortName.Location = new System.Drawing.Point(155, 48);
            this.SortName.Name = "SortName";
            this.SortName.Size = new System.Drawing.Size(80, 33);
            this.SortName.TabIndex = 1;
            this.SortName.Text = "이름";
            this.SortName.UseVisualStyleBackColor = true;
            this.SortName.CheckedChanged += new System.EventHandler(this.SortName_CheckedChanged);
            // 
            // SortNum
            // 
            this.SortNum.AutoSize = true;
            this.SortNum.Location = new System.Drawing.Point(36, 48);
            this.SortNum.Name = "SortNum";
            this.SortNum.Size = new System.Drawing.Size(80, 33);
            this.SortNum.TabIndex = 0;
            this.SortNum.Text = "번호";
            this.SortNum.UseVisualStyleBackColor = true;
            this.SortNum.CheckedChanged += new System.EventHandler(this.SortNum_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(469, 249);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 29);
            this.label4.TabIndex = 21;
            this.label4.Text = "구분";
            // 
            // ProductType
            // 
            this.ProductType.FormattingEnabled = true;
            this.ProductType.Items.AddRange(new object[] {
            "원자재",
            "완제품"});
            this.ProductType.Location = new System.Drawing.Point(534, 246);
            this.ProductType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ProductType.Name = "ProductType";
            this.ProductType.Size = new System.Drawing.Size(104, 37);
            this.ProductType.TabIndex = 20;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateBtn.Location = new System.Drawing.Point(829, 84);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(125, 48);
            this.UpdateBtn.TabIndex = 19;
            this.UpdateBtn.Text = "변경";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DBGrid
            // 
            this.DBGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DBGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGrid.Location = new System.Drawing.Point(57, 509);
            this.DBGrid.Name = "DBGrid";
            this.DBGrid.RowHeadersWidth = 62;
            this.DBGrid.RowTemplate.Height = 30;
            this.DBGrid.Size = new System.Drawing.Size(1121, 417);
            this.DBGrid.TabIndex = 4;
            this.DBGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBGrid_CellClick);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(170, 243);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(279, 40);
            this.txtPrice.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(52, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "단가";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(170, 161);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(279, 40);
            this.txtProductName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(52, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "상품명";
            // 
            // txtProductNum
            // 
            this.txtProductNum.Location = new System.Drawing.Point(170, 84);
            this.txtProductNum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtProductNum.Name = "txtProductNum";
            this.txtProductNum.Size = new System.Drawing.Size(279, 40);
            this.txtProductNum.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(52, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "상품번호";
            // 
            // OpenDBBtn
            // 
            this.OpenDBBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenDBBtn.Location = new System.Drawing.Point(838, 156);
            this.OpenDBBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.OpenDBBtn.Name = "OpenDBBtn";
            this.OpenDBBtn.Size = new System.Drawing.Size(280, 48);
            this.OpenDBBtn.TabIndex = 7;
            this.OpenDBBtn.Text = "조회";
            this.OpenDBBtn.UseVisualStyleBackColor = true;
            this.OpenDBBtn.Click += new System.EventHandler(this.OpenDBBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteBtn.Location = new System.Drawing.Point(993, 84);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(125, 48);
            this.DeleteBtn.TabIndex = 6;
            this.DeleteBtn.Text = "삭제";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // AppendBtn
            // 
            this.AppendBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AppendBtn.Location = new System.Drawing.Point(671, 84);
            this.AppendBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AppendBtn.Name = "AppendBtn";
            this.AppendBtn.Size = new System.Drawing.Size(125, 48);
            this.AppendBtn.TabIndex = 4;
            this.AppendBtn.Text = "신규";
            this.AppendBtn.UseVisualStyleBackColor = true;
            this.AppendBtn.Click += new System.EventHandler(this.AppendBtn_Click);
            // 
            // ProductPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "ProductPage";
            this.Size = new System.Drawing.Size(1573, 984);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button OpenDBBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AppendBtn;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DBGrid;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ProductType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SortLow;
        private System.Windows.Forms.RadioButton SortHigh;
        private System.Windows.Forms.RadioButton SortName;
        private System.Windows.Forms.RadioButton SortNum;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox SearchText;
    }
}
