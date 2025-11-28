using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2025_CS_Project
{
    public partial class InventoryPage : UserControl
    {
        DBCLASS db = new DBCLASS();
        public InventoryPage()
        {
            InitializeComponent();
            db.DB_ObjCreate();
            db.DB_Open("park", "tiger", "SELECT * FROM Warehouse");
        }

        void ShowList()
        {
            try
            {
                db.DS.Clear();
                db.DBAdapter.Fill(db.DS, "Warehouse");
                WarehouseList.Items.Clear();
                foreach (DataRow row in db.DS.Tables["Warehouse"].Rows)
                {
                    string name = row["WarehouseName"].ToString();
                    WarehouseList.Items.Add(name);
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        
        void InventoryPage_Load(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            ShowList();
        }
        bool isNum(string str, string err_msg)
        {
            int num;
            if (!int.TryParse(str, out num))
            {
                MessageBox.Show(err_msg);
                return false;
            }
            return true;
        }
        void AddWarehouse()
        {
            try
            {
                // 숫자 검증
                if (!isNum(txtWarehouseNum.Text, "창고번호를 숫자로 입력하세요."))
                    return;

                int warehouseID = Convert.ToInt32(txtWarehouseNum.Text);
                string warehouseName = txtWarehouseName.Text;

                // DataTable 가져오기
                DataTable table = db.DS.Tables["Warehouse"];
                table.PrimaryKey = new DataColumn[] { table.Columns["WarehouseID"] };

                // 기존 행 찾기
                DataRow existingRow = table.Rows.Find(warehouseID);

                if (existingRow != null)
                {
                    // 이미 존재하면 수정
                    existingRow["WarehouseName"] = warehouseName;
                    MessageBox.Show("기존 창고 정보를 수정했습니다.");
                }
                else
                {
                    // 새 행 추가
                    DataRow newRow = table.NewRow();
                    newRow["WarehouseID"] = warehouseID;
                    newRow["WarehouseName"] = warehouseName;
                    table.Rows.Add(newRow);
                    MessageBox.Show("새 창고를 추가했습니다.");
                }

                // DB 업데이트
                db.DBAdapter.Update(db.DS, "Warehouse");
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        void DeleteWarehouse()
        {
            try
            {
                if (WarehouseList.SelectedItem == null)
                {
                    MessageBox.Show("삭제할 창고를 선택하세요.");
                    return;
                }

                string selectedName = WarehouseList.SelectedItem.ToString();
                DataTable table = db.DS.Tables["Warehouse"];

                // 선택된 창고명을 기준으로 행 찾기
                DataRow[] rows = table.Select($"WarehouseName = '{selectedName.Replace("'", "''")}'");

                if (rows.Length > 0)
                {
                    if (MessageBox.Show("선택한 창고를 정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // DataRow 삭제
                        rows[0].Delete();

                        // DB 반영
                        db.DBAdapter.Update(db.DS, "Warehouse");

                        // ListBox 갱신
                        ShowList();
                        txtWarehouseNum.Clear();
                        txtWarehouseName.Clear();

                        MessageBox.Show("창고가 삭제되었습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("삭제할 창고를 찾을 수 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 중 오류: " + ex.Message);
            }
        }


        private void AppendBtn_Click(object sender, EventArgs e)
        {
            AddWarehouse();
            ShowList();
        }

        private void WarehouseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WarehouseList.SelectedItem == null) return;

            string selectedName = WarehouseList.SelectedItem.ToString();
            DataTable table = db.DS.Tables["Warehouse"];

            // 선택된 창고명을 기준으로 DataRow 찾기
            DataRow[] rows = table.Select($"WarehouseName = '{selectedName.Replace("'", "''")}'");

            if (rows.Length > 0)
            {
                txtWarehouseNum.Text = rows[0]["WarehouseID"].ToString();
                txtWarehouseName.Text = rows[0]["WarehouseName"].ToString();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteWarehouse();
            ShowList();
        }
    }
}
