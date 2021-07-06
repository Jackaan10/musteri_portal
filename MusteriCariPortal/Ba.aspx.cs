using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{ 
public partial class Ba : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        cmbDonem.Items.Clear();
        if (DateTime.Now.Month.ToString() == "2")
        {
            cmbDonem.Items.Add("Ocak");
        }
        else if (DateTime.Now.Month.ToString() == "3")
        {
            cmbDonem.Items.Add("Şubat");
        }
        else if (DateTime.Now.Month.ToString() == "4")
        {
            cmbDonem.Items.Add("Mart");
        }
        else if (DateTime.Now.Month.ToString() == "5")
        {
            cmbDonem.Items.Add("Nisan");
        }
        else if (DateTime.Now.Month.ToString() == "6")
        {
            cmbDonem.Items.Add("Mayıs");
        }
        else if (DateTime.Now.Month.ToString() == "7")
        {
            cmbDonem.Items.Add("Haziran");
        }
        else if (DateTime.Now.Month.ToString() == "8")
        {
            cmbDonem.Items.Add("Temmuz");
        }
        else if (DateTime.Now.Month.ToString() == "9")
        {
            cmbDonem.Items.Add("Ağustos");
        }
        else if (DateTime.Now.Month.ToString() == "10")
        {
            cmbDonem.Items.Add("Eylül");
        }
        else if (DateTime.Now.Month.ToString() == "11")
        {
            cmbDonem.Items.Add("Ekim");
        }
        else if (DateTime.Now.Month.ToString() == "12")
        {
            cmbDonem.Items.Add("Kasım");
        }
        else if (DateTime.Now.Month.ToString() == "1")
        {
            cmbDonem.Items.Add("Aralık");
        }
    }
    protected void btnSorgula_Click(object sender, EventArgs e)
    {
        BaKod.Donem = cmbDonem.Text;
        if (BaKod.Donem == "")
        {
            Response.Write("Lütfen Dönem Seçiniz");
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('BaForm.aspx');", true);
        }        
    }
}
}