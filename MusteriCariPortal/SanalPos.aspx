<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="SanalPos.aspx.cs" Inherits="MusteriCariPortal.SanalPos" %>

<%@ Register Src="UserControl/ucAna.ascx" TagName="ucAna" TagPrefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <div id="mainContainer" class="container">               
                <div class="page-container">  
                    <div class="container"> 
        <div>
        <script type="text/javascript">
            function onlyNumber(e) {
                var keyCode = event.keyCode;
                if ((keyCode < 46 || keyCode > 57) && keyCode != 8 && keyCode != 9 && keyCode != 0 && keyCode != 47 && (keyCode < 96 || keyCode > 105)) {

                    return false;
                }
            }
        </script>
        <br />
    </div>
    <div style="height: 38px; font-size: xx-large; text-align: center; color: #0055C4;">
        Hilmi Beken Online Ödeme Sistemi
    </div>
    <br />
    <br />
    <uc1:ucAna ID="ucAna1" runat="server" />
    <br />
    <br />
    <div style="font-weight: 700; color: #0055C4; font-size: large">
        Ödeme Bilgileri<br />
    </div>
    <div style="width: 795px; border: thin outset #CCCCCC"></div>
    <br />
    <table>
        <tr>
            <td style="font-weight: 700; font-size: large; height: 26px;">
                <asp:CheckBox ID="chkSec" runat="server" Text="Borç Miktarını Öde" /></td>
        </tr>
        <tr>
            <td style="height: 23px"></td><td style="height: 23px">
            <asp:Label ID="lblMsj" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700; font-size: large;">Borç Miktarı</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtBakiye" style="text-align:right;" runat="server" Width="62px" Height="26px" ReadOnly="True"></asp:TextBox>TL
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="font-weight: 700; font-size: large;">Ödenecek Tutar</td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtOdemeTutar" style="text-align:right;" runat="server" Width="62px" Height="26px" onkeydown="return onlyNumber(event)"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 795px; border: thin outset #CCCCCC"></div>
    <br />
    <div>
        <table>
            <tr>
                <td style="width: 631px">
                    <asp:CheckBox ID="chkOnBilgi" runat="server" Text="     Ön Bilgilendirme Formunu Kabul ediyorum" />
                    <br />
                    <br />
                    <asp:CheckBox ID="chkSozlesme" runat="server" Text="   Satış Sözleşmesini Kabul Ediyorum" />

                </td>
                <td style="width: 143px">&nbsp;<ASP:Button ID="btnDevam" runat="server" Height="44px" OnClick="btnDevam_Click" Text="Devam" Width="133px">
                </ASP:Button>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="width: 795px; border: thin outset #CCCCCC"></div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
       </div>
     </div>
    </div>

</asp:Content>

