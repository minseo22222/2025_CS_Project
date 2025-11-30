using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class TradeManageForm : Form
    {
        // 공통 DB 클래스 사용
        DBCLASS dbc = new DBCLASS();

        // 나중에 Form1 이랑 연동할 때 쓸 수 있는 선택된 거래번호 (지금은 안 써도 됨)
        public int? SelectedTradeId { get; private set; }

        // 계정 정보 (필요하면 나중에 공통 상수로 빼도 됨)
        private const string DbUser = "HONG1";
        private const string DbPw = "1111";

        public TradeManageForm()
        {
            InitializeComponent();
            dbc.DB_Open(
                    "SELECT TradeID, TradeDate, TradeType, TotalAmount " +
                    "FROM Trade ORDER BY TradeID"
                );

            dbc.DB_ObjCreate();
        }

        // ★ Form2 로드 시 자동으로 거래목록 불러오기
        private void TradeManageForm_Load(object sender, EventArgs e)
        {
            LoadTradeList();

            // 그리드 기본 설정 (보기 전용)
            dgvTradeList.ReadOnly = true;
            dgvTradeList.AllowUserToAddRows = false;
            dgvTradeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTradeList.MultiSelect = false;

            dgvTradeDetail.ReadOnly = true;
            dgvTradeDetail.AllowUserToAddRows = false;
            dgvTradeDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTradeDetail.MultiSelect = false;
        }

        // 거래 목록 불러오기 (헤더)
        private void LoadTradeList()
        {
            try
            {
                dbc.DS.Clear();
                dbc.DBAdapter.Fill(dbc.DS, "Trade");    // DS 에 "Trade" 테이블 채우기

                dgvTradeList.DataSource = dbc.DS.Tables["Trade"];

                // 컬럼 헤더 한글로
                dgvTradeList.Columns["TRADEID"].HeaderText = "거래번호";
                dgvTradeList.Columns["TRADEDATE"].HeaderText = "거래일자";
                dgvTradeList.Columns["TRADETYPE"].HeaderText = "매매유형";
                dgvTradeList.Columns["TOTALAMOUNT"].HeaderText = "총금액";

                dgvTradeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "거래목록 로드 오류");
            }
        }

        // 거래목록에서 행을 클릭하면 해당 거래의 상세 불러오기
        private void dgvTradeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 헤더 클릭 방지
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvTradeList.Rows[e.RowIndex];

                // 혹시 모를 빈 값 방지
                if (row.Cells["TRADEID"].Value == DBNull.Value || row.Cells["TRADEID"].Value == null)
                    return;

                int tradeId = Convert.ToInt32(row.Cells["TRADEID"].Value);

                // 선택된 거래번호 저장(추후 Form1 연동용)
                SelectedTradeId = tradeId;

                LoadTradeDetail(tradeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "거래 선택 오류");
            }
        }

        // 특정 거래의 상세내역 조회
        private void LoadTradeDetail(int tradeId)
        {
            try
            {
                string conStr =
                    "User Id=" + DbUser + "; Password=" + DbPw + "; " +
                    "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";

                string sql = @"
                    SELECT td.TradeID,
                           td.LineNo,
                           td.ProductID,
                           p.ProductName,
                           td.Quantity,
                           td.UnitPrice,
                           td.Amount
                      FROM TradeDetail td
                      JOIN Product p
                        ON td.ProductID = p.ProductID
                     WHERE td.TradeID = :tradeId
                     ORDER BY td.LineNo";

                using (var conn = new OracleConnection(conStr))
                using (var cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Add("tradeId", tradeId);

                    using (var da = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvTradeDetail.DataSource = dt;

                        // 컬럼 헤더 한글로
                        dgvTradeDetail.Columns["TRADEID"].HeaderText = "거래번호";
                        dgvTradeDetail.Columns["LINENO"].HeaderText = "순번";
                        dgvTradeDetail.Columns["PRODUCTID"].HeaderText = "상품코드";
                        dgvTradeDetail.Columns["PRODUCTNAME"].HeaderText = "상품명";
                        dgvTradeDetail.Columns["QUANTITY"].HeaderText = "수량";
                        dgvTradeDetail.Columns["UNITPRICE"].HeaderText = "단가";
                        dgvTradeDetail.Columns["AMOUNT"].HeaderText = "금액";

                        dgvTradeDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "거래상세 로드 오류");
            }
        }
    }
}
