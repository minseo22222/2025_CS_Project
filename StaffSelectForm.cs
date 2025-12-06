using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class StaffSelectForm : Form
    {
        DBCLASS dbc = new DBCLASS();

        // TradePage 에서 받아갈 값들
        public int SelectedStaffId { get; private set; }
        public string SelectedStaffName { get; private set; }
        private DataTable _staffTable;

        public StaffSelectForm()
        {
            InitializeComponent();

            try
            {
                // Employee 테이블(직원)에서 목록 조회
                //  ※ 컬럼명은 EMPLOYEEID / NAME / DEPARTMENT / PHONENUMBER
                dbc.DB_ObjCreate();
                dbc.DB_Open(
                    "SELECT EmployeeID, Name, Department, PhoneNumber " +
                    "FROM Employee " +
                    "ORDER BY EmployeeID");

                // DataSet 에 "Employee" 라는 이름으로 채움
                dbc.DBAdapter.Fill(dbc.DS, "Employee");
                _staffTable = dbc.DS.Tables["Employee"];

                dgvStaff.DataSource = _staffTable;
                dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 그리드 컬럼 헤더 한글로 변경 (선택 사항)
                dgvStaff.Columns["EMPLOYEEID"].HeaderText = "직원번호";
                dgvStaff.Columns["NAME"].HeaderText = "이름";
                dgvStaff.Columns["DEPARTMENT"].HeaderText = "부서";
                dgvStaff.Columns["PHONENUMBER"].HeaderText = "전화번호";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 직원 더블클릭 → 선택 완료
        private void dgvStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rowView = dgvStaff.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;

            // EmployeeID 가 NUMBER(10) 이라고 가정하고 int 로 변환
            // 만약 나중에 문자형 사번을 쓰고 싶으면
            // SelectedStaffId 를 string 으로 바꾸면 됨.
            SelectedStaffId = Convert.ToInt32(row["EMPLOYEEID"]);
            SelectedStaffName = row["NAME"].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ─────────────────────────────────────
        // 현재 그리드 선택을 TextBox 에 표시
        // ─────────────────────────────────────
        private void UpdateSelectedStaffTextFromGrid()
        {
            if (dgvStaff.CurrentRow == null)
            {
                txtSelectedStaff.Text = "";
                return;
            }

            var row = dgvStaff.CurrentRow;

            // 컬럼명은 실제 테이블에 맞게 수정 (예: EMPLOYEEID, NAME)
            object idObj = row.Cells["EMPLOYEEID"].Value;
            object nameObj = row.Cells["NAME"].Value;

            if (idObj == null || idObj == DBNull.Value) return;

            int id = Convert.ToInt32(idObj);
            string name = Convert.ToString(nameObj);

            txtSelectedStaff.Text = name;

            SelectedStaffId = id;
            SelectedStaffName = name;
        }

        // 셀 클릭 시
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            UpdateSelectedStaffTextFromGrid();
        }

        // 선택 변경 시
        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedStaffTextFromGrid();
        }

        // 확인 버튼
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null)
            {
                MessageBox.Show("직원을 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateSelectedStaffTextFromGrid();

            if (SelectedStaffId <= 0)
            {
                MessageBox.Show("직원을 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 취소 버튼
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSearchStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearchStaff_Click(sender, EventArgs.Empty);
            }
        }


        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
            if (_staffTable == null) return;

            string keyword = txtSearchStaff.Text.Trim();
            keyword = keyword.Replace("'", "''");

            if (string.IsNullOrEmpty(keyword))
            {
                _staffTable.DefaultView.RowFilter = "";
            }
            else
            {
                // 이름 컬럼명 확인: NAME / STAFFNAME 등
                _staffTable.DefaultView.RowFilter =
                    $"NAME LIKE '%{keyword}%'";
            }

            if (dgvStaff.Rows.Count > 0)
            {
                dgvStaff.CurrentCell = dgvStaff.Rows[0].Cells[0];
            }
            UpdateSelectedStaffTextFromGrid(); 
        }
    }
}
