using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using iTextSharp.tool.xml;

namespace MusteriCariPortal
{


    public partial class CariEkstre : System.Web.UI.Page
    {
        double borc = 0;
        double alacak = 0;
        bool sayfa = false;
        double bakiye = 0;
        string borcGrid;
        int day;
        SqlConnection conn;
        LinkButton c = new LinkButton();

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            
        }




        private void Detay()
        {
           

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
               
                if (GridView2.Rows[i].Cells[14].Text != "Diğer İstasyonlar")
                {
                    if (GridView2.Rows[i].Cells[14].Text != "Kendi İstasyonumuz" )
                    {
                        if (GridView2.Rows[i].Cells[14].Text != "Bizim_İstasyon")
                        {

                            if (GridView2.Rows[i].Cells[13].Text != "IRS")
                            {
                                GridView2.Rows[i].Cells[0].Text = "";
                            }

                        }
                    }

                }

              

            }
        }

        
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)

        {
             
            if (rdbTarih.SelectedIndex == 0)
            {
   
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 1800000000;
                cmd.CommandText = "PORTAL_CARIBAKIYE";
                cmd.CommandType = CommandType.StoredProcedure;                                                         
                cmd.Parameters.AddWithValue("@TARIH1", Convert.ToDateTime(DateTime.Now.AddDays(-30)));
                cmd.Parameters.AddWithValue("@TARIH2", Convert.ToDateTime(DateTime.Now));
                cmd.Parameters.AddWithValue("@KODU", Session[0].ToString());
                SqlDataAdapter adpVeri = new SqlDataAdapter();
                adpVeri.SelectCommand = cmd;
                System.Data.DataTable tblMotorin = new System.Data.DataTable();
                adpVeri.Fill(tblMotorin);
                GridView2.DataSource = tblMotorin;
                GridView2.DataBind();

                for (int i = 0; i < GridView2.Rows.Count; i++)
                {

                                 
                    GridView2.HeaderRow.Cells[1].Visible = false;
                    GridView2.FooterRow.Cells[1].Visible = false;
                    GridView2.Rows[i].Cells[1].Visible = false;
                    GridView2.HeaderRow.Cells[2].Visible = false;
                    GridView2.FooterRow.Cells[2].Visible = false;
                    GridView2.Rows[i].Cells[2].Visible = false;
                    GridView2.HeaderRow.Cells[3].Visible = false;
                    GridView2.FooterRow.Cells[3].Visible = false;
                    GridView2.Rows[i].Cells[3].Visible = false;
                    GridView2.HeaderRow.Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[6].Visible = false;
                    GridView2.Rows[i].Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[10].Visible = false;
                    GridView2.HeaderRow.Cells[10].Visible = false;
                    GridView2.Rows[i].Cells[10].Visible = false;
                    GridView2.FooterRow.Cells[11].Visible = false;
                    GridView2.HeaderRow.Cells[11].Visible = false;
                    GridView2.Rows[i].Cells[11].Visible = false;
                    GridView2.FooterRow.Cells[12].Visible = false;
                    GridView2.HeaderRow.Cells[12].Visible = false;
                    GridView2.Rows[i].Cells[12].Visible = false;
                    GridView2.FooterRow.Cells[13].Visible = false;
                    GridView2.HeaderRow.Cells[13].Visible = false;
                    GridView2.Rows[i].Cells[13].Visible = false;
                   
                    //c = new LinkButton();
                    //c.ID = "ch_" + i.ToString();
                    //c.Text = GridView1.Rows[i].Cells[1].Text;
                    //GridView1.Rows[i].Cells[1].Controls.Add(c);
                }



            }
            else if (rdbTarih.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 1800000000;
                cmd.CommandText = "PORTAL_CARIBAKIYE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TARIH1", Convert.ToDateTime(DateTime.Now.AddDays(-90)));
                cmd.Parameters.AddWithValue("@TARIH2", Convert.ToDateTime(DateTime.Now));
                cmd.Parameters.AddWithValue("@KODU", Session[0].ToString());
                SqlDataAdapter adpVeri = new SqlDataAdapter();
                adpVeri.SelectCommand = cmd;
                System.Data.DataTable tblMotorin = new System.Data.DataTable();
                adpVeri.Fill(tblMotorin);
                GridView2.DataSource = tblMotorin;
                GridView2.DataBind();

                for (int i = 0; i < GridView2.Rows.Count; i++)
                {


                    GridView2.HeaderRow.Cells[1].Visible = false;
                    GridView2.FooterRow.Cells[1].Visible = false;
                    GridView2.Rows[i].Cells[1].Visible = false;
                    GridView2.HeaderRow.Cells[2].Visible = false;
                    GridView2.FooterRow.Cells[2].Visible = false;
                    GridView2.Rows[i].Cells[2].Visible = false;
                    GridView2.HeaderRow.Cells[3].Visible = false;
                    GridView2.FooterRow.Cells[3].Visible = false;
                    GridView2.Rows[i].Cells[3].Visible = false;
                    GridView2.HeaderRow.Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[6].Visible = false;
                    GridView2.Rows[i].Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[10].Visible = false;
                    GridView2.HeaderRow.Cells[10].Visible = false;
                    GridView2.Rows[i].Cells[10].Visible = false;
                    GridView2.FooterRow.Cells[11].Visible = false;
                    GridView2.HeaderRow.Cells[11].Visible = false;
                    GridView2.Rows[i].Cells[11].Visible = false;
                    GridView2.FooterRow.Cells[12].Visible = false;
                    GridView2.HeaderRow.Cells[12].Visible = false;
                    GridView2.Rows[i].Cells[12].Visible = false;
                    GridView2.FooterRow.Cells[13].Visible = false;
                    GridView2.HeaderRow.Cells[13].Visible = false;
                    GridView2.Rows[i].Cells[13].Visible = false;

                    //c = new LinkButton();
                    //c.ID = "ch_" + i.ToString();
                    //c.Text = GridView1.Rows[i].Cells[1].Text;
                    //GridView1.Rows[i].Cells[1].Controls.Add(c);
                }

            }
            else if(rdbTarih.SelectedIndex == 2)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 1800000000;
                cmd.CommandText = "PORTAL_CARIBAKIYE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TARIH1", Convert.ToDateTime(DateTime.Now.AddDays(-180)));
                cmd.Parameters.AddWithValue("@TARIH2", Convert.ToDateTime(DateTime.Now));
                cmd.Parameters.AddWithValue("@KODU", Session[0].ToString());
                SqlDataAdapter adpVeri = new SqlDataAdapter();
                adpVeri.SelectCommand = cmd;
                System.Data.DataTable tblMotorin = new System.Data.DataTable();
                adpVeri.Fill(tblMotorin);
                GridView2.DataSource = tblMotorin;
                GridView2.DataBind();

                for (int i = 0; i < GridView2.Rows.Count; i++)
                {


                    GridView2.HeaderRow.Cells[1].Visible = false;
                    GridView2.FooterRow.Cells[1].Visible = false;
                    GridView2.Rows[i].Cells[1].Visible = false;
                    GridView2.HeaderRow.Cells[2].Visible = false;
                    GridView2.FooterRow.Cells[2].Visible = false;
                    GridView2.Rows[i].Cells[2].Visible = false;
                    GridView2.HeaderRow.Cells[3].Visible = false;
                    GridView2.FooterRow.Cells[3].Visible = false;
                    GridView2.Rows[i].Cells[3].Visible = false;
                    GridView2.HeaderRow.Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[6].Visible = false;
                    GridView2.Rows[i].Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[10].Visible = false;
                    GridView2.HeaderRow.Cells[10].Visible = false;
                    GridView2.Rows[i].Cells[10].Visible = false;
                    GridView2.FooterRow.Cells[11].Visible = false;
                    GridView2.HeaderRow.Cells[11].Visible = false;
                    GridView2.Rows[i].Cells[11].Visible = false;
                    GridView2.FooterRow.Cells[12].Visible = false;
                    GridView2.HeaderRow.Cells[12].Visible = false;
                    GridView2.Rows[i].Cells[12].Visible = false;
                    GridView2.FooterRow.Cells[13].Visible = false;
                    GridView2.HeaderRow.Cells[13].Visible = false;
                    GridView2.Rows[i].Cells[13].Visible = false;

                    //c = new LinkButton();
                    //c.ID = "ch_" + i.ToString();
                    //c.Text = GridView1.Rows[i].Cells[1].Text;
                    //GridView1.Rows[i].Cells[1].Controls.Add(c);
                }

            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 1800000000;
                cmd.CommandText = "PORTAL_CARIBAKIYE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TARIH1", Convert.ToDateTime(DateTime.Now.AddDays(-360)));
                cmd.Parameters.AddWithValue("@TARIH2", Convert.ToDateTime(DateTime.Now));
                cmd.Parameters.AddWithValue("@KODU", Session[0].ToString());
                SqlDataAdapter adpVeri = new SqlDataAdapter();
                adpVeri.SelectCommand = cmd;
                System.Data.DataTable tblMotorin = new System.Data.DataTable();
                adpVeri.Fill(tblMotorin);
                GridView2.DataSource = tblMotorin;
                GridView2.DataBind();
         
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                 
                   
                    GridView2.HeaderRow.Cells[1].Visible = false;
                    GridView2.FooterRow.Cells[1].Visible = false;
                    GridView2.Rows[i].Cells[1].Visible = false;
                    GridView2.HeaderRow.Cells[2].Visible = false;
                    GridView2.FooterRow.Cells[2].Visible = false;
                    GridView2.Rows[i].Cells[2].Visible = false;
                    GridView2.HeaderRow.Cells[3].Visible = false;
                    GridView2.FooterRow.Cells[3].Visible = false;
                    GridView2.Rows[i].Cells[3].Visible = false;
                    GridView2.HeaderRow.Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[6].Visible = false;
                    GridView2.Rows[i].Cells[6].Visible = false;
                    GridView2.FooterRow.Cells[10].Visible = false;
                    GridView2.HeaderRow.Cells[10].Visible = false;
                    GridView2.Rows[i].Cells[10].Visible = false;
                    GridView2.FooterRow.Cells[11].Visible = false;
                    GridView2.HeaderRow.Cells[11].Visible = false;
                    GridView2.Rows[i].Cells[11].Visible = false;
                    GridView2.FooterRow.Cells[12].Visible = false;
                    GridView2.HeaderRow.Cells[12].Visible = false;
                    GridView2.Rows[i].Cells[12].Visible = false;
                    GridView2.FooterRow.Cells[13].Visible = false;
                    GridView2.HeaderRow.Cells[13].Visible = false;
                    GridView2.Rows[i].Cells[13].Visible = false;
                    
                    //c = new LinkButton();
                    //c.ID = "ch_" + i.ToString();
                    //c.Text = GridView1.Rows[i].Cells[1].Text;
                    //GridView1.Rows[i].Cells[1].Controls.Add(c);
                }
            }
           
            Detay();

            
        }

        #region Veri Getir
        private void VeriGetirir(int day)
        {
            SqlDataAdapter adpEkstra = new SqlDataAdapter("SELECT [TARİH]=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104),[FİŞ TÜR]='Devir',[REFERANS]='',[AÇIKLAMA]='DEVİR FİŞİ',[BORÇ]=(SELECT ISNULL(SUM(AMOUNT),0) FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF WHERE SIGN=0 AND CL.CODE='" + Session[0].ToString() + "' AND CLF.DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(day).ToString().Substring(0, 10) + "',104) AND CLF.DATE_<=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104)   AND CANCELLED=0),  \r\n" +
    "[ALACAK]=(SELECT ISNULL(SUM(AMOUNT),0) FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF WHERE SIGN=1 AND CL.CODE='" + Session[0].ToString() + "' AND CLF.DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(day).ToString().Substring(0, 10) + "',104)  AND CLF.DATE_<=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104)  AND CANCELLED=0),[BAKİYE]='0',[I]='' \r\n,[SPE]='0'" +
    "UNION ALL   \r\n" +
"SELECT DISTINCT CLF.DATE_ AS [TARİH],\r\n" +
"[FİŞ TÜRÜ]= \r\n" +
"CASE WHEN CLF.TRCODE=37 THEN  \r\n" +
"'Perakende Satış'  \r\n" +
"ELSE  \r\n" +
"CASE WHEN CLF.TRCODE=32 THEN  \r\n" +
"'Perakende Satış İade'  \r\n" +
"ELSE  \r\n" +
"CASE WHEN CLF.TRCODE=20 THEN  \r\n" +
"'Gelen Havale'  \r\n" +
"ELSE CASE WHEN CLF.TRCODE=5 THEN \r\n" +
"'Virman'  \r\n" +
"ELSE CASE WHEN CLF.TRCODE=31 THEN \r\n" +
"'Satınalma Faturası' \r\n" +
"ELSE CASE WHEN CLF.TRCODE=21 THEN \r\n" +
"'Gönderilen Havale' \r\n" +
"END \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
",CLF.LOGICALREF [REFERANS], \r\n" +
"CLF.LINEEXP AS [AÇIKLAMA],\r\n" +
"[BORÇ]=  \r\n" +
"CASE WHEN CLF.SIGN=0 THEN   \r\n" +
"CLF.TRNET  \r\n" +
"ELSE   \r\n" +
"'0'  \r\n" +
"END, \r\n" +
"[ALACAK]=  \r\n" +
"CASE WHEN CLF.SIGN=1 THEN   \r\n" +
"CLF.TRNET   \r\n" +
"ELSE   \r\n" +
" '0'  \r\n" +
    "END,[BAKİYE]='0',CLF.TRANNO,CLF.SPECODE FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF WHERE CL.CODE = '" + Session[0].ToString() + "'  AND CL.ACTIVE=0 and CLF.TRCODE<>'14' AND  CLF.DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(day).ToString().Substring(0, 10) + "',104) AND CLF.DATE_<=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10) + "',104) AND CLF.CANCELLED=0 AND CLF.PAIDINCASH=0 ORDER BY [TARİH] ", conn);
            DataTable tblDetayli = new DataTable();
            adpEkstra.Fill(tblDetayli);
            GridView2.DataSource = tblDetayli;
            GridView2.DataBind();
            Detay();

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                GridView2.Rows[i].Cells[1].Text = GridView2.Rows[i].Cells[1].Text.ToString().Substring(0, 10);
                borc = Convert.ToDouble(GridView2.Rows[i].Cells[5].Text.ToString());
                alacak = Convert.ToDouble(GridView2.Rows[i].Cells[6].Text.ToString());
                if (i > 0)
                {

                    if (GridView2.Rows[i].Cells[5].Text != "0")
                    { GridView2.Rows[i].Cells[7].Text = Convert.ToString(borc + Convert.ToDouble(GridView2.Rows[i - 1].Cells[7].Text)); }
                    else
                    {
                        { GridView2.Rows[i].Cells[7].Text = Convert.ToString(Convert.ToDouble(GridView2.Rows[i - 1].Cells[7].Text) - alacak); }
                    }
                }
                else
                {
                    GridView2.Rows[i].Cells[7].Text = Convert.ToString(borc - alacak);
                }
                decimal sayi = Convert.ToDecimal(GridView2.Rows[i].Cells[5].Text);
                GridView2.Rows[i].Cells[5].Text = sayi.ToString("N");
                decimal sayi1 = Convert.ToDecimal(GridView2.Rows[i].Cells[6].Text);
                GridView2.Rows[i].Cells[6].Text = sayi1.ToString("N");
                decimal sayi2 = Convert.ToDecimal(GridView2.Rows[i].Cells[7].Text);
                GridView2.Rows[i].Cells[7].Text = sayi2.ToString("N");
                GridView2.HeaderRow.Cells[8].Visible = false;
                GridView2.FooterRow.Cells[8].Visible = false;
                GridView2.Rows[i].Cells[8].Visible = false;
                GridView2.FooterRow.Cells[9].Visible = false;
                GridView2.HeaderRow.Cells[9].Visible = false;
                GridView2.Rows[i].Cells[9].Visible = false;

                //c = new LinkButton();
                //c.ID = "ch_" + i.ToString();
                //c.Text = GridView1.Rows[i].Cells[1].Text;
                //GridView1.Rows[i].Cells[1].Controls.Add(c);
            }
        }

        #endregion

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    


        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
               
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView2.Rows[index];
            int rowIndex = index;          
            Session["Fat_Ref"] = GridView2.Rows[rowIndex].Cells[11].Text.ToString();
            Session["Ref"] = GridView2.Rows[rowIndex].Cells[13].Text.ToString();
            Session["ist"] = GridView2.Rows[rowIndex].Cells[14].Text.ToString();
            Session["spe"] = GridView2.Rows[rowIndex].Cells[12].Text.ToString();
            Session["tarih"] = GridView2.Rows[rowIndex].Cells[4].Text.ToString();           
            string navigateURL = "Plaka_Dokum.aspx";
            string target = "_blank";
            string windowProperties = "status=yes, menubar=yes, toolbar=yes";
            string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
            Detay();
            //Response.Redirect("Plaka_Dokum.aspx");
        }
   
        public override void VerifyRenderingInServerForm(Control control)
        {
            //return;
        }

        #region Yazıcıya gönderir
        protected void BtnYazdir_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView2.Rows.Count > 0)
            {
                GridView2.PagerSettings.Visible = false;
                //GridView1.DataBind();
                //  VeriGetir();
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView2.RenderControl(hw);
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
                GridView2.PagerSettings.Visible = true;
                GridView2.DataBind();
                VeriGetirir(day);

            }
        }
        #endregion

        #region Pdf e çıkartır
        protected void BtnPdf_Click(object sender, ImageClickEventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    GridView2.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    GridView2.HeaderRow.Style.Add("font-size", "12px");
                    GridView2.HeaderRow.Style.Add("background-color", "Gray");
                    GridView2.Style.Add("text-decoration", "none");
                    GridView2.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                    GridView2.Style.Add("font-size", "10px");
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Cari Ekstre.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        #endregion

        #region Excel e çıkartır
        protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
        {
            GridView2.HeaderRow.Cells[0].Visible = false;
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                GridView2.Rows[i].Cells[0].Visible = false;
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Cari Ekstre.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView2.AllowPaging = false;
            //GridView1.DataBind();
            //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
            GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
            GridView2.HeaderRow.Cells[0].Style.Add("background-color", "#d2e009");
            GridView2.HeaderRow.Cells[1].Style.Add("background-color", "#d2e009");
            GridView2.HeaderRow.Cells[2].Style.Add("background-color", "#d2e009");
            GridView2.HeaderRow.Cells[3].Style.Add("background-color", "#d2e009");
            GridView2.HeaderRow.Cells[4].Style.Add("background-color", "#d2e009");
            GridView2.HeaderRow.Cells[5].Style.Add("background-color", "#d2e009");
            GridView2.HeaderRow.Cells[6].Style.Add("background-color", "#d2e009");
            GridView2.HeaderRow.Cells[7].Style.Add("background-color", "#d2e009");
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                GridViewRow row = GridView2.Rows[i];
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
                }
            }
            GridView2.RenderControl(hw);
            //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
            string style = @" ";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //WebClient deneme = new WebClient();
            //deneme.DownloadFile("http://localhost:29808/Form/Cari_Talep_Formu.docx", "~\\Cari_Talep_Formu.docx");
            string dosyaAdi = Server.MapPath("Form") + "\\" + "Cari_Talep_Formu.docx";
            FileInfo dosya = new FileInfo(dosyaAdi);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "filename=Hilmi Beken Cari Talep Formu.docx");
            Response.AddHeader("Content-Length", dosya.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(dosyaAdi);
            Response.End();
            Response.Write("Dosya indirildi");
        }
       
    }

    
  
    
    
}   