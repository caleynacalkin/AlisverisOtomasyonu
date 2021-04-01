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
    public partial class frmaAnaEkran : Form
    {
        public frmaAnaEkran()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-9C43OSS4\\SQLEXPRESS;Initial Catalog=Invent_Proje;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;


        private void frmSatis_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnKytEkle_Click(object sender, EventArgs e)
        {
            frmKayitEkle ekle = new frmKayitEkle();
            ekle.ShowDialog();
        }

        private void btnKayitListele_Click(object sender, EventArgs e)
        {
            frmSiparisKaydiListele listele = new frmSiparisKaydiListele();
            listele.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            SqlConnection Conn = new SqlConnection("Data Source=LAPTOP-9C43OSS4\\SQLEXPRESS;Initial Catalog=Invent_Proje;Integrated Security=True");
            SqlCommand Comm1 = new SqlCommand("select MagazaAdi  from Satis where SatisMiktari = (select MAX(SatisMiktari) from Satis) group by MagazaAdi", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                MessageBox.Show( DR1.GetValue(0).ToString());
            }
            Conn.Close();






        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection("Data Source=LAPTOP-9C43OSS4\\SQLEXPRESS;Initial Catalog=Invent_Proje;Integrated Security=True");
            SqlCommand Comm1 = new SqlCommand("SELECT [UrunAdi] FROM[Invent_Proje].[dbo].[Satis] where SatisMiktari = (select MAX(SatisMiktari) from Satis)", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                MessageBox.Show(DR1.GetValue(0).ToString());
            }
            Conn.Close();

        }
    }
}
