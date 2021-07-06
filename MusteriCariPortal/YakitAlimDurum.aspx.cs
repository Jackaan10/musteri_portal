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
public partial class YakitAlimDurum : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
    SqlConnection conn2 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
    DataTable tblPlaka;
    System.Web.UI.WebControls.CheckBox c;
    System.Web.UI.WebControls.Label l;
    string alici;
    string ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        VeriGetir();
    }
    private void VeriGetir()
    {
        SqlDataAdapter adpPlaka = new SqlDataAdapter("SELECT [SEÇİM]='',PLAKA,DURUM FROM BS_PLAKA WHERE CARIKOD='" + Session[0].ToString() + "'", conn);
        tblPlaka = new DataTable();
        adpPlaka.Fill(tblPlaka);
        this.grdArac.DataSource = tblPlaka;
        this.grdArac.DataBind();
        chkOlustur();
    }
    public void chkOlustur()
    {
        if (grdArac.Rows.Count > 9)
        {
            for (int i = 0; i < grdArac.Rows.Count; i++)
            {
                System.Web.UI.WebControls.CheckBox c = new System.Web.UI.WebControls.CheckBox();
                c.ID = "ch_" + i.ToString();
                System.Web.UI.WebControls.Label l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["SEÇİM"].ToString();
                l.Width = 20;
                c.Width = 20;
                grdArac.Rows[i].Cells[0].Controls.Add(c);
                grdArac.Rows[i].Cells[0].Controls.Add(l);
            }
        }
        else
        {
            for (int i = 0; i < grdArac.Rows.Count; i++)
            {
                c = new System.Web.UI.WebControls.CheckBox();
                c.ID = "ch_" + i.ToString();
                l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["SEÇİM"].ToString();
                l.Width = 20;
                c.Width = 20;
                grdArac.Rows[i].Cells[0].Controls.Add(c);
                grdArac.Rows[i].Cells[0].Controls.Add(l);
            }
        }
    }
    protected void grdArac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdArac.PageIndex = e.NewPageIndex;
        VeriGetir();
    }
    protected void grdArac_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Width = 20;
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        SqlDataAdapter adpPlaka = new SqlDataAdapter("SELECT [SEÇİM]='',PLAKA,DURUM FROM BS_PLAKA WHERE CARIKOD='" + Session[0].ToString() + "'  AND PLAKA LIKE '%" + txtPlaka.Text + "%'", conn);
        DataTable tblAra = new DataTable();
        adpPlaka.Fill(tblAra);
        this.grdArac.DataSource = tblAra;
        this.grdArac.DataBind();
        chkOlustur();
    }
    protected void btnKapat_Click(object sender, EventArgs e)
    {
        int sayi = 0;
        for (int i = 0; i < grdArac.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox c = (System.Web.UI.WebControls.CheckBox)grdArac.Rows[i].Cells[0].FindControl("ch_" + i.ToString());
            if (c.Checked) // işaretlenen checkbox kontrolü, yapılcak işlem burada tanımlanacak.
            {
                SqlCommand cmdKapat = new SqlCommand("INSERT INTO YAKITTALEP (CARIKOD,TARIH,PLAKA,TALEP,BASLANGICSAAT) VALUES (@CARIKOD,@TARIH,@PLAKA,@TALEP,@BASLANGICSAAT)", conn);
                cmdKapat.Parameters.AddWithValue("@CARIKOD", Session[0].ToString());
                cmdKapat.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Today));
                cmdKapat.Parameters.AddWithValue("@PLAKA", grdArac.Rows[i].Cells[1].Text.ToString());
                cmdKapat.Parameters.AddWithValue("@TALEP", "KAPAT");
                cmdKapat.Parameters.AddWithValue("@BASLANGICSAAT", DateTime.Now.ToLongTimeString());
                conn.Open();
                cmdKapat.ExecuteNonQuery();
                conn.Close();
                sayi++;
            }
        }
        if (sayi == 0)
        {

        }
        else
        {
            #region referans bulunuyor
            SqlCommand cmdRef = new SqlCommand("SELECT MAX(ID) FROM YAKITTALEP", conn);
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
            SqlCommand cmdAlici = new SqlCommand("SELECT DSPSENDEMAILADDR FROM LG_316_CLCARD WHERE CODE ='" + Session[0].ToString() + "'", conn2);
            conn2.Open();
            SqlDataReader rdrAlici = cmdAlici.ExecuteReader();
            while (rdrAlici.Read())
            {
                alici = rdrAlici[0].ToString();
            }
            conn2.Close();
            #endregion
            //ALICI EKLENİYOR
            msj.To.Add(alici);
            //GÖNDEREN EKLENİYOR
            msj.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
            msj.Subject = "Yakıt Kapatma";
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
            msj1.To.Add("melih@hilmibeken.com");
            //GÖNDEREN EKLENİYOR
            msj1.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
            msj1.Subject = "Yakıt Kapatma";
            //msj.SubjectEncoding = Encoding.UTF8;
            //msj.BodyEncoding = Encoding.UTF8;
            //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
            // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
            //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            msj1.IsBodyHtml = true;
            msj1.Body = Session[0].ToString() + "          " + "Cari Kodlu Firmanın " + ID + " Referans Numaralı Plaka Yakıt Kapama Talebi Bulunmaktadır.";
            sc1.Port = 587;
            sc1.Host = "smtp.yandex.com.tr"; // Host Adresi
            sc1.EnableSsl = true;
            sc1.Send(msj1);
            msj1.Dispose();
            #endregion
            Response.Redirect("YakitAlimDurum.aspx");
        }
    }
    protected void btnAc_Click(object sender, EventArgs e)
    {
        int sayi1 = 0;
        for (int i = 0; i < grdArac.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox c = (System.Web.UI.WebControls.CheckBox)grdArac.Rows[i].Cells[0].FindControl("ch_" + i.ToString());
            if (c.Checked) // işaretlenen checkbox kontrolü, yapılcak işlem burada tanımlanacak.
            {
                SqlCommand cmdKapat = new SqlCommand("INSERT INTO YAKITTALEP (CARIKOD,TARIH,PLAKA,TALEP,BASLANGICSAAT) VALUES (@CARIKOD,@TARIH,@PLAKA,@TALEP,@BASLANGICSAAT)", conn);
                cmdKapat.Parameters.AddWithValue("@CARIKOD", Session[0].ToString());
                cmdKapat.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Today));
                cmdKapat.Parameters.AddWithValue("@PLAKA", grdArac.Rows[i].Cells[1].Text.ToString());
                cmdKapat.Parameters.AddWithValue("@TALEP", "AÇ");
                cmdKapat.Parameters.AddWithValue("@BASLANGICSAAT", DateTime.Now.ToLongTimeString());
                conn.Open();
                cmdKapat.ExecuteNonQuery();
                conn.Close();
                sayi1++;
            }
        }
        if (sayi1 == 0)
        {

        }
        else
        {
            #region referans bulunuyor
            SqlCommand cmdRef = new SqlCommand("SELECT MAX(ID) FROM YAKITTALEP", conn);
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
            SqlCommand cmdAlici = new SqlCommand("SELECT DSPSENDEMAILADDR FROM LG_316_CLCARD WHERE CODE ='" + Session[0].ToString() + "'", conn2);
            conn2.Open();
            SqlDataReader rdrAlici = cmdAlici.ExecuteReader();
            while (rdrAlici.Read())
            {
                alici = rdrAlici[0].ToString();
            }
            conn2.Close();
            #endregion
            //ALICI EKLENİYOR
            msj.To.Add(alici);
            //GÖNDEREN EKLENİYOR
            msj.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
            msj.Subject = "Yakıt Açma";
            //msj.SubjectEncoding = Encoding.UTF8;
            //msj.BodyEncoding = Encoding.UTF8;
            //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
            // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
            //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            msj.IsBodyHtml = true;
            msj.Body = ID + "Referans Numaralı Talebiniz Tarafımıza iletilmiştir En Kısa Sürede İşleme Alınacaktır.";
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
            msj1.To.Add("melih@hilmibeken.com");
            //GÖNDEREN EKLENİYOR
            msj1.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
            msj1.Subject = "Yakıt Açma";
            //msj.SubjectEncoding = Encoding.UTF8;
            //msj.BodyEncoding = Encoding.UTF8;
            //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
            // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
            //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            msj1.IsBodyHtml = true;
            msj1.Body = Session[0].ToString() + "          " + "Cari Kodlu Firmanın " + ID + "Referans Numaralı Plaka Yakıt Açma Talebi Bulunmaktadır.";
            sc1.Port = 587;
            sc1.Host = "smtp.yandex.com.tr"; // Host Adresi
            sc1.EnableSsl = true;
            sc1.Send(msj1);
            msj1.Dispose();
            #endregion
            Response.Redirect("YakitAlimDurum.aspx");
        }
    }
}
}