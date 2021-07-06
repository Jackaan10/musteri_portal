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
public partial class BaForm : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
}