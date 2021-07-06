<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="MusteriLimit.aspx.cs" Inherits="MusteriCariPortal.MusteriLimit" %>

<%@ Register src="UserControl/ucAna.ascx" tagname="ucAna" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-weight: 700; font-size: large; color: #FF6600">
        <br/>
        <br/>
        Limit Bilgileri<br />
    <div style="width: 795px; border: thin outset #CCCCCC"></div>
    </div>
    <div>
        <br/>
        <br/>
        <uc1:ucAna ID="ucAna1" runat="server" />
    </div>
    <div>
      <br/>
    </div>
    <div style="border: thin outset #000000; width: 436px;">
    <table>
        <tr>
            <td style="width: 175px">Aylık Limit Tutarı :</td>
            <td style="width: 200px; text-align: right;">
                <asp:TextBox ID="txtLimit" runat="server" Enabled="False" Width="200px" style="text-align: right">0</asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 175px">Kullanım Tutarı :</td>
            <td style="width: 200px; text-align: right;">
                <asp:TextBox ID="txtKullanim" runat="server" Enabled="False" Width="200px" style="text-align: right">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 175px">Güncel Limit Tutarı :</td>
            <td style="width: 200px; text-align: right;">
                <asp:TextBox ID="txtGuncel" runat="server" Enabled="False" Width="200px" style="text-align: right"></asp:TextBox>
            </td>
        </tr>
    </table>  
    </div>
    <div>
        <br/>  Not:Veriler Ön Bilgi Mahiyetinde Olup, Hata ve Unutma Müstesnadır.Mütabakat İçin Muhasebe Birimimizle İrtibata Geçmenizi Rica Ederiz.
        </div>
     <div style="font-weight: 700; font-size: medium; color: #FF6600">
        <br/>
         Limit Güncelleme Talebi
    <div style="width: 795px; border: thin outset #CCCCCC"></div>
         <br/>
    </div>
    <div style="border: thin outset #000000; width: 436px;">
    <table>
        <tr>
            <td style="width: 175px">Aylık Limit Tutar Talebi :</td>
            <td style="width: 200px">
                <asp:TextBox ID="txtLimitTalep" runat="server" Width="200px" style="text-align: right"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 175px">Açıklama :</td>
            <td style="width: 200px">
                <asp:TextBox ID="txtAciklama" runat="server" Width="198px" Height="107px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>  
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnKaydet" runat="server" Height="36px" Text="Talebi Gönder" Width="202px" OnClick="btnKaydet_Click" />
            </td>
        </tr>     
    </table>  
    </div>
    <div>
        <br/>
        <br/>
        <br/>
    </div>
    </asp:Content>

