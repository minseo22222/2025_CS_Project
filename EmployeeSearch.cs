using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace _2025_CS_Project
{
    public partial class EmployeeSearch : Form
    {
        string connectionString = "User Id=hong1; Password=1111; Data Source=localhost:1521/xe";
        public EmployeeSearch()
        {
            InitializeComponent();
        }

        private void EmployeeSearch_Load(object sender, EventArgs e)
        {
            if (cboCategory.Items.Count > 0)
            {
                cboCategory.SelectedIndex = 0;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // (1) 콤보박스에서 선택한 항목(한글)을 DB 컬럼명(영어)으로 변환
                    string targetColumn = "Name"; // 기본값

                    if (cboCategory.Text == "직급") targetColumn = "Rank";
                    else if (cboCategory.Text == "부서") targetColumn = "Department";
                    else if (cboCategory.Text == "사원번호") targetColumn = "EmployeeID";

                    // (2) 기본 쿼리 작성 (퇴사일 컬럼도 같이 가져옴)
                    // LIKE 검색을 위해 :keyword 파라미터 사용 준비
                    string sql = "SELECT EmployeeID, Name, Rank, Department, HireDate, PhoneNumber, ResignationDate " +
                                 "FROM Employee " +
                                 "WHERE " + targetColumn + " LIKE :keyword ";

                    // (3) 핵심: 체크박스 여부에 따라 재직자/퇴사자 구분
                    if (chkResigned.Checked == true)
                    {
                        // 체크됨 -> 퇴사자만 보기 (퇴사일이 있는 사람)
                        sql += " AND ResignationDate IS NOT NULL ";
                    }
                    else
                    {
                        // 체크안됨 -> 재직자만 보기 (퇴사일이 없는 사람)
                        sql += " AND ResignationDate IS NULL ";
                    }

                    // 정렬 추가
                    sql += " ORDER BY EmployeeID ASC";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    // 검색어 앞뒤로 %를 붙여서 포함된 글자 검색
                    cmd.Parameters.Add("keyword", "%" + txtSearchKeyword.Text.Trim() + "%");

                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);

                    DBGrids.DataSource = dt;
                    DBGrids.ReadOnly = true;

                    // (4) 결과 개수 라벨 업데이트
                    string status = chkResigned.Checked ? "퇴사자" : "재직자";
                    if (lblTotalCount != null)
                        lblTotalCount.Text = $"검색된 {status}: {dt.Rows.Count}명";

                    // (5) 그리드뷰 헤더 한글로 변경 및 디자인
                    if (dt.Rows.Count > 0)
                    {
                        DBGrids.Columns["EmployeeID"].HeaderText = "사원번호";
                        DBGrids.Columns["Name"].HeaderText = "이름";
                        DBGrids.Columns["Rank"].HeaderText = "직급";
                        DBGrids.Columns["Department"].HeaderText = "부서";
                        DBGrids.Columns["HireDate"].HeaderText = "입사일";
                        DBGrids.Columns["PhoneNumber"].HeaderText = "전화번호";

                        // 퇴사일 컬럼 처리 (재직자일 땐 숨기고, 퇴사자일 땐 보여주기)
                        if (DBGrids.Columns.Contains("ResignationDate"))
                        {
                            DBGrids.Columns["ResignationDate"].HeaderText = "퇴사일";
                            DBGrids.Columns["ResignationDate"].Visible = chkResigned.Checked;
                        }
                    }
                    else
                    {
                        // 검색 결과가 없을 때 메시지 (너무 자주 뜨면 귀찮으니 생략 가능)
                        // MessageBox.Show("검색 결과가 없습니다.");
                    }

                    // 그리드뷰 스타일 설정
                    DBGrids.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DBGrids.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DBGrids.AllowUserToAddRows = false;

                    // 헤더 가운데 정렬
                    DBGrids.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DBGrids.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색 오류: " + ex.Message);
                }
            }
        }

        private void txtSearchKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchKeyword.Text = "";       // 검색어 지우기
            cboCategory.SelectedIndex = 0;    // 콤보박스 '이름'으로 원복
            chkResigned.Checked = false;      // 퇴사자 보기 체크 해제

            DBGrids.DataSource = null;
            if (lblTotalCount != null) lblTotalCount.Text = "검색된 인원 :";
        }
    }
}
