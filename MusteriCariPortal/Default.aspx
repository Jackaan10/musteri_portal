
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MusteriCariPortal.Default" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densityDpi=device-dpi" />
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
 

  <style>
img {
  display: block;
  margin-left: auto;
  margin-right: auto;
}

h6{
    display:inline-block;
    
}

.align-left{
    float: left;
    color:rgb(90, 90, 90);
}
.align-right{
    float: right;
    color:rgb(90, 90, 90);
}
.responsive{
    max-width:100%;
    height:auto;
}

</style>
     
    <title>Hilmi Beken Müşteri Portalı</title>
</head>
<body>
   <form method="post" id="form1" runat="server">
       <div class="container">
           <div class="row">
               <div class="col-md-4 col-md-offset-4">
                   <div class="login-panel panel panel-default" style="margin-top:40px;height:480px;">
                       <div class="panel-heading" style="background-color:darkgray;color:#fff">
                           <h3 class="panel-title"></h3>
                       </div>
                       <br/>
                       <img src="image/logo_beken.png" class="responsive"   width="300" height="100"/>
                        <br/>
                        <br/>
                        <br/>
                       <div class="panel-body">
                           <div class="form-group">
                               <label for="emailField">Kullanıcı Adı</label>
                               <div class="input-group">
                                   <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                   <asp:TextBox ID="txtKullaniciAd" runat="server" CssClass="form-control"></asp:TextBox>
                               </div>
                           </div>
                           <div class="form-group">
                               <label for="emailField">Şifre</label>
                               <div class="input-group">
                                   <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                   <asp:TextBox ID="txtParola" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                               </div>
                           </div>
                           <div>
                              <h5>"Giriş" butonuna basmanız halinde,portalımızı kullanmanız sırasında tarafınıza ait veriler <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Style="color: #0026ff">Hilmi Beken Müşteri WEB Portal Kişisel Veriler Hakkında Aydınlatma Metni</asp:LinkButton> kapsamında işlenecektir.</h5>
                           </div>
                           <asp:Button  ID="btnGiris" OnClientClick="btnGiris_Click"  runat="server" CssClass="form-control" class="btn btn-primary btn-block btn-lg btn-signin" Text="Giriş" OnClick="btnGiris_Click" />
                           <br />
                           <span id="error_message"></span>
                           
                           
                           <a class="forgot-password" href="SifreHatirlatma.aspx" ><h6 class="align-left">Şifremi Unuttum</h6></a>
                           <a class="change-password" href="SifreDegistirme.aspx"><h6 class="align-right">Şifre Değiştirme</h6></a>
                            
                       </div>


                       </div>
                     <iframe width="360" height="215" src="https://www.youtube.com/embed/bb2lZslo4gA" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                   </div>
              
               </div>
       </div>
     </form>
</body>
</html>
