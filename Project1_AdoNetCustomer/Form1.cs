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

        SqlConnection sqlConnection = new SqlConnection("server=MUSTAFACK1365;initial catalog=DbCustomer;integrated security=true"); // servera bağlanıyoruz
        private void btnList_Click(object sender, EventArgs e)
        {
           
                                                                                                                                          

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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("insert into TblCity(CityName,CityCountry) values (@cityName,@cityCountry)", sqlConnection); // sql tarafında çalışacak komutu yazıyoruz
            command.Parameters.AddWithValue("@cityName",txtCityName.Text);   
            command.Parameters.AddWithValue("@cityCountry",txtCityCountry.Text);   
            command.ExecuteNonQuery();  // T-SQL etkilenen kayıt sayılarını döndürür. değişiklikleri kaydediyor

            sqlConnection.Close ();
            MessageBox.Show("Şehir başarılı bir şekilde eklendi ");

           

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Delete From TblCity where CityId=@cityId",sqlConnection);
            command.Parameters.AddWithValue("@cityId",txtCityId.Text);  
            command.ExecuteNonQuery ();

            sqlConnection.Close();

            MessageBox.Show("Şehir başarılı bir şekilde silindi ","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open ();
            SqlCommand command = new SqlCommand("update TblCity Set CityName=@cityName,CityCountry=@cityCountry where CityId=@cityId",sqlConnection);
            command.Parameters.AddWithValue("@cityId", txtCityId.Text); 
            command.Parameters.AddWithValue("@cityName", txtCityName.Text);
            command.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);
            command.ExecuteNonQuery (); 
            sqlConnection.Close ();
            MessageBox.Show("Şehir başarılı bir şekilde güncellendi ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
