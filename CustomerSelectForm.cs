using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class CustomerSelectForm : Form
    {
        DBCLASS dbc = new DBCLASS();

        public int SelectedCustomerId { get; private set; }
        public string SelectedCustomerName { get; private set; }

        public CustomerSelectForm()
        {
            InitializeComponent();

            try
            {
                // Customer 테이블에서 거래처 목록 조회
                dbc.DB_ObjCreate();
                dbc.DB_Open(
                    "SELECT CustomerID, CustomerName, BusinessNo, Address, Phone, Fax " +
                    "FROM Customer " +
                    "ORDER BY CustomerID");

                dbc.DBAdapter.Fill(dbc.DS, "Customer");

                dgvCustomer.DataSource = dbc.DS.Tables["Customer"];
                dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // ★ 컬럼 헤더 한글로
                dgvCustomer.Columns["CUSTOMERID"].HeaderText = "거래처번호";
                dgvCustomer.Columns["CUSTOMERNAME"].HeaderText = "거래처명";
                dgvCustomer.Columns["BUSINESSNO"].HeaderText = "사업자번호";
                dgvCustomer.Columns["ADDRESS"].HeaderText = "주소";
                dgvCustomer.Columns["PHONE"].HeaderText = "전화번호";
                dgvCustomer.Columns["FAX"].HeaderText = "FAX번호";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rowView = dgvCustomer.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;

            SelectedCustomerId = Convert.ToInt32(row["CUSTOMERID"]);
            SelectedCustomerName = row["CUSTOMERNAME"].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
