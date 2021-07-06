using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{
    public partial class PosOdeme : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            SqlCommand cmdBakiye = new SqlCommand("INSERT INTO AKTARIM..POS_ODEME (CARIKOD,TUTAR,SIPARISNO,TARIH,SAAT,DURUM) VALUES (@CARIKOD,@TUTAR,@SIPARISNO,@TARIH,@SAAT,@DURUM)", conn);

            string siparisno = "ODEME-" + Session[0].ToString() + "-" + DateTime.Now.Ticks.ToString();
            Session["siparisNo"] = siparisno.ToString();

            cmdBakiye.Parameters.AddWithValue("@CARIKOD", Session[0].ToString());
            cmdBakiye.Parameters.AddWithValue("@TUTAR", Convert.ToDouble(Session["Tutar"]));
            cmdBakiye.Parameters.AddWithValue("@SIPARISNO", siparisno);
            cmdBakiye.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Now));
            cmdBakiye.Parameters.AddWithValue("@SAAT", DateTime.Now.Hour.ToString());
            cmdBakiye.Parameters.AddWithValue("@DURUM", false);
            conn.Open();
            cmdBakiye.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            //String clientId = "400705286"; //Banka tarafından verilen işyeri numarası
            //String amount = Session["Tutar"].ToString();        //işlem tutarı
            //String oid = siparisno;               //Sipariş numarası
            //String cariid = Session[0].ToString();               //Sipariş numarası
            //String okUrl = "http://portal.hilmibeken.com:66/OdemeTamam.aspx"; //işlem başarılıysa dönülecek web sayfası
            //String failUrl = "http://portal.hilmibeken.com:66/OdemeHatali.aspx"; //işlem başarısızsa dönülecek web sayfası
            //String rnd = DateTime.Now.ToString();  //Sürekli değişen bir değer tarih gibi

            //String taksit = "";     //Taksit miktarı
            //String islemtipi = "Auth"; //işlem tipi
            //String storekey = "TRPS5286";  //işyeri anahtarı
            //String hashstr = clientId + oid + amount + okUrl + failUrl + islemtipi + taksit + rnd + storekey;
            //System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            //byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashstr);
            //byte[] inputbytes = sha.ComputeHash(hashbytes);
            //String hash = Convert.ToBase64String(inputbytes); //Güvenlik ve kontrol amaçlı oluşturulan hash



        }
        protected void btnDevam_Click(object sender, EventArgs e)
        {

        }
    }
}