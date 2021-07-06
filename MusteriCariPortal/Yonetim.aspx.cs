using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{ 
public partial class Yonetim : System.Web.UI.Page
{
    double borc = 0;
    double alacak = 0;
    bool sayfa = false;
    double bakiye = 0;
    string borcGrid;
    DataTable tbl;
    SqlConnection conn;
    LinkButton c = new LinkButton();
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        //Label2.Text = Session[1].ToString();
        CariDetayGetir();
    }
    private void CariDetayGetir()
    {
        //ServiceReference1.ServiceSoapClient cariDetay = new ServiceReference1.ServiceSoapClient();
        //DataTable tbl = cariDetay.CariDetay(Session[0].ToString());
        SqlDataAdapter adpCariDetay = new SqlDataAdapter("SELECT DEFINITION_ AS [CARİ AD],ADDR1 AS [ADRES],TELNRS1 AS [TELEFON],EMAILADDR AS [E-MAİL],INCHARGE AS [YETKİLİ],TAXNR AS [VERGİ NO] FROM LG_316_CLCARD WHERE CODE='" + Session[0].ToString() + "'", conn);
        DataTable tblCari = new DataTable();
        adpCariDetay.Fill(tblCari);
        GridView2.DataSource = tblCari;
        GridView2.DataBind();
    }
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        VeriGetir();
    }
    private void VeriGetir()
    {
        //ServiceReference1.ServiceSoapClient detay = new ServiceReference1.ServiceSoapClient();
        //tbl = detay.Ekstre(Session[0].ToString(), dtBaslangic.Text, dtBitis.Text);
        SqlDataAdapter adpEkstre = new SqlDataAdapter("SELECT  [TARİH]=CONVERT(DATETIME,'" + dtBaslangic.Value + "',104),[FİŞ TÜR]='Devir',[REFERANS]='',[BORÇ]=(SELECT ISNULL(SUM(AMOUNT),0) FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF WHERE SIGN=0 AND CL.CODE='" + Session[0].ToString() + "' AND CLF.DATE_>='2015-01-01'  AND CLF.DATE_<=CONVERT(DATETIME,'" + dtBaslangic.Value + "',104)  ),  \r\n" +
"[ALACAK]=(SELECT ISNULL(SUM(AMOUNT),0) FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF WHERE SIGN=1 AND CL.CODE='" + Session[0].ToString() + "' AND CLF.DATE_>='2015-01-01'  AND CLF.DATE_<=CONVERT(DATETIME,'" + dtBaslangic.Value + "',104)),[BAKİYE]='0' \r\n" +
"UNION ALL   \r\n" +
"SELECT CLF.DATE_ AS [TARİH],\r\n" +
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
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
",CLF.LOGICALREF [REFERANS], \r\n" +
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
"END,[BAKİYE]='0' FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF  WHERE  CL.CODE = '" + Session[0].ToString() + "'  AND CL.ACTIVE=0 and CLF.TRCODE<>'14' AND  CLF.DATE_>=CONVERT(DATETIME,'" + dtBaslangic.Value + "',104) AND DATE_<=CONVERT(DATETIME,'" + dtBitis.Value + "',104) AND CLF.CANCELLED=0", conn);
        DataTable tblDetay = new DataTable();
        adpEkstre.Fill(tblDetay);
        GridView1.DataSource = tblDetay;
        GridView1.DataBind();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Cells[1].Text = GridView1.Rows[i].Cells[1].Text.ToString().Substring(0, 10);
            borc = Convert.ToDouble(GridView1.Rows[i].Cells[4].Text.ToString());
            alacak = Convert.ToDouble(GridView1.Rows[i].Cells[5].Text.ToString());
            if (i > 0)
            {
                if (GridView1.Rows[i].Cells[4].Text != "0")
                { GridView1.Rows[i].Cells[6].Text = Convert.ToString(borc + Convert.ToDouble(GridView1.Rows[i - 1].Cells[6].Text)); }
                else
                {
                    { GridView1.Rows[i].Cells[6].Text = Convert.ToString(Convert.ToDouble(GridView1.Rows[i - 1].Cells[6].Text) - alacak); }
                }
            }
            else
            {
                GridView1.Rows[i].Cells[6].Text = Convert.ToString(borc - alacak);
            }
            decimal sayi = Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
            GridView1.Rows[i].Cells[4].Text = sayi.ToString("N");
            decimal sayi1 = Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);
            GridView1.Rows[i].Cells[5].Text = sayi1.ToString("N");
            decimal sayi2 = Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
            GridView1.Rows[i].Cells[6].Text = sayi2.ToString("N");
            //c = new LinkButton();
            //c.ID = "ch_" + i.ToString();
            //c.Text = GridView1.Rows[i].Cells[1].Text;
            //GridView1.Rows[i].Cells[1].Controls.Add(c);
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = GridView1.Rows[index];
        int rowIndex = index;
        string Referans = GridView1.Rows[rowIndex].Cells[3].Text;
        Session["Ref"] = Referans.ToString();
        string navigateURL = "Plaka_Dokum.aspx";
        string target = "_blank";
        string windowProperties = "status=yes, menubar=yes, toolbar=yes";
        string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";       
        Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
        //Response.Redirect("Plaka_Dokum.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)

    { }
    protected void btnYazdir_Click(object sender, ImageClickEventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            GridView1.PagerSettings.Visible = false;
            //GridView1.DataBind();
            //  VeriGetir();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
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
            GridView1.PagerSettings.Visible = true;
            GridView1.DataBind();
            VeriGetir();
        }     
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //WebClient deneme = new WebClient();
        //deneme.DownloadFile("http://localhost:29808/Form/Cari_Talep_Formu.docx", "~\\Cari_Talep_Formu.docx");

        string dosyaAdi = Server.MapPath("Form") + "\\" +"Cari_Talep_Formu.docx";
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