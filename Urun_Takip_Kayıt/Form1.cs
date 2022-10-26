using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Urun_Takip_Kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=402-02;Initial Catalog=dburun;User ID=sa;Password=1234");
        private void btnListele_Click(object sender, EventArgs e)
        {
            //sqlden veri çekme işlemi
            SqlCommand komut = new SqlCommand("Select * from tblkategori ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //sqle veri kaybetme işlemi
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tblkategori (adi) Values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtkategoriad.Text);
            komut2.ExecuteNonQuery(); //sorguyu çalıştırmak için kullanılır.
            baglanti.Close();
            MessageBox.Show("Kategoriniz başarılı bir şekilde eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Sqlde silmek için kullanılır
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete from tblkategori where ID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı bir şekilde silindi");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //sqlde güncellemek için
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update tblkategori set adi=@p1 where ID=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtkategoriad.Text);
            komut4.Parameters.AddWithValue("@p2", txtID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı bir şekilde Güncellendi!");
        }
    }
}
//Data Source=402-02;Initial Catalog=dburun;User ID=sa;Password=1234