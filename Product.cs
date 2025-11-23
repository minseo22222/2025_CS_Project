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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace _2025_CS_Project
{

    public partial class Product : Form
    {

        DBCLASS dbclass1 = new DBCLASS();
        DBCLASS dbclass2 = new DBCLASS();
        DBCLASS dbclass1_product = new DBCLASS();
        DBCLASS dbclass2_product = new DBCLASS();
        public Product()
        {

            InitializeComponent();
            dbclass1.DB_ObjCreate();
            dbclass1_product.DB_ObjCreate();
            dbclass2.DB_ObjCreate();
            dbclass2_product.DB_ObjCreate();

            dbclass1.DB_Open("park", "tiger", "SELECT * FROM RawMaterial");
            dbclass1.DBAdapter.Fill(dbclass1.DS, "RawMaterial");
            dbclass1.DS.Tables["RawMaterial"].PrimaryKey =
                new DataColumn[] { dbclass1.DS.Tables["RawMaterial"].Columns["product_code"] };

            dbclass1_product.DB_Open("park", "tiger", "SELECT * FROM Product WHERE product_type='R'");
            dbclass1_product.DBAdapter.Fill(dbclass1_product.DS, "Product"); // 반드시 Fill 먼저
            dbclass1_product.DS.Tables["Product"].PrimaryKey =
                new DataColumn[] { dbclass1_product.DS.Tables["Product"].Columns["product_code"] };

            dbclass2.DB_Open("park", "tiger", "SELECT * FROM FinishedProduct");
            dbclass2.DBAdapter.Fill(dbclass2.DS, "FinishedProduct");
            dbclass2.DS.Tables["FinishedProduct"].PrimaryKey =
                new DataColumn[] { dbclass2.DS.Tables["FinishedProduct"].Columns["product_code"] };

            dbclass2_product.DB_Open("park", "tiger", "SELECT * FROM Product WHERE product_type='F'");
            dbclass2_product.DBAdapter.Fill(dbclass2_product.DS, "Product");
            dbclass2_product.DS.Tables["Product"].PrimaryKey =
                new DataColumn[] { dbclass2_product.DS.Tables["Product"].Columns["product_code"] };
        }
        void ShowRawMaterial()
        {
            try
            {
                dbclass1.DS.Clear();
                dbclass1.DBAdapter.Fill(dbclass1.DS, "RawMaterial");

                dbclass1_product.DS.Clear();
                dbclass1_product.DBAdapter.Fill(dbclass1_product.DS, "Product");

                var table = new DataTable();
                table.Columns.Add("product_code");
                table.Columns.Add("product_name");
                table.Columns.Add("stock_qty");
                table.Columns.Add("purchase_price");

                foreach (DataRow r in dbclass1.DS.Tables["RawMaterial"].Rows)
                {
                    string code = r["product_code"].ToString();
                    DataRow prodRow = dbclass1_product.DS.Tables["Product"].Rows.Find(code);
                    if (prodRow != null)
                    {
                        table.Rows.Add(code, prodRow["product_name"], prodRow["stock_qty"], r["purchase_price"]);
                    }
                }

                DBGrid.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ShowFinishedProduct()
        {
            try
            {
                dbclass2.DS.Clear();
                dbclass2.DBAdapter.Fill(dbclass2.DS, "FinishedProduct");

                dbclass2_product.DS.Clear();
                dbclass2_product.DBAdapter.Fill(dbclass2_product.DS, "Product");

                var table = new DataTable();
                table.Columns.Add("product_code");
                table.Columns.Add("product_name");
                table.Columns.Add("stock_qty");
                table.Columns.Add("sale_price");

                foreach (DataRow r in dbclass2.DS.Tables["FinishedProduct"].Rows)
                {
                    string code = r["product_code"].ToString();
                    DataRow prodRow = dbclass2_product.DS.Tables["Product"].Rows.Find(code);
                    if (prodRow != null)
                    {
                        table.Rows.Add(code, prodRow["product_name"], prodRow["stock_qty"], r["sale_price"]);
                    }
                }

                DBGrid.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            ShowRawMaterial();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                ShowRawMaterial();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                ShowFinishedProduct();
        }

        private void DBGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // 현재 선택된 행을 가져옴
            DataGridViewRow row = DBGrid.Rows[e.RowIndex];

            // 공통 컬럼 (Product 테이블)
            txtCode.Text = row.Cells["product_code"].Value?.ToString();
            txtName.Text = row.Cells["product_name"].Value?.ToString();
            txtStock.Text = row.Cells["stock_qty"].Value?.ToString();

            // RawMaterial 또는 FinishedProduct 여부에 따라 값 넣기
            if (radioButton1.Checked) // RawMaterial
            {
                txtPrice.Text = row.Cells["purchase_price"].Value?.ToString();
            }
            else if (radioButton2.Checked) // FinishedProduct
            {
                txtPrice.Text = row.Cells["sale_price"].Value?.ToString();
            }
        }
        private void AddRaw()
        {
            if (dbclass2_product.DS.Tables["Product"].Rows.Find(txtCode.Text) != null)
            {
                MessageBox.Show("이미 존재하는 제품 코드입니다.");
                return;
            }
            // Product 추가
            DataRow pRow = dbclass1_product.DS.Tables["Product"].NewRow();
            pRow["product_code"] = txtCode.Text;
            pRow["product_name"] = txtName.Text;
            pRow["stock_qty"] = Convert.ToInt32(txtStock.Text);
            pRow["product_type"] = 'R'; // 반드시 지정
            dbclass1_product.DS.Tables["Product"].Rows.Add(pRow);
            dbclass1_product.DBAdapter.Update(dbclass1_product.DS, "Product");

            // RawMaterial 추가
            DataRow rRow = dbclass1.DS.Tables["RawMaterial"].NewRow();
            rRow["product_code"] = txtCode.Text;
            rRow["purchase_price"] = Convert.ToDecimal(txtPrice.Text);
            dbclass1.DS.Tables["RawMaterial"].Rows.Add(rRow);
            dbclass1.DBAdapter.Update(dbclass1.DS, "RawMaterial");

            ShowRawMaterial();
        }
        private void AddFinished()
        {
            if (dbclass1_product.DS.Tables["Product"].Rows.Find(txtCode.Text) != null)
            {
                MessageBox.Show("이미 존재하는 제품 코드입니다.");
                return;
            }
            DataRow pRow = dbclass2_product.DS.Tables["Product"].NewRow();
            pRow["product_code"] = txtCode.Text;
            pRow["product_name"] = txtName.Text;
            pRow["stock_qty"] = Convert.ToInt32(txtStock.Text);
            pRow["product_type"] = 'F'; // 반드시 지정
            dbclass2_product.DS.Tables["Product"].Rows.Add(pRow);
            dbclass2_product.DBAdapter.Update(dbclass2_product.DS, "Product");

            DataRow fRow = dbclass2.DS.Tables["FinishedProduct"].NewRow();
            fRow["product_code"] = txtCode.Text;
            fRow["sale_price"] = Convert.ToDecimal(txtPrice.Text);
            dbclass2.DS.Tables["FinishedProduct"].Rows.Add(fRow);
            dbclass2.DBAdapter.Update(dbclass2.DS, "FinishedProduct");

            ShowFinishedProduct();
        }

        private void appendBtn_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                AddRaw();
            }
            else if (radioButton2.Checked)
            {
                AddFinished();
            }
        }
        private void UpdateRaw()
        {
            DataRow pRow = dbclass1_product.DS.Tables["Product"].Rows.Find(txtCode.Text);
            pRow["product_name"] = txtName.Text;
            pRow["stock_qty"] = Convert.ToInt32(txtStock.Text);
            dbclass1_product.DBAdapter.Update(dbclass1_product.DS, "Product");

            DataRow rRow = dbclass1.DS.Tables["RawMaterial"].Rows.Find(txtCode.Text);
            rRow["purchase_price"] = Convert.ToDecimal(txtPrice.Text);
            dbclass1.DBAdapter.Update(dbclass1.DS, "RawMaterial");

            ShowRawMaterial();
        }
        private void UpdateFinished()
        {
            DataRow pRow = dbclass2_product.DS.Tables["Product"].Rows.Find(txtCode.Text);
            pRow["product_name"] = txtName.Text;
            pRow["stock_qty"] = Convert.ToInt32(txtStock.Text);
            dbclass2_product.DBAdapter.Update(dbclass2_product.DS, "Product");

            DataRow fRow = dbclass2.DS.Tables["FinishedProduct"].Rows.Find(txtCode.Text);
            fRow["sale_price"] = Convert.ToDecimal(txtPrice.Text);
            dbclass2.DBAdapter.Update(dbclass2.DS, "FinishedProduct");

            ShowFinishedProduct();
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                UpdateRaw();
            }
            else if (radioButton2.Checked)
            {
               UpdateFinished();
            }
        }
        private void DeleteRaw()
        {
            DataRow rRow = dbclass1.DS.Tables["RawMaterial"].Rows.Find(txtCode.Text);
            rRow.Delete();
            dbclass1.DBAdapter.Update(dbclass1.DS, "RawMaterial");

            DataRow pRow = dbclass1_product.DS.Tables["Product"].Rows.Find(txtCode.Text);
            pRow.Delete();
            dbclass1_product.DBAdapter.Update(dbclass1_product.DS, "Product");

            ShowRawMaterial();
        }

        private void DeleteFinished()
        {
            DataRow fRow = dbclass2.DS.Tables["FinishedProduct"].Rows.Find(txtCode.Text);
            fRow.Delete();
            dbclass2.DBAdapter.Update(dbclass2.DS, "FinishedProduct");

            DataRow pRow = dbclass2_product.DS.Tables["Product"].Rows.Find(txtCode.Text);
            pRow.Delete();
            dbclass2_product.DBAdapter.Update(dbclass2_product.DS, "Product");

            ShowFinishedProduct();
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                DeleteRaw();
            }
            else if (radioButton2.Checked)
            {
                DeleteFinished();
            }
        }
    }
}