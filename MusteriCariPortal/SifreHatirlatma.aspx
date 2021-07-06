<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SifreHatirlatma.aspx.cs" Inherits="MusteriCariPortal.SifreHatirlatma" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
        .auto-style2 {
            width: 4px;
            height: 37px;
        }
         .auto-style18 {
            
            color: #FF6600;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div style="text-align: right">
                <div style="text-align: center">
                    &nbsp;<img alt="" class="auto-style17" src="image/logo_beken.png" />
                </div>
                </br>
            </br>
            </br>
            <div class="auto-style18" style="text-align: center; font-size: 22px;">
                <strong>Kullanici Şifre Hatırlatma Modülü<br /></br>
            </div>
                <table style="height: 67px; width: 303px" align="center">
                    <tr>
                        <td class="auto-style20">Kullanıcı Adı
                            <td class="auto-style21">:</td>
                            <td class="auto-style22">
                                <asp:TextBox ID="txtKullaniciAd" runat="server" Height="27px" Width="170px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">Tanımlı Email</td>
                        <td class="auto-style21">:</td>
                        <td class="auto-style22">
                            <asp:TextBox ID="txtEmail" runat="server" Height="27px" Width="170px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td class="auto-style2"></td>
                        <td class="auto-style1">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style19"></td>
                        <td></td>
                        <td>
                            <asp:Label ID="lblUyari" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="height: 67px; width: 303px" align="center">
                    <tr>
                        <td class="auto-style14" style="width: 89px">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Giriş</asp:LinkButton>
                            <td class="auto-style11" style="width: 47px">&nbsp;</td>
                            <td class="auto-style11">
                <strong>
                                <asp:Button ID="btnGonder" runat="server" Height="40px" Text="Gönder" Width="175px" OnClick="btnGonder_Click">
                                </asp:Button>
                            </td>
                    </tr>
                </table>
            </div>
            </br>
        </br>
        </br>
        </br>
        </br>
        </div>
    </form>
</body>
</html>
