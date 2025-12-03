namespace _2025_CS_Project
{
    partial class TradePage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWarehouseSearch = new System.Windows.Forms.Button();
            this.btnStaffSearch = new System.Windows.Forms.Button();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTradeDate = new System.Windows.Forms.DateTimePicker();
            this.cboTradeType = new System.Windows.Forms.ComboBox();
            this.txtTradeNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductAdd = new System.Windows.Forms.Button();
            this.ProductDel = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.colProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStaffSearch);
            this.groupBox1.Controls.Add(this.btnCustomerSearch);
            this.groupBox1.Controls.Add(this.txtStaff);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.cboPayment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpTradeDate);
            this.groupBox1.Controls.Add(this.cboTradeType);
            this.groupBox1.Controls.Add(this.txtTradeNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(67, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "매매관리";
            // 
            // btnWarehouseSearch
            // 
            this.btnWarehouseSearch.Location = new System.Drawing.Point(257, 325);
            this.btnWarehouseSearch.Name = "btnWarehouseSearch";
            this.btnWarehouseSearch.Size = new System.Drawing.Size(79, 31);
            this.btnWarehouseSearch.TabIndex = 23;
            this.btnWarehouseSearch.Text = "Search";
            this.btnWarehouseSearch.UseVisualStyleBackColor = true;
            this.btnWarehouseSearch.Click += new System.EventHandler(this.btnWarehouseSearch_Click);
            // 
            // btnStaffSearch
            // 
            this.btnStaffSearch.Location = new System.Drawing.Point(607, 47);
            this.btnStaffSearch.Name = "btnStaffSearch";
            this.btnStaffSearch.Size = new System.Drawing.Size(79, 31);
            this.btnStaffSearch.TabIndex = 22;
            this.btnStaffSearch.Text = "Search";
            this.btnStaffSearch.UseVisualStyleBackColor = true;
            this.btnStaffSearch.Click += new System.EventHandler(this.btnStaffSearch_Click);
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Location = new System.Drawing.Point(258, 151);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(79, 31);
            this.btnCustomerSearch.TabIndex = 21;
            this.btnCustomerSearch.Text = "Search";
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.Location = new System.Drawing.Point(106, 328);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(145, 21);
            this.txtWarehouse.TabIndex = 20;
            // 
            // txtStaff
            // 
            this.txtStaff.Location = new System.Drawing.Point(443, 47);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(145, 30);
            this.txtStaff.TabIndex = 19;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(107, 151);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(145, 30);
            this.txtCustomer.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(373, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "총금액";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(444, 122);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(169, 30);
            this.txtTotalAmount.TabIndex = 16;
            // 
            // cboPayment
            // 
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Items.AddRange(new object[] {
            "계좌이체",
            "카드",
            "현금",
            ""});
            this.cboPayment.Location = new System.Drawing.Point(444, 88);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(121, 28);
            this.cboPayment.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(373, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "결제수단";
            // 
            // dtpTradeDate
            // 
            this.dtpTradeDate.CustomFormat = "yyyy년 MM월 dd일";
            this.dtpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTradeDate.Location = new System.Drawing.Point(107, 81);
            this.dtpTradeDate.Name = "dtpTradeDate";
            this.dtpTradeDate.Size = new System.Drawing.Size(200, 30);
            this.dtpTradeDate.TabIndex = 12;
            // 
            // cboTradeType
            // 
            this.cboTradeType.FormattingEnabled = true;
            this.cboTradeType.Items.AddRange(new object[] {
            "매입",
            "매출"});
            this.cboTradeType.Location = new System.Drawing.Point(107, 117);
            this.cboTradeType.Name = "cboTradeType";
            this.cboTradeType.Size = new System.Drawing.Size(64, 28);
            this.cboTradeType.TabIndex = 10;
            // 
            // txtTradeNo
            // 
            this.txtTradeNo.Location = new System.Drawing.Point(107, 45);
            this.txtTradeNo.Name = "txtTradeNo";
            this.txtTradeNo.ReadOnly = true;
            this.txtTradeNo.Size = new System.Drawing.Size(169, 30);
            this.txtTradeNo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(63, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "창고";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(50, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "거래처";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(387, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "담당자";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(36, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "매매유형";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(36, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "거래일자";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "거래번호";
            // 
            // ProductAdd
            // 
            this.ProductAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProductAdd.Location = new System.Drawing.Point(240, 269);
            this.ProductAdd.Name = "ProductAdd";
            this.ProductAdd.Size = new System.Drawing.Size(75, 32);
            this.ProductAdd.TabIndex = 2;
            this.ProductAdd.Text = "상품추가";
            this.ProductAdd.UseVisualStyleBackColor = true;
            this.ProductAdd.Click += new System.EventHandler(this.ProductAdd_Click);
            // 
            // ProductDel
            // 
            this.ProductDel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProductDel.Location = new System.Drawing.Point(321, 269);
            this.ProductDel.Name = "ProductDel";
            this.ProductDel.Size = new System.Drawing.Size(75, 32);
            this.ProductDel.TabIndex = 3;
            this.ProductDel.Text = "상품삭제";
            this.ProductDel.UseVisualStyleBackColor = true;
            this.ProductDel.Click += new System.EventHandler(this.ProductDel_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClearBtn.Location = new System.Drawing.Point(114, 26);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 32);
            this.ClearBtn.TabIndex = 4;
            this.ClearBtn.Text = "초기화";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveBtn.Location = new System.Drawing.Point(401, 269);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 32);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "저장";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchBtn.Location = new System.Drawing.Point(749, 36);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 32);
            this.SearchBtn.TabIndex = 7;
            this.SearchBtn.Text = "조회";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.Controls.Add(this.ProductDel);
            this.groupBox2.Controls.Add(this.ProductAdd);
            this.groupBox2.Controls.Add(this.SaveBtn);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(67, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(757, 321);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "매매상세";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProduct,
            this.colProductID,
            this.colQty,
            this.colUnitPrice,
            this.colAmount,
            this.colStockQty});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDetail.Location = new System.Drawing.Point(3, 25);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(751, 224);
            this.dgvDetail.TabIndex = 8;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
            this.dgvDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetail_CurrentCellDirtyStateChanged);
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "상품코드";
            this.colProduct.Name = "colProduct";
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "상품ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "수량";
            this.colQty.Name = "colQty";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "단가";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "금액";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colStockQty
            // 
            this.colStockQty.HeaderText = "재고수량";
            this.colStockQty.Name = "colStockQty";
            this.colStockQty.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(26, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "매매등록";
            // 
            // TradePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnWarehouseSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "TradePage";
            this.Size = new System.Drawing.Size(927, 656);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTradeType;
        private System.Windows.Forms.TextBox txtTradeNo;
        private System.Windows.Forms.DateTimePicker dtpTradeDate;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ProductAdd;
        private System.Windows.Forms.Button ProductDel;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnWarehouseSearch;
        private System.Windows.Forms.Button btnStaffSearch;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.TextBox txtWarehouse;
        private System.Windows.Forms.TextBox txtStaff;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockQty;
    }
}
