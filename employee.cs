using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2025_CS_Project
{
    public partial class employee : UserControl
    {
        string connectionString = "User Id=hong1; Password=1111; Data Source=localhost:1521/xe";
        public employee()
        {
            InitializeComponent();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            LoadComboData(); // 부서/직급 콤보박스 채우기
            LoadData();      // 직원 목록 채우기
        }
        private void LoadComboData()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 부서 콤보박스
                    string sqlDept = "SELECT DeptName FROM Departments ORDER BY DeptName ASC";
                    OracleCommand cmdDept = new OracleCommand(sqlDept, conn);
                    OracleDataReader rdrDept = cmdDept.ExecuteReader();

                    cboDept.Items.Clear();
                    while (rdrDept.Read())
                    {
                        cboDept.Items.Add(rdrDept["DeptName"].ToString());
                    }
                    rdrDept.Close();

                    // 직급 콤보박스 (SortNo 순서대로)
                    string sqlRank = "SELECT RankName FROM Ranks ORDER BY SortNo ASC";
                    OracleCommand cmdRank = new OracleCommand(sqlRank, conn);
                    OracleDataReader rdrRank = cmdRank.ExecuteReader();

                    cboRank.Items.Clear();
                    while (rdrRank.Read())
                    {
                        cboRank.Items.Add(rdrRank["RankName"].ToString());
                    }
                    rdrRank.Close();
                }
                catch (Exception ex)
                {
                    // 아직 테이블이 없거나 DB 연결 안될 때 오류 무시 (혹은 메시지 띄우기)
                    // MessageBox.Show("기초 데이터 로드 오류: " + ex.Message);
                }
            }
        }

        // (2) 직원 목록 채우기 (재직자만)
        private void LoadData()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 퇴사일이 비어있는 사람만 조회
                    string sql = "SELECT EmployeeID, Name, Rank, Department, HireDate, PhoneNumber " +
                                 "FROM Employee " +
                                 "WHERE ResignationDate IS NULL " +
                                 "ORDER BY EmployeeID ASC";

                    OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);

                    DBGrids.DataSource = dt;
                    DBGrids.ReadOnly = true;

                    DBGrids.Columns["EmployeeID"].HeaderText = "사원번호";
                    DBGrids.Columns["Name"].HeaderText = "이름";
                    DBGrids.Columns["Rank"].HeaderText = "직급";
                    DBGrids.Columns["Department"].HeaderText = "부서";
                    DBGrids.Columns["HireDate"].HeaderText = "입사일";
                    DBGrids.Columns["PhoneNumber"].HeaderText = "전화번호";

                    DBGrids.Columns["HireDate"].Visible = false;     // 입사일 숨김
                    DBGrids.Columns["PhoneNumber"].Visible = false;  // 전화번호 숨김
                    DBGrids.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DBGrids.ColumnHeadersDefaultCellStyle.Font = new Font(DBGrids.Font, FontStyle.Bold);
                    DBGrids.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                    DBGrids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    DBGrids.ColumnHeadersHeight = 35; // 적절한 높이로 조절

                    // 3. 데이터 셀(내용) 스타일 설정
                    // 가운데 정렬
                    DBGrids.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // 셀 텍스트 줄바꿈 방지
                    DBGrids.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

                    // 총 인원수 라벨 업데이트
                    if (lblTotalCount != null)
                        lblTotalCount.Text = "총 인원 : " + dt.Rows.Count + "명";

                    // 그리드뷰 디자인
                    DBGrids.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DBGrids.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DBGrids.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB 연결 실패: " + ex.Message);
                }
            }
        }

        private string GetNextEmployeeID()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. 현재 연도 구하기 (예: "2025")
                    string currentYear = DateTime.Now.Year.ToString();

                    // 2. 올해 입사한 사원 중 가장 큰 번호 찾기 (예: 2025005)
                    // LIKE '2025%'를 써서 올해 번호만 찾습니다.
                    string sql = "SELECT MAX(EmployeeID) FROM Employee WHERE EmployeeID LIKE :year || '%'";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add("year", currentYear);

                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        // 올해 입사자가 한 명도 없으면 "2025001" 리턴
                        return currentYear + "001";
                    }
                    else
                    {
                        // 가장 큰 번호가 있다면 (예: "2025005")
                        string maxID = result.ToString();

                        // 뒤의 3자리만 잘라서 숫자로 바꿈 (005 -> 5)
                        int seq = int.Parse(maxID.Substring(4));

                        // 1을 더해서 다시 3자리 문자로 만듦 (6 -> "006")
                        seq++;
                        return currentYear + seq.ToString("000"); // 2025006 리턴
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("사원번호 생성 중 오류: " + ex.Message);
                    return "";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            cboRank.SelectedIndex = -1;
            cboDept.SelectedIndex = -1;
            dtpHireDate.Value = DateTime.Now;
            txtPhone.Text = "";

            txtID.Text = GetNextEmployeeID();
            txtID.Enabled = false; // 혹은 ReadOnly = true
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                // 1. [변경점] 저장 직전에 최신 사원번호 다시 생성 (중복 방지)
                string newID = GetNextEmployeeID();

                string sql = "INSERT INTO Employee (EmployeeID, Name, Rank, Department, HireDate, PhoneNumber) " +
                             "VALUES (:id, :name, :rank, :dept, :hiredate, :phone)";

                OracleCommand cmd = new OracleCommand(sql, conn);

                // 2. [변경점] 생성된 newID를 넣음
                cmd.Parameters.Add("id", newID);
                cmd.Parameters.Add("name", txtName.Text);
                cmd.Parameters.Add("rank", cboRank.Text);
                cmd.Parameters.Add("dept", cboDept.Text);
                cmd.Parameters.Add("hiredate", dtpHireDate.Value);
                cmd.Parameters.Add("phone", txtPhone.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("직원 등록 완료! 사원번호: " + newID); // 사용자에게 알려줌
                    LoadData();
                    btnReset_Click(null, null); // 초기화하면서 다음 번호 갱신
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류 발생: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Enabled == true) { MessageBox.Show("수정할 직원을 목록에서 선택하세요."); return; }

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Employee SET Name=:name, Rank=:rank, Department=:dept, HireDate=:hiredate, PhoneNumber=:phone " +
                             "WHERE EmployeeID=:id";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add("name", txtName.Text);
                cmd.Parameters.Add("rank", cboRank.Text);
                cmd.Parameters.Add("dept", cboDept.Text);
                cmd.Parameters.Add("hiredate", dtpHireDate.Value);
                cmd.Parameters.Add("phone", txtPhone.Text);
                cmd.Parameters.Add("id", txtID.Text); // 조건절

                cmd.ExecuteNonQuery();
                MessageBox.Show("수정되었습니다.");
                LoadData();
            }
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            if (txtID.Enabled == true) { MessageBox.Show("퇴사 처리할 직원을 선택하세요."); return; }

            if (MessageBox.Show("정말 퇴사 처리 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    // 퇴사일만 업데이트
                    string sql = "UPDATE Employee SET ResignationDate = SYSDATE WHERE EmployeeID = :id";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add("id", txtID.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("퇴사 처리 되었습니다.");
                    LoadData();
                    btnReset_Click(null, null);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeSearch searchPopup = new EmployeeSearch();

            // 2. 폼 띄우기 (ShowDialog는 창을 닫기 전까지 부모 창 조작 불가 - 모달 방식)
            searchPopup.ShowDialog();

            // 3. 다 쓰고나면 메모리 해제
            searchPopup.Dispose();
        }

        private void DBGrids_SelectionChanged(object sender, EventArgs e)
        {
            if (DBGrids.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DBGrids.SelectedRows[0];

                txtID.Text = row.Cells["EmployeeID"].Value.ToString(); 
                txtName.Text = row.Cells["Name"].Value.ToString();    
                cboRank.Text = row.Cells["Rank"].Value.ToString();       
                cboDept.Text = row.Cells["Department"].Value.ToString(); 

                // 입사일 (날짜 변환)
                if (DateTime.TryParse(row.Cells["HireDate"].Value.ToString(), out DateTime date)) 
                    dtpHireDate.Value = date;

                txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString(); 

                // ID는 수정 못하게 막기
                txtID.Enabled = false;
            }
        }
    }
}
