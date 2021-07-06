<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="AracLimit.aspx.cs" Inherits="MusteriCariPortal.AracLimit" %>

<%@ Register src="UserControl/ucAna.ascx" tagname="ucAna" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="font-weight: 700; font-size: large; color: #FF6600">
        <br/>
        <br/>
         Araç Limit Güncelleme<br />
        <div style="width: 795px; border: thin outset #CCCCCC"></div>
    </div>
    <div>
        <br />
        <br/>
        <uc1:ucAna ID="ucAna1" runat="server" />
        <br/>
    </div>
     <div>
         <br/>         
         <br/>
        <table style="width: 797px">
            <tr>
                <td style="width: 169px">Plaka<br />
                    <asp:TextBox ID="txtPlaka" runat="server" Width="99px"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btnAra" runat="server" Text="Ara" Width="45px" OnClick="btnAra_Click" />
                </td>
                <td style="text-align: center; color: #FF6600; width: 455px;">
                    <br />
                    <asp:Button ID="btnAracLimit" runat="server" Text="Talebi Gönder" Width="162px" OnClick="btnAracLimit_Click" Height="26px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td style="width: 29px"></td>
            </tr>
        </table>
         <br/>
    </div>
       <div>
        <asp:GridView ID="grdArac" runat="server" AllowPaging="True" Width="795px" OnPageIndexChanging="grdArac_PageIndexChanging" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCreated="grdArac_RowCreated" PageSize="200">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" width="20px"/>
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </div>
    <div>
         <br/>
         <br/>
    </div>
</asp:Content>

