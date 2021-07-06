<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="YakitAlimDurum.aspx.cs" Inherits="MusteriCariPortal.YakitAlimDurum" %>

<%@ Register Src="UserControl/ucAna.ascx" TagName="ucAna" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <br/>
         <br/>
    </div>
    <div style="font-weight: 700; color: #FF6600">Araç Yakıt Alım Durumu Güncelleme</div>
    <div style="width: 795px; border: thin outset #CCCCCC"></div>
    <div>
        <br/>
         <br/>
    </div>
    <uc1:ucAna ID="ucAna1" runat="server" />
    <div>
         <br/>         
         <br/>
        <table style="width: 797px">
            <tr>
                <td style="width: 185px">Plaka<br />
                    <asp:TextBox ID="txtPlaka" runat="server" Width="99px"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btnAra" runat="server" Text="Ara" Width="45px" OnClick="btnAra_Click" />
                </td>
                <td style="text-align: center; color: #FF6600">Seçili Araçları<br />
                    <br />
                    <asp:Button ID="btnKapat" runat="server" Text="Yakıt Alımına Kapat" Width="159px" OnClick="btnKapat_Click" Height="26px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAc" runat="server" Text="Yakıt Alımına Aç" Width="176px" OnClick="btnAc_Click" />
                </td>
                <td style="width: 29px"></td>
            </tr>
        </table>
         <br/>
    </div>
    <div>
        <asp:GridView ID="grdArac" runat="server" AllowPaging="True" Width="796px" OnPageIndexChanging="grdArac_PageIndexChanging" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCreated="grdArac_RowCreated" PageSize="200">
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

