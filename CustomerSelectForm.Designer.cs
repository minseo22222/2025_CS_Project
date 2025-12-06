namespace _2025_CS_Project
{
    partial class CustomerSelectForm
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
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.txtSelectedCustomer = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(130, 73);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowTemplate.Height = 23;
            this.dgvCustomer.Size = new System.Drawing.Size(489, 323);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellClick);
            this.dgvCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellDoubleClick);
            this.dgvCustomer.SelectionChanged += new System.EventHandler(this.dgvCustomer_SelectionChanged);
            // 
            // txtSelectedCustomer
            // 
            this.txtSelectedCustomer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSelectedCustomer.Location = new System.Drawing.Point(220, 413);
            this.txtSelectedCustomer.Name = "txtSelectedCustomer";
            this.txtSelectedCustomer.ReadOnly = true;
            this.txtSelectedCustomer.Size = new System.Drawing.Size(150, 26);
            this.txtSelectedCustomer.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(520, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(414, 407);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 34);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "확인";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "거래처 선택";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearchCustomer.Location = new System.Drawing.Point(130, 33);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(384, 29);
            this.txtSearchCustomer.TabIndex = 12;
            this.txtSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyDown);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchCustomer.Location = new System.Drawing.Point(520, 29);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(100, 34);
            this.btnSearchCustomer.TabIndex = 13;
            this.btnSearchCustomer.Text = "검색";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(126, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "거래처명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(60, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "선택한 거래처";
            // 
            // CustomerSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearchCustomer);
            this.Controls.Add(this.txtSearchCustomer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSelectedCustomer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvCustomer);
            this.Name = "CustomerSelectForm";
            this.Text = "CustomerSelectForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.TextBox txtSelectedCustomer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}