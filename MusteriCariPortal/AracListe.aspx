<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="AracListe.aspx.cs" Inherits="MusteriCariPortal.AracListe" %>

<%@ Register Src="UserControl/ucAna.ascx" TagName="ucAna" TagPrefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <br/>
        <br/>
    </div>
    <div style="font-weight: 700; color: #FF6600">
        Tanımlı Plaka Listesi
         <br/>
    </div>
    <div style="width: 795px; border: thin outset #CCCCCC"></div>
    <div>
        <br/>
        <br/>
        <uc1:ucAna ID="ucAna1" runat="server" />
        <br/>
        <br/>
    </div>
    <div>
        
        <asp:GridView ID="grdPlaka" runat="server" AllowPaging="True" Width="799px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="200">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br/>


    </div>
    <br/>
        <br/>
    <br/>
        <br/>
</asp:Content>

