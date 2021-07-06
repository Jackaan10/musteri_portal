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
public partial class BayiAnaSayfa : System.Web.UI.Page
{
    SqlConnection conn, connBizim;
    SqlDataAdapter adpStok, adpEskiKayit;
    DataTable tblStok, tblEskiKayit;
    SqlCommand cmdKaydet;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCariAd.Text = Session["CariAd"].ToString();
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        //if (!IsPostBack)
        //{
        VeriCek();
        txtOlustur();
        //}
    }
    private void VeriCek()
    {
        adpStok = new SqlDataAdapter("SELECT  UN.BARCODE AS BARKOD,IT.NAME AS [ÜRÜN AD],IT.CODE,[HB FİYAT]=MAX(PR.PRICE),[ÜRÜN FİYAT]='',[UYGULAMA İSKONTO]='',[UYGULAMA İSKONTO 2]='',[MAL FAZLASI]='' FROM LG_316_ITEMS IT LEFT OUTER JOIN LG_316_MARK MR ON MR.LOGICALREF=IT.MARKREF LEFT OUTER JOIN LG_316_UNITBARCODE UN ON UN.ITEMREF=IT.LOGICALREF LEFT OUTER JOIN LG_316_01_STLINE STL ON STL.STOCKREF=IT.LOGICALREF LEFT OUTER JOIN LG_316_01_INVOICE INV ON STL.INVOICEREF=INV.LOGICALREF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=INV.CLIENTREF LEFT OUTER JOIN LG_316_PRCLIST PR ON PR.CARDREF=IT.LOGICALREF WHERE  INV.DATE_>= CONVERT(DATETIME,'" + DateTime.Now.AddDays(-365).ToString().Substring(0, 10) + "',104) AND INV.TRCODE=1 AND CL.CODE='" + Session["CariKod"].ToString() + "' AND PR.PTYPE=1  GROUP BY IT.NAME,UN.BARCODE,IT.CODE ORDER BY IT.NAME", conn);
        tblStok = new DataTable();
        adpStok.Fill(tblStok);
        this.grdStok.DataSource = tblStok;
        this.grdStok.DataBind();
    }
    public void txtOlustur()
    {
        for (int i = 0; i < grdStok.Rows.Count; i++)
        {
            System.Web.UI.WebControls.TextBox urunFiyat = new System.Web.UI.WebControls.TextBox();
            urunFiyat.ID = "ch_" + i.ToString();
            System.Web.UI.WebControls.Label urunFiyatL = new System.Web.UI.WebControls.Label();
            urunFiyatL.Text = tblStok.Rows[i]["ÜRÜN FİYAT"].ToString();
            urunFiyat.Width = 100;
            //urunFiyat.TextMode = "NUMBER";
            grdStok.Rows[i].Cells[4].Controls.Add(urunFiyat);
            
            
            System.Web.UI.WebControls.TextBox Iskonto = new System.Web.UI.WebControls.TextBox();
            Iskonto.ID = "ck_" + i.ToString();
            System.Web.UI.WebControls.Label IskontoL = new System.Web.UI.WebControls.Label();
            IskontoL.Text = tblStok.Rows[i]["UYGULAMA İSKONTO"].ToString();
            Iskonto.Width = 100;
            grdStok.Rows[i].Cells[5].Controls.Add(Iskonto);

            System.Web.UI.WebControls.TextBox Iskonto2 = new System.Web.UI.WebControls.TextBox();
            Iskonto.ID = "ck_" + i.ToString();
            System.Web.UI.WebControls.Label IskontoL2 = new System.Web.UI.WebControls.Label();
            IskontoL.Text = tblStok.Rows[i]["UYGULAMA İSKONTO 2"].ToString();
            Iskonto.Width = 100;
            grdStok.Rows[i].Cells[6].Controls.Add(Iskonto2);

            System.Web.UI.WebControls.TextBox MalFazlasi = new System.Web.UI.WebControls.TextBox();
            MalFazlasi.ID = "cl_" + i.ToString();
            System.Web.UI.WebControls.Label MalFazlasiL = new System.Web.UI.WebControls.Label();
            MalFazlasiL.Text = tblStok.Rows[i]["MAL FAZLASI"].ToString();
            MalFazlasi.Width = 100;
            grdStok.Rows[i].Cells[7].Controls.Add(MalFazlasi);
        }
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        #region kayıt kontrol ediliyor
        SqlDataAdapter adpKontrol = new SqlDataAdapter("SELECT * FROM SATINALMA_BAYI_FIYATLISTESI WHERE TARIH=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104) AND CARIKOD='" + Session["CariKod"].ToString() + "'", connBizim);
        DataTable tblKontrol = new DataTable();
        adpKontrol.Fill(tblKontrol);
        #endregion
        #region yeni kayıt atılıyor
        if (tblKontrol.Rows.Count == 0)
        {
            for (int i = 0; i < grdStok.Rows.Count; i++)
            {
                TextBox veriUrunFiyat = (TextBox)grdStok.Rows[i].Cells[3].FindControl("ch_" + i.ToString());
                TextBox veriUygulamaIskonto = (TextBox)grdStok.Rows[i].Cells[4].FindControl("ck_" + i.ToString());
                TextBox veriUygulamaIskonto2 = (TextBox)grdStok.Rows[i].Cells[5].FindControl("ck_" + i.ToString());
                TextBox veriMalFazlasi = (TextBox)grdStok.Rows[i].Cells[6].FindControl("cl_" + i.ToString());

                cmdKaydet = new SqlCommand("INSERT INTO SATINALMA_BAYI_FIYATLISTESI (CARIKOD,CARIAD,TARIH,BARKOD,URUNAD,URUNKOD,HBFIYAT,URUNFIYAT,UYGULAMAISKONTO,UYGULAMAISKONTO2,MALFAZLASI,ACIKLAMA) VALUES (@CARIKOD,@CARIAD,@TARIH,@BARKOD,@URUNAD,@URUNKOD,@HBFIYAT,@URUNFIYAT,@UYGULAMAISKONTO,@UYGULAMAISKONTO2,@MALFAZLASI,@ACIKLAMA)", connBizim);
                cmdKaydet.Parameters.AddWithValue("@CARIKOD", Session["CariKod".ToString()]);
                cmdKaydet.Parameters.AddWithValue("@CARIAD", Session["CariAd".ToString()]);
                cmdKaydet.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10)));
                cmdKaydet.Parameters.AddWithValue("@BARKOD", grdStok.Rows[i].Cells[0].Text);
                cmdKaydet.Parameters.AddWithValue("@URUNAD", grdStok.Rows[i].Cells[1].Text);
                cmdKaydet.Parameters.AddWithValue("@URUNKOD", grdStok.Rows[i].Cells[2].Text);
                cmdKaydet.Parameters.AddWithValue("@HBFIYAT", Convert.ToDouble(grdStok.Rows[i].Cells[3].Text));
                if (veriUrunFiyat.Text.ToString() != "")
                {
                    cmdKaydet.Parameters.AddWithValue("@URUNFIYAT", Convert.ToDouble(veriUrunFiyat.Text));
                }
                else
                {
                    cmdKaydet.Parameters.AddWithValue("@URUNFIYAT", 0);
                }
                if (veriUygulamaIskonto.Text != "")
                {
                    cmdKaydet.Parameters.AddWithValue("@UYGULAMAISKONTO", Convert.ToDouble(veriUygulamaIskonto.Text));
                }
                else
                {
                    cmdKaydet.Parameters.AddWithValue("@UYGULAMAISKONTO", 0);
                }
                if (veriUygulamaIskonto2.Text != "")
                {
                    cmdKaydet.Parameters.AddWithValue("@UYGULAMAISKONTO2", Convert.ToDouble(veriUygulamaIskonto2.Text));
                }
                else
                {
                    cmdKaydet.Parameters.AddWithValue("@UYGULAMAISKONTO2", 0);
                }
                if (veriMalFazlasi.Text != "")
                {
                    cmdKaydet.Parameters.AddWithValue("@MALFAZLASI", Convert.ToDouble(veriMalFazlasi.Text));
                }
                else
                {
                    cmdKaydet.Parameters.AddWithValue("@MALFAZLASI", 0);
                }
                if (i == 0)
                {
                    cmdKaydet.Parameters.AddWithValue("@ACIKLAMA", txtAciklama.Text);
                }
                else
                {
                    cmdKaydet.Parameters.AddWithValue("@ACIKLAMA", "");
                }
                connBizim.Open();
                cmdKaydet.ExecuteNonQuery();
                connBizim.Close();
            }
            #region mail yollanıyor
            System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new System.Net.NetworkCredential("bilgi@hilmibeken.com", "123456!");
            //ALICI EKLENİYOR
            msj.To.Add("hbsatinalma@hilmibeken.com");
            //GÖNDEREN EKLENİYOR
            msj.From = new System.Net.Mail.MailAddress("bilgi@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL", Encoding.UTF8);
            msj.Subject = "Bayi İşlem Maili";
            msj.IsBodyHtml = true;
            msj.Body = "Hilmi Beken Otomatik Mail Sistemi İle Gönderilmiştir." + "<br/>" + " <br/> " + "      " + Session["CariAd"].ToString() + " firması tarafından yeni fiyat girişi yapılmıştır.Kontrol beklemektedir.;";
            sc.Port = 587;
            sc.Host = "smtp.yandex.com.tr"; // Host Adresi
            sc.EnableSsl = true;
            sc.Send(msj);
            msj.Dispose();
            #endregion
        }
        #endregion
        #region eski kayıt güncelleniyor
        else
        {
            for (int i = 0; i < grdStok.Rows.Count; i++)
            {
                TextBox veriUrunFiyat = (TextBox)grdStok.Rows[i].Cells[3].FindControl("ch_" + i.ToString());
                TextBox veriUygulamaIskonto = (TextBox)grdStok.Rows[i].Cells[4].FindControl("ck_" + i.ToString());
                TextBox veriUygulamaIskonto2 = (TextBox)grdStok.Rows[i].Cells[5].FindControl("ck_" + i.ToString());
                TextBox veriMalFazlasi = (TextBox)grdStok.Rows[i].Cells[6].FindControl("cl_" + i.ToString());
                SqlCommand cmdGuncelle = new SqlCommand("UPDATE SATINALMA_BAYI_FIYATLISTESI SET URUNFIYAT=@URUNFIYAT,UYGULAMAISKONTO=@UYGULAMAISKONTO,UYGULAMAISKONTO2=@UYGULAMAISKONTO2,MALFAZLASI=@MALFAZLASI WHERE TARIH=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104) AND CARIKOD='" + Session["CariKod"].ToString() + "' AND BARKOD='" + grdStok.Rows[i].Cells[0].Text + "'", connBizim);
                #region eski kayıt kontrol
                adpEskiKayit = new SqlDataAdapter("SELECT URUNFIYAT,UYGULAMAISKONTO,UYGULAMAISKONTO2,MALFAZLASI FROM SATINALMA_BAYI_FIYATLISTESI WHERE TARIH=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104) AND CARIKOD='" + Session["CariKod"].ToString() + "' AND BARKOD='" + grdStok.Rows[i].Cells[0].Text + "'", connBizim);
                tblEskiKayit = new DataTable();
                adpEskiKayit.Fill(tblEskiKayit);
                #endregion
                #region yeni ürün fiyat
                if (veriUrunFiyat.Text != "")
                {
                    if (Convert.ToDouble(tblEskiKayit.Rows[0][0]) == Convert.ToDouble(veriUrunFiyat.Text))
                    {
                        cmdGuncelle.Parameters.AddWithValue("@URUNFIYAT", Convert.ToDouble(tblEskiKayit.Rows[0][0]));
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@URUNFIYAT", Convert.ToDouble(veriUrunFiyat.Text));
                    }
                }
                else
                {
                    if (tblEskiKayit.Rows[0][0] != "")
                    {
                        cmdGuncelle.Parameters.AddWithValue("@URUNFIYAT", Convert.ToDouble(tblEskiKayit.Rows[0][0]));
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@URUNFIYAT", 0);
                    }
                }
                #endregion
                #region uygulama iskonto

                if (veriUygulamaIskonto.Text != "")
                {
                    if (Convert.ToDouble(tblEskiKayit.Rows[0][1]) == Convert.ToDouble(veriUygulamaIskonto.Text))
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO", Convert.ToDouble(tblEskiKayit.Rows[0][1]));
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO", Convert.ToDouble(veriUygulamaIskonto.Text));
                    }
                }
                else
                {
                    if (tblEskiKayit.Rows[0][1] != "")
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO", Convert.ToDouble(tblEskiKayit.Rows[0][1]));
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO", 0);
                    }
                }

                if (veriUygulamaIskonto2.Text != "")
                {
                    if (Convert.ToDouble(tblEskiKayit.Rows[0][2]) == Convert.ToDouble(veriUygulamaIskonto2.Text))
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO2", Convert.ToDouble(tblEskiKayit.Rows[0][2]));
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO2", Convert.ToDouble(veriUygulamaIskonto2.Text));
                    }
                }
                else
                {
                    if (tblEskiKayit.Rows[0][2] != "")
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO2", Convert.ToDouble(tblEskiKayit.Rows[0][2]));
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@UYGULAMAISKONTO2", 0);
                    }
                }
                #endregion

                #region mal fazlası
                if (veriMalFazlasi.Text != "")
                {
                    if (Convert.ToDouble(tblEskiKayit.Rows[0][2]) == Convert.ToDouble(veriMalFazlasi.Text))
                    {
                        
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@MALFAZLASI", Convert.ToDouble(veriMalFazlasi.Text));
                    }                    
                }
                else
                {
                    if (tblEskiKayit.Rows[0][2] != "")
                    {
                        cmdGuncelle.Parameters.AddWithValue("@MALFAZLASI", Convert.ToDouble(tblEskiKayit.Rows[0][2]));
                    }
                    else
                    {
                        cmdGuncelle.Parameters.AddWithValue("@MALFAZLASI", 0);
                    }                   
                }
                #endregion
                connBizim.Open();
                cmdGuncelle.ExecuteNonQuery();
                connBizim.Close();
            }
            #region mail yollanıyor
            System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new System.Net.NetworkCredential("bilgi@hilmibeken.com", "123456!");
            //ALICI EKLENİYOR
            msj.To.Add("hbsatinalma@hilmibeken.com");
            //GÖNDEREN EKLENİYOR
            msj.From = new System.Net.Mail.MailAddress("bilgi@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL", Encoding.UTF8);
            msj.Subject = "Bayi İşlem Maili";
            msj.IsBodyHtml = true;
            msj.Body = "Hilmi Beken Otomatik Mail Sistemi İle Gönderilmiştir." + "<br/>" + " <br/> " + "      " + Session["CariAd"].ToString() + " firması tarafından fiyat güncelleme işlemi yapılmıştır.Kontrol beklemektedir.;";
            sc.Port = 587;
            sc.Host = "smtp.yandex.com.tr"; // Host Adresi
            sc.EnableSsl = true;
            sc.Send(msj);
            msj.Dispose();
            #endregion
        }
        #endregion
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "İşlem Sonucu", "<script>alert('Kayıt Edildi');</script>");
        Response.Redirect("BayiAnaSayfa.aspx");
    }
    protected void grdStok_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[1].Wrap = false;
        }
        catch (Exception)
        {


        }

    }
}
}