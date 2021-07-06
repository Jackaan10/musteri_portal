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

public partial class SifreDegistirme : System.Web.UI.Page
{
    SqlConnection conn;
    DataTable tblKontrol;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        #region cari kontrol ediliyor
        SqlDataAdapter adpKontrol = new SqlDataAdapter("SELECT * FROM LG_316_CLCARD WHERE  WEBADDR='" + txtKullaniciAd.Text + "' AND ADRESSNO='" + txtParola.Text + "'", conn);
        tblKontrol = new DataTable();
        adpKontrol.Fill(tblKontrol);
        #endregion
        if (tblKontrol.Rows.Count > 0)
        {
            SqlCommand cmdGuncelle = new SqlCommand("UPDATE LG_316_CLCARD SET ADRESSNO='" + txtYeni.Text + "' WHERE WEBADDR='" + txtKullaniciAd.Text + "' AND ADRESSNO='" + txtParola.Text + "'", conn);
            conn.Open();
            cmdGuncelle.ExecuteNonQuery();
            conn.Close();
            txtKullaniciAd.Text = "";
            txtParola.Text = "";
            txtYeni.Text = "";
            Response.Write("Şifreniz Değiştirilmiştir");
        }
        else
        {
            lblUyari.Text = "Kullanıcı Adı veya Parola Hatalı.Tekrar deneyiniz";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
}