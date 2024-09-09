using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_AdoNetCustomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("server=MUSTAFACK1365;initial catalog=DbCustomer;integrated security=true"); // servera bağlanıyoruz
                                                                                                                                          

            sqlConnection.Open();

            // komutlar başlangıcı 
            SqlCommand command = new SqlCommand("Select * From TblCity ", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command );  // adapter bir köprü görevi görecek 

            DataTable dt = new DataTable(); // veriyi dolduıruyoruz
            dataGridView1.DataSource = dt;  // veri kaynağını belirtiyoruz . 
            adapter.Fill( dt );

            // komutlar sonu 
            sqlConnection.Close();
        }
    }
}
