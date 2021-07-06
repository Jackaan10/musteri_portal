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
    public partial class Plaka_Dokum : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlConnection connB;
        DataTable tblPlaka;
        SqlDataAdapter adpDetay;
        protected void Page_Load(object sender, EventArgs e)
        {

            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            connB = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);

            if (Session["ist"].ToString() == "Kendi İstasyonumuz")
            { Session["ist"] = "Bizim_İstasyon"; }
            if (Session["spe"].ToString() == "IRS")
            {
               connB.Open();
                DateTime tarihbas=Convert.ToDateTime( Session["tarih"]);
                tarihbas = tarihbas.AddDays(-15);
                adpDetay = new SqlDataAdapter("SELECT PLAKA,CONVERT(VARCHAR(10),TARIH,104) AS [ALIMTARIH],LITRE,FIYAT,TUTAR FROM TURPAK_IRSALIYE WHERE TARIH>=CONVERT(DATETIME,'" + tarihbas + "',104) AND TARIH<=CONVERT(DATETIME,'" + Session["tarih"] + "',104) AND  CARIKOD='" + Session[0].ToString() + "'", connB);
                tblPlaka = new DataTable();
                adpDetay.Fill(tblPlaka);
                grdFatura.DataSource = tblPlaka;
                grdFatura.DataBind();

                decimal toplamSayi = 0;

                //burada basit bir toplama işlemi yapıyoruz. 4. sutundaki verileri alt alta topluyoruz.
                for (int i = 0; i < grdFatura.Rows.Count; i++)
                {
                    toplamSayi += Convert.ToDecimal(grdFatura.Rows[i].Cells[4].Text);

                }
                grdFatura.FooterRow.Cells[3].Text = "Toplam :";

                // kaçtane kayıt olduğunu footerımızın 3. sutununa yazıyoruz.
                grdFatura.FooterRow.Cells[4].Text = toplamSayi.ToString();

                // topladığımız değerleri footerdaki 4. sutuna yazıyoruz.

            }
            else
            {
                DetayGetir();
            }
           

        }
        private void DetayGetir()
         
        {

            //ServiceReference1.ServiceSoapClient plakaDetay = new ServiceReference1.ServiceSoapClient();
            //DataTable tbl = plakaDetay.Detay(Session["Ref"].ToString());
            adpDetay = new SqlDataAdapter("SELECT distinct BS.PLAKA,BSP.ARACTUR,CONVERT(VARCHAR(10),BS.ALIMTARIH,104) AS [ALIMTARIH],BS.ALIMSAAT,BS.ISTASYON,BS.EXCELURUNADI as [ÜRÜN ADI],BS.MIKTAR,BS.BIRIMFIYAT,BS.TUTAR  FROM AKTARIM.dbo.BS_PLAKA BSP LEFT OUTER JOIN AKTARIM.dbo.BS_FATURA BS ON BS.PLAKA=BSP.PLAKA LEFT OUTER JOIN LG_316_CLCARD CL ON CL.CODE=BS.CARIKOD LEFT OUTER JOIN LG_316_01_INVOICE INV ON INV.CLIENTREF=CL.LOGICALREF WHERE CL.CODE='" + Session[0].ToString() + "' AND INV.DATE_=CONVERT(DATETIME,'" + Session["tarih"] + "',104) AND  BSP.PLAKA=BS.PLAKA AND BS.NOTES1 = '" + Session["ist"].ToString() + "' AND BS.TARIH=CONVERT(DATETIME,'" + Session["tarih"] + "',104) AND INV.FICHENO='" + Session["Fat_Ref"] + "' AND INV.DOCTRACKINGNR=BS.SHELLFATNO  AND INV.GENEXP1 IN('" + Session["ist"].ToString() + "','Kendi İstasyonumuz') AND BS.ISTASYON NOT IN('HİLMİ BEKEN / DIST') AND INV.CAPIBLOCK_CREATEDBY=1  UNION ALL  SELECT distinct BS.PLAKA,BSP.ARACTUR,CONVERT(VARCHAR(10),BS.ALIMTARIH,104) AS [ALIMTARIH],BS.ALIMSAAT,BS.ISTASYON,IT.NAME AS [ÜRÜN ADI],BS.MIKTAR,BS.BIRIMFIYAT,BS.TUTAR  FROM AKTARIM.dbo.BS_PLAKA BSP LEFT OUTER JOIN AKTARIM.dbo.BS_ATSFATURA BS ON BS.PLAKA=BSP.PLAKA LEFT OUTER JOIN LG_316_CLCARD CL ON CL.CODE=BS.CARIKOD LEFT OUTER JOIN LG_316_01_INVOICE INV ON INV.CLIENTREF=CL.LOGICALREF LEFT OUTER JOIN BEKEN2010.DBO.LG_316_ITEMS IT ON IT.CODE=BS.YAKIT WHERE CL.CODE='" + Session[0].ToString() + "' AND INV.DATE_=CONVERT(DATETIME,'" + Session["tarih"] + "',104) AND  BSP.PLAKA=BS.PLAKA AND BS.NOTES = '" + Session["ist"].ToString() + "' AND BS.TARIH=CONVERT(DATETIME,'" + Session["tarih"] + "',104) AND INV.FICHENO='" + Session["Fat_Ref"] + "' AND INV.GENEXP1='" + Session["ist"].ToString() + "'  AND INV.CAPIBLOCK_CREATEDBY=1 UNION ALL SELECT distinct BS.PLAKA,BSP.ARACTUR,CONVERT(VARCHAR(10),BS.ALIMTARIH,104) AS [ALIMTARIH],BS.ALIMSAAT,BS.ISTASYON,IT.NAME AS [ÜRÜN ADI],BS.MIKTAR,BS.BIRIMFIYAT,BS.TUTAR  FROM AKTARIM.dbo.BS_PLAKA BSP LEFT OUTER JOIN AKTARIM.dbo.BS_YAKITMATIKFATURA BS ON BS.PLAKA=BSP.PLAKA LEFT OUTER JOIN LG_316_CLCARD CL ON CL.CODE=BS.CARIKOD LEFT OUTER JOIN LG_316_01_INVOICE INV ON INV.CLIENTREF=CL.LOGICALREF LEFT OUTER JOIN BEKEN2010.DBO.LG_316_ITEMS IT ON IT.CODE=BS.YAKIT WHERE CL.CODE='" + Session[0].ToString() + "' AND INV.DATE_=CONVERT(DATETIME,'" + Session["tarih"] + "',104) AND  BSP.PLAKA=BS.PLAKA AND BS.NOTES = '" + Session["ist"].ToString() + "' AND  BS.TARIH=CONVERT(DATETIME,'" + Session["tarih"] + "',104) AND INV.FICHENO='" + Session["Fat_Ref"] + "'  AND INV.GENEXP1='" + Session["ist"].ToString() + "' AND INV.CAPIBLOCK_CREATEDBY = 1", conn);
            tblPlaka = new DataTable();
            adpDetay.Fill(tblPlaka);          
            grdFatura.DataSource = tblPlaka;
            grdFatura.DataBind();
            for (int i = 0; i < grdFatura.Rows.Count; i++)
            {
                grdFatura.Rows[i].Cells[1].Text = grdFatura.Rows[i].Cells[1].Text.ToString();
                decimal sayi = Convert.ToDecimal(grdFatura.Rows[i].Cells[8].Text);
                grdFatura.Rows[i].Cells[8].Text = sayi.ToString("N");
                decimal sayi1 = Convert.ToDecimal(grdFatura.Rows[i].Cells[6].Text);
                grdFatura.Rows[i].Cells[6].Text = sayi1.ToString("N");
                decimal sayi2 = Convert.ToDecimal(grdFatura.Rows[i].Cells[7].Text);
                grdFatura.Rows[i].Cells[7].Text = sayi2.ToString("N");
            }

            decimal toplamSayi = 0;

            //burada basit bir toplama işlemi yapıyoruz. 4. sutundaki verileri alt alta topluyoruz.
            for (int i = 0; i < grdFatura.Rows.Count; i++)
            {
                toplamSayi += Convert.ToDecimal(grdFatura.Rows[i].Cells[8].Text);

            }
            grdFatura.FooterRow.Cells[6].Text = "Toplam :";

            // kaçtane kayıt olduğunu footerımızın 3. sutununa yazıyoruz.
            grdFatura.FooterRow.Cells[8].Text = toplamSayi.ToString();

            // topladığımız değerleri footerdaki 4. sutuna yazıyoruz.



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
            }
            DetayGetir();
        }
        #endregion

        #region Pdf e Çıkartır
        protected void BtnPdf_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Aylık Plaka Alım Tutarı.pdf");
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

        #region Excel e çıkartır
        protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Aylık Plaka Alım Tutarı.xls");
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
            grdFatura.HeaderRow.Cells[6].Style.Add("background-color", "#d2e009");
            grdFatura.HeaderRow.Cells[7].Style.Add("background-color", "#d2e009");
            grdFatura.HeaderRow.Cells[8].Style.Add("background-color", "#d2e009");
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
                    row.Cells[6].Style.Add("background-color", "#92b5d4");
                    row.Cells[7].Style.Add("background-color", "#92b5d4");
                    row.Cells[8].Style.Add("background-color", "#92b5d4");
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
    }
}