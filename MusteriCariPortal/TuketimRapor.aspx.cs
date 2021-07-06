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

    public partial class TuketimRapor : System.Web.UI.Page
    {
        SqlConnection con;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
                 
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            if (!IsPostBack)
            {
                SqlCommand com = new SqlCommand("SELECT DISTINCT TOP 10 DATE_,DOCTRACKINGNR AS [TAKİPNO],CONVERT(VARCHAR(10), DATE_, 104) AS [TARİH]  FROM LG_316_01_INVOICE INV LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=INV.CLIENTREF WHERE CL.CODE= '" + Session[0].ToString() + "' AND INV.TRCODE IN (7,8) AND INV.DOCTRACKINGNR <> '' ORDER BY DATE_ DESC ", con); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset
                dpl1.DataTextField = ds.Tables[0].Columns["Tarih"].ToString(); // text field name of table dispalyed in dropdown
                dpl1.DataValueField = ds.Tables[0].Columns["TakipNo"].ToString();           // to retrive specific  textfield name 
                dpl1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                dpl1.DataBind();  //binding dropdownlist
                

                

            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           
            VeriGetirir();

        }
        private void VeriGetirir()
        {
            
            SqlDataAdapter Adpt = new SqlDataAdapter("SELECT DISTINCT BS.ALIMTARIH AS [ALIM TARİH],BS.PLAKA,BS.ISTASYON,BS.ALIMSAAT AS [ALIM SAATİ],BS.MIKTAR[LİTRE],BS.BIRIMFIYAT AS [FİYAT],BS.TUTAR FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_01_INVOICE INV ON INV.FICHENO=CLF.TRANNO LEFT OUTER JOIN LG_316_CLCARD CL ON INV.CLIENTREF=CL.LOGICALREF LEFT OUTER JOIN AKTARIM.DBO.BS_FATURA BS ON BS.SHELLFATNO=INV.DOCTRACKINGNR AND BS.CARIKOD=CL.CODE  WHERE CL.CODE= '" + Session[0].ToString() + "' AND INV.DOCTRACKINGNR = '" + dpl1.SelectedValue + "' ORDER BY ALIMTARIH DESC", con);
            DataTable tblVeriler = new DataTable();
            Adpt.Fill(tblVeriler);
            grdFatura.DataSource = tblVeriler;
            grdFatura.DataBind();
            #region tarih- para formatı
            for (int i = 0; i < grdFatura.Rows.Count; i++)
            {
                grdFatura.Rows[i].Cells[0].Text = grdFatura.Rows[i].Cells[0].Text.ToString().Substring(0, 10);
                if (grdFatura.Rows[i].Cells[2].Text.ToString().Length > 14)
                {
                    grdFatura.Rows[i].Cells[2].Text = grdFatura.Rows[i].Cells[2].Text.ToString().Substring(0, 15);
                }
                decimal sayi = Convert.ToDecimal(grdFatura.Rows[i].Cells[6].Text);
                grdFatura.Rows[i].Cells[6].Text = sayi.ToString("N");
                decimal sayi1 = Convert.ToDecimal(grdFatura.Rows[i].Cells[4].Text);
                grdFatura.Rows[i].Cells[4].Text = sayi1.ToString("N");
            }
            #endregion
            #region alttoplam
            decimal toplamSayi = 0;
            decimal toplamSayi2 = 0;
            //burada basit bir toplama işlemi yapıyoruz. 4. sutundaki verileri alt alta topluyoruz.
            for (int i = 0; i < grdFatura.Rows.Count; i++)
            {
                toplamSayi += Convert.ToDecimal(grdFatura.Rows[i].Cells[4].Text);
                toplamSayi2 += Convert.ToDecimal(grdFatura.Rows[i].Cells[6].Text);
            }
            grdFatura.FooterRow.Cells[3].Text = "Toplam :";
            grdFatura.FooterRow.Cells[5].Text = "Toplam :";
            // kaçtane kayıt olduğunu footerımızın 3. sutununa yazıyoruz.
            grdFatura.FooterRow.Cells[4].Text = toplamSayi.ToString();
            grdFatura.FooterRow.Cells[6].Text = toplamSayi2.ToString();
            // topladığımız değerleri footerdaki 4. sutuna yazıyoruz.
            #endregion
        }


        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            VeriGetir();
        }
        private void VeriGetir()
        {
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT TARIH AS [ALIM TARİH],PLAKA,ISTASYON='HİLMİ BEKEN',[ALIM SAAT]='',LITRE,FIYAT,TUTAR FROM TURPAK_IRSALIYE WHERE CARIKOD='" + Session[0].ToString() + "' AND TARIH>=CONVERT(DATETIME,'" + txtFromDate.Text + "',104) AND TARIH<=CONVERT(DATETIME,'" + txtToDate.Text + "',104) UNION ALL  SELECT ALIMTARIH,PLAKA,ISTASYON,ALIMSAAT,MIKTAR,BIRIMFIYAT,TUTAR FROM BS_ATSFATURA WHERE  ALIMTARIH>=CONVERT(DATETIME,'" + txtFromDate.Text + "',104) AND ALIMTARIH<=CONVERT(DATETIME,'" + txtToDate.Text + "',104) AND  CARIKOD='" + Session[0].ToString() + "' UNION ALL SELECT ALIMTARIH,PLAKA,ISTASYON,ALIMSAAT,MIKTAR,BIRIMFIYAT,TUTAR FROM BS_FATURA WHERE  ALIMTARIH>=CONVERT(DATETIME,'" + txtFromDate.Text + "',104) AND ALIMTARIH<=CONVERT(DATETIME,'" + txtToDate.Text + "',104) AND  CARIKOD='" + Session[0].ToString() + "' UNION ALL SELECT ALIMTARIH,PLAKA,ISTASYON,ALIMSAAT,MIKTAR,BIRIMFIYAT,TUTAR FROM BS_YAKITMATIKFATURA WHERE  ALIMTARIH>=CONVERT(DATETIME,'" + txtFromDate.Text + "',104) AND ALIMTARIH<=CONVERT(DATETIME,'" + txtToDate.Text + "',104) AND  CARIKOD='" + Session[0].ToString() + "' ORDER BY [ALIM TARİH] desc", conn);
            DataTable tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            grdFatura.DataSource = tblVeri;
            grdFatura.DataBind();
            #region tarih- para formatı
            for (int i = 0; i < grdFatura.Rows.Count; i++)
            {
                grdFatura.Rows[i].Cells[0].Text = grdFatura.Rows[i].Cells[0].Text.ToString().Substring(0, 10);
                if (grdFatura.Rows[i].Cells[2].Text.ToString().Length > 14)
                {
                    grdFatura.Rows[i].Cells[2].Text = grdFatura.Rows[i].Cells[2].Text.ToString().Substring(0, 15);
                }
                decimal sayi = Convert.ToDecimal(grdFatura.Rows[i].Cells[6].Text);
                grdFatura.Rows[i].Cells[6].Text = sayi.ToString("N");
                decimal sayi1 = Convert.ToDecimal(grdFatura.Rows[i].Cells[4].Text);
                grdFatura.Rows[i].Cells[4].Text = sayi1.ToString("N");
            }
            #endregion
            #region alttoplam
            decimal toplamSayi = 0;
            decimal toplamSayi2 = 0;
            //burada basit bir toplama işlemi yapıyoruz. 4. sutundaki verileri alt alta topluyoruz.
            for (int i = 0; i < grdFatura.Rows.Count; i++)
            {
                toplamSayi += Convert.ToDecimal(grdFatura.Rows[i].Cells[4].Text);
                toplamSayi2 += Convert.ToDecimal(grdFatura.Rows[i].Cells[6].Text);
            }
            grdFatura.FooterRow.Cells[3].Text = "Toplam :";
            grdFatura.FooterRow.Cells[5].Text = "Toplam :";
            // kaçtane kayıt olduğunu footerımızın 3. sutununa yazıyoruz.
            grdFatura.FooterRow.Cells[4].Text = toplamSayi.ToString();
            grdFatura.FooterRow.Cells[6].Text = toplamSayi2.ToString();
            // topladığımız değerleri footerdaki 4. sutuna yazıyoruz.
            #endregion

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

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
                VeriGetir();
            }
        }
        #endregion

        #region Excel e çıkartır
        protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Tüketim Raporu.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //grdFatura.AllowPaging = false;
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
            string Date = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Tüketim Raporu" + Date + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdFatura.HeaderRow.Style.Add("width", "20%");
            grdFatura.HeaderRow.Style.Add("font-size", "12px");
            grdFatura.HeaderRow.Style.Add("background-color", "Gray");
            grdFatura.Style.Add("text-decoration", "none");
            grdFatura.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grdFatura.Style.Add("font-size", "10px");
            grdFatura.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            for (int j = 0; j < grdFatura.Rows.Count; j++)
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