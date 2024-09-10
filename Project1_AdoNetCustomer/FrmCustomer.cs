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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("server=MUSTAFACK1365;initial catalog=DbCustomer;integrated security=true");
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            // komutlar başlangıcı 
            SqlCommand command = new SqlCommand("select CustomerId,CustomerName,CustomerSurname,CustomerBalance,CustomerStatus,CityName from TblCustomer inner join TblCity on TblCity.CityId=TblCustomer.CustomerCity ", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);  // adapter bir köprü görevi görecek 

            DataTable dt = new DataTable(); // veriyi dolduıruyoruz
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;  // veri kaynağını belirtiyoruz . 


            // komutlar sonu 
            sqlConnection.Close();
        }
    }
}


// select CustomerId,CustomerName,CustomerSurname,CustomerBalance,CustomerStatus,CityName from TblCustomer inner join TblCity on TblCity.CityId=TblCustomer.CustomerCity