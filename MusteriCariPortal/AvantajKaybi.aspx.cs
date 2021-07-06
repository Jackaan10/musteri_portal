using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
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

namespace MusteriCariPortal
{
    public partial class AvantajKaybi : System.Web.UI.Page
    {
        int day;
        SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void VeriGetirir()
        {
            double topla = 0;
            double toplamSayi = 0;
            double toplamTutar = 0;
        SqlDataAdapter adpVeri = new SqlDataAdapter ("SELECT BS.PLAKA,BS.ISTASYON,CONVERT(VARCHAR(10), BS.ALIMTARIH,104) AS [ALIM TARİH],MIKTAR AS [MİKTAR],TUTAR AS [TUTAR],[AVANTAJ KAYBI]= ISNULL(CASE WHEN IT.NAME = 'KURŞUNSUZ BENZİN 97 TTS-ATS' AND BS.NOTES1 = 'Diğer İstasyonlar'  THEN(((SUM(TUTAR)/100) * REPLACE(TCG.SHELLBIZIMBENZIN, ',', '.'))  -  REPLACE(TCG.SHELLDIGERBENZIN, ',', '.')) WHEN IT.NAME = 'MOTORİN DİESEL TTS-ATS' AND BS.NOTES1 = 'Diğer İstasyonlar' OR IT.NAME = 'MOTORİN V POWER DİESEL TTS-ATS' AND BS.NOTES1 = 'Diğer İstasyonlar'  THEN (((SUM(TUTAR)/100) * REPLACE(TCG.SHELLBIZIMMOTORIN, ',', '.'))  -  REPLACE(TCG.SHELLDIGERMOTORIN, ',', '.')) END,0) FROM BS_FATURA BS LEFT OUTER JOIN TTSPORTAL_CARIBILGI TCG ON TCG.CARIKOD = BS.CARIKOD LEFT OUTER JOIN BEKEN2010.DBO.LG_316_ITEMS IT ON IT.CODE = BS.URUNNO  WHERE TARIH>=CONVERT(DATETIME,'" + txtFromDate.Text + "',104) AND TARIH<=CONVERT(DATETIME,'" + txtToDate.Text + "',104) AND ISTASYON IN ('Yeniköy.','Aspendos Bulvari.','Afyon Kavşak','İmrehor') AND BS.CARIKOD='" + Session[0].ToString() + "' GROUP BY IT.NAME,NOTES1,TCG.SHELLDIGERBENZIN,TCG.SHELLBIZIMBENZIN,TCG.SHELLBIZIMMOTORIN,TCG.SHELLDIGERMOTORIN,BS.PLAKA,BS.MIKTAR,BS.TUTAR,BS.ISTASYON,BS.ALIMTARIH ORDER BY ALIMTARIH DESC", conn);
            DataTable tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            this.grdVeri.DataSource = tblVeri;
            this.grdVeri.DataBind();
            if (tblVeri.Rows.Count > 0)
            {
                #region para formatı
                for (int i = 0; i < grdVeri.Rows.Count; i++)
                {
                    topla += Convert.ToDouble(grdVeri.Rows[i].Cells[5].Text);
                    toplamSayi += Convert.ToDouble(grdVeri.Rows[i].Cells[3].Text);
                    toplamTutar += Convert.ToDouble(grdVeri.Rows[i].Cells[4].Text);
                    decimal sayi = Convert.ToDecimal(grdVeri.Rows[i].Cells[3].Text);
                    grdVeri.Rows[i].Cells[3].Text = sayi.ToString("N");
                    decimal sayi1 = Convert.ToDecimal(grdVeri.Rows[i].Cells[4].Text);
                    grdVeri.Rows[i].Cells[4].Text = sayi1.ToString("N");
                    decimal sayi2 = Convert.ToDecimal(grdVeri.Rows[i].Cells[5].Text);
                    grdVeri.Rows[i].Cells[5].Text = sayi2.ToString("N");
                    #endregion
                    toplam.Text = topla.ToString("N");
                    grdVeri.FooterRow.Cells[3].Text = toplamSayi.ToString("N");
                    grdVeri.FooterRow.Cells[4].Text = toplamTutar.ToString("N");
                    grdVeri.FooterRow.Cells[5].Text = topla.ToString("N");
                }
            }
            else
            {

                toplam.Text = "Avantaj Kaybınız Bulunmamaktadır.";


            }

        }
       
        private void VeriGetir(int day)
        {
            double topla = 0;
            double toplamSayi = 0;
            double toplamTutar = 0;
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT BS.PLAKA,BS.ISTASYON,CONVERT(VARCHAR(10), BS.ALIMTARIH,104) AS [ALIM TARİH],MIKTAR AS [MİKTAR],TUTAR AS [TUTAR],[AVANTAJ KAYBI]= ISNULL(CASE WHEN IT.NAME = 'KURŞUNSUZ BENZİN 97 TTS-ATS' AND BS.NOTES1 = 'Diğer İstasyonlar'  THEN(((SUM(TUTAR)/100) * REPLACE(TCG.SHELLBIZIMBENZIN, ',', '.'))  -  REPLACE(TCG.SHELLDIGERBENZIN, ',', '.')) WHEN IT.NAME = 'MOTORİN DİESEL TTS-ATS' AND BS.NOTES1 = 'Diğer İstasyonlar' OR IT.NAME = 'MOTORİN V POWER DİESEL TTS-ATS' AND BS.NOTES1 = 'Diğer İstasyonlar'  THEN (((SUM(TUTAR)/100) * REPLACE(TCG.SHELLBIZIMMOTORIN, ',', '.'))  -  REPLACE(TCG.SHELLDIGERMOTORIN, ',', '.')) END,0) FROM BS_FATURA BS LEFT OUTER JOIN TTSPORTAL_CARIBILGI TCG ON TCG.CARIKOD = BS.CARIKOD LEFT OUTER JOIN BEKEN2010.DBO.LG_316_ITEMS IT ON IT.CODE = BS.URUNNO  WHERE TARIH>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(day).ToString().Substring(0, 10) + "',104) AND TARIH<=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104) AND ISTASYON IN ('Yeniköy.','Aspendos Bulvari.','Afyon Kavşak','İmrehor') AND BS.CARIKOD='" + Session[0].ToString() + "' GROUP BY IT.NAME,NOTES1,TCG.SHELLDIGERBENZIN,TCG.SHELLBIZIMBENZIN,TCG.SHELLBIZIMMOTORIN,TCG.SHELLDIGERMOTORIN,BS.PLAKA,BS.MIKTAR,BS.TUTAR,BS.ISTASYON,BS.ALIMTARIH ORDER BY ALIMTARIH DESC", conn);
            DataTable tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            this.grdVeri.DataSource = tblVeri;
            this.grdVeri.DataBind();
            if (tblVeri.Rows.Count > 0)
            {
                #region para formatı
                for (int i = 0; i < grdVeri.Rows.Count; i++)
                {
                    topla += Convert.ToDouble(grdVeri.Rows[i].Cells[5].Text);
                    toplamSayi += Convert.ToDouble(grdVeri.Rows[i].Cells[3].Text);
                    toplamTutar += Convert.ToDouble(grdVeri.Rows[i].Cells[4].Text);
                    decimal sayi = Convert.ToDecimal(grdVeri.Rows[i].Cells[3].Text);
                    grdVeri.Rows[i].Cells[3].Text = sayi.ToString("N");
                    decimal sayi1 = Convert.ToDecimal(grdVeri.Rows[i].Cells[4].Text);
                    grdVeri.Rows[i].Cells[4].Text = sayi1.ToString("N");
                    decimal sayi2 = Convert.ToDecimal(grdVeri.Rows[i].Cells[5].Text);
                    grdVeri.Rows[i].Cells[5].Text = sayi2.ToString("N");
                    #endregion
                    toplam.Text = topla.ToString("N");
                    grdVeri.FooterRow.Cells[3].Text = toplamSayi.ToString("N");
                    grdVeri.FooterRow.Cells[4].Text = toplamTutar.ToString("N");
                    grdVeri.FooterRow.Cells[5].Text = topla.ToString("N");
                }
            }
            else
            {

                toplam.Text = "Avantaj Kaybınız Bulunmamaktadır.";
                

            }
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            VeriGetirir();
            rdbTarih.ClearSelection();
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (rdbTarih.SelectedIndex == 0)
            {
                day = -30;
                

            }
            else if (rdbTarih.SelectedIndex == 1)
            {
                day = -90;

            }
            else if (rdbTarih.SelectedIndex == 2)
            {
                day = -180;

            }
            else if (rdbTarih.SelectedIndex == 3)
            {
                day = -365;

            }
            else
            {
                day = -1825;
            }

            VeriGetir(day);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //return;
        }

        #region Yazıcıya gönderir
        protected void BtnYazdir_Click(object sender, ImageClickEventArgs e)
        {
            if (grdVeri.Rows.Count > 0)
            {
                grdVeri.PagerSettings.Visible = false;
                //grdVeri.DataBind();
                //  VeriGetir();
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdVeri.RenderControl(hw);
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
                grdVeri.PagerSettings.Visible = true;
                grdVeri.DataBind();
                VeriGetir(day);
            }
        }
        #endregion

        #region Excel e çıkartır
        protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Avantaj Kaybı.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdVeri.AllowPaging = false;
            //grdVeri.DataBind();
            //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
            grdVeri.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
            grdVeri.HeaderRow.Cells[0].Style.Add("background-color", "#d2e009");
            grdVeri.HeaderRow.Cells[1].Style.Add("background-color", "#d2e009");
            grdVeri.HeaderRow.Cells[2].Style.Add("background-color", "#d2e009");
            grdVeri.HeaderRow.Cells[3].Style.Add("background-color", "#d2e009");
            grdVeri.HeaderRow.Cells[4].Style.Add("background-color", "#d2e009");
            grdVeri.HeaderRow.Cells[5].Style.Add("background-color", "#d2e009");
            for (int i = 0; i < grdVeri.Rows.Count; i++)
            {
                GridViewRow row = grdVeri.Rows[i];
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
            grdVeri.RenderControl(hw);
            //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
            string style = @" ";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Pdf e Çıkartır
        protected void BtnPdf_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";
            string Date = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Avantaj Kaybı" + Date + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdVeri.HeaderRow.Style.Add("width", "20%");
            grdVeri.HeaderRow.Style.Add("font-size", "12px");
            grdVeri.HeaderRow.Style.Add("background-color", "Gray");
            grdVeri.Style.Add("text-decoration", "none");
            grdVeri.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grdVeri.Style.Add("font-size", "10px");
            grdVeri.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            for (int j = 0; j < grdVeri.Rows.Count; j++)
            {
                pdfDoc.NewPage();
                htmlparser.Parse(sr);
            }
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        #endregion

    }
}