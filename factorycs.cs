using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace _2025_CS_Project
{
    public partial class factorycs : UserControl
    {
        string connectionString = "User Id=hong1; Password=1111; Data Source=localhost:1521/xe";

        // 자재 목록 관리용 임시 테이블 (MaterialID 컬럼 추가됨)
        DataTable dtTempMaterials = new DataTable();

        private string selectedProdID = null;

        public factorycs()
        {
            InitializeComponent();
            InitializeMaterialGrid();
        }

        private void Production_Load(object sender, EventArgs e)
        {
            LoadProductCombo(); // 완제품 목록 불러오기
            LoadMaterialCombo();
            LoadHistory();      // 이력 조회

            // 이벤트 연결
            cboProduct.SelectedIndexChanged += CboProduct_SelectedIndexChanged;
            numTotal.ValueChanged += RecalculateMaterials; // 생산량 바뀌면 자재량도 다시 계산

            numDefect.ValueChanged += NumDefect_ValueChanged;
            dgvHistory.CellClick += DgvHistory_CellClick;
        }

        private void NumDefect_ValueChanged(object sender, EventArgs e)
        {
            int totalProd = (int)numTotal.Value;
            int defect = (int)numDefect.Value;

            if (defect > totalProd) defect = totalProd;
            txtGood.Text = (totalProd - defect).ToString();

            // 자재는 건드리지 않음!
        }

        private void DgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 헤더 클릭 무시

            DataGridViewRow row = dgvHistory.Rows[e.RowIndex];

            selectedProdID = row.Cells["ProdID"].Value.ToString();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 생산 이력 기본 정보 가져오기
                    string sql = "SELECT ProductID, TotalQty, DefectQty, GoodQty, Manager " +
                                 "FROM PRODUCTIONHISTORY WHERE ProdID = :pid";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add("pid", selectedProdID);

                    OracleDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        cboProduct.SelectedValue = rdr["ProductID"];
                        numTotal.Value = Convert.ToInt32(rdr["TotalQty"]);
                        numDefect.Value = Convert.ToInt32(rdr["DefectQty"]);
                        txtGood.Text = rdr["GoodQty"].ToString();
                        txtManager.Text = rdr["Manager"].ToString();
                    }
                    rdr.Close();

                    // 사용된 자재 목록 가져오기
                    dtTempMaterials.Clear();

                    string sqlMat = "SELECT pm.MaterialID, p.ProductName, pm.Quantity " +
                                   "FROM PRODUCTIONMATERIALS pm " +
                                   "JOIN PRODUCT p ON pm.MaterialID = p.ProductID " +
                                   "WHERE pm.ProdID = :pid";

                    OracleCommand cmdMat = new OracleCommand(sqlMat, conn);
                    cmdMat.Parameters.Add("pid", selectedProdID);

                    OracleDataReader rdrMat = cmdMat.ExecuteReader();
                    while (rdrMat.Read())
                    {
                        DataRow matRow = dtTempMaterials.NewRow();
                        matRow["MaterialID"] = rdrMat["MaterialID"];
                        matRow["MaterialName"] = rdrMat["ProductName"];
                        matRow["UnitQty"] = 0; // 수정 모드에서는 의미 없음
                        matRow["TotalQty"] = rdrMat["Quantity"];
                        dtTempMaterials.Rows.Add(matRow);
                    }
                    rdrMat.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("이력 조회 오류: " + ex.Message);
                }
            }
        }
        // =========================================================
        // 1. 초기 세팅 & 콤보박스 로드
        // =========================================================
        private void InitializeMaterialGrid()
        {
            dtTempMaterials.Columns.Add("MaterialID", typeof(int));    // 숨겨진 ID
            dtTempMaterials.Columns.Add("MaterialName", typeof(string));
            dtTempMaterials.Columns.Add("TotalQty", typeof(int));      // 총 투입 수량

            dgvMaterials.DataSource = dtTempMaterials;

            dgvMaterials.Columns["MaterialID"].Visible = false; // ID는 안보이게
            dgvMaterials.Columns["MaterialName"].HeaderText = "원자재명";
            dgvMaterials.Columns["TotalQty"].HeaderText = "총 투입량";

            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadMaterialCombo()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Product 테이블에서 category가 '원재료'인 항목만 가져오기
                    string sql = "SELECT ProductID, ProductName FROM PRODUCT WHERE category = '원재료' ORDER BY ProductName";
                    OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);

                    cboMaterial.DisplayMember = "ProductName"; // 사용자에게 보이는 글자
                    cboMaterial.ValueMember = "ProductID";     // 내부적으로 쓰는 값(ID)
                    cboMaterial.DataSource = dt;
                    cboMaterial.SelectedIndex = -1; // 초기엔 선택 해제
                }
                catch (Exception ex)
                {
                    MessageBox.Show("원자재 로드 오류: " + ex.Message);
                }
            }
        }

        private void LoadProductCombo()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // category가 '완제품'인 것만 가져오기
                    string sql = "SELECT ProductID, ProductName FROM PRODUCT WHERE category = '완제품' ORDER BY ProductName";
                    OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);

                    cboProduct.DisplayMember = "ProductName"; // 사용자에게 보이는 글자
                    cboProduct.ValueMember = "ProductID";     // 내부적으로 쓰는 값(ID)
                    cboProduct.DataSource = dt;
                    cboProduct.SelectedIndex = -1; // 초기엔 아무것도 선택 안함
                }
                catch (Exception ex)
                {
                    MessageBox.Show("상품 로드 오류: " + ex.Message);
                }
            }
        }

        // =========================================================
        // 2. 핵심 로직: BOM 연동 & 자동 계산
        // =========================================================

        // 완제품 선택 시 -> BOM 테이블에서 자재 긁어오기
        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex == -1 || cboProduct.SelectedValue == null) return;

            // 값이 숫자가 아닌 경우(로딩 중) 방지
            if (!int.TryParse(cboProduct.SelectedValue.ToString(), out int parentID)) return;

            dtTempMaterials.Clear(); // 기존 목록 비우기

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // BOM 테이블과 Product 테이블 조인 (자재명 가져오기 위함)
                    string sql = "SELECT b.ChildID, p.ProductName, b.RequiredQty " +
                                 "FROM BOM b " +
                                 "JOIN PRODUCT p ON b.ChildID = p.ProductID " +
                                 "WHERE b.ParentID = :pid";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add("pid", parentID);

                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        DataRow row = dtTempMaterials.NewRow();
                        row["MaterialID"] = rdr["ChildID"];
                        row["MaterialName"] = rdr["ProductName"];
                        row["TotalQty"] = 0; // 일단 0, 아래 Recalculate에서 계산
                        dtTempMaterials.Rows.Add(row);
                    }
                    rdr.Close();

                    // 불러온 후 수량 재계산
                    RecalculateMaterials(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("BOM 조회 오류: " + ex.Message);
                }
            }
        }

        // 생산량(numTotal)이 바뀌면 자재 총 소요량도 자동 변경
        private void RecalculateMaterials(object sender, EventArgs e)
        {
            int totalProd = (int)numTotal.Value;
            int defect = (int)numDefect.Value;

            // 양품 계산
            if (defect > totalProd) defect = totalProd;
            txtGood.Text = (totalProd - defect).ToString();

            // 자재 소요량 계산 (생산량 * BOM소요량)
            foreach (DataRow row in dtTempMaterials.Rows)
            {
                int unitQty = Convert.ToInt32(row["UnitQty"]);
                if (unitQty > 0) // BOM 기반 자재만 재계산
                {
                    row["TotalQty"] = unitQty * totalProd;
                }
            }
        }

        // =========================================================
        // 3. 저장 로직 (Inventory 재고 반영 포함)
        // =========================================================
        private void btnFinalRegister_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex == -1) { MessageBox.Show("완제품을 선택하세요."); return; }
            if (numTotal.Value <= 0) { MessageBox.Show("생산 수량을 입력하세요."); return; }

            int prodID = Convert.ToInt32(cboProduct.SelectedValue);
            int totalQty = (int)numTotal.Value;
            int goodQty = int.Parse(txtGood.Text);

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                OracleTransaction trans = conn.BeginTransaction();

                try
                {
                    // (1) 생산 ID 생성 (P + 날짜 + 순번)
                    string newProdID = GetNextProductionID(conn);

                    // (2) 생산 이력 저장 (ProductionHistory)
                    string sqlHist = "INSERT INTO PRODUCTIONHISTORY (ProdID, ProductID, ProdDate, TotalQty, DefectQty, GoodQty, Manager) " +
                                     "VALUES (:id, :pid, SYSDATE, :total, :defect, :good, :mgr)";

                    OracleCommand cmdHist = new OracleCommand(sqlHist, conn);
                    cmdHist.Transaction = trans;
                    cmdHist.Parameters.Add("id", newProdID);
                    cmdHist.Parameters.Add("pid", prodID);
                    cmdHist.Parameters.Add("total", totalQty);
                    cmdHist.Parameters.Add("defect", (int)numDefect.Value);
                    cmdHist.Parameters.Add("good", goodQty);
                    cmdHist.Parameters.Add("mgr", txtManager.Text);
                    cmdHist.ExecuteNonQuery();

                    // (3) 생산 자재 저장 및 **원자재 재고 차감**
                    foreach (DataRow row in dtTempMaterials.Rows)
                    {
                        int matID = Convert.ToInt32(row["MaterialID"]);
                        int usedQty = Convert.ToInt32(row["TotalQty"]);

                        // 3-1. 실적 테이블 저장
                        string sqlMat = "INSERT INTO PRODUCTIONMATERIALS (No, ProdID, MaterialID, Quantity) " +
                                        "VALUES (seq_production_materials.NEXTVAL, :pid, :mid, :qty)";
                        OracleCommand cmdMat = new OracleCommand(sqlMat, conn);
                        cmdMat.Transaction = trans;
                        cmdMat.Parameters.Add("pid", newProdID);
                        cmdMat.Parameters.Add("mid", matID);
                        cmdMat.Parameters.Add("qty", usedQty);
                        cmdMat.ExecuteNonQuery();

                        // 3-2. Inventory 테이블에서 원자재 감소 (모든 창고 합산 혹은 특정 창고 지정 필요. 여기선 임의의 창고나 전체 감소 로직 필요)
                        // **주의**: Inventory는 (WarehouseID, ProductID)가 PK입니다.
                        // 로직 단순화를 위해 1번 창고(WarehouseID=1)에서 뺀다고 가정하겠습니다.
                        string sqlInvenMinus = "UPDATE INVENTORY SET Quantity = Quantity - :qty " +
                                               "WHERE ProductID = :pid AND WarehouseID = 1";
                        // 만약 데이터가 없으면 Insert가 필요할 수도 있으나, 원자재는 보통 입고가 먼저 되어있다고 가정.

                        OracleCommand cmdInvM = new OracleCommand(sqlInvenMinus, conn);
                        cmdInvM.Transaction = trans;
                        cmdInvM.Parameters.Add("qty", usedQty);
                        cmdInvM.Parameters.Add("pid", matID);
                        int updated = cmdInvM.ExecuteNonQuery();

                        if (updated == 0) // 해당 창고에 재고 데이터가 아예 없던 경우
                        {
                            // 에러를 띄우거나, 마이너스 재고로 Insert (정책에 따라 다름)
                            // 여기서는 0에서 뺌
                            string sqlInsert = "INSERT INTO INVENTORY (WarehouseID, ProductID, Quantity) VALUES (1, :pid, -:qty)";
                            OracleCommand cmdIns = new OracleCommand(sqlInsert, conn);
                            cmdIns.Transaction = trans;
                            cmdIns.Parameters.Add("pid", matID);
                            cmdIns.Parameters.Add("qty", usedQty);
                            cmdIns.ExecuteNonQuery();
                        }
                    }

                    // (4) **완제품 재고 증가** (Inventory) - 역시 1번 창고 가정
                    string sqlInvenPlus = "MERGE INTO INVENTORY i " +
                                          "USING DUAL ON (i.WarehouseID = 1 AND i.ProductID = :pid) " +
                                          "WHEN MATCHED THEN UPDATE SET Quantity = Quantity + :qty " +
                                          "WHEN NOT MATCHED THEN INSERT (WarehouseID, ProductID, Quantity) VALUES (1, :pid, :qty)";

                    OracleCommand cmdInvP = new OracleCommand(sqlInvenPlus, conn);
                    cmdInvP.Transaction = trans;
                    cmdInvP.Parameters.Add("pid", prodID);
                    cmdInvP.Parameters.Add("qty", goodQty); // 양품 수량만큼 증가
                    cmdInvP.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("생산 완료! 재고가 반영되었습니다.");
                    LoadHistory();

                    RefreshInventoryPage();
                    // 초기화
                    numTotal.Value = 0;
                    dtTempMaterials.Clear();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("생산 처리 실패: " + ex.Message);
                }
            }
        }

        private void RefreshInventoryPage()
        {
            // 부모 폼(Form1)을 찾아서 InventoryPage를 새로고침
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                foreach (Control ctrl in parentForm.Controls)
                {
                    if (ctrl is InventoryPage)
                    {
                        ((InventoryPage)ctrl).RefreshInventory();
                        break;
                    }
                }
            }
        }

        // ID 생성 함수 (이전과 동일)
        private string GetNextProductionID(OracleConnection conn)
        {
            string datePrefix = "P" + DateTime.Now.ToString("yyyyMMdd");
            string sql = "SELECT MAX(ProdID) FROM PRODUCTIONHISTORY WHERE ProdID LIKE :prefix || '%'";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add("prefix", datePrefix);
            object result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value) return datePrefix + "001";
            int seq = int.Parse(result.ToString().Substring(9));
            return datePrefix + (++seq).ToString("000");
        }

        // 이력 조회 함수 (조인해서 이름 가져오기)
        private void LoadHistory()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Product 테이블과 조인하여 상품명 표시
                    string sql = "SELECT h.ProdID, p.ProductName, h.ProdDate, h.GoodQty " +
                                 "FROM PRODUCTIONHISTORY h " +
                                 "JOIN PRODUCT p ON h.ProductID = p.ProductID " +
                                 "ORDER BY h.ProdID DESC";
                    OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    dgvHistory.DataSource = dt;
                    dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvHistory.Columns["ProdID"].HeaderText = "생산번호";
                    dgvHistory.Columns["ProductName"].HeaderText = "제품명";
                    dgvHistory.Columns["ProdDate"].HeaderText = "생산일자";
                    dgvHistory.Columns["GoodQty"].HeaderText = "양품수량";
                }
                catch { }
            }
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedValue == null || cboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("추가할 원자재를 선택하세요.");
                return;
            }
            if (numMatQty.Value <= 0)
            {
                MessageBox.Show("투입 수량은 0보다 커야 합니다.");
                return;
            }

            // 2. 안전한 형변환 (오류의 주된 원인 해결)
            // SelectedValue를 int로 안전하게 변환
            int matID = Convert.ToInt32(cboMaterial.SelectedValue);
            string matName = cboMaterial.Text;
            int inputQty = (int)numMatQty.Value;

            // 3. dgvMaterials에 이미 같은 자재가 있는지 확인 (중복 처리)
            foreach (DataRow row in dtTempMaterials.Rows)
            {
                if (Convert.ToInt32(row["MaterialID"]) == matID)
                {
                    // 이미 있다면 수량만 업데이트
                    row["TotalQty"] = Convert.ToInt32(row["TotalQty"]) + inputQty;

                    // 입력창 초기화 후 종료
                    cboMaterial.SelectedIndex = -1;
                    numMatQty.Value = 0;
                    return;
                }
            }

            // 4. 새 자재라면 임시 테이블에 행 추가
            DataRow newRow = dtTempMaterials.NewRow();
            newRow["MaterialID"] = matID;
            newRow["MaterialName"] = matName;
            newRow["TotalQty"] = inputQty;

            dtTempMaterials.Rows.Add(newRow);

            // 5. 입력창 초기화
            cboMaterial.SelectedIndex = -1;
            numMatQty.Value = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedProdID))
            {
                MessageBox.Show("수정할 이력을 선택하세요.");
                return;
            }

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                OracleTransaction trans = conn.BeginTransaction();

                try
                {
                    int prodID = Convert.ToInt32(cboProduct.SelectedValue);
                    int totalQty = (int)numTotal.Value;
                    int defectQty = (int)numDefect.Value;
                    int goodQty = int.Parse(txtGood.Text);

                    // (1) 생산 이력 업데이트
                    string sqlUpdate = "UPDATE PRODUCTIONHISTORY SET " +
                                      "ProductID = :pid, TotalQty = :total, DefectQty = :defect, " +
                                      "GoodQty = :good, Manager = :mgr " +
                                      "WHERE ProdID = :prodid";

                    OracleCommand cmdUpdate = new OracleCommand(sqlUpdate, conn);
                    cmdUpdate.Transaction = trans;
                    cmdUpdate.Parameters.Add("pid", prodID);
                    cmdUpdate.Parameters.Add("total", totalQty);
                    cmdUpdate.Parameters.Add("defect", defectQty);
                    cmdUpdate.Parameters.Add("good", goodQty);
                    cmdUpdate.Parameters.Add("mgr", txtManager.Text);
                    cmdUpdate.Parameters.Add("prodid", selectedProdID);
                    cmdUpdate.ExecuteNonQuery();

                    // (2) 기존 자재 목록 삭제
                    string sqlDelMat = "DELETE FROM PRODUCTIONMATERIALS WHERE ProdID = :pid";
                    OracleCommand cmdDel = new OracleCommand(sqlDelMat, conn);
                    cmdDel.Transaction = trans;
                    cmdDel.Parameters.Add("pid", selectedProdID);
                    cmdDel.ExecuteNonQuery();

                    // (3) 새 자재 목록 추가
                    foreach (DataRow row in dtTempMaterials.Rows)
                    {
                        int matID = Convert.ToInt32(row["MaterialID"]);
                        int qty = Convert.ToInt32(row["TotalQty"]);

                        string sqlMat = "INSERT INTO PRODUCTIONMATERIALS (No, ProdID, MaterialID, Quantity) " +
                                       "VALUES (seq_production_materials.NEXTVAL, :pid, :mid, :qty)";
                        OracleCommand cmdMat = new OracleCommand(sqlMat, conn);
                        cmdMat.Transaction = trans;
                        cmdMat.Parameters.Add("pid", selectedProdID);
                        cmdMat.Parameters.Add("mid", matID);
                        cmdMat.Parameters.Add("qty", qty);
                        cmdMat.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("수정 완료!");
                    LoadHistory();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("수정 실패: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedProdID))
            {
                MessageBox.Show("삭제할 이력을 선택하세요.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "정말 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes) return;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // ProductionMaterials는 ON DELETE CASCADE로 자동 삭제됨
                    string sql = "DELETE FROM PRODUCTIONHISTORY WHERE ProdID = :pid";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add("pid", selectedProdID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("삭제 완료!");
                    LoadHistory();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("삭제 실패: " + ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // 폼 초기화 함수
        private void ClearForm()
        {
            selectedProdID = null;
            cboProduct.SelectedIndex = -1;
            numTotal.Value = 0;
            numDefect.Value = 0;
            txtGood.Text = "0";
            txtManager.Text = "";
            dtTempMaterials.Clear();
        }

        private void StaffeS_Click(object sender, EventArgs e)
        {
            StaffSelectForm frm = new StaffSelectForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // StaffSelectForm에서 선택한 직원 정보 가져오기
                // (StaffSelectForm에 선택된 직원명을 반환하는 속성이 있다고 가정)
                txtManager.Text = frm.SelectedStaffName; // 또는 frm.SelectedStaffID 등
            }
        }

        private void ProductionDetail_Click(object sender, EventArgs e)
        {
            ShowSelectedRecordDetail();
        }
        private void ShowSelectedRecordDetail()
        {
            // 1. 선택된 행 확인
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("상세 보기를 원하는 생산 기록을 목록에서 선택하세요.",
                    "선택 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 선택된 행에서 ProdID 값 추출 (대소문자 주의!)
            string selectedProdID = dgvHistory.SelectedRows[0].Cells["ProdID"].Value.ToString();

            // 3. 상세 폼 표시
            ProductionDetailForm detailForm = new ProductionDetailForm(selectedProdID);
            detailForm.ShowDialog();
        }
    }
}