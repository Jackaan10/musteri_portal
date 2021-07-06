using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MusteriCariPortal
{ 
  public partial class Default : System.Web.UI.Page
  {
    SqlCommand cmdCariAd;
    string cariAd, kullaniciKod, kullaniciAd, thetext = "Kullanıcı adı veya Parola hatalı!";
    SqlConnection conn;
    int txtLeft = 130;
    int txtTop = 780;
        protected void Page_Load(object sender, EventArgs e)
    
        {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            
            kullaniciKod = "";
            kullaniciAd = "";
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            //32234234234

                ///    ServiceReference1.ServiceSoapClient sr = new ServiceReference1.ServiceSoapClient();
                //    string deger = sr.Sifre(txtKullaniciAd.Text, txtParola.Text);
                if (txtKullaniciAd.Text == "" || txtParola.Text == "")
                {

                }
                else
                {
                    SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT CODE,DEFINITION_ FROM LG_316_CLCARD WHERE WEBADDR='" + txtKullaniciAd.Text + "' AND ADRESSNO='" + txtParola.Text + "'", conn);
                    DataTable tblVeri = new DataTable();
                    adpVeri.Fill(tblVeri);
                    foreach (DataRow item in tblVeri.Rows)
                    {
                        kullaniciKod = item[0].ToString();
                        kullaniciAd = item[1].ToString();
                    }
                    if (kullaniciKod.Substring(0, 3) == "120")
                    {
                        MusteriCariPortal.BaKod.kod = kullaniciKod;
                        Session["CariKod"] = kullaniciKod.ToString();
                        Session["CariAd"] = kullaniciAd.ToString();
                        Session["FirmaAd"] = txtKullaniciAd.Text;
                        Response.Redirect("AnaSayfa.aspx");
      
                    }
                    else if (kullaniciKod.Substring(0, 3) == "320")
                    {
                        Session["CariKod"] = kullaniciKod.ToString();
                        Session["CariAd"] = kullaniciAd.ToString();
                        Response.Redirect("BayiAnaSayfa.aspx");

                    }
                    else 
                    {
                    Response.Write("<div style=\"position:absolute; left:" + txtLeft + "px; top:" + txtTop + "px \">" + thetext + "</div>");
                    }
                }
        }
        

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
        Response.Redirect("SifreDegistirme.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        Response.Redirect("SifreHatirlatma.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //WebClient deneme = new WebClient();
            //deneme.DownloadFile("http://localhost:29808/Form/Cari_Talep_Formu.docx", "~\\Cari_Talep_Formu.docx");
            string dosyaAdi = Server.MapPath("Form") + "\\" + "HB Müşteri Web Portal Aydınlatma Metni 10.03.2020.docx";
            FileInfo dosya = new FileInfo(dosyaAdi);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "filename=Hilmi Beken Müşteri Web Portal Aydınlatma Metni.docx");
            Response.AddHeader("Content-Length", dosya.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(dosyaAdi);
            Response.End();
            Response.Write("Dosya indirildi");
        }
    }
}