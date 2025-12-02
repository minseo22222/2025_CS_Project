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
    public partial class InventroyUpdate : Form
    {
        DBCLASS db = new DBCLASS();
        bool isEditMode = false;

        public InventroyUpdate(int warehouseID)
        {
            InitializeComponent();
            db.DB_ObjCreate();
            txtWarehouseNum.Text = warehouseID.ToString();
        }

        // ✅ 수정 모드용 세터
        public void SetProduct(int productID, string productName, int qty)
        {
            txtProductNum.Text = productID.ToString();
            txtProductName.Text = productName;
            txtQty.Text = qty.ToString();

            txtProductNum.ReadOnly = true;
            txtProductName.ReadOnly = true;

            isEditMode = true; // ✅ 수정모드 진입
        }

        private void ProductSearchBtn_Click(object sender, EventArgs e)
        {
            if (isEditMode)
                return; // ✅ 수정 모드에서는 상품 변경 불가

            ProductInfo frm = new ProductInfo();

            frm.ProductSelected += (productID, productName) =>
            {
                txtProductNum.Text = productID.ToString();
                txtProductName.Text = productName;
            };

            frm.ShowDialog();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            // 창고번호 확인
            if (!int.TryParse(txtWarehouseNum.Text, out int warehouseID))
            {
                MessageBox.Show("창고번호 오류");
                return;
            }

            // 상품번호 확인
            if (!int.TryParse(txtProductNum.Text, out int productID))
            {
                MessageBox.Show("상품을 선택하세요.");
                return;
            }

            // 수량 확인
            if (!int.TryParse(txtQty.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("수량을 올바르게 입력하세요.");
                return;
            }

            try
            {
                // Inventory 테이블 로드
                db.DB_Open("SELECT * FROM Inventory");
                db.DBAdapter.Fill(db.DS, "Inventory");

                DataTable table = db.DS.Tables["Inventory"];
                // 기본키 설정: WarehouseID + ProductID
                table.PrimaryKey = new DataColumn[] { table.Columns["WarehouseID"], table.Columns["ProductID"] };

                // 기존 재고 확인
                DataRow row = table.Rows.Find(new object[] { warehouseID, productID });

                if (isEditMode)
                {
                    // ✅ 수정 모드
                    if (row != null)
                    {
                        row["Quantity"] = qty; // 수량 변경
                    }
                    else
                    {
                        MessageBox.Show("선택된 재고를 찾을 수 없습니다.");
                        return;
                    }
                }
                else
                {
                    // ✅ 추가 모드
                    if (row != null)
                    {
                        // 기존 재고가 있으면 수량 더하기
                        row["Quantity"] = Convert.ToInt32(row["Quantity"]) + qty;
                    }
                    else
                    {
                        // 새로운 재고 추가
                        DataRow newRow = table.NewRow();
                        newRow["WarehouseID"] = warehouseID;
                        newRow["ProductID"] = productID;
                        newRow["Quantity"] = qty;
                        table.Rows.Add(newRow);
                    }
                }

                // DB 반영
                db.DBAdapter.Update(db.DS, "Inventory");

                MessageBox.Show(isEditMode ? "재고가 수정되었습니다." : "재고가 추가되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("재고 처리 오류: " + ex.Message);
            }
        }




        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
