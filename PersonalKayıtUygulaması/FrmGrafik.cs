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
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=Veli\\SQLEXPRESS;Initial Catalog=PersonelKontrol;Integrated Security=True;");

        private void FrmGrafik_Load(object sender, EventArgs e)
        {

            baglantı.Open();
            SqlCommand komutg1 = new SqlCommand("Select PerSehir,Count(*) From Tbl_Personel Group By PerSehir",baglantı);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read()) 
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglantı.Close();

            //grafik 2

            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("Select PerMeslek,Avg(Permaas) From Tbl_personel Group By PerMeslek", baglantı);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maaş"].Points.AddXY(dr2[0], dr2[1]);

            }
            baglantı.Close();

        }
    }
}
