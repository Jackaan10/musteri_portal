<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="BayiAnaSayfa.aspx.cs" Inherits="MusteriCariPortal.BayiAnaSayfa" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <br />
    <asp:Label ID="lblCariAd" runat="server" Font-Bold="True" Font-Size="Large" Text="-"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <div>

        <asp:Label ID="Label1" runat="server" Text="Açıklama :" Font-Bold="True" Font-Size="Large"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;<asp:TextBox ID="txtAciklama" runat="server" Height="171px" TextMode="MultiLine" Width="100%"></asp:TextBox>

        <br />
        <br />
        <asp:GridView ID="grdStok" runat="server" AllowPaging="True" Width="100%" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" PageSize="200" OnRowCreated="grdStok_RowCreated">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Width="20px" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Button ID="btnKaydet" runat="server" Height="59px" Text="Kaydet" Width="100%" OnClick="btnKaydet_Click" OnClientClick="return confirm('işlemler Kaydedilecektir Devam Edilsinmi?');" CommandName="Kaydet" />
    </div>
    <br />
    <br />
    <br />
</asp:Content>

