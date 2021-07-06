using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MusteriCariPortal
{ 
public partial class Kurumsal : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT DEFINITION_,TAXNR,TAXOFFICE,ADDR1,ADDR2,INCHARGE,EMAILADDR,TOWN AS [İLÇE],CITY AS [İL],POSTCODE,TELNRS1 FROM LG_316_CLCARD WHERE CODE='" + Session[0].ToString() + "'", conn);
        DataTable tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        foreach (DataRow item in tblVeri.Rows)
        {
            //lblUnvan.Text = item[0].ToString();
            //lblVergiDaire.Text = item[1].ToString();
            //lblVergiNo.Text = item[2].ToString();
            txtAdres.Text = item[3].ToString();
            txtIl.Text=item[8].ToString();
            txtIlce.Text=item[7].ToString();
            txtpostaKod.Text=item[9].ToString();
            lblYetkili.Text = item[5].ToString();
            lblMail.Text = item[6].ToString();
            txtAdres0.Text = item[3].ToString();
            txtIl0.Text = item[8].ToString();
            txtIlce0.Text = item[7].ToString();
            txtpostaKod0.Text = item[9].ToString();
            lblTelefon.Text = item[10].ToString();
        }
    }
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