<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="PosOdeme.aspx.cs" Inherits="MusteriCariPortal.PosOdeme" %>

<%@ Register Src="UserControl/ucAna.ascx" TagName="ucAna" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function tikla() {
            document.getElementById("btnDevam").value = "Devam";
        }
    </script>
    <style type="text/css">
        .auto-style18 {
            text-align: center;
            border-width: 0px;
        }

        .auto-style19 {
            color: #FF6600;
        }

        #btnDevam {
            height: 47px;
            width: 117px;
        }
    </style>
</head>
<body>
    <%

        //  AŞAĞIDA 3D SECURE İŞLEMİ İÇİN GEREKLİ ALANLAR VE KULLANIMLARI İLE ASP.NET KOD ÖRNEĞİ VERİLMİŞTİR. GİRİLEN DEĞERLER TEST AMAÇLI GİRİLMİŞTİR.
        //  3D PAY HOSTING MODEL ÜZERİNE DÜZENLENMİŞ KOD ÖRNEĞİDİR. İŞ YERLERİ KENDİ DEĞERLERİYLE DEĞİŞKENLERİ TANIMLAMALIDIR. 
        //  İŞ YERLERİNE REFERANS AMAÇLI OLUŞTURULMUŞTUR.

        String clientId = "400705286"; //Banka tarafından verilen işyeri numarası
        String amount = Session["Tutar"].ToString();        //işlem tutarı
        String oid = Session["siparisNo"].ToString();               //Sipariş numarası
        String cariid = Session[0].ToString();               //Sipariş numarası
        String okUrl = "http://portal.hilmibeken.com:66/OdemeBasarili.aspx"; //işlem başarılıysa dönülecek web sayfası
        String failUrl = "http://portal.hilmibeken.com:66/OdemeHatali.aspx"; //işlem başarısızsa dönülecek web sayfası  

        String rnd = DateTime.Now.ToString();  //Sürekli değişen bir değer tarih gibi

        String taksit = "";     //Taksit miktarı
        String islemtipi = "Auth"; //işlem tipi
        String storekey = "TRPS5286";  //işyeri anahtarı
        String hashstr = clientId + oid + amount + okUrl + failUrl + islemtipi + taksit + rnd + storekey;
        System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashstr);
        byte[] inputbytes = sha.ComputeHash(hashbytes);

        String hash = Convert.ToBase64String(inputbytes); //Güvenlik ve kontrol amaçlı oluşturulan hash

        // Ödeme ve 3D onayı için gereken parametreler

    %>
    <div style="text-align: center">

        <img alt="" class="auto-style18" src="image/logo_beken.png" />
    </div>
    <br />
    <div class="auto-style19" style="text-align: center">
        <strong>Devam Etmek İçin Butona Tıklayınız<br />
        </strong>
    </div>
    <div style="width: 2000px; border: thin outset #CCCCCC"></div>
    <br />
    <br />
    <center>
            <form method="post" action="https://sanalpos.teb.com.tr/fim/est3Dgate">
                <input type="hidden" name="clientid" value="<%=clientId%>">
                <input type="hidden" name="amount" value="<%=amount%>">
                <input type="hidden" name="cariid" value="<%=cariid%>">
                <input type="hidden" name="oid" value="<%=oid%>">	
                <input type="hidden" name="okUrl" value="<%=okUrl%>" >
                <input type="hidden" name="failUrl" value="<%=failUrl%>" >
                <input type="hidden" name="islemtipi" value="<%=islemtipi%>" >
                <input type="hidden" name="taksit" value="<%=taksit%>">
                <input type="hidden" name="rnd" value="<%=rnd%>" >
                <input type="hidden" name="hash" value="<%=hash%>" >                
	          
                <input type="hidden" name="storetype" value="3d_pay_hosting" >
	
                <input type="hidden" name="refreshtime" value="10" >
		
                <input type="hidden" name="lang" value="tr">
                <input type="hidden" name="firmaadi" value="Benim Firmam">
	
                <input type="hidden" name="Fismi" value="is">
                <input type="hidden" name="faturaFirma" value="faturaFirma">
                <input type="hidden" name="Fadres" value="XXX">
                <input type="hidden" name="Fadres2" value="XXX">
                <input type="hidden" name="Fil" value="XXX">

                <input type="hidden" name="Filce" value="XXX">
                <input type="hidden" name="Fpostakodu" value="postakod93013">
                <input type="hidden" name="tel" value="XXX">
                <input type="hidden" name="fulkekod" value="tr">

                <input type="hidden" name="nakliyeFirma" value="na fi">
                <input type="hidden" name="tismi" value="XXX">
                <input type="hidden" name="tadres" value="XXX">
                <input type="hidden" name="tadres2" value="XXX">

                <input type="hidden" name="til" value="XXX">
                <input type="hidden" name="tilce" value="XXX">
                <input type="hidden" name="tpostakodu" value="ttt postakod93013">
                <input type="hidden" name="tulkekod" value="usa">
                <input type="hidden" name="itemnumber1" value="a1">
                <input type="hidden" name="productcode1" value="a2">
                <input type="hidden" name="qty1" value="3">
                <input type="hidden" name="desc1" value="a4 desc">
                <input type="hidden" name="id1" value="a5">
                <input type="hidden" name="price1" value="6.25">
                <input type="hidden" name="total1" value="7.50">                                  
                <input type="submit" value="Devam" id="btnDevam"/>  
                        
            </form>            
         <%--   <b>Kullanılan Hidden Parametreler</b>
            <br>
                
                &lt;input type="hidden" name="clientid" value=""&gt;<br>
                &lt;input type="hidden" name="amount" value=""&gt;<br>

                &lt;input type="hidden" name="oid" value="hla56bu"&gt;	<br>
                &lt;input type="hidden" name="okUrl" value="" &gt;<br>
                &lt;input type="hidden" name="failUrl" value="" &gt;<br>
                &lt;input type="hidden" name="islemtipi" value="" &gt;<br>
                &lt;input type="hidden" name="taksit" value=""&gt;<br>
                &lt;input type="hidden" name="rnd" value="" &gt;<br>
                &lt;input type="hidden" name="hash" value="" &gt;<br>
	
                &lt;input type="hidden" name="storetype" value="3d_pay_hosting" &gt;<br>
	
                &lt;input type="hidden" name="refreshtime" value="" &gt;<br>
		
                &lt;input type="hidden" name="lang" value=""&gt;<br>
                &lt;input type="hidden" name="firmaadi" value=""&gt;<br>
	
                &lt;input type="hidden" name="Fismi" value=""&gt;<br>
                &lt;input type="hidden" name="faturaFirma" value=""&gt;<br>
                &lt;input type="hidden" name="Fadres" value=""&gt;<br>
                &lt;input type="hidden" name="Fadres2" value=""&gt;<br>
                &lt;input type="hidden" name="Fil" value=""&gt;<br>

                &lt;input type="hidden" name="Filce" value=""&gt;<br>
                &lt;input type="hidden" name="Fpostakodu" value=""&gt;<br>
                &lt;input type="hidden" name="tel" value=""&gt;<br>
                &lt;input type="hidden" name="fulkekod" value=""&gt;<br>

                &lt;input type="hidden" name="nakliyeFirma" value=""&gt;<br>
                &lt;input type="hidden" name="tismi" value=""&gt;<br>
                &lt;input type="hidden" name="tadres" value=""&gt;<br>
                &lt;input type="hidden" name="tadres2" value=""&gt;<br>

                &lt;input type="hidden" name="til" value=""&gt;<br>
                &lt;input type="hidden" name="tilce" value=""&gt;<br>
                &lt;input type="hidden" name="tpostakodu" value=""&gt;<br>
                &lt;input type="hidden" name="tulkekod" value=""&gt;<br>
	
                &lt;input type="hidden" name="itemnumber1" value=""&gt;<br>
                &lt;input type="hidden" name="productcode1" value=""&gt;<br>
                &lt;input type="hidden" name="qty1" value=""&gt;<br>
                &lt;input type="hidden" name="desc1" value=""&gt;<br>
                &lt;input type="hidden" name="id1" value=""&gt;<br>

                &lt;input type="hidden" name="price1" value=""&gt;<br>
                &lt;input type="hidden" name="total1" value=""&gt;<br>
                
               
            --%>
        </center>
    <br />
    <div style="width: 2000px; border: thin outset #CCCCCC"></div>
</body>
</html>
