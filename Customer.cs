using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class Customer : UserControl
    {
        DBCLASS dbc = new DBCLASS();

        public Customer()
        {
            InitializeComponent();

            // DB 객체 생성 + SELECT 문 세팅
            dbc.DB_ObjCreate();
            dbc.DB_Open("SELECT * FROM customer");
        }

        /// <summary>
        /// customer 테이블을 가져오고 PrimaryKey(CUSTOMERID)를 설정해 주는 공통 함수
        /// </summary>
        private DataTable GetCustomerTable()
        {
            // DataSet 안에 아직 customer 테이블이 없으면 채움
            if (!dbc.DS.Tables.Contains("customer"))
            {
                dbc.DBAdapter.Fill(dbc.DS, "customer");
            }

            DataTable table = dbc.DS.Tables["customer"];

            // PrimaryKey 한 번만 설정
            if (table.PrimaryKey == null || table.PrimaryKey.Length == 0)
            {
                table.PrimaryKey = new DataColumn[] { table.Columns["CUSTOMERID"] };
            }

            return table;
        }

        // ====================== SHOW 버튼 ======================
        private void ShowDBBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.DS.Clear();
                dbc.DBAdapter.Fill(dbc.DS, "customer");

                DataTable table = dbc.DS.Tables["customer"];
                DBGrid.DataSource = table.DefaultView;

                DBGrid.Columns["CUSTOMERID"].HeaderText = "거래처번호";
                DBGrid.Columns["BUSINESSNO"].HeaderText = "사업자번호";
                DBGrid.Columns["CUSTOMERNAME"].HeaderText = "거래처명";
                DBGrid.Columns["ADDRESS"].HeaderText = "주소";
                DBGrid.Columns["REPRESENTATIVE"].HeaderText = "대표자이름";
                DBGrid.Columns["PHONE"].HeaderText = "전화번호";
                DBGrid.Columns["FAX"].HeaderText = "FAX번호";
            }
            catch (DataException de) { MessageBox.Show(de.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ====================== ADD 버튼 ======================
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) 거래처번호 숫자 체크
                if (!int.TryParse(txtid.Text, out int custId))
                {
                    MessageBox.Show("거래처번호는 숫자로 입력하세요.");
                    txtid.Focus();
                    return;
                }

                // 2) 거래처명 NOT NULL 체크
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("거래처명은 필수 입력 항목입니다.");
                    txtName.Focus();
                    return;
                }

                DataTable table = GetCustomerTable();

                // 3) PK 중복 체크
                if (table.Rows.Find(custId) != null)
                {
                    MessageBox.Show("이미 존재하는 거래처번호입니다.");
                    txtid.Focus();
                    return;
                }

                // 4) 새 행 생성 + 값 채우기
                DataRow newRow = table.NewRow();
                newRow["CUSTOMERID"] = custId;                     // txtid
                newRow["BUSINESSNO"] = txtid2.Text.Trim();
                newRow["CUSTOMERNAME"] = txtName.Text.Trim();
                newRow["ADDRESS"] = txtAddr.Text.Trim();
                newRow["REPRESENTATIVE"] = txtPName.Text.Trim();
                newRow["PHONE"] = txtPhone.Text.Trim();
                newRow["FAX"] = txtFax.Text.Trim();

                table.Rows.Add(newRow);

                // 5) DB 반영
                dbc.DBAdapter.Update(dbc.DS, "customer");

                DBGrid.DataSource = table.DefaultView;
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ====================== UPDATE 버튼 ======================
        private void UpdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtid.Text, out int custId))
                {
                    MessageBox.Show("수정할 거래처번호를 먼저 선택하세요.");
                    txtid.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("거래처명은 필수 입력 항목입니다.");
                    txtName.Focus();
                    return;
                }

                DataTable table = GetCustomerTable();

                // PK로 행 찾기
                DataRow row = table.Rows.Find(custId);
                if (row == null)
                {
                    MessageBox.Show("수정할 거래처를 찾을 수 없습니다.");
                    return;
                }

                row["BUSINESSNO"] = txtid2.Text.Trim();
                row["CUSTOMERNAME"] = txtName.Text.Trim();
                row["ADDRESS"] = txtAddr.Text.Trim();
                row["REPRESENTATIVE"] = txtPName.Text.Trim();
                row["PHONE"] = txtPhone.Text.Trim();
                row["FAX"] = txtFax.Text.Trim();

                dbc.DBAdapter.Update(dbc.DS, "customer");

                DBGrid.DataSource = table.DefaultView;
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ====================== DELETE 버튼 ======================
        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtid.Text, out int custId))
                {
                    MessageBox.Show("삭제할 거래처번호를 먼저 선택하세요.");
                    txtid.Focus();
                    return;
                }

                if (MessageBox.Show("정말 삭제하시겠습니까?",
                                    "삭제 확인",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                DataTable table = GetCustomerTable();

                DataRow row = table.Rows.Find(custId);
                if (row == null)
                {
                    MessageBox.Show("삭제할 거래처를 찾을 수 없습니다.");
                    return;
                }

                row.Delete(); // 행 삭제 표시

                dbc.DBAdapter.Update(dbc.DS, "customer");

                DBGrid.DataSource = table.DefaultView;
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ====================== 그리드 클릭 → 텍스트박스 채우기 ======================
        private void DBGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataTable table = GetCustomerTable();

                if (e.RowIndex > table.Rows.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }

                DataRow currRow = table.Rows[e.RowIndex];

                txtid.Text = currRow["CUSTOMERID"].ToString();
                txtid2.Text = currRow["BUSINESSNO"].ToString();
                txtName.Text = currRow["CUSTOMERNAME"].ToString();
                txtAddr.Text = currRow["ADDRESS"].ToString();
                txtPName.Text = currRow["REPRESENTATIVE"].ToString();
                txtPhone.Text = currRow["PHONE"].ToString();
                txtFax.Text = currRow["FAX"].ToString();
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                // 항상 최신 customer 테이블 가져오기
                DataTable table = GetCustomerTable();
                DataView view = table.DefaultView;

                // 검색어가 비어 있으면 필터 해제 = 전체 보기
                if (string.IsNullOrEmpty(keyword))
                {
                    view.RowFilter = "";   // 필터 제거
                    DBGrid.DataSource = view;
                    return;
                }

                // RowFilter에 들어갈 따옴표 이스케이프
                string escaped = keyword.Replace("'", "''");

                // 숫자로만 되어 있으면: 거래처번호로 검색 + 이름에도 같이 검색
                if (int.TryParse(keyword, out int custId))
                {
                    // CUSTOMERID = 숫자 OR CUSTOMERNAME LIKE '%키워드%'
                    view.RowFilter =
                        $"CUSTOMERID = {custId} OR CUSTOMERNAME LIKE '%{escaped}%'";
                }
                else
                {
                    // 글자로 검색할 땐 거래처명에 포함되는지 검색
                    view.RowFilter = $"CUSTOMERNAME LIKE '%{escaped}%'";
                }

                DBGrid.DataSource = view;
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
