using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{
    public partial class OdemeHatali : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsj.Text = "Ödemeniz gerçekleştirilemedi..!! Lütfen daha sonra tekrar deneyiniz,sorun devam ederse bankanıza başvurunuz.";

            

        }
    }
}