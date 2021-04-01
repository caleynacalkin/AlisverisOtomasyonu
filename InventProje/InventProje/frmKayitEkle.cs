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

namespace InventProje
{
    public partial class frmKayitEkle : Form
    {
        public frmKayitEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-9C43OSS4\\SQLEXPRESS;Initial Catalog=Invent_Proje;Integrated Security=True");

        private void frmKayitEkle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Urun", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["MagazaAdi"]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Urun", baglanti);
            SqlDataReader read1 = komut1.ExecuteReader();
            while (read1.Read())
            {
                comboBox2.Items.Add(read1["UrunAdi"]);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
  
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Satis(SatisMiktari,Tarih,Stok,MagazaAdi,UrunAdi) values(@SatisMiktari,@Tarih,@Stok,@MagazaAdi,@UrunAdi)", baglanti);
          // komut.Parameters.AddWithValue("@SatisId", txtId.Text);
            komut.Parameters.AddWithValue("@SatisMiktari", Convert.ToInt32(txtSatisMiktari.Text));
            komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@Stok", Convert.ToInt32(txtStok.Text));
            komut.Parameters.AddWithValue("@MagazaAdi",comboBox1.SelectedItem);
            komut.Parameters.AddWithValue("@UrunAdi", comboBox2.SelectedItem);
           
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayit eklendi.");
            foreach(Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void txtSatisMiktari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false; 
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtStok_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTarih_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || !char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
