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

                // ★ DataTable 을 필터링용 필드에 보관
                _customerTable = dbc.DS.Tables["Customer"];

                // ★ 그리드는 이 테이블에 바인딩
                dgvCustomer.DataSource = _customerTable;
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

        // ─────────────────────────────────────
        // 현재 그리드 선택을 TextBox 에 표시하는 공통 함수
        // ─────────────────────────────────────
        private void UpdateSelectedCustomerTextFromGrid()
        {
            if (dgvCustomer.CurrentRow == null)
            {
                txtSelectedCustomer.Text = "";
                return;
            }

            var row = dgvCustomer.CurrentRow;

            // 컬럼 이름은 실제 DB 컬럼명에 맞게 사용
            // 예: CUSTOMERID, CUSTOMERNAME
            object idObj = row.Cells["CUSTOMERID"].Value;
            object nameObj = row.Cells["CUSTOMERNAME"].Value;

            if (idObj == null || idObj == DBNull.Value) return;

            int id = Convert.ToInt32(idObj);
            string name = Convert.ToString(nameObj);

            // TextBox 에 선택된 거래처 이름 출력
            txtSelectedCustomer.Text = name;

            // 속성에도 미리 저장해 두면 OK 버튼에서 바로 사용 가능
            SelectedCustomerId = id;
            SelectedCustomerName = name;
        }

        // ─────────────────────────────────────
        // 그리드 셀 클릭 시 → 선택 정보 TextBox 반영
        // ─────────────────────────────────────
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  // 헤더 줄 클릭 방지
            UpdateSelectedCustomerTextFromGrid();
        }

        // 선택이 바뀔 때도 동일하게 반영 (키보드 ↑↓ 으로 이동할 때)
        // 디자이너에서 SelectionChanged 에 연결
        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedCustomerTextFromGrid();
        }

        // ─────────────────────────────────────
        // 확인 버튼 클릭 : 선택된 거래처를 Form 호출자에게 돌려주기
        // ─────────────────────────────────────
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow == null)
            {
                MessageBox.Show("거래처를 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 혹시나 SelectedCustomerId 가 세팅 안 되어 있을 수도 있으니
            // 한 번 더 안전하게 갱신
            UpdateSelectedCustomerTextFromGrid();

            if (SelectedCustomerId <= 0)
            {
                MessageBox.Show("거래처를 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ─────────────────────────────────────
        // 취소 버튼 클릭 : 아무 것도 선택하지 않고 닫기
        // ─────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 고객 목록 전체를 보관할 테이블 (검색 시 필터링용)
        private DataTable _customerTable;


        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // ‘띵’ 소리 방지
                btnSearchCustomer_Click(sender, EventArgs.Empty);
            }
        }

        // 검색 버튼 클릭
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (_customerTable == null) return;

            string keyword = txtSearchCustomer.Text.Trim();

            // 작은따옴표(') 가 들어가면 RowFilter 문법이 깨지니 이스케이프
            keyword = keyword.Replace("'", "''");

            if (string.IsNullOrEmpty(keyword))
            {
                // 검색어 비어 있으면 전체 표시
                _customerTable.DefaultView.RowFilter = "";
            }
            else
            {
                // 고객명으로 부분 검색
                // 컬럼명이 CUSTOMERNAME / CUSTOMER_NAME 인지 확인해서 맞게 수정
                _customerTable.DefaultView.RowFilter =
                    $"CUSTOMERNAME LIKE '%{keyword}%'";
                // 만약 ID 로도 찾고 싶으면 예:
                // _customerTable.DefaultView.RowFilter =
                //    $"CUSTOMERNAME LIKE '%{keyword}%' OR Convert(CUSTOMERID, 'System.String') LIKE '%{keyword}%'";
            }

            // 필터 후에 현재 선택 변경 → 아래 TextBox 갱신
            if (dgvCustomer.Rows.Count > 0)
            {
                dgvCustomer.CurrentCell = dgvCustomer.Rows[0].Cells[0];
            }
            UpdateSelectedCustomerTextFromGrid();   // 之前我们写过的函数
        }

    }
}
