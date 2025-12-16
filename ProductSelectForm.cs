using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class ProductSelectForm : Form
    {
        // Form2 에서 넘겨주는 정보
        public string TradeType { get; set; }      // "매입" / "매출"
        public string WarehouseName { get; set; }  // 창고명(텍스트박스에서 받음)

        // 선택 결과
        public int SelectedProductId { get; private set; }
        public string SelectedProductName { get; private set; }
        public int SelectedQuantity { get; private set; } = 1;
        public decimal SelectedUnitPrice { get; private set; }

        // DB 접속 계정
        private const string DbUser = "HONG1";
        private const string DbPw = "1111";

        public ProductSelectForm()
        {
            InitializeComponent();
        }

        // ▷ Oracle 접속 문자열
        private string GetConnectionString()
        {
            return
                "User Id=" + DbUser + "; Password=" + DbPw + "; " +
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";
        }

        // ▷ 폼 로드 시 상품 목록 로드
        private void ProductSelectForm_Load(object sender, EventArgs e)
        {
            txtQty.Text = "1";   // 기본 수량 1
            LoadProductList();
        }

        // ▷ TradeType 에 따라 category(완제품/원재료) 로만 필터링해서 상품 목록 로드
        private void LoadProductList()
        {
            string conStr = GetConnectionString();

            // 1) 매입/매출 → category 로 변환
            string categoryFilter = null;

            if (!string.IsNullOrWhiteSpace(TradeType))
            {
                string tt = TradeType.Trim();
                if (tt == "매입")
                    categoryFilter = "원재료";   // 매입 시 원재료만
                else if (tt == "매출")
                    categoryFilter = "완제품";  // 매출 시 완제품만
            }

            // 2) Product 테이블만 사용 (Inventory, Warehouse 조인 X)
            string sql = @"
        SELECT ProductID,
               ProductName,
               UnitPrice,
               category AS CATEGORY
          FROM Product
         WHERE 1 = 1";

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                sql += " AND category = :category";
            }

            sql += " ORDER BY ProductID";

            try
            {
                using (var conn = new OracleConnection(conStr))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(categoryFilter))
                    {
                        cmd.Parameters.Add("category", OracleDbType.Varchar2).Value = categoryFilter;
                    }

                    using (var da = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvProduct.DataSource = dt;

                        // 컬럼 한글 헤더
                        if (dgvProduct.Columns.Contains("PRODUCTID"))
                            dgvProduct.Columns["PRODUCTID"].HeaderText = "상품코드";
                        if (dgvProduct.Columns.Contains("PRODUCTNAME"))
                            dgvProduct.Columns["PRODUCTNAME"].HeaderText = "상품명";
                        if (dgvProduct.Columns.Contains("UNITPRICE"))
                            dgvProduct.Columns["UNITPRICE"].HeaderText = "단가";
                        if (dgvProduct.Columns.Contains("CATEGORY"))
                            dgvProduct.Columns["CATEGORY"].HeaderText = "분류";

                        dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvProduct.ReadOnly = true;
                        dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvProduct.MultiSelect = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("상품 목록 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ▷ OK 버튼 클릭 : 현재 선택된 행 + 수량을 돌려줌
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow == null)
            {
                MessageBox.Show("선택된 상품이 없습니다.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("수량은 1 이상의 정수로 입력하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQty.Focus();
                return;
            }

            SelectedQuantity = qty;

            // DataGridView → DataRowView 가져오기
            var drv = dgvProduct.CurrentRow.DataBoundItem as DataRowView;
            if (drv != null)
            {
                SelectedProductId = Convert.ToInt32(drv["PRODUCTID"]);
                SelectedProductName = drv["PRODUCTNAME"].ToString();
                SelectedUnitPrice = Convert.ToDecimal(drv["UNITPRICE"]);
            }
            else
            {
                SelectedProductId = Convert.ToInt32(
                    dgvProduct.CurrentRow.Cells["PRODUCTID"].Value);
                SelectedProductName =
                    dgvProduct.CurrentRow.Cells["PRODUCTNAME"].Value.ToString();
                SelectedUnitPrice = Convert.ToDecimal(
                    dgvProduct.CurrentRow.Cells["UNITPRICE"].Value);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ▷ Cancel 버튼 클릭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ▷ 행 더블클릭 시 OK 버튼과 동일하게 동작
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnOK.PerformClick();
        }
    }
}
