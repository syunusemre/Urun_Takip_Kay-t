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
    public partial class frmUrun : Form
    {
        public frmUrun()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=402-02;Initial Catalog=dburun;User ID=sa;Password=1234");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select * from tblurunler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tblurunler (urunad,stok,alisfiyat,satisfiyat,kategori)" +
                "values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txturunad.Text);
            komut2.Parameters.AddWithValue("@p2", numstok.Value);
            komut2.Parameters.AddWithValue("@p3", txtalisfiyat.Text);
            komut2.Parameters.AddWithValue("@p4", txtsatisfiyat.Text);
            komut2.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı bir şekilde Kaydedildi!!");
        }

        private void frmUrun_Load(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select * from tblkategori", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut3);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox1.DisplayMember = "adi";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = dt2;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("delete from tblurunler where UrunID=@p1",baglanti);
            SqlDataAdapter da3 = new SqlDataAdapter(komut4);
            komut4.Parameters.AddWithValue("@p1", txtID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İslemi Gerçekleşti!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txturunad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numstok.Value =int.Parse( dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtalisfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsatisfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();



        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("update tblurunler set " +
                "urunad=@p1,stok=@p2,alisfiyati=@p3,satisfiyati=@p4,kategori=@p5,urundID=@p6", baglanti);
            komut5.Parameters.AddWithValue("@p1", txturunad.Text);
            komut5.Parameters.AddWithValue("@p2", numstok.Value);
            komut5.Parameters.AddWithValue("@p3", txtalisfiyat.Text);
            komut5.Parameters.AddWithValue("@p4", txtsatisfiyat.Text);
            komut5.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut5.Parameters.AddWithValue("@p6", txtID.Text);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
