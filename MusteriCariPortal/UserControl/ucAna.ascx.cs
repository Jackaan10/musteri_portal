using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{ 
public partial class UserControl_ucAna : System.Web.UI.UserControl
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
         conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT DEFINITION_,TAXNR,TAXOFFICE,ADDR1,ADDR2,INCHARGE,EMAILADDR,TOWNCODE AS [İLÇE],CITYCODE AS [İL],POSTCODE,TELNRS1 FROM LG_316_CLCARD WHERE CODE='" + Session[0].ToString() + "'", conn);
        DataTable tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        foreach (DataRow item in tblVeri.Rows)
        {
            lblUnvan.Text = item[0].ToString();
            lblVergiDaire.Text = item[1].ToString();
            lblVergiNo.Text = item[2].ToString();
        }
    }
}
}