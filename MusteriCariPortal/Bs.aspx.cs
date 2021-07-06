using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{


public partial class Default2 : System.Web.UI.Page
{
    SqlConnection conn;
    string cariAd, alici;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        cmbDonem.Items.Clear();
        cmbDonem.Items.Add("Ocak");
        cmbDonem.Items.Add("Şubat");
        cmbDonem.Items.Add("Mart");
        cmbDonem.Items.Add("Nisan");
        cmbDonem.Items.Add("Mayıs");
        cmbDonem.Items.Add("Haziran");
        cmbDonem.Items.Add("Temmuz");
        cmbDonem.Items.Add("Ağustos");
        cmbDonem.Items.Add("Eylül");
        cmbDonem.Items.Add("Ekim");
        cmbDonem.Items.Add("Kasım");
        cmbDonem.Items.Add("Aralık");
        //if (DateTime.Now.Month.ToString() == "2")
        //{
        //    cmbDonem.Items.Add("Ocak");
        //}
        //else if (DateTime.Now.Month.ToString() == "3")
        //{
        //    cmbDonem.Items.Add("Şubat");
        //}
        //else if (DateTime.Now.Month.ToString() == "4")
        //{
        //    cmbDonem.Items.Add("Mart");
        //}
        //else if (DateTime.Now.Month.ToString() == "5")
        //{
        //    cmbDonem.Items.Add("Nisan");
        //}
        //else if (DateTime.Now.Month.ToString() == "6")
        //{
        //    cmbDonem.Items.Add("Mayıs");
        //}
        //else if (DateTime.Now.Month.ToString() == "7")
        //{
        //    cmbDonem.Items.Add("Haziran");
        //}
        //else if (DateTime.Now.Month.ToString() == "8")
        //{
        //    cmbDonem.Items.Add("Temmuz");
        //}
        //else if (DateTime.Now.Month.ToString() == "9")
        //{
        //    cmbDonem.Items.Add("Ağustos");
        //}
        //else if (DateTime.Now.Month.ToString() == "10")
        //{
        //    cmbDonem.Items.Add("Eylül");
        //}
        //else if (DateTime.Now.Month.ToString() == "11")
        //{
        //    cmbDonem.Items.Add("Ekim");
        //}
        //else if (DateTime.Now.Month.ToString() == "12")
        //{
        //    cmbDonem.Items.Add("Kasım");
        //}
        //else if (DateTime.Now.Month.ToString() == "1")
        //{
        //    cmbDonem.Items.Add("Aralık");
        //}
    }
    protected void btnSorgula_Click(object sender, EventArgs e)
    {
           
        BaKod.Donem = cmbDonem.Text;
        if (BaKod.Donem == "")
        {
            Response.Write("Lütfen Dönem Seçiniz");
        }
        else
        {
            if (cmbDonem.SelectedIndex + 1 == DateTime.Now.Month - 1)
            {
                if (DateTime.Now.Day < 20)
                { Response.Write("Bir önceki dönem Mütabakat bilgilerinizi takip eden ayın 20 sinden önce görüntüleyemezsiniz"); }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('BsForm.aspx');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('BsForm.aspx');", true);
            }
        }
    }
    protected void btnOnayla_Click(object sender, EventArgs e)
    {
        #region kayıt kontrol ediliyor
        SqlDataAdapter adpKontrol = new SqlDataAdapter("SELECT * FROM AKTARIM.DBO.PORTAL_MUTABAKAT WHERE CARIKOD='" + Session[0].ToString() + "' AND DONEM='" + cmbDonem.Text + "'", conn);
        DataTable tblKontrol = new DataTable();
        adpKontrol.Fill(tblKontrol);
        #endregion
        if (tblKontrol.Rows.Count == 0)
        {
            SqlCommand cmdKayit = new SqlCommand("INSERT INTO AKTARIM.DBO.PORTAL_MUTABAKAT (TARIH,DONEM,CARIAD,CARIKOD) VALUES (@TARIH,@DONEM,@CARIAD,@CARIKOD)", conn);
            cmdKayit.Parameters.AddWithValue("@TARIH", DateTime.Now);
            cmdKayit.Parameters.AddWithValue("@DONEM", cmbDonem.Text);
            #region cariad Bulunuyor
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT DEFINITION_ FROM LG_316_CLCARD WHERE CODE='" + Session[0].ToString() + "'", conn);
            DataTable tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            foreach (DataRow item in tblVeri.Rows)
            {
                cariAd = item[0].ToString();
            }
            #endregion
            cmdKayit.Parameters.AddWithValue("@CARIAD", cariAd);
            cmdKayit.Parameters.AddWithValue("@CARIKOD", Session[0].ToString());
            conn.Open();
            cmdKayit.ExecuteNonQuery();
            conn.Close();
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
            msj.To.Add("marketmuhasebe@hilmibeken.com");
            msj.To.Add("destek@hilmibeken.com");
            //GÖNDEREN EKLENİYOR
            msj.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
            msj.Subject = "Mütabakat";
            //msj.SubjectEncoding = Encoding.UTF8;
            //msj.BodyEncoding = Encoding.UTF8;
            //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
            // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
            //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            msj.IsBodyHtml = true;
            msj.Body = cariAd + "   Firması ile " + "   " + cmbDonem.Text + "  Dönemi için Mütabakat Sağlanmıştır";
            sc.Port = 587;
            sc.Host = "smtp.yandex.com.tr"; // Host Adresi
            sc.EnableSsl = true;
            sc.Send(msj);
            msj.Dispose();
            #endregion
            Response.Write("Mütabakat Onayı Sağlanmıştır");
        }
        else
        { Response.Write("Seçili Dönem Mütabakatı Daha Önceden Yapılmıştır."); }
    }
}
}