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
            this.btnStaffSearch = new System.Windows.Forms.Button();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTradeDate = new System.Windows.Forms.DateTimePicker();
            this.cboTradeType = new System.Windows.Forms.ComboBox();
            this.txtTradeNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWarehouseSearch = new System.Windows.Forms.Button();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ProductAdd = new System.Windows.Forms.Button();
            this.ProductDel = new System.Windows.Forms.Button();
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
            this.statistics = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.ClearBtn);
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
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.groupBox1.Location = new System.Drawing.Point(42, 122);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1261, 330);
=======
            this.groupBox1.Location = new System.Drawing.Point(34, 102);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1009, 275);
>>>>>>> Stashed changes
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "매매관리";
            // 
            // btnStaffSearch
            // 
<<<<<<< Updated upstream
            this.btnStaffSearch.Location = new System.Drawing.Point(1015, 67);
            this.btnStaffSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnStaffSearch.Name = "btnStaffSearch";
            this.btnStaffSearch.Size = new System.Drawing.Size(142, 47);
=======
            this.btnStaffSearch.Location = new System.Drawing.Point(812, 56);
            this.btnStaffSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStaffSearch.Name = "btnStaffSearch";
            this.btnStaffSearch.Size = new System.Drawing.Size(114, 39);
>>>>>>> Stashed changes
            this.btnStaffSearch.TabIndex = 22;
            this.btnStaffSearch.Text = "담당자등록";
            this.btnStaffSearch.UseVisualStyleBackColor = true;
            this.btnStaffSearch.Click += new System.EventHandler(this.btnStaffSearch_Click);
            // 
            // btnCustomerSearch
            // 
<<<<<<< Updated upstream
            this.btnCustomerSearch.Location = new System.Drawing.Point(430, 227);
            this.btnCustomerSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(140, 47);
=======
            this.btnCustomerSearch.Location = new System.Drawing.Point(344, 189);
            this.btnCustomerSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(112, 39);
>>>>>>> Stashed changes
            this.btnCustomerSearch.TabIndex = 21;
            this.btnCustomerSearch.Text = "거래처등록";
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // txtStaff
            // 
<<<<<<< Updated upstream
            this.txtStaff.Location = new System.Drawing.Point(739, 71);
            this.txtStaff.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(239, 42);
=======
            this.txtStaff.Location = new System.Drawing.Point(591, 59);
            this.txtStaff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(192, 36);
>>>>>>> Stashed changes
            this.txtStaff.TabIndex = 19;
            // 
            // txtCustomer
            // 
<<<<<<< Updated upstream
            this.txtCustomer.Location = new System.Drawing.Point(179, 227);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(239, 42);
=======
            this.txtCustomer.Location = new System.Drawing.Point(143, 189);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(192, 36);
>>>>>>> Stashed changes
            this.txtCustomer.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label7.Location = new System.Drawing.Point(621, 190);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 29);
=======
            this.label7.Location = new System.Drawing.Point(497, 158);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 24);
>>>>>>> Stashed changes
            this.label7.TabIndex = 17;
            this.label7.Text = "총금액";
            // 
            // txtTotalAmount
            // 
<<<<<<< Updated upstream
            this.txtTotalAmount.Location = new System.Drawing.Point(740, 182);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(279, 42);
=======
            this.txtTotalAmount.Location = new System.Drawing.Point(592, 152);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(191, 36);
>>>>>>> Stashed changes
            this.txtTotalAmount.TabIndex = 16;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.ClearBtn.Location = new System.Drawing.Point(1126, 272);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(125, 48);
=======
            this.ClearBtn.Location = new System.Drawing.Point(901, 227);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(100, 40);
>>>>>>> Stashed changes
            this.ClearBtn.TabIndex = 4;
            this.ClearBtn.Text = "거래초기화";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // cboPayment
            // 
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Items.AddRange(new object[] {
            "계좌이체",
            "카드",
            "현금",
            ""});
<<<<<<< Updated upstream
            this.cboPayment.Location = new System.Drawing.Point(740, 132);
            this.cboPayment.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(199, 38);
=======
            this.cboPayment.Location = new System.Drawing.Point(592, 110);
            this.cboPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(191, 33);
>>>>>>> Stashed changes
            this.cboPayment.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label9.Location = new System.Drawing.Point(621, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 29);
=======
            this.label9.Location = new System.Drawing.Point(497, 115);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 24);
>>>>>>> Stashed changes
            this.label9.TabIndex = 14;
            this.label9.Text = "결제수단";
            // 
            // dtpTradeDate
            // 
            this.dtpTradeDate.CustomFormat = "yyyy년 MM월 dd일";
            this.dtpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
<<<<<<< Updated upstream
            this.dtpTradeDate.Location = new System.Drawing.Point(179, 121);
            this.dtpTradeDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpTradeDate.Name = "dtpTradeDate";
            this.dtpTradeDate.Size = new System.Drawing.Size(330, 42);
=======
            this.dtpTradeDate.Location = new System.Drawing.Point(143, 101);
            this.dtpTradeDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTradeDate.Name = "dtpTradeDate";
            this.dtpTradeDate.Size = new System.Drawing.Size(265, 36);
>>>>>>> Stashed changes
            this.dtpTradeDate.TabIndex = 12;
            // 
            // cboTradeType
            // 
            this.cboTradeType.FormattingEnabled = true;
            this.cboTradeType.Items.AddRange(new object[] {
            "매입",
            "매출"});
<<<<<<< Updated upstream
            this.cboTradeType.Location = new System.Drawing.Point(179, 175);
            this.cboTradeType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboTradeType.Name = "cboTradeType";
            this.cboTradeType.Size = new System.Drawing.Size(104, 38);
=======
            this.cboTradeType.Location = new System.Drawing.Point(143, 146);
            this.cboTradeType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTradeType.Name = "cboTradeType";
            this.cboTradeType.Size = new System.Drawing.Size(84, 33);
>>>>>>> Stashed changes
            this.cboTradeType.TabIndex = 10;
            // 
            // txtTradeNo
            // 
<<<<<<< Updated upstream
            this.txtTradeNo.Location = new System.Drawing.Point(179, 67);
            this.txtTradeNo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTradeNo.Name = "txtTradeNo";
            this.txtTradeNo.ReadOnly = true;
            this.txtTradeNo.Size = new System.Drawing.Size(279, 42);
=======
            this.txtTradeNo.Location = new System.Drawing.Point(143, 56);
            this.txtTradeNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTradeNo.Name = "txtTradeNo";
            this.txtTradeNo.ReadOnly = true;
            this.txtTradeNo.Size = new System.Drawing.Size(265, 36);
>>>>>>> Stashed changes
            this.txtTradeNo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label5.Location = new System.Drawing.Point(84, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 29);
=======
            this.label5.Location = new System.Drawing.Point(67, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
>>>>>>> Stashed changes
            this.label5.TabIndex = 4;
            this.label5.Text = "거래처";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label4.Location = new System.Drawing.Point(645, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 29);
=======
            this.label4.Location = new System.Drawing.Point(516, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
>>>>>>> Stashed changes
            this.label4.TabIndex = 3;
            this.label4.Text = "담당자";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label3.Location = new System.Drawing.Point(60, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 29);
=======
            this.label3.Location = new System.Drawing.Point(48, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
>>>>>>> Stashed changes
            this.label3.TabIndex = 2;
            this.label3.Text = "매매유형";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label2.Location = new System.Drawing.Point(60, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 29);
=======
            this.label2.Location = new System.Drawing.Point(48, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
>>>>>>> Stashed changes
            this.label2.TabIndex = 1;
            this.label2.Text = "거래일자";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label1.Location = new System.Drawing.Point(60, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 29);
=======
            this.label1.Location = new System.Drawing.Point(48, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
>>>>>>> Stashed changes
            this.label1.TabIndex = 0;
            this.label1.Text = "거래번호";
            // 
            // btnWarehouseSearch
            // 
<<<<<<< Updated upstream
            this.btnWarehouseSearch.Location = new System.Drawing.Point(370, 476);
            this.btnWarehouseSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnWarehouseSearch.Name = "btnWarehouseSearch";
            this.btnWarehouseSearch.Size = new System.Drawing.Size(131, 47);
=======
            this.btnWarehouseSearch.Location = new System.Drawing.Point(296, 397);
            this.btnWarehouseSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWarehouseSearch.Name = "btnWarehouseSearch";
            this.btnWarehouseSearch.Size = new System.Drawing.Size(105, 39);
>>>>>>> Stashed changes
            this.btnWarehouseSearch.TabIndex = 23;
            this.btnWarehouseSearch.Text = "창고찾기";
            this.btnWarehouseSearch.UseVisualStyleBackColor = true;
            this.btnWarehouseSearch.Click += new System.EventHandler(this.btnWarehouseSearch_Click);
            // 
            // txtWarehouse
            // 
<<<<<<< Updated upstream
            this.txtWarehouse.Location = new System.Drawing.Point(116, 481);
            this.txtWarehouse.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(239, 28);
=======
            this.txtWarehouse.Location = new System.Drawing.Point(93, 401);
            this.txtWarehouse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(192, 25);
>>>>>>> Stashed changes
            this.txtWarehouse.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label6.Location = new System.Drawing.Point(45, 481);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 29);
=======
            this.label6.Location = new System.Drawing.Point(36, 401);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 24);
>>>>>>> Stashed changes
            this.label6.TabIndex = 5;
            this.label6.Text = "창고";
            // 
            // ProductAdd
            // 
            this.ProductAdd.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.ProductAdd.Location = new System.Drawing.Point(400, 384);
            this.ProductAdd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ProductAdd.Name = "ProductAdd";
            this.ProductAdd.Size = new System.Drawing.Size(125, 48);
=======
            this.ProductAdd.Location = new System.Drawing.Point(320, 320);
            this.ProductAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProductAdd.Name = "ProductAdd";
            this.ProductAdd.Size = new System.Drawing.Size(100, 40);
>>>>>>> Stashed changes
            this.ProductAdd.TabIndex = 2;
            this.ProductAdd.Text = "상품추가";
            this.ProductAdd.UseVisualStyleBackColor = true;
            this.ProductAdd.Click += new System.EventHandler(this.ProductAdd_Click);
            // 
            // ProductDel
            // 
            this.ProductDel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.ProductDel.Location = new System.Drawing.Point(535, 384);
            this.ProductDel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ProductDel.Name = "ProductDel";
            this.ProductDel.Size = new System.Drawing.Size(125, 48);
=======
            this.ProductDel.Location = new System.Drawing.Point(428, 320);
            this.ProductDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProductDel.Name = "ProductDel";
            this.ProductDel.Size = new System.Drawing.Size(100, 40);
>>>>>>> Stashed changes
            this.ProductDel.TabIndex = 3;
            this.ProductDel.Text = "상품삭제";
            this.ProductDel.UseVisualStyleBackColor = true;
            this.ProductDel.Click += new System.EventHandler(this.ProductDel_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.SaveBtn.Location = new System.Drawing.Point(670, 384);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(125, 48);
=======
            this.SaveBtn.Location = new System.Drawing.Point(536, 320);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(100, 40);
>>>>>>> Stashed changes
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "거래 등록";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.SearchBtn.Location = new System.Drawing.Point(931, 26);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(372, 86);
=======
            this.SearchBtn.Location = new System.Drawing.Point(745, 22);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(298, 72);
>>>>>>> Stashed changes
            this.SearchBtn.TabIndex = 7;
            this.SearchBtn.Text = "거래내역보기";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.Controls.Add(this.ProductDel);
            this.groupBox2.Controls.Add(this.ProductAdd);
            this.groupBox2.Controls.Add(this.SaveBtn);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.groupBox2.Location = new System.Drawing.Point(42, 521);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox2.Size = new System.Drawing.Size(1261, 452);
=======
            this.groupBox2.Location = new System.Drawing.Point(34, 434);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1009, 377);
>>>>>>> Stashed changes
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "매매상세";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProduct,
            this.colProductID,
            this.colQty,
            this.colUnitPrice,
            this.colAmount,
            this.colStockQty});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Top;
<<<<<<< Updated upstream
            this.dgvDetail.Location = new System.Drawing.Point(5, 38);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(1251, 336);
=======
            this.dgvDetail.Location = new System.Drawing.Point(4, 32);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(1001, 280);
>>>>>>> Stashed changes
            this.dgvDetail.TabIndex = 8;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
            this.dgvDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetail_CurrentCellDirtyStateChanged);
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "상품코드";
            this.colProduct.MinimumWidth = 6;
            this.colProduct.Name = "colProduct";
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "상품ID";
            this.colProductID.MinimumWidth = 6;
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "수량";
            this.colQty.MinimumWidth = 6;
            this.colQty.Name = "colQty";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "단가";
            this.colUnitPrice.MinimumWidth = 6;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "금액";
            this.colAmount.MinimumWidth = 6;
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colStockQty
            // 
            this.colStockQty.HeaderText = "재고수량";
            this.colStockQty.MinimumWidth = 6;
            this.colStockQty.Name = "colStockQty";
            this.colStockQty.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label8.Location = new System.Drawing.Point(36, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 36);
=======
            this.label8.Location = new System.Drawing.Point(29, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 30);
>>>>>>> Stashed changes
            this.label8.TabIndex = 9;
            this.label8.Text = "거래등록";
            // 
            // statistics
            // 
            this.statistics.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.statistics.Location = new System.Drawing.Point(782, 26);
            this.statistics.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.statistics.Name = "statistics";
            this.statistics.Size = new System.Drawing.Size(125, 86);
=======
            this.statistics.Location = new System.Drawing.Point(626, 22);
            this.statistics.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statistics.Name = "statistics";
            this.statistics.Size = new System.Drawing.Size(100, 72);
>>>>>>> Stashed changes
            this.statistics.TabIndex = 24;
            this.statistics.Text = "거래 통계";
            this.statistics.UseVisualStyleBackColor = true;
            this.statistics.Click += new System.EventHandler(this.statistics_Click);
            // 
            // TradePage
            // 
<<<<<<< Updated upstream
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
>>>>>>> Stashed changes
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.statistics);
            this.Controls.Add(this.btnWarehouseSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
<<<<<<< Updated upstream
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "TradePage";
            this.Size = new System.Drawing.Size(1354, 984);
=======
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TradePage";
            this.Size = new System.Drawing.Size(1083, 820);
>>>>>>> Stashed changes
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
        private System.Windows.Forms.Button statistics;
    }
}
