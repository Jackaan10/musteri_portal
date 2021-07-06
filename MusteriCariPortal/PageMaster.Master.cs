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
    public partial class PageMaster : System.Web.UI.MasterPage
    {

        SqlConnection conn;
        SqlDataAdapter adpVeri;
        DataTable tbldetay;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            
            adpVeri = new SqlDataAdapter("SELECT DEFINITION_ FROM BEKEN2010.dbo.LG_316_CLCARD WHERE WEBADDR='" + Session["FirmaAd"].ToString() + "'", conn);
            tbldetay = new DataTable();
            adpVeri.Fill(tbldetay);
            lblfirma.Text = tbldetay.Rows[0][0].ToString();
            
        }
    }
}