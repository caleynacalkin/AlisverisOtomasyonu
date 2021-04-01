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
using System.Data.Sql;

namespace InventProje
{
    public partial class frmSiparisKaydiListele : Form
    {
        public frmSiparisKaydiListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-9C43OSS4\\SQLEXPRESS;Initial Catalog=Invent_Proje;Integrated Security=True");
        DataSet daset = new DataSet(); // kayitlari burada gecici olarak tutucaz

        private void frmSiparisKaydiListele_Load(object sender, EventArgs e)
        {
            Kayit_Goster();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Urun",baglanti);
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

        private void Kayit_Goster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Satis", baglanti);
            adtr.Fill(daset, "Satis");
            dataGridView1.DataSource = daset.Tables["Satis"];
            baglanti.Close();
        }

        string satisId;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            satisId=dataGridView1.CurrentRow.Cells["SatisId"].Value.ToString();
            txtSatisMiktari.Text = dataGridView1.CurrentRow.Cells["SatisMiktari"].Value.ToString();
            txtTarih.Text = dataGridView1.CurrentRow.Cells["Tarih"].Value.ToString();
            txtStok.Text = dataGridView1.CurrentRow.Cells["Stok"].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells["MagazaAdi"].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Satis SET SatisMiktari=@SatisMiktari,Tarih=@Tarih,Stok=@Stok,MagazaAdi=@MagazaAdi,UrunAdi=@UrunAdi where SatisId=@SatisId", baglanti);
            komut.Parameters.AddWithValue("@SatisId", satisId);
            komut.Parameters.AddWithValue("@SatisMiktari", Convert.ToInt32(txtSatisMiktari.Text));
            komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@Stok", Convert.ToInt32(txtStok.Text));
           komut.Parameters.AddWithValue("@MagazaAdi", comboBox1.SelectedItem);
            komut.Parameters.AddWithValue("@UrunAdi", comboBox2.SelectedItem);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["Satis"].Clear();
            Kayit_Goster();
            MessageBox.Show("Kayit güncellendi.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Satis where SatisId='"+dataGridView1.CurrentRow.Cells["SatisId"].Value.ToString()+"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["Satis"].Clear();
            Kayit_Goster();
            MessageBox.Show("Kayıt silindi.");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
