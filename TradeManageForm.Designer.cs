namespace _2025_CS_Project
{
    partial class TradeManageForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvTradeList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTradeDetail = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.상품추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상품삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수량수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWarehouseSearch = new System.Windows.Forms.Button();
            this.btnStaffSearch = new System.Windows.Forms.Button();
<<<<<<< Updated upstream
=======
            this.btnTradeSearch = new System.Windows.Forms.Button();
>>>>>>> Stashed changes
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTradeDate = new System.Windows.Forms.DateTimePicker();
            this.cboTradeType = new System.Windows.Forms.ComboBox();
            this.txtTradeNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
<<<<<<< Updated upstream
            this.btnTradeSearch = new System.Windows.Forms.Button();
=======
>>>>>>> Stashed changes
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeDetail)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTradeList
            // 
            this.dgvTradeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< Updated upstream
            this.dgvTradeList.Location = new System.Drawing.Point(20, 93);
            this.dgvTradeList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvTradeList.Name = "dgvTradeList";
            this.dgvTradeList.RowHeadersWidth = 62;
            this.dgvTradeList.RowTemplate.Height = 23;
            this.dgvTradeList.Size = new System.Drawing.Size(957, 338);
=======
            this.dgvTradeList.Location = new System.Drawing.Point(13, 50);
            this.dgvTradeList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvTradeList.Name = "dgvTradeList";
            this.dgvTradeList.RowHeadersWidth = 62;
            this.dgvTradeList.RowTemplate.Height = 23;
            this.dgvTradeList.Size = new System.Drawing.Size(766, 217);
>>>>>>> Stashed changes
            this.dgvTradeList.TabIndex = 0;
            this.dgvTradeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTradeList_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
<<<<<<< Updated upstream
            this.label1.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(413, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
=======
            this.label1.Font = new System.Drawing.Font("SimSun", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(323, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
>>>>>>> Stashed changes
            this.label1.TabIndex = 2;
            this.label1.Text = "거래목록";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
<<<<<<< Updated upstream
            this.label2.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(413, 449);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 33);
=======
            this.label2.Font = new System.Drawing.Font("SimSun", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(323, 277);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 28);
>>>>>>> Stashed changes
            this.label2.TabIndex = 3;
            this.label2.Text = "거래상세";
            // 
            // dgvTradeDetail
            // 
            this.dgvTradeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTradeDetail.ContextMenuStrip = this.contextMenuStrip1;
<<<<<<< Updated upstream
            this.dgvTradeDetail.Location = new System.Drawing.Point(20, 486);
            this.dgvTradeDetail.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvTradeDetail.Name = "dgvTradeDetail";
            this.dgvTradeDetail.RowHeadersWidth = 62;
            this.dgvTradeDetail.RowTemplate.Height = 23;
            this.dgvTradeDetail.Size = new System.Drawing.Size(957, 388);
=======
            this.dgvTradeDetail.Location = new System.Drawing.Point(13, 308);
            this.dgvTradeDetail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvTradeDetail.Name = "dgvTradeDetail";
            this.dgvTradeDetail.RowHeadersWidth = 62;
            this.dgvTradeDetail.RowTemplate.Height = 23;
            this.dgvTradeDetail.Size = new System.Drawing.Size(766, 237);
>>>>>>> Stashed changes
            this.dgvTradeDetail.TabIndex = 4;
            this.dgvTradeDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTradeDetail_CellEndEdit);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상품추가ToolStripMenuItem,
            this.상품삭제ToolStripMenuItem,
            this.수량수정ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
<<<<<<< Updated upstream
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 100);
=======
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 76);
>>>>>>> Stashed changes
            // 
            // 상품추가ToolStripMenuItem
            // 
            this.상품추가ToolStripMenuItem.Name = "상품추가ToolStripMenuItem";
<<<<<<< Updated upstream
            this.상품추가ToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
=======
            this.상품추가ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
>>>>>>> Stashed changes
            this.상품추가ToolStripMenuItem.Text = "상품추가";
            this.상품추가ToolStripMenuItem.Click += new System.EventHandler(this.상품추가ToolStripMenuItem_Click);
            // 
            // 상품삭제ToolStripMenuItem
            // 
            this.상품삭제ToolStripMenuItem.Name = "상품삭제ToolStripMenuItem";
<<<<<<< Updated upstream
            this.상품삭제ToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
=======
            this.상품삭제ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
>>>>>>> Stashed changes
            this.상품삭제ToolStripMenuItem.Text = "상품삭제";
            this.상품삭제ToolStripMenuItem.Click += new System.EventHandler(this.상품삭제ToolStripMenuItem_Click);
            // 
            // 수량수정ToolStripMenuItem
            // 
            this.수량수정ToolStripMenuItem.Name = "수량수정ToolStripMenuItem";
<<<<<<< Updated upstream
            this.수량수정ToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
=======
            this.수량수정ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
>>>>>>> Stashed changes
            this.수량수정ToolStripMenuItem.Text = "수량수정";
            this.수량수정ToolStripMenuItem.Click += new System.EventHandler(this.수량수정ToolStripMenuItem_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.btnDel.Location = new System.Drawing.Point(249, 637);
            this.btnDel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(155, 57);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "Del";
=======
            this.btnDel.Location = new System.Drawing.Point(197, 441);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(124, 48);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "삭제";
>>>>>>> Stashed changes
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.btnUpdate.Location = new System.Drawing.Point(65, 637);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(155, 57);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Updata";
=======
            this.btnUpdate.Location = new System.Drawing.Point(40, 441);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(124, 48);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "수정";
>>>>>>> Stashed changes
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnWarehouseSearch);
            this.groupBox1.Controls.Add(this.btnStaffSearch);
            this.groupBox1.Controls.Add(this.btnTradeSearch);
            this.groupBox1.Controls.Add(this.btnCustomerSearch);
            this.groupBox1.Controls.Add(this.txtWarehouse);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label10);
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
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.groupBox1.Location = new System.Drawing.Point(1033, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(724, 755);
=======
            this.groupBox1.Location = new System.Drawing.Point(802, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(523, 508);
>>>>>>> Stashed changes
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "매매관리";
            // 
            // btnWarehouseSearch
            // 
<<<<<<< Updated upstream
            this.btnWarehouseSearch.Location = new System.Drawing.Point(430, 420);
            this.btnWarehouseSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnWarehouseSearch.Name = "btnWarehouseSearch";
            this.btnWarehouseSearch.Size = new System.Drawing.Size(132, 46);
            this.btnWarehouseSearch.TabIndex = 26;
            this.btnWarehouseSearch.Text = "Search";
=======
            this.btnWarehouseSearch.Location = new System.Drawing.Point(384, 327);
            this.btnWarehouseSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWarehouseSearch.Name = "btnWarehouseSearch";
            this.btnWarehouseSearch.Size = new System.Drawing.Size(106, 38);
            this.btnWarehouseSearch.TabIndex = 26;
            this.btnWarehouseSearch.Text = "검색";
>>>>>>> Stashed changes
            this.btnWarehouseSearch.UseVisualStyleBackColor = true;
            this.btnWarehouseSearch.Click += new System.EventHandler(this.btnWarehouseSearch_Click);
            // 
            // btnStaffSearch
            // 
<<<<<<< Updated upstream
            this.btnStaffSearch.Location = new System.Drawing.Point(452, 308);
            this.btnStaffSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStaffSearch.Name = "btnStaffSearch";
            this.btnStaffSearch.Size = new System.Drawing.Size(132, 46);
            this.btnStaffSearch.TabIndex = 22;
            this.btnStaffSearch.Text = "Search";
            this.btnStaffSearch.UseVisualStyleBackColor = true;
            this.btnStaffSearch.Click += new System.EventHandler(this.btnStaffSearch_Click);
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Location = new System.Drawing.Point(430, 226);
            this.btnCustomerSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(132, 46);
            this.btnCustomerSearch.TabIndex = 21;
            this.btnCustomerSearch.Text = "Search";
=======
            this.btnStaffSearch.Location = new System.Drawing.Point(384, 235);
            this.btnStaffSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStaffSearch.Name = "btnStaffSearch";
            this.btnStaffSearch.Size = new System.Drawing.Size(106, 38);
            this.btnStaffSearch.TabIndex = 22;
            this.btnStaffSearch.Text = "검색";
            this.btnStaffSearch.UseVisualStyleBackColor = true;
            this.btnStaffSearch.Click += new System.EventHandler(this.btnStaffSearch_Click);
            // 
            // btnTradeSearch
            // 
            this.btnTradeSearch.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTradeSearch.Location = new System.Drawing.Point(356, 441);
            this.btnTradeSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTradeSearch.Name = "btnTradeSearch";
            this.btnTradeSearch.Size = new System.Drawing.Size(125, 48);
            this.btnTradeSearch.TabIndex = 12;
            this.btnTradeSearch.Text = "거래검색";
            this.btnTradeSearch.UseVisualStyleBackColor = true;
            this.btnTradeSearch.Click += new System.EventHandler(this.btnTradeSearch_Click);
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Location = new System.Drawing.Point(384, 162);
            this.btnCustomerSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(106, 38);
            this.btnCustomerSearch.TabIndex = 21;
            this.btnCustomerSearch.Text = "검색";
>>>>>>> Stashed changes
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // txtWarehouse
            // 
<<<<<<< Updated upstream
            this.txtWarehouse.Location = new System.Drawing.Point(178, 424);
            this.txtWarehouse.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(239, 42);
            this.txtWarehouse.TabIndex = 25;
=======
            this.txtWarehouse.Location = new System.Drawing.Point(111, 331);
            this.txtWarehouse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(266, 36);
            this.txtWarehouse.TabIndex = 25;
            this.txtWarehouse.TextChanged += new System.EventHandler(this.txtWarehouse_TextChanged);
>>>>>>> Stashed changes
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label10.Location = new System.Drawing.Point(107, 424);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 29);
            this.label10.TabIndex = 24;
            this.label10.Text = "창고";
            // 
            // txtStaff
            // 
            this.txtStaff.Location = new System.Drawing.Point(178, 308);
            this.txtStaff.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(239, 42);
            this.txtStaff.TabIndex = 19;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(178, 226);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(239, 42);
            this.txtCustomer.TabIndex = 18;
=======
            this.label10.Location = new System.Drawing.Point(55, 331);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 24);
            this.label10.TabIndex = 24;
            this.label10.Text = "창고";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtStaff
            // 
            this.txtStaff.Location = new System.Drawing.Point(111, 235);
            this.txtStaff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(266, 36);
            this.txtStaff.TabIndex = 19;
            this.txtStaff.TextChanged += new System.EventHandler(this.txtStaff_TextChanged);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(111, 166);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(266, 36);
            this.txtCustomer.TabIndex = 18;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
>>>>>>> Stashed changes
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label7.Location = new System.Drawing.Point(62, 482);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 29);
=======
            this.label7.Location = new System.Drawing.Point(37, 378);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 24);
>>>>>>> Stashed changes
            this.label7.TabIndex = 17;
            this.label7.Text = "총금액";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtTotalAmount
            // 
<<<<<<< Updated upstream
            this.txtTotalAmount.Location = new System.Drawing.Point(180, 476);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(279, 42);
=======
            this.txtTotalAmount.Location = new System.Drawing.Point(113, 375);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(264, 36);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            this.cboPayment.Location = new System.Drawing.Point(180, 370);
            this.cboPayment.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(199, 38);
            this.cboPayment.TabIndex = 15;
=======
            this.cboPayment.Location = new System.Drawing.Point(113, 286);
            this.cboPayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(264, 33);
            this.cboPayment.TabIndex = 15;
            this.cboPayment.SelectedIndexChanged += new System.EventHandler(this.cboPayment_SelectedIndexChanged);
>>>>>>> Stashed changes
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label9.Location = new System.Drawing.Point(62, 376);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 29);
            this.label9.TabIndex = 14;
            this.label9.Text = "결제수단";
=======
            this.label9.Location = new System.Drawing.Point(19, 291);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = "결제수단";
            this.label9.Click += new System.EventHandler(this.label9_Click);
>>>>>>> Stashed changes
            // 
            // dtpTradeDate
            // 
            this.dtpTradeDate.CustomFormat = "yyyy년 MM월 dd일";
            this.dtpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
<<<<<<< Updated upstream
            this.dtpTradeDate.Location = new System.Drawing.Point(178, 122);
            this.dtpTradeDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpTradeDate.Name = "dtpTradeDate";
            this.dtpTradeDate.Size = new System.Drawing.Size(331, 42);
            this.dtpTradeDate.TabIndex = 12;
=======
            this.dtpTradeDate.Location = new System.Drawing.Point(111, 80);
            this.dtpTradeDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpTradeDate.Name = "dtpTradeDate";
            this.dtpTradeDate.Size = new System.Drawing.Size(266, 36);
            this.dtpTradeDate.TabIndex = 12;
            this.dtpTradeDate.ValueChanged += new System.EventHandler(this.dtpTradeDate_ValueChanged);
>>>>>>> Stashed changes
            // 
            // cboTradeType
            // 
            this.cboTradeType.FormattingEnabled = true;
            this.cboTradeType.Items.AddRange(new object[] {
            "매입",
            "매출"});
<<<<<<< Updated upstream
            this.cboTradeType.Location = new System.Drawing.Point(178, 176);
            this.cboTradeType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboTradeType.Name = "cboTradeType";
            this.cboTradeType.Size = new System.Drawing.Size(104, 38);
=======
            this.cboTradeType.Location = new System.Drawing.Point(111, 125);
            this.cboTradeType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboTradeType.Name = "cboTradeType";
            this.cboTradeType.Size = new System.Drawing.Size(84, 33);
>>>>>>> Stashed changes
            this.cboTradeType.TabIndex = 10;
            this.cboTradeType.SelectedIndexChanged += new System.EventHandler(this.cboTradeType_SelectedIndexChanged);
            // 
            // txtTradeNo
            // 
<<<<<<< Updated upstream
            this.txtTradeNo.Location = new System.Drawing.Point(178, 68);
            this.txtTradeNo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTradeNo.Name = "txtTradeNo";
            this.txtTradeNo.ReadOnly = true;
            this.txtTradeNo.Size = new System.Drawing.Size(279, 42);
            this.txtTradeNo.TabIndex = 9;
=======
            this.txtTradeNo.Location = new System.Drawing.Point(111, 35);
            this.txtTradeNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTradeNo.Name = "txtTradeNo";
            this.txtTradeNo.ReadOnly = true;
            this.txtTradeNo.Size = new System.Drawing.Size(266, 36);
            this.txtTradeNo.TabIndex = 9;
            this.txtTradeNo.TextChanged += new System.EventHandler(this.txtTradeNo_TextChanged);
>>>>>>> Stashed changes
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label5.Location = new System.Drawing.Point(83, 232);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 29);
=======
            this.label5.Location = new System.Drawing.Point(35, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
>>>>>>> Stashed changes
            this.label5.TabIndex = 4;
            this.label5.Text = "거래처";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label4.Location = new System.Drawing.Point(85, 320);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 29);
=======
            this.label4.Location = new System.Drawing.Point(37, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
>>>>>>> Stashed changes
            this.label4.TabIndex = 3;
            this.label4.Text = "담당자";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label3.Location = new System.Drawing.Point(60, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 29);
=======
            this.label3.Location = new System.Drawing.Point(17, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
>>>>>>> Stashed changes
            this.label3.TabIndex = 2;
            this.label3.Text = "매매유형";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(17, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "거래일자";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(60, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 29);
            this.label6.TabIndex = 1;
            this.label6.Text = "거래일자";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
<<<<<<< Updated upstream
            this.label8.Location = new System.Drawing.Point(60, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "거래번호";
            // 
            // btnTradeSearch
            // 
            this.btnTradeSearch.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTradeSearch.Location = new System.Drawing.Point(430, 631);
            this.btnTradeSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnTradeSearch.Name = "btnTradeSearch";
            this.btnTradeSearch.Size = new System.Drawing.Size(205, 63);
            this.btnTradeSearch.TabIndex = 12;
            this.btnTradeSearch.Text = "거래검색";
            this.btnTradeSearch.UseVisualStyleBackColor = true;
            this.btnTradeSearch.Click += new System.EventHandler(this.btnTradeSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(2167, 862);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(205, 63);
=======
            this.label8.Location = new System.Drawing.Point(17, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "거래번호";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(1734, 718);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(164, 52);
>>>>>>> Stashed changes
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TradeManageForm
            // 
<<<<<<< Updated upstream
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 944);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 585);
>>>>>>> Stashed changes
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTradeDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTradeList);
<<<<<<< Updated upstream
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
=======
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
>>>>>>> Stashed changes
            this.Name = "TradeManageForm";
            this.Text = "거래내역";
            this.Load += new System.EventHandler(this.TradeManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeDetail)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTradeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTradeDetail;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStaffSearch;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.TextBox txtStaff;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpTradeDate;
        private System.Windows.Forms.ComboBox cboTradeType;
        private System.Windows.Forms.TextBox txtTradeNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnWarehouseSearch;
        private System.Windows.Forms.TextBox txtWarehouse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 상품추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상품삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수량수정ToolStripMenuItem;
        private System.Windows.Forms.Button btnTradeSearch;
        private System.Windows.Forms.Button btnClose;
    }
}