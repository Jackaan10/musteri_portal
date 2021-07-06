<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ucAna.ascx.cs" Inherits="MusteriCariPortal.UserControl_ucAna" %>
<div style="width: 800px; background-color: #CCCCCC;">
    <table style="width: 800px">
        <tr>
            <td style="width: 170px; height: 23px;">Müşteri Ünvanı:</td>
            <td style="width: 250px; height: 23px;">
                <asp:Label ID="lblUnvan" runat="server" style="font-size: small" Text="-"></asp:Label>
            </td>
            <td style="width: 117px; height: 23px;"></td>
            <td style="height: 23px"></td>
        </tr>
        <tr>
            <td style="width: 170px">Vergi Numarası:</td>
            <td style="width: 250px">
                <asp:Label ID="lblVergiDaire" runat="server" style="font-size: small" Text="-"></asp:Label>
            </td>
            <td style="width: 117px">Vergi Dairesi :</td>
            <td>
                <asp:Label ID="lblVergiNo" runat="server" style="font-size: small" Text="-"></asp:Label>
            </td>
        </tr>
    </table>
</div>

