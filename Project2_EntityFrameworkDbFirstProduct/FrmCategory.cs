﻿using System;
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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        Db2_Project20Entities db = new Db2_Project20Entities();
        void CategoryList()
        {
            dataGridView1.DataSource = db.TblCategory.ToList();
        }
        private void FrmCategory_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TblCategory tblCategory = new TblCategory();
            tblCategory.CategoryName = txtCategoryName.Text;
           
            db.TblCategory.Add(tblCategory);
            db.SaveChanges();
            CategoryList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var value = db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            CategoryList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var value = db.TblCategory.Find(id);
            value.CategoryName = txtCategoryName.Text;
            db.SaveChanges();
            CategoryList();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
