namespace _2025_CS_Project
{
    partial class InventoryPage
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShowBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AppendBtn = new System.Windows.Forms.Button();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtWarehouseNum = new System.Windows.Forms.TextBox();
            this.WarehouseList = new System.Windows.Forms.ListBox();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtInvSearch = new System.Windows.Forms.TextBox();
            this.invSearchBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "창고명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "창고번호";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ShowBtn);
            this.groupBox1.Controls.Add(this.DeleteBtn);
            this.groupBox1.Controls.Add(this.AppendBtn);
            this.groupBox1.Controls.Add(this.txtWarehouseName);
            this.groupBox1.Controls.Add(this.txtWarehouseNum);
            this.groupBox1.Controls.Add(this.WarehouseList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(54, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 866);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "창고관리";
            // 
            // ShowBtn
            // 
            this.ShowBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowBtn.Location = new System.Drawing.Point(333, 149);
            this.ShowBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ShowBtn.Name = "ShowBtn";
            this.ShowBtn.Size = new System.Drawing.Size(188, 42);
            this.ShowBtn.TabIndex = 17;
            this.ShowBtn.Text = "조회";
            this.ShowBtn.UseVisualStyleBackColor = true;
            this.ShowBtn.Click += new System.EventHandler(this.ShowBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteBtn.Location = new System.Drawing.Point(396, 93);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(125, 48);
            this.DeleteBtn.TabIndex = 16;
            this.DeleteBtn.Text = "삭제";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // AppendBtn
            // 
            this.AppendBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AppendBtn.Location = new System.Drawing.Point(396, 37);
            this.AppendBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AppendBtn.Name = "AppendBtn";
            this.AppendBtn.Size = new System.Drawing.Size(125, 48);
            this.AppendBtn.TabIndex = 14;
            this.AppendBtn.Text = "확인";
            this.AppendBtn.UseVisualStyleBackColor = true;
            this.AppendBtn.Click += new System.EventHandler(this.AppendBtn_Click);
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Location = new System.Drawing.Point(133, 93);
            this.txtWarehouseName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(230, 40);
            this.txtWarehouseName.TabIndex = 15;
            // 
            // txtWarehouseNum
            // 
            this.txtWarehouseNum.Location = new System.Drawing.Point(133, 48);
            this.txtWarehouseNum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtWarehouseNum.Name = "txtWarehouseNum";
            this.txtWarehouseNum.Size = new System.Drawing.Size(230, 40);
            this.txtWarehouseNum.TabIndex = 14;
            // 
            // WarehouseList
            // 
            this.WarehouseList.FormattingEnabled = true;
            this.WarehouseList.ItemHeight = 29;
            this.WarehouseList.Location = new System.Drawing.Point(31, 198);
            this.WarehouseList.Name = "WarehouseList";
            this.WarehouseList.Size = new System.Drawing.Size(431, 642);
            this.WarehouseList.TabIndex = 13;
            this.WarehouseList.SelectedIndexChanged += new System.EventHandler(this.WarehouseList_SelectedIndexChanged);
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(26, 92);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.RowHeadersWidth = 62;
            this.dataGridViewInventory.RowTemplate.Height = 30;
            this.dataGridViewInventory.Size = new System.Drawing.Size(883, 696);
            this.dataGridViewInventory.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.invSearchBtn);
            this.groupBox2.Controls.Add(this.txtInvSearch);
            this.groupBox2.Controls.Add(this.dataGridViewInventory);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 14.25F);
            this.groupBox2.Location = new System.Drawing.Point(629, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(927, 852);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "재고목록(우클릭으로 관리)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStockToolStripMenuItem,
            this.updateStockToolStripMenuItem,
            this.deleteStockToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 100);
            // 
            // addStockToolStripMenuItem
            // 
            this.addStockToolStripMenuItem.Name = "addStockToolStripMenuItem";
            this.addStockToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
            this.addStockToolStripMenuItem.Text = "재고추가";
            this.addStockToolStripMenuItem.Click += new System.EventHandler(this.addStockToolStripMenuItem_Click);
            // 
            // updateStockToolStripMenuItem
            // 
            this.updateStockToolStripMenuItem.Name = "updateStockToolStripMenuItem";
            this.updateStockToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
            this.updateStockToolStripMenuItem.Text = "재고수정";
            this.updateStockToolStripMenuItem.Click += new System.EventHandler(this.updateStockToolStripMenuItem_Click);
            // 
            // deleteStockToolStripMenuItem
            // 
            this.deleteStockToolStripMenuItem.Name = "deleteStockToolStripMenuItem";
            this.deleteStockToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
            this.deleteStockToolStripMenuItem.Text = "재고삭제";
            this.deleteStockToolStripMenuItem.Click += new System.EventHandler(this.deleteStockToolStripMenuItem_Click);
            // 
            // txtInvSearch
            // 
            this.txtInvSearch.Location = new System.Drawing.Point(26, 45);
            this.txtInvSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtInvSearch.Name = "txtInvSearch";
            this.txtInvSearch.Size = new System.Drawing.Size(785, 40);
            this.txtInvSearch.TabIndex = 18;
            // 
            // invSearchBtn
            // 
            this.invSearchBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.invSearchBtn.Location = new System.Drawing.Point(830, 43);
            this.invSearchBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.invSearchBtn.Name = "invSearchBtn";
            this.invSearchBtn.Size = new System.Drawing.Size(79, 42);
            this.invSearchBtn.TabIndex = 18;
            this.invSearchBtn.Text = "검색";
            this.invSearchBtn.UseVisualStyleBackColor = true;
            this.invSearchBtn.Click += new System.EventHandler(this.invSearchBtn_Click);
            // 
            // InventoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "InventoryPage";
            this.Size = new System.Drawing.Size(1573, 984);
            this.Load += new System.EventHandler(this.InventoryPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox WarehouseList;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.TextBox txtWarehouseNum;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AppendBtn;
        private System.Windows.Forms.Button ShowBtn;
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStockToolStripMenuItem;
        private System.Windows.Forms.Button invSearchBtn;
        private System.Windows.Forms.TextBox txtInvSearch;
    }
}
