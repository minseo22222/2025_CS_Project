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

namespace _2025_CS_Project
{
    public partial class FactoryLine : UserControl
    {
        DBCLASS db = new DBCLASS();

        private string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=hong1;Password=1111;";

        int selectedParentID = -1;

        public FactoryLine()
        {
            InitializeComponent();
            this.VisibleChanged += FactoryLine_VisibleChanged;
        }

        private void FactoryLine_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                LoadFinishedGoods();
                LoadRawMaterials();
                if (selectedParentID != -1)
                {
                    LoadBOM(selectedParentID);
                }
            }
        }

        private void ProductionPage_Load(object sender, EventArgs e)
        {
            LoadFinishedGoods();
            LoadRawMaterials();
        }

        void LoadFinishedGoods()
        {
            try
            {
                string sql = "SELECT ProductID AS \"제품번호\", ProductName AS \"제품명\", UnitPrice AS \"판매가\" " +
                             "FROM Product " +
                             "WHERE category = '완제품' " +
                             "ORDER BY ProductID";

                // ★ [수정 1] DB 객체 생성부터 먼저 합니다.
                db.DB_ObjCreate();

                // ★ [수정 2] DS(데이터셋)가 없는 경우를 대비해 안전장치 추가
                if (db.DS == null) db.DS = new DataSet();

                // ★ [수정 3] 이제 안전하게 테이블 확인 후 삭제
                if (db.DS.Tables.Contains("FinishedGoods"))
                    db.DS.Tables["FinishedGoods"].Clear();

                db.DB_Open(sql);
                db.DBAdapter.Fill(db.DS, "FinishedGoods");

                dgvFinishedGoods.DataSource = db.DS.Tables["FinishedGoods"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("완제품 목록 로드 오류: " + ex.Message);
            }
        }

        void LoadRawMaterials()
        {
            try
            {
                string sql = "SELECT ProductID, ProductName " +
                             "FROM Product " +
                             "WHERE category = '원재료' " +
                             "ORDER BY ProductName";

                DBCLASS dbCombo = new DBCLASS();
                dbCombo.DB_ObjCreate(); // ★ 객체 생성 먼저

                // ★ 안전장치
                if (dbCombo.DS == null) dbCombo.DS = new DataSet();

                dbCombo.DB_Open(sql);
                dbCombo.DBAdapter.Fill(dbCombo.DS, "RawMaterials");

                cboRawMaterials.DataSource = null;
                cboRawMaterials.DataSource = dbCombo.DS.Tables["RawMaterials"];
                cboRawMaterials.DisplayMember = "ProductName";
                cboRawMaterials.ValueMember = "ProductID";

                cboRawMaterials.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("원자재 목록 로드 오류: " + ex.Message);
            }
        }

        void LoadBOM(int parentID)
        {
            try
            {
                string sql = "SELECT b.ChildID AS \"자재번호\", p.ProductName AS \"자재명\", " +
                             "p.UnitPrice AS \"단가\", b.RequiredQty AS \"필요수량\" " +
                             "FROM BOM b " +
                             "JOIN Product p ON b.ChildID = p.ProductID " +
                             "WHERE b.ParentID = " + parentID + " " +
                             "ORDER BY p.ProductName";

                // ★ [수정] 여기도 순서 변경 및 안전장치
                db.DB_ObjCreate();

                if (db.DS == null) db.DS = new DataSet();

                if (db.DS.Tables.Contains("BOM_List"))
                    db.DS.Tables["BOM_List"].Clear();

                db.DB_Open(sql);
                db.DBAdapter.Fill(db.DS, "BOM_List");

                dgvBOM.DataSource = db.DS.Tables["BOM_List"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("BOM 상세 로드 오류: " + ex.Message);
            }
        }

        private void dgvFinishedGoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                // 값이 null일 경우를 대비해 ?.ToString() 사용
                string idStr = dgvFinishedGoods.Rows[e.RowIndex].Cells["제품번호"].Value?.ToString();

                if (int.TryParse(idStr, out int pid))
                {
                    selectedParentID = pid;
                    LoadBOM(selectedParentID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("선택 오류: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedParentID == -1)
            {
                MessageBox.Show("먼저 왼쪽 목록에서 '완제품'을 선택하세요.");
                return;
            }
            if (cboRawMaterials.SelectedValue == null)
            {
                MessageBox.Show("추가할 '원자재'를 선택하세요.");
                return;
            }
            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("올바른 '필요수량'을 숫자로 입력하세요.");
                return;
            }

            // SelectedValue가 null일 수 있으므로 안전하게 변환
            int childID = 0;
            if (cboRawMaterials.SelectedValue != null)
            {
                childID = Convert.ToInt32(cboRawMaterials.SelectedValue);
            }

            try
            {
                string sql = "INSERT INTO BOM (ParentID, ChildID, RequiredQty) " +
                             "VALUES (:pid, :cid, :qty)";

                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("pid", selectedParentID));
                        cmd.Parameters.Add(new OracleParameter("cid", childID));
                        cmd.Parameters.Add(new OracleParameter("qty", qty));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("자재가 구성에 추가되었습니다.");
                LoadBOM(selectedParentID);
                txtQty.Text = "";
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1)
                    MessageBox.Show("이미 이 제품에 등록된 자재입니다.");
                else
                    MessageBox.Show("DB 오류: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBOM.CurrentRow == null)
            {
                MessageBox.Show("삭제할 자재를 오른쪽 목록에서 선택하세요.");
                return;
            }

            // 값이 없을 경우를 대비해 안전하게 가져오기
            var cellVal = dgvBOM.CurrentRow.Cells["자재번호"].Value;
            if (cellVal == null) return;

            int childID = Convert.ToInt32(cellVal);
            string childName = dgvBOM.CurrentRow.Cells["자재명"].Value?.ToString();

            if (MessageBox.Show($"'{childName}' 자재를 구성에서 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM BOM WHERE ParentID = :pid AND ChildID = :cid";

                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        conn.Open();
                        using (OracleCommand cmd = new OracleCommand(sql, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("pid", selectedParentID));
                            cmd.Parameters.Add(new OracleParameter("cid", childID));

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("삭제되었습니다.");
                    LoadBOM(selectedParentID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("삭제 오류: " + ex.Message);
                }
            }
        }
    }
}