using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MusteriCariPortal
{ 
public partial class MusteriLimit : System.Web.UI.Page
{
    SqlConnection conn, conn2;
    string alici;
    string ID;
    string tarih = DateTime.Today.ToString().Substring(0, 10);
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        conn2 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        #region aylık limit
        SqlCommand cmdLimit = new SqlCommand("SELECT ISNULL(DBSLIMIT1,0) FROM LG_316_CLCARD WHERE CODE='" + Session[0].ToString() + "'", conn);
        conn.Open();
        SqlDataReader rdrLimit = cmdLimit.ExecuteReader();
        while (rdrLimit.Read())
        {
            txtLimit.Text = rdrLimit[0].ToString();
        }
        decimal sayi = Convert.ToDecimal(txtLimit.Text);
        txtLimit.Text = sayi.ToString("#,##.00");
        conn.Close();
        #endregion
        #region kullanılan limit
        SqlCommand cmdKullanım = new SqlCommand("SELECT ISNULL(SUM(TOPLAMTUTAR),0) FROM BS_DBS WHERE CARIKOD='" + Session[0].ToString() + "' AND TARIH>=CONVERT(DATETIME,'" + "01." + tarih.Substring(3) + "',104) AND TARIH<=CONVERT (DATETIME,'" + tarih + "',104)", conn2);
        conn2.Open();
        SqlDataReader rdrKullanim = cmdKullanım.ExecuteReader();
        while (rdrKullanim.Read())
        {
            txtKullanim.Text = rdrKullanim[0].ToString();
        }
        decimal sayi2 = Convert.ToDecimal(txtKullanim.Text);
        txtKullanim.Text = sayi2.ToString("#,##.00");
        conn2.Close();
        #endregion
        #region kalan limit
        txtGuncel.Text = Convert.ToString(Convert.ToDouble(txtLimit.Text) - Convert.ToDouble(txtKullanim.Text));
        decimal sayi3 = Convert.ToDecimal(txtGuncel.Text);
        txtGuncel.Text = sayi3.ToString("#,##.00");
        #endregion
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (txtLimitTalep.Text != "")
        {
            SqlCommand cmdTalep = new SqlCommand("INSERT INTO LIMIT_TALEP (CARIKOD,TARIH,LIMIT,ACIKLAMA,BASLANGICSAAT) VALUES (@CARIKOD,@TARIH,@LIMIT,@ACIKLAMA,@BASLANGICSAAT)", conn2);
            cmdTalep.Parameters.AddWithValue("@CARIKOD", Session[0].ToString());
            cmdTalep.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Today));
            cmdTalep.Parameters.AddWithValue("@LIMIT", txtLimitTalep.Text.Replace(',', '.'));
            cmdTalep.Parameters.AddWithValue("@ACIKLAMA", txtAciklama.Text);
            cmdTalep.Parameters.AddWithValue("@BASLANGICSAAT", DateTime.Now.ToLongTimeString());
            conn2.Open();
            cmdTalep.ExecuteNonQuery();
            conn2.Close();
            #region referans bulunuyor
            SqlCommand cmdRef = new SqlCommand("SELECT MAX(ID) FROM LIMIT_TALEP", conn);
            conn.Open();
            SqlDataReader rdrRef = cmdRef.ExecuteReader();
            while (rdrRef.Read())
            {
                ID = rdrRef[0].ToString();
            }
            conn.Close();
            #endregion
            #region mail gönderiliyor
            System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new System.Net.NetworkCredential("tts@hilmibeken.com", "123456!");
            #region alıcı bulunuyor
            SqlCommand cmdAlici = new SqlCommand("SELECT DSPSENDEMAILADDR FROM LG_316_CLCARD WHERE CODE ='" + Session[0].ToString() + "'", conn);
            conn.Open();
            SqlDataReader rdrAlici = cmdAlici.ExecuteReader();
            while (rdrAlici.Read())
            {
                alici = rdrAlici[0].ToString();
            }
            conn.Close();
            #endregion
            //ALICI EKLENİYOR
            msj.To.Add(alici);
            //GÖNDEREN EKLENİYOR
            msj.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
            msj.Subject = "Cihaz Talebi";
            //msj.SubjectEncoding = Encoding.UTF8;
            //msj.BodyEncoding = Encoding.UTF8;
            //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
            // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
            //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            msj.IsBodyHtml = true;
            msj.Body = ID + " Referans Numaralı Talebiniz Tarafımıza iletilmiştir En Kısa Sürede İşleme Alınacaktır.";
            sc.Port = 587;
            sc.Host = "smtp.yandex.com.tr"; // Host Adresi
            sc.EnableSsl = true;
            sc.Send(msj);
            msj.Dispose();
            #endregion
            #region bizim  mail gönderiliyor
            System.Net.Mail.MailMessage msj1 = new System.Net.Mail.MailMessage();
            SmtpClient sc1 = new SmtpClient();
            sc1.Credentials = new System.Net.NetworkCredential("tts@hilmibeken.com", "123456!");
            //ALICI EKLENİYOR 
            msj1.To.Add("portal@hilmibeken.com");
            //GÖNDEREN EKLENİYOR
            msj1.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
            msj1.Subject = "Müşteri Limit Talebi Bulunmaktadır";
            //msj.SubjectEncoding = Encoding.UTF8;
            //msj.BodyEncoding = Encoding.UTF8;
            //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
            // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
            //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            msj1.IsBodyHtml = true;
            msj1.Body = Session[0].ToString() + "          " + "Cari Kodlu Firmanın " + ID + "Referans Numaralı Limit Güncelleme Talebi Bulunmaktadır.";
            sc1.Port = 587;
            sc1.Host = "smtp.yandex.com.tr"; // Host Adresi
            sc1.EnableSsl = true;
            sc1.Send(msj1);
            msj1.Dispose();
            #endregion
            Response.Redirect("MusteriLimit.aspx");
        }
    }
}
}