<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="Kurumsal.aspx.cs" Inherits="MusteriCariPortal.Kurumsal" %>

<%@ Register Src="~/UserControl/ucAna.ascx" TagPrefix="uc1" TagName="ucAna" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="color: #FF6600; font-size: large">
        <strong>&nbsp;Firma Bilgileri Güncelleme&nbsp;</strong></p>
    <div>
     
    </div>
    <div style="width: 800px; background-color: #CCCCCC;">
        <uc1:ucAna runat="server" ID="ucAna" />
    </div>
    <div style="font-weight: 700">
        </br>

        Adres Bilgileri<br />
        <div style="border: thin ridge #999999; width:794px; font-weight: normal;"></div>
        <div>
            </br>
        </div>
        
                            <table style="height: 133px; width: 571px">
                                <tr>
                                    <td style="font-weight: 700; width: 179px; height: 104px;">Adres </td>
                                    <td style="width: 251px; height: 104px;">
                                        <asp:TextBox ID="txtAdres" runat="server" Height="97px" TextMode="MultiLine" Width="234px" Enabled="False"></asp:TextBox>
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td style="font-weight: 700; width: 179px;">İl</td>
                                    <td style="width: 251px">
                                        <asp:TextBox ID="txtIl" runat="server" Width="235px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: 700; width: 179px;">İlçe</td>
                                    <td style="width: 251px">
                                        <asp:TextBox ID="txtIlce" runat="server" Width="235px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="font-weight: 700; height: 26px; width: 179px;">Posta Kodu</td>
                                    <td style="height: 26px; width: 251px;">
                                        <asp:TextBox ID="txtpostaKod" runat="server" Width="235px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="font-weight: 700; width: 179px;">&nbsp;</td>
                                    <td style="width: 251px">
                                        &nbsp;</td>
                                </tr>
                                                              
                            </table>
                
               
                            <table style="height: 133px; width: 571px">
                                <tr>
                                    <td style="font-weight: 700; width: 179px; height: 104px;">Adres </td>
                                    <td style="width: 251px; height: 104px;">
                                        <asp:TextBox ID="txtAdres0" runat="server" Enabled="False" Height="97px" TextMode="MultiLine" Width="234px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: 700; width: 179px;">İl</td>
                                    <td style="width: 251px">
                                        <asp:TextBox ID="txtIl0" runat="server" Enabled="False" Width="235px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: 700; width: 179px;">İlçe</td>
                                    <td style="width: 251px">
                                        <asp:TextBox ID="txtIlce0" runat="server" Enabled="False" Width="235px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: 700; height: 26px; width: 179px;">Posta Kodu</td>
                                    <td style="height: 26px; width: 251px;">
                                        <asp:TextBox ID="txtpostaKod0" runat="server" Enabled="False" Width="235px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: 700; width: 179px;">&nbsp;</td>
                                    <td style="width: 251px">&nbsp;</td>
                                </tr>
                            </table>
                   

    </div>
    <div style="font-weight: 700">
        <br />      
        İletişim Bilgileri<br />
        <br />
        <br />
        <div style="border: thin ridge #999999; width:794px; font-weight: normal;" >
            <table>
                <tr>
                    <td style="width: 239px; font-weight: 700; font-size: small;">Yetkili Kişi </td>
                    <td style="width: 340px">
                        <asp:Label ID="lblYetkili" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 239px; font-weight: 700; height: 23px; font-size: small;">E-Mail</td>
                    <td style="width: 340px; height: 23px;">
                        <asp:Label ID="lblMail" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 239px; font-weight: 700; height: 23px; font-size: small;">Telefon</td>
                    <td style="width: 340px; height: 23px;">
                        <asp:Label ID="lblTelefon" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
    </div>
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="color: #000000">Sistemimizde Değişmesini İstediğiniz Cari Bilgiler için Linkteki Formu İndirip Doldurarak info@hilmibeken.com adresi üzerinden bizlere Ulaştırınız</asp:LinkButton>
 <br />
        <br />
    </div>
</asp:Content>

