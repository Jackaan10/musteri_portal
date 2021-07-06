using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{ 
public partial class SifreHatirlatma : System.Web.UI.Page
{
    SqlConnection conn;
    DataTable tblKontrol;
    string sifre;
    protected void Page_Load(object sender, EventArgs e)
    {
        sifre = "";
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        #region cari kontrol ediliyor
        SqlDataAdapter adpKontrol = new SqlDataAdapter("SELECT * FROM LG_316_CLCARD WHERE  WEBADDR='" + txtKullaniciAd.Text + "' AND DSPSENDEMAILADDR='" + txtEmail.Text + "'", conn);
        tblKontrol = new DataTable();
        adpKontrol.Fill(tblKontrol);
        #endregion
        if (tblKontrol.Rows.Count > 0)
        {
            #region şifre bulunuyor
            SqlCommand cmdSifre = new SqlCommand("SELECT ADRESSNO FROM LG_316_CLCARD WHERE DSPSENDEMAILADDR='" + txtEmail.Text + "'", conn);
            conn.Open();
            SqlDataReader rdrSifre = cmdSifre.ExecuteReader();
            while (rdrSifre.Read())
            {
                sifre = rdrSifre[0].ToString();
            }
            conn.Close();
            #endregion
            if (sifre != "")
            {
                #region mail gönderiliyor
                System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
                SmtpClient sc = new SmtpClient();
                sc.Credentials = new System.Net.NetworkCredential("tts@hilmibeken.com", "123456!");
                conn.Close();
                //ALICI EKLENİYOR
                msj.To.Add(txtEmail.Text);
                // msj.To.Add("portal@hilmibeken.com");
                //GÖNDEREN EKLENİYOR
                msj.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
                msj.Subject = "Şifre Hatırlatma";
                //msj.SubjectEncoding = Encoding.UTF8;
                //msj.BodyEncoding = Encoding.UTF8;
                //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
                // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
                //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
                msj.IsBodyHtml = true;
                msj.Body = "Şifreniz : " + sifre + "       ;    " + "Eğer Şifre Hatırlatma Modülünü kullanmadıysanız şirketimizle iletişime geçiniz";
                sc.Port = 587;
                sc.Host = "smtp.yandex.com.tr"; // Host Adresi
                sc.EnableSsl = true;
                sc.Send(msj);
                msj.Dispose();
                #endregion
            }
        }
        else
        {
            Response.Write("Tanımlı kullanıcı veya mail bulunamamıştır.Bilgilerinizi kontrol ediniz.");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
}