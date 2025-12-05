using System;
using System.Data;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class WarehouseSelectForm : Form
    {
        // 공통 DB 클래스
        DBCLASS dbc = new DBCLASS();

        // Form1 / TradeManageForm 에서 받아갈 값
        public int SelectedWarehouseId { get; private set; }
        public string SelectedWarehouseName { get; private set; }

        // 검색용으로 전체 창고 목록을 보관할 테이블
        private DataTable _warehouseTable;

        // ─────────────────────────────────────
        // 생성자
        // ─────────────────────────────────────
        public WarehouseSelectForm()
        {
            InitializeComponent();

            try
            {
                // 1) DB 어댑터 준비
                dbc.DB_ObjCreate();

                // 2) 창고 목록 조회용 기본 SELECT
                dbc.DB_Open(
                    "SELECT WarehouseID, WarehouseName " +
                    "FROM Warehouse " +
                    "ORDER BY WarehouseID");

                // 3) DataSet 에 Warehouse 테이블 채우기 ★★
                dbc.DBAdapter.Fill(dbc.DS, "Warehouse");

                // 4) 검색/바인딩에 사용할 DataTable 참조 보관
                _warehouseTable = dbc.DS.Tables["Warehouse"];

                // 5) 그리드에 바인딩
                dgvWarehouse.DataSource = _warehouseTable;
                dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvWarehouse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvWarehouse.MultiSelect = false;
                dgvWarehouse.ReadOnly = true;
                dgvWarehouse.AllowUserToAddRows = false;

                // 6) 컬럼 헤더 한글 표시 (컬럼이 존재할 때만)
                if (dgvWarehouse.Columns.Contains("WAREHOUSEID"))
                    dgvWarehouse.Columns["WAREHOUSEID"].HeaderText = "창고코드";
                if (dgvWarehouse.Columns.Contains("WAREHOUSENAME"))
                    dgvWarehouse.Columns["WAREHOUSENAME"].HeaderText = "창고명";
            }
            catch (Exception ex)
            {
                MessageBox.Show("창고 목록 로드 중 오류가 발생했습니다.\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────
        // 현재 그리드 선택을 TextBox 에 표시
        // ─────────────────────────────────────
        private void UpdateSelectedWarehouseTextFromGrid()
        {
            if (dgvWarehouse.CurrentRow == null)
            {
                txtSelectedWarehouse.Text = "";
                return;
            }

            var row = dgvWarehouse.CurrentRow;

            // 실제 컬럼명은 WAREHOUSEID / WAREHOUSENAME 으로 들어옴
            object idObj = row.Cells["WAREHOUSEID"].Value;
            object nameObj = row.Cells["WAREHOUSENAME"].Value;

            if (idObj == null || idObj == DBNull.Value) return;

            int id = Convert.ToInt32(idObj);
            string name = Convert.ToString(nameObj);

            // TextBox 에 현재 선택된 창고명 표시
            txtSelectedWarehouse.Text = name;

            // 호출 폼에서 사용할 값도 함께 세팅
            SelectedWarehouseId = id;
            SelectedWarehouseName = name;
        }

        // ─────────────────────────────────────
        // 그리드 셀 더블클릭 → 선택 완료
        // ─────────────────────────────────────
        private void dgvWarehouse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 클릭된 행 기준으로 선택 정보 업데이트
            dgvWarehouse.CurrentCell = dgvWarehouse.Rows[e.RowIndex].Cells[0];
            UpdateSelectedWarehouseTextFromGrid();

            if (SelectedWarehouseId <= 0)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 셀 클릭 시 → 아래 TextBox 에 반영
        private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            UpdateSelectedWarehouseTextFromGrid();
        }

        // 키보드 ↑↓ 로 선택 이동 시에도 반영
        private void dgvWarehouse_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedWarehouseTextFromGrid();
        }

        // ─────────────────────────────────────
        // 확인 버튼 클릭
        // ─────────────────────────────────────
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.CurrentRow == null)
            {
                MessageBox.Show("창고를 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateSelectedWarehouseTextFromGrid();

            if (SelectedWarehouseId <= 0)
            {
                MessageBox.Show("창고를 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ─────────────────────────────────────
        // 취소 버튼 클릭
        // ─────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ─────────────────────────────────────
        // 검색 TextBox 에서 Enter 키 → 검색 버튼 실행
        // ─────────────────────────────────────
        private void txtSearchWarehouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;       // 삑 소리 방지
                btnSearchWarehouse_Click(sender, EventArgs.Empty);
            }
        }

        // ─────────────────────────────────────
        // 검색 버튼 클릭 : 창고명/코드 검색
        // ─────────────────────────────────────
        private void btnSearchWarehouse_Click(object sender, EventArgs e)
        {
            if (_warehouseTable == null) return;

            string keyword = txtSearchWarehouse.Text.Trim();
            keyword = keyword.Replace("'", "''"); // RowFilter 문법 보호

            if (string.IsNullOrEmpty(keyword))
            {
                // 검색어 비어 있으면 전체 표시
                _warehouseTable.DefaultView.RowFilter = "";
            }
            else
            {
                // 창고명 + 창고코드(문자열 변환) 둘 다에서 부분검색
                _warehouseTable.DefaultView.RowFilter =
                    $"WAREHOUSENAME LIKE '%{keyword}%' " +
                    $"OR Convert(WAREHOUSEID, 'System.String') LIKE '%{keyword}%'";
            }

            // 필터 이후 첫 행으로 포커스 이동
            if (dgvWarehouse.Rows.Count > 0)
            {
                dgvWarehouse.CurrentCell = dgvWarehouse.Rows[0].Cells[0];
            }
            UpdateSelectedWarehouseTextFromGrid();
        }
    }
}
