using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MusteriCariPortal
{


public partial class SanalPos : System.Web.UI.Page
{
    SqlConnection conn;
    double bakiye;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsj.Text = "";
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        SqlCommand cmdBakiye = new SqlCommand("SELECT CAST((ISNULL(SUM(AMOUNT),0)-(SELECT ISNULL(SUM(AMOUNT),0)  FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF WHERE SIGN=1  AND CL.CODE='" + Session[0].ToString() + "'))AS DECIMAL(10,2)) AS TOPLAM FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF LEFT OUTER JOIN LG_316_PAYPLANS PY ON PY.LOGICALREF=CL.PAYMENTREF  LEFT OUTER JOIN LG_316_01_INVOICE INV ON INV.LOGICALREF=CLF.SOURCEFREF WHERE SIGN=0 AND CL.CODE ='" + Session[0].ToString() + "' AND CL.BANKACCOUNTS7<>'H' AND CL.CYPHCODE NOT IN ('P','KEMER','AFYON','KORKUTELI','ATSO','LUKOIL') AND CL.ACTIVE=0  AND CLF.CANCELLED=''", conn);
        conn.Open();
        SqlDataReader rdrBakiye = cmdBakiye.ExecuteReader();
        while (rdrBakiye.Read())
        {
            bakiye = Convert.ToDouble(rdrBakiye[0]);
        }
        conn.Close();
        txtBakiye.Text = bakiye.ToString();
    }
    protected void TxtOdeme_Click(object sender, EventArgs e)
    {
        //ePayment.cc5payment sanalPos = new ePayment.cc5payment();
        //sanalPos. = "https://sanalpos.teb.com.tr/fim/est3Dgate";
        //sanalPos.name = "hilmiadmin";
        //sanalPos.password = "SFRE5286";
        ////sanalPos.clientid = "400705286";
        //sanalPos.orderresult = 0;
        //sanalPos.cardnumber = txtNumara.Text;
        //sanalPos.expmonth = cmbAy.Text;
        //sanalPos.expyear = cmbYil.Text;
        //sanalPos.cv2 = txtCvc.Text;
        ////sanalPos.subtotal = txtOdemeTutar.Text;
        //sanalPos.currency = "949";
        ////sanalPos.chargetype = "Auth";


        //String okUrl = "http://onay.hilmibeken.com:93/OdemeTamam.aspx";     //İşlem başarılıysa dönülecek sayfa
        //String failUrl = "http://onay.hilmibeken.com:93/OdemeHatali.aspx";
        //String hashstr = "400705286" + "" + txtOdemeTutar.Text + okUrl + failUrl + "Auth" + "" + DateTime.Now.ToString() + "";
        //System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        //byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashstr);
        //byte[] inputbytes = sha.ComputeHash(hashbytes);
        //String hash = Convert.ToBase64String(inputbytes);    





        //String clientId = "400705286";   //Banka tarafından verilen işyeri numarası     
        //String amount = txtOdeme.Text;         //İşlem tutarı
        //String oid = "";                 //Sipariş Numarası
        ////String okUrl = "http://onay.hilmibeken.com:93/OdemeTamam.aspx";     //İşlem başarılıysa dönülecek sayfa
        ////String failUrl = "http://onay.hilmibeken.com:93/OdemeHatali.aspx";   //İşlem başarısızsa dönülecek sayfa
        //String rnd = DateTime.Now.ToString();  //Kontrol ve güvenlik amaçlı sürekli değişen bir değer tarih gibi

        //String taksit = "";      //Taksit sayısı
        //String islemtipi = "Auth"; //İşlem tipi
        //String storekey = "xxxxxx";  //İş yeri anahtarı
        ////String hashstr = clientId + oid + amount + okUrl + failUrl + islemtipi + taksit + rnd + storekey;
        ////System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        ////byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashstr);
        ////byte[] inputbytes = sha.ComputeHash(hashbytes);

        ////String hash = Convert.ToBase64String(inputbytes);  //Güvenlik amaçlı hash değeri

    }
    protected void btnDevam_Click(object sender, EventArgs e)
    {
        lblMsj.Text = "";
        if (chkSec.Checked == true)
        {
            if (chkOnBilgi.Checked == true && chkSozlesme.Checked == true)
            {
                Session["Tutar"] = txtBakiye.Text;
                Response.Redirect("PosOdeme.aspx");
            }
            else
            {
                lblMsj.Text = "Lütfen Bilgilendirme Formu ve Satış Sözleşmesi Seçeneklerini İşaretleyiniz.";
            }
        }
        else
        {
            if (txtOdemeTutar.Text != "")
            {
                if (chkOnBilgi.Checked == true && chkSozlesme.Checked == true)
                {
                    Session["Tutar"] = txtOdemeTutar.Text;
                    Response.Redirect("PosOdeme.aspx");                     
                }
                else
                {
                    lblMsj.Text = "Lütfen Bilgilendirme Formu ve Satış Sözleşmesi Seçeneklerini İşaretleyiniz.";
                }
            }
        }
    }
}
}