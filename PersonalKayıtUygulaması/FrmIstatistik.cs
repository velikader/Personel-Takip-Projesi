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

namespace PersonalKayıtUygulaması
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=Veli\\SQLEXPRESS;Initial Catalog=PersonelKontrol;Integrated Security=True;");

        private void Form2_Load(object sender, EventArgs e)
        {
            // Toplam Personel Sayısı 


            baglantı.Open();
            SqlCommand komut1 = new SqlCommand("Select Count (*) From Tbl_Personel",baglantı);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read()) 
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglantı.Close();

            // Evli Personel Sayısı

            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("Select Count (*) From Tbl_Personel where Perdurum = 1",baglantı);
            SqlDataReader d2 = komut2.ExecuteReader();
            while (d2.Read()) 
            {
                LblEvliPersonel.Text = d2[0].ToString();
            }
            baglantı.Close();

            //Bekar Personel Sayısı

            baglantı.Open();
            SqlCommand komut3 = new SqlCommand("Select Count (*) From Tbl_Personel where Perdurum =0",baglantı);
            SqlDataReader d3 = komut3.ExecuteReader();
            while (d3.Read()) 
            {
                LblBekarPersonel.Text = d3[0].ToString();
            }
            baglantı.Close();

            //Sehir Sayısı
            baglantı.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(PerSehir))from Tbl_Personel", baglantı);
            SqlDataReader d4 = komut4.ExecuteReader();
            while (d4.Read()) 
            {
                LblSehirsayısı.Text = d4[0].ToString();
            }
            baglantı.Close();

            //Toplam Maaş 

            baglantı.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) from Tbl_Personel",baglantı);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read()) 
            {
                LblToplmMaas.Text = dr5[0].ToString();
            }
            baglantı.Close();

            //Ortalama Maaş
            baglantı.Open ();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) from Tbl_Personel",baglantı);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read()) 
            {
                LblOrtlamaMaas.Text = dr6[0].ToString();
            }
            baglantı.Close ();
        }
    }
}
