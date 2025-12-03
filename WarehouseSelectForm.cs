using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class WarehouseSelectForm : Form
    {
        DBCLASS dbc = new DBCLASS();

        public int SelectedWarehouseId { get; private set; }
        public string SelectedWarehouseName { get; private set; }

        public WarehouseSelectForm()
        {
            InitializeComponent();

            try
            {
                // Warehouse 테이블에서 창고 목록 조회
                dbc.DB_ObjCreate();
                dbc.DB_Open(
                    "SELECT WarehouseID, WarehouseName " +
                    "FROM Warehouse " +
                    "ORDER BY WarehouseID");

                dbc.DBAdapter.Fill(dbc.DS, "Warehouse");

                dgvWarehouse.DataSource = dbc.DS.Tables["Warehouse"];
                dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // ★ 컬럼 헤더 한글로
                dgvWarehouse.Columns["WAREHOUSEID"].HeaderText = "창고코드";
                dgvWarehouse.Columns["WAREHOUSENAME"].HeaderText = "창고명";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvWarehouse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rowView = dgvWarehouse.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;

            SelectedWarehouseId = Convert.ToInt32(row["WAREHOUSEID"]);
            SelectedWarehouseName = row["WAREHOUSENAME"].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
