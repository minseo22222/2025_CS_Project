namespace _2025_CS_Project
{
    partial class WarehouseSelectForm
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
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWarehouse
            // 
            this.dgvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouse.Location = new System.Drawing.Point(52, 30);
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.RowTemplate.Height = 23;
            this.dgvWarehouse.Size = new System.Drawing.Size(489, 323);
            this.dgvWarehouse.TabIndex = 0;
            this.dgvWarehouse.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouse_CellDoubleClick);
            // 
            // WarehouseSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvWarehouse);
            this.Name = "WarehouseSelectForm";
            this.Text = "WarehouseSelectForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWarehouse;
    }
}