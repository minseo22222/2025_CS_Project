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

                dgvStaff.DataSource = dbc.DS.Tables["Employee"];
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
    }
}
