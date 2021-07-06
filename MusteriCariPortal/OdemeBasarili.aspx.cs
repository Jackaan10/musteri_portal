using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{
    public partial class OdemeBasarili : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.Form.ToString());

            string sonuc = Request.Form.Get("Response");
            string siparisno = Request.Form.Get("oid");
            string cariid = Request.Form.Get("cariid");

            Response.Write("<br /> sonuc (" + sonuc +")");
            Response.Write("<br /> siparis no (" + siparisno + ")");
            Response.Write("<br /> cariid (" + cariid + ")");
            Response.Write("<br /> ");

            if (sonuc.Trim() == "Approved")
            {
                // sql kodu yazılacak durum true olarak değiştirilecek

                conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
                SqlCommand cmdBakiye = new SqlCommand("UPDATE AKTARIM.dbo.POS_ODEME SET DURUM=@DURUM WHERE [SIPARISNO]='" + Session["siparisNo"].ToString() + "' ", conn);
                cmdBakiye.Parameters.AddWithValue("@DURUM", true);
                conn.Open();
                cmdBakiye.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("OdemeTamam.aspx");
            }
            else
            {

                Response.Redirect("OdemeHatali.aspx");
            }
        }
    }
}