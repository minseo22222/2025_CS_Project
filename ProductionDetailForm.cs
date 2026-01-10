using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class ProductionDetailForm : Form
    {
        string connectionString = "User Id=hong1; Password=1111; Data Source=localhost:1521/xe";
        private string _prodID;
        private DataTable dtAllProductions; // 전체 생산 기록 저장용
<<<<<<< Updated upstream

        // UI 컨트롤 이름 추정:
        // 검색 콤보박스: cboSearchField
        // 검색 텍스트박스: txtSearch
        // 검색 버튼: btnSearch
        // 초기화 버튼: btnReset
        // 생산 기록 DataGridView: dgvAllProductions
        // (UI 컨트롤 이름이 실제와 다를 경우, 해당하는 이름으로 변경해야 합니다.)

        public ProductionDetailForm(string prodID)
        {
            InitializeComponent();
            _prodID = prodID;
            this.Text = "생산 기록 상세";
            this.Load += ProdDetailForm_Load;
=======
        private string _initialProductName;

        public ProductionDetailForm(string prodID, string productName)
        {
            InitializeComponent();
            _prodID = prodID;
            _initialProductName = productName;
            this.Text = "생산 기록 상세";
>>>>>>> Stashed changes

            // 이벤트 핸들러 연결 (기존 코드에 없었다면 추가 필요)
            btnSearch.Click += btnSearch_Click;
            btnReset.Click += btnReset_Click;
        }

        private void ProdDetailForm_Load(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            LoadAllProductions(); // 전체 생산 기록 로드

            // *** 콤보박스를 검색 필드 선택용으로 변경 (LoadProductCombo() 대체) ***
            SetupSearchCombo();

            // 전달받은 생산번호가 있으면 해당 기록 표시
=======
            LoadAllProductions(); 
            SetupSearchCombo();

            if (!string.IsNullOrEmpty(_initialProductName))
            {

                DataView dv = new DataView(dtAllProductions);

                dv.RowFilter = $"제품명 = '{_initialProductName.Replace("'", "''")}'";

                if (dv.Count == 0)
                {
                    MessageBox.Show($"'{_initialProductName}' 제품의 생산 내역이 없습니다.",
                                    "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // 창 닫기
                    return;
                }

                cboSearchField.SelectedItem = "제품명";
                txtSearch.Text = _initialProductName;
                btnSearch.PerformClick(); // 검색 실행
            }

>>>>>>> Stashed changes
            if (!string.IsNullOrEmpty(_prodID))
            {
                LoadDetailByProdID(_prodID);
            }
        }

<<<<<<< Updated upstream
        // ===================================
        // 전체 생산 기록 조회
        // ===================================
=======
>>>>>>> Stashed changes
        private void LoadAllProductions()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT h.ProdID AS 생산번호, 
                               p.ProductName AS 제품명, 
                               h.ProdDate AS 생산일자,
                               h.TotalQty AS 총생산량,
                               h.DefectQty AS 불량수량,
                               h.GoodQty AS 양품수량,
                               h.Manager AS 담당자
                        FROM PRODUCTIONHISTORY h
                        JOIN PRODUCT p ON h.ProductID = p.ProductID
                        ORDER BY h.ProdDate DESC, h.ProdID DESC";

                    OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
                    dtAllProductions = new DataTable();
                    oda.Fill(dtAllProductions);

                    dgvAllProductions.DataSource = dtAllProductions;
                    dgvAllProductions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // 행 클릭 이벤트 연결
                    dgvAllProductions.SelectionChanged += DgvAllProductions_SelectionChanged;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("생산 기록 로드 오류: " + ex.Message);
                }
            }
        }

        // ===================================
        // *** 새로운 검색 필드 콤보박스 설정 ***
        // (기존 LoadProductCombo() 함수 대체)
        // ===================================
        private void SetupSearchCombo()
        {
            // 컨트롤 이름이 cboSearchField라고 가정합니다.
            cboSearchField.Items.Clear();
            cboSearchField.Items.Add("제품명");
            cboSearchField.Items.Add("생산번호");
            cboSearchField.Items.Add("담당자");
            cboSearchField.Items.Add("생산일자");
            cboSearchField.SelectedIndex = 0; // 기본값: 제품명
        }

        // (LoadDetailByProdID와 DgvAllProductions_SelectionChanged는 변경 없음)
        // ... LoadDetailByProdID 및 DgvAllProductions_SelectionChanged 코드는 그대로 유지 ...
        // ===================================
        // 그리드에서 생산 기록 선택 시
        // ===================================
        private void DgvAllProductions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAllProductions.SelectedRows.Count == 0) return;

            string selectedProdID = dgvAllProductions.SelectedRows[0].Cells["생산번호"].Value.ToString();
            LoadDetailByProdID(selectedProdID);
        }

        // ===================================
        // 특정 생산번호의 상세 정보 로드
        // ===================================
        private void LoadDetailByProdID(string prodID)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. 생산 기본 정보 조회
                    string sqlInfo = @"
                        SELECT h.ProdID, p.ProductName, h.Manager, h.ProdDate, 
                               h.TotalQty, h.DefectQty, h.GoodQty 
                        FROM PRODUCTIONHISTORY h 
                        JOIN PRODUCT p ON h.ProductID = p.ProductID 
                        WHERE h.ProdID = :prodID";

                    OracleCommand cmdInfo = new OracleCommand(sqlInfo, conn);
                    cmdInfo.Parameters.Add("prodID", prodID);
                    OracleDataReader rdr = cmdInfo.ExecuteReader();

                    if (rdr.Read())
                    {
                        // UI 컨트롤 이름이 txtDetailProdID, txtDetailProductName 등으로 가정합니다.
                        txtDetailProdID.Text = rdr["PRODID"].ToString();
                        txtDetailProductName.Text = rdr["PRODUCTNAME"].ToString();
                        txtDetailManager.Text = rdr["MANAGER"].ToString();

                        if (rdr["PRODDATE"] != DBNull.Value)
                            txtDetailDate.Text = Convert.ToDateTime(rdr["PRODDATE"]).ToString("yyyy-MM-dd");

                        txtDetailTotal.Text = rdr["TOTALQTY"].ToString();
                        txtDetailDefect.Text = rdr["DEFECTQTY"].ToString();
                        txtDetailGood.Text = rdr["GOODQTY"].ToString();
                    }
                    rdr.Close();

                    // 2. 투입 자재 상세 목록 조회 (이 코드는 변경 없이 유지)
                    string sqlMaterials = @"
                        SELECT p.ProductName AS 원자재명, pm.Quantity AS 투입수량 
                        FROM PRODUCTIONMATERIALS pm 
                        JOIN PRODUCT p ON pm.MaterialID = p.ProductID 
                        WHERE pm.ProdID = :prodID";

                    OracleDataAdapter oda = new OracleDataAdapter(sqlMaterials, conn);
                    oda.SelectCommand.Parameters.Add("prodID", prodID);

                    DataTable dtMaterials = new DataTable();
                    oda.Fill(dtMaterials);

                    // UI 컨트롤 이름이 dgvDetailMaterials라고 가정합니다.
                    dgvDetailMaterials.DataSource = dtMaterials;
                    dgvDetailMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("상세 정보 로드 오류: " + ex.Message);
                }
            }
        }

        // ===================================
        // 검색 버튼 클릭 (수정됨)
        // ===================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtAllProductions == null || cboSearchField.SelectedItem == null) return;

            string selectedField = cboSearchField.SelectedItem.ToString();
            string searchKeyword = txtSearch.Text.Trim();
            string filter = "";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                // SQL LIKE 문에서 사용되는 와일드카드 문자를 이스케이프 처리
                string escapedKeyword = searchKeyword.Replace("'", "''");

                // 선택된 필드에 따라 필터 문자열 생성
                switch (selectedField)
                {
                    case "생산번호":
                        filter = $"생산번호 LIKE '%{escapedKeyword}%'";
                        break;
                    case "제품명":
                        filter = $"제품명 LIKE '%{escapedKeyword}%'";
                        break;
                    case "담당자":
                        filter = $"담당자 LIKE '%{escapedKeyword}%'";
                        break;
                    case "생산일자":
                        // 날짜 검색의 경우, DataTable의 ProdDate 컬럼이 문자열 형태라면 LIKE 사용 가능
                        // 만약 DataTable에서 ProdDate가 DateTime 형식이면, 변환 또는 다른 방식의 필터링 필요
                        // 여기서는 데이터 로드 시 ProdDate가 '생산일자'로 별칭되었고,
                        // DataRowView의 RowFilter는 문자열 비교를 하기 때문에 LIKE를 사용합니다.
                        filter = $"Convert(생산일자, 'System.String') LIKE '%{escapedKeyword}%'";
                        break;
                    default:
                        // 모든 필드에서 검색
                        filter = $"(생산번호 LIKE '%{escapedKeyword}%' OR " +
                                 $"제품명 LIKE '%{escapedKeyword}%' OR " +
                                 $"담당자 LIKE '%{escapedKeyword}%' OR " +
                                 $"Convert(생산일자, 'System.String') LIKE '%{escapedKeyword}%')";
                        break;
                }
            }

            // 필터 적용
            DataView dv = dtAllProductions.DefaultView;
            dv.RowFilter = filter;
            dgvAllProductions.DataSource = dv;
        }

        // ===================================
        // 초기화 버튼 클릭 (수정됨: 콤보박스 초기화)
        // ===================================
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboSearchField.SelectedIndex = 0; // 제품명으로 초기화
            txtSearch.Clear();

            if (dtAllProductions != null)
            {
                dtAllProductions.DefaultView.RowFilter = "";
                dgvAllProductions.DataSource = dtAllProductions;
            }
        }

        // ===================================
        // 닫기 버튼
        // ===================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}