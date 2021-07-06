using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;




namespace MusteriCariPortal
{ 
  public partial class FaturalanmayanAlim : System.Web.UI.Page
  {
        SqlConnection conn, conn1;
        string musteriKod = "";
        string bayi, kullanici, parola;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            conn1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            string bastar;
            if (DateTime.Now.Day > 15)
            {
                bastar = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "16";
            }
            else
            {
                bastar = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "01";
            }
            Session["tarih"] = bastar;
            #region müşteri kodu bulunuyor
            conn.Open();
            SqlCommand cmdMusteriKod = new SqlCommand("SELECT SHELLMUSTERIKOD FROM TTSPORTAL_CARIBILGI WHERE CARIKOD='" + Session[0].ToString() + "'", conn);

            SqlDataReader rdrMusteriKod = cmdMusteriKod.ExecuteReader();
            while (rdrMusteriKod.Read())
            {
                musteriKod = rdrMusteriKod[0].ToString();
            }
            conn.Close();
            #endregion
            if (musteriKod != "")
            {
                #region veritabanından okunuyor
                SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT CONVERT(VARCHAR(10),TARIH, 104) as [TARİH],SAAT,PLAKA,MIKTAR,BIRIMFIYAT,TOPLAMTUTAR FROM BS_DBS WHERE CARIKOD='" + Session[0].ToString() + "' AND DURUM=0 AND PLAKA NOT IN ('8ABS389') ORDER BY TARIH desc", conn);
                DataTable tblVeri = new DataTable();
                adpVeri.Fill(tblVeri);
                this.grdFatura.DataSource = tblVeri;
                this.grdFatura.DataBind();
                #endregion
            }
            else
            {
                SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT CONVERT(VARCHAR(10),TARIH, 104) as [TARİH],SAAT,PLAKA,LITRE,BIRIMFIYAT,TUTAR FROM LUKOIL_LIMIT WHERE CARIKOD='" + Session[0].ToString() + "' AND DURUM=0 AND PLAKA NOT IN ('8ABS389') AND TARIH='" + Session["tarih"] + "' ORDER BY TARIH desc", conn);
                DataTable tblVeri = new DataTable();
                adpVeri.Fill(tblVeri);
                this.grdFatura.DataSource = tblVeri;
                this.grdFatura.DataBind();

            }
            #region tarih düzenleniyor
           
            #endregion
            if (grdFatura.Rows.Count > 0)
            {
                #region tarih- para formatı
                for (int i = 0; i < grdFatura.Rows.Count; i++)
                {
                    grdFatura.Rows[i].Cells[0].Text = grdFatura.Rows[i].Cells[0].Text.ToString().Substring(0, 10);
                    decimal sayi = Convert.ToDecimal(grdFatura.Rows[i].Cells[5].Text);
                    grdFatura.Rows[i].Cells[5].Text = sayi.ToString("N");
                    decimal sayi1 = Convert.ToDecimal(grdFatura.Rows[i].Cells[4].Text);
                    grdFatura.Rows[i].Cells[4].Text = sayi1.ToString("N");
                    decimal sayi2 = Convert.ToDecimal(grdFatura.Rows[i].Cells[3].Text);
                    grdFatura.Rows[i].Cells[3].Text = sayi2.ToString("N");
                }
                #endregion
                #region alttoplam
                decimal toplamSayi = 0;
                decimal toplamSayi2 = 0;
                //burada basit bir toplama işlemi yapıyoruz. 4. sutundaki verileri alt alta topluyoruz.
                for (int i = 0; i < grdFatura.Rows.Count; i++)
                {
                    toplamSayi += Convert.ToDecimal(grdFatura.Rows[i].Cells[3].Text);
                    toplamSayi2 += Convert.ToDecimal(grdFatura.Rows[i].Cells[5].Text);
                }
                grdFatura.FooterRow.Cells[2].Text = "Toplam :";
                grdFatura.FooterRow.Cells[4].Text = "Toplam :";
                // kaçtane kayıt olduğunu footerımızın 3. sutununa yazıyoruz.
                grdFatura.FooterRow.Cells[3].Text = toplamSayi.ToString();
                grdFatura.FooterRow.Cells[5].Text = toplamSayi2.ToString();
                // topladığımız değerleri footerdaki 4. sutuna yazıyoruz.
                #endregion
            }
          

        }

        public override void VerifyRenderingInServerForm(Control control)
        { }

        #region Yazıcıya gönderir
        protected void BtnYazdir_Click(object sender, ImageClickEventArgs e)
    {
        if (grdFatura.Rows.Count > 0)
        {
            grdFatura.PagerSettings.Visible = false;
            //grdFatura.DataBind();
            //  VeriGetir();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdFatura.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'")
                .Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            grdFatura.PagerSettings.Visible = true;
            grdFatura.DataBind();
            #region alttoplam
            decimal toplamSayi = 0;
            decimal toplamSayi2 = 0;
            //burada basit bir toplama işlemi yapıyoruz. 4. sutundaki verileri alt alta topluyoruz.
            for (int i = 0; i < grdFatura.Rows.Count; i++)
            {
                toplamSayi += Convert.ToDecimal(grdFatura.Rows[i].Cells[3].Text);
                toplamSayi2 += Convert.ToDecimal(grdFatura.Rows[i].Cells[5].Text);
            }
            grdFatura.FooterRow.Cells[2].Text = "Toplam :";
            grdFatura.FooterRow.Cells[4].Text = "Toplam :";
            // kaçtane kayıt olduğunu footerımızın 3. sutununa yazıyoruz.
            grdFatura.FooterRow.Cells[3].Text = toplamSayi.ToString();
            grdFatura.FooterRow.Cells[5].Text = toplamSayi2.ToString();
            // topladığımız değerleri footerdaki 4. sutuna yazıyoruz.
            #endregion
        }
    }
        #endregion

        #region Excel e çıkartır
        protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
        {

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Faturalanmamış Alım.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grdFatura.AllowPaging = false;
        // grdFatura.DataBind();
        //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
        grdFatura.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
        grdFatura.HeaderRow.Cells[0].Style.Add("background-color", "#d2e009");
        grdFatura.HeaderRow.Cells[1].Style.Add("background-color", "#d2e009");
        grdFatura.HeaderRow.Cells[2].Style.Add("background-color", "#d2e009");
        grdFatura.HeaderRow.Cells[3].Style.Add("background-color", "#d2e009");
        grdFatura.HeaderRow.Cells[4].Style.Add("background-color", "#d2e009");
        grdFatura.HeaderRow.Cells[5].Style.Add("background-color", "#d2e009");
        for (int i = 0; i < grdFatura.Rows.Count; i++)
        {
            GridViewRow row = grdFatura.Rows[i];
            //Arka plan rengini beyaz olarak ayarlıyoruz 
            row.BackColor = System.Drawing.Color.White;
            //Her row’un text özelliğine bir class atıyoruz 
            row.Attributes.Add("class", "textmode");
            //Biraz daha güzellik katmak için 2. Row’ların arka planlarına farklı bir renk veriyoruz 
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#92b5d4");
                row.Cells[1].Style.Add("background-color", "#92b5d4");
                row.Cells[2].Style.Add("background-color", "#92b5d4");
                row.Cells[3].Style.Add("background-color", "#92b5d4");
                row.Cells[4].Style.Add("background-color", "#92b5d4");
                row.Cells[5].Style.Add("background-color", "#92b5d4");
            }
        }
        grdFatura.RenderControl(hw);
        //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
        string style = @" ";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();

        }
        #endregion

        #region Pdf e çıkartır
        protected void BtnPdf_Click(object sender, ImageClickEventArgs e)
        {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Faturalanmamış Alım.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grdFatura.AllowPaging = false;
        // grdFatura.DataBind();
        grdFatura.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        }
        #endregion
    }

}