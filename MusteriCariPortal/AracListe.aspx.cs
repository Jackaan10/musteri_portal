using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{ 
public partial class AracListe : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        VeriGetir();       
    }
    private void VeriGetir()
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        SqlDataAdapter adpPlaka = new SqlDataAdapter("SELECT PLAKA,DURUM FROM BS_PLAKA WHERE CARIKOD='" + Session[0].ToString() + "'", conn);
        //Response.Write(Session[0].ToString());
        DataTable tblPlaka = new DataTable();
        adpPlaka.Fill(tblPlaka);
        this.grdPlaka.DataSource = tblPlaka;
        this.grdPlaka.DataBind();
    }
    protected void grdPlaka_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grdPlaka.PageIndex = e.NewPageIndex;
        //VeriGetir();
    }
}

}