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
 public partial class AracLimit : System.Web.UI.Page
 {
    int sayi;
    string alici;
    string ID;
    SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
    SqlConnection conn1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
    DataTable tblPlaka;
    System.Web.UI.WebControls.CheckBox c;
    System.Web.UI.WebControls.Label l;
    string musteriKod = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        VeriGetir();
    }
    private void VeriGetir()
    {
        #region müşteri kodu bulunuyor
        conn1.Open();
        SqlCommand cmdMusteriKod = new SqlCommand("SELECT BANKNAMES7 FROM LG_316_CLCARD WHERE CODE='" + Session[0].ToString() + "'", conn1);
        SqlDataReader rdrMusteriKod = cmdMusteriKod.ExecuteReader();
        while (rdrMusteriKod.Read())
        {
            musteriKod = rdrMusteriKod[0].ToString();
        }
        conn1.Close();
        #endregion        
        #region veritabanından okunuyor
        SqlDataAdapter adpPlaka = new SqlDataAdapter("SELECT [SEÇİM]='',PLAKA,LIMIT AS [GÜNCEL LİMİT (TL)],[TALEP EDİLEN LİMİT (TL)]='' FROM BS_PLAKA WHERE CARIKOD='" + Session[0].ToString() + "'  AND PLAKA LIKE '%" + txtPlaka.Text + "%'", conn);
        tblPlaka = new DataTable();
        adpPlaka.Fill(tblPlaka);
        this.grdArac.DataSource = tblPlaka;
        this.grdArac.DataBind();
        chkOlustur();
        txtOlustur();
        #endregion
    }
    public void chkOlustur()
    {
        if (grdArac.Rows.Count > 9)
        {
            for (int i = 0; i < grdArac.Rows.Count; i++)
            {
                System.Web.UI.WebControls.CheckBox c = new System.Web.UI.WebControls.CheckBox();
                c.ID = "chk_" + i.ToString();
                System.Web.UI.WebControls.Label l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["SEÇİM"].ToString();
                l.Width = 20;
                c.Width = 20;
                grdArac.Rows[i].Cells[0].Controls.Add(c);
                grdArac.Rows[i].Cells[0].Controls.Add(l);
                grdArac.Rows[i].Cells[3].Enabled = false;
                sayi = i;
                c.AutoPostBack = true;
                c.CheckedChanged += c_CheckedChanged;
            }
        }
        else
        {
            for (int i = 0; i < grdArac.Rows.Count; i++)
            {
                c = new System.Web.UI.WebControls.CheckBox();
                c.ID = "chk_" + i.ToString();
                l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["SEÇİM"].ToString();
                l.Width = 20;
                c.Width = 20;
                grdArac.Rows[i].Cells[0].Controls.Add(c);
                grdArac.Rows[i].Cells[0].Controls.Add(l);
                grdArac.Rows[i].Cells[3].Enabled = false;
                sayi = i;
                c.AutoPostBack = true;
                c.CheckedChanged += c_CheckedChanged;
            }
        }
    }
    void c_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < grdArac.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox c = (System.Web.UI.WebControls.CheckBox)grdArac.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (c.Checked) // işaretlenen checkbox kontrolü, yapılcak işlem burada tanımlanacak.
            {
                grdArac.Rows[i].Cells[3].Enabled = true;
            }
        }
    }
    public void txtOlustur()
    {
        if (grdArac.Rows.Count > 9)
        {
            for (int i = 0; i < grdArac.Rows.Count; i++)
            {
                System.Web.UI.WebControls.TextBox c = new System.Web.UI.WebControls.TextBox();
                c.ID = "ch_" + i.ToString();
                System.Web.UI.WebControls.Label l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["TALEP EDİLEN LİMİT (TL)"].ToString();
                //l.Width = 200;
                c.Width = 280;
                grdArac.Rows[i].Cells[3].Controls.Add(c);
                grdArac.Rows[i].Cells[1].Width = 200;
                grdArac.Rows[i].Cells[2].Width = 200;
                //grdArac.Rows[i].Cells[2].Controls.Add(l);
            }
        }
        else
        {
            for (int i = 0; i < grdArac.Rows.Count; i++)
            {
                System.Web.UI.WebControls.TextBox c = new System.Web.UI.WebControls.TextBox();
                c.ID = "ch_" + i.ToString();
                l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["TALEP EDİLEN LİMİT (TL)"].ToString();
                //l.Width = 200;
                c.Width = 280;
                grdArac.Rows[i].Cells[3].Controls.Add(c);
                grdArac.Rows[i].Cells[1].Width = 200;
                grdArac.Rows[i].Cells[2].Width = 200;
                //grdArac.Rows[i].Cells[2].Controls.Add(l);
            }
        }
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        SqlDataAdapter adpPlaka = new SqlDataAdapter("SELECT [SEÇİM]='',PLAKA,LIMIT  AS [GÜNCEL LİMİT (TL)],[TALEP EDİLEN LİMİT (TL)]='' FROM BS_PLAKA WHERE CARIKOD='" + Session[0].ToString() + "'  AND PLAKA LIKE '%" + txtPlaka.Text + "%'", conn);
        DataTable tblAra = new DataTable();
        adpPlaka.Fill(tblAra);
        this.grdArac.DataSource = tblAra;
        this.grdArac.DataBind();
        chkOlustur();
        txtOlustur();
    }
    protected void grdArac_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Width = 20;
    }
    protected void grdArac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdArac.PageIndex = e.NewPageIndex;
        VeriGetir();
    }
    protected void btnAracLimit_Click(object sender, EventArgs e)
    {
        #region web servisten online veri okunuyor
       // TtsService. aracLimit = new TtsService.SALESTRANSACTIONINFO();
       //aracLimit.SetCardLimitCountandDays("0011799164", "Admin", "Beken0505b", musteriKod, Convert.ToDateTime(bastar), DateTime.Now, "", "", "", "");       
        #endregion
        for (int i = 0; i < grdArac.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox c = (System.Web.UI.WebControls.CheckBox)grdArac.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (c.Checked) // işaretlenen checkbox kontrolü, yapılcak işlem burada tanımlanacak.
            {
                TextBox veri = (TextBox)grdArac.Rows[i].Cells[3].FindControl("ch_" + i.ToString());
                SqlCommand cmdKaydet = new SqlCommand("INSERT INTO  BS_PLAKA_LIMIT_TALEP (CARIKOD,PLAKA,LIMITTALEP,TARIH,BASLANGICSAAT) VALUES (@CARIKOD,@PLAKA,@LIMITTALEP,@TARIH,@BASLANGICSAAT)", conn);
                cmdKaydet.Parameters.AddWithValue("@CARIKOD", Session[0].ToString());
                cmdKaydet.Parameters.AddWithValue("@PLAKA", grdArac.Rows[i].Cells[1].Text);
                cmdKaydet.Parameters.AddWithValue("@LIMITTALEP", Convert.ToDouble(veri.Text));
                cmdKaydet.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Today));
                cmdKaydet.Parameters.AddWithValue("@BASLANGICSAAT", DateTime.Now.ToLongTimeString());
                conn.Open();
                cmdKaydet.ExecuteNonQuery();
                conn.Close();
            }
        }
        #region mail sistemi
        #region referans bulunuyor
        SqlCommand cmdRef = new SqlCommand("SELECT MAX(ID) FROM BS_PLAKA_LIMIT_TALEP", conn);
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
        SqlCommand cmdAlici = new SqlCommand("SELECT DSPSENDEMAILADDR FROM LG_316_CLCARD WHERE CODE ='" + Session[0].ToString() + "'", conn1);
        conn1.Open();
        SqlDataReader rdrAlici = cmdAlici.ExecuteReader();
        while (rdrAlici.Read())
        {
            alici = rdrAlici[0].ToString();
        }
        conn1.Close();
        #endregion
        //ALICI EKLENİYOR
        msj.To.Add(alici);
        // msj.To.Add("portal@hilmibeken.com");
        //GÖNDEREN EKLENİYOR
        msj.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
        msj.Subject = "Cihaz Talebi";
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
        msj1.To.Add("destek@hilmibeken.com");
        //msj1.To.Add("bilgiislem@hilmibeken.com");
        //GÖNDEREN EKLENİYOR
        msj1.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL SİSTEMİ", Encoding.UTF8);
        msj1.Subject = "Araç Limit Talebi Bulunmaktadır";
        //msj.SubjectEncoding = Encoding.UTF8;
        //msj.BodyEncoding = Encoding.UTF8;
        //System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;      
        // byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(yol);
        //yol = System.Text.Encoding.UTF8.GetString(utf8Bytes);
        msj1.IsBodyHtml = true;
        msj1.Body = Session[0].ToString() + "          " + "Cari Kodlu Firmanın " + ID + "Referans Numaralı Araç Limit Bulunmaktadır";
        sc1.Port = 587;
        sc1.Host = "smtp.yandex.com.tr"; // Host Adresi
        sc1.EnableSsl = true;
        sc1.Send(msj1);
        msj1.Dispose();
        #endregion
        #endregion
        Response.Redirect("AracLimit.aspx");
    }
 }
}