using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_EntityFrameworkDbFirstProduct
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        Db2_Project20Entities db = new Db2_Project20Entities();
        void ProductList()
        {
            dataGridView1.DataSource=db.TblProduct.ToList();
        }
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values=db.TblCategory.ToList();
            cmbProductCategory.DisplayMember = "CategoryName";
            cmbProductCategory.ValueMember = "CategoryId";
            cmbProductCategory.DataSource  = values;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));

           
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductName = txtProductName.Text;
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.CategoryId = int.Parse(cmbProductCategory.SelectedValue.ToString());
            db.SaveChanges();
            ProductList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ProductList();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TblProduct tblProduct = new TblProduct();
            tblProduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
            tblProduct.ProductName = txtProductName.Text;
            tblProduct.ProductStock=int.Parse(txtProductStock.Text);
            tblProduct.CategoryId=int.Parse (cmbProductCategory.SelectedValue.ToString());
            db.TblProduct.Add(tblProduct);
            db.SaveChanges();
            ProductList();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));  
            db.TblProduct.Remove(value);
            db.SaveChanges();
            ProductList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values=db.TblProduct.Where(x=>x.ProductName==txtProductName.Text).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
