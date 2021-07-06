<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="FaturalanmayanAlim.aspx.cs" EnableEventValidation="false" Inherits="MusteriCariPortal.FaturalanmayanAlim" %>

<%@ Register Src="UserControl/ucAna.ascx" TagName="ucAna" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


      <div id="mainContainer" class="container">               
                <div class="page-container">  
                    <div class="container">

    <div style="font-weight: 700; font-size: large; color: #0055C4">
        <br/>
     
       Faturalanmamış Alım Listesi<br />
        <div style="border: thin outset #CCCCCC"></div>
    </div>
   <br />
                        <br />
                        <br />
    <div>
                    <asp:ImageButton ID="btnYazdir" runat="server" Height="27px" ImageUrl="~/image/printer.ico" OnClick="BtnYazdir_Click" Width="42px" style="text-align: right" />
                    <asp:ImageButton ID="btnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="BtnExcel_Click" />
                  <asp:ImageButton ID="btnPdf" runat="server" Height="29px" ImageUrl="~/image/pdf.jpg" Width="40px" ToolTip="Pdf" Style="text-align: right" OnClick="BtnPdf_Click" />
            
        <br/>
    </div>
   <div>
       <br/>

        <div class="table-responsive">
        <asp:GridView ID="grdFatura" runat="server"   CellPadding="2" ForeColor="#333333" GridLines="None"  style="text-align:right" ShowFooter="True" Width="100%" BorderStyle="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Black" />
            <HeaderStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="ActiveCaptionText" />
            <PagerStyle BackColor="WhiteSmoke" ForeColor="#333333" />
            <RowStyle HorizontalAlign="Right" BackColor="WhiteSmoke" ForeColor="#333333" />
            <SelectedRowStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="WhiteSmoke" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
            </div>
       <br/> 
        </div>
          <div style="height: 75px; font-weight: 700; font-size: medium;">
            Veriler Ön Bilgi Mahiyetinde Olup, Hata ve Unutma Müstesnadır.Detaylı bilgi için, lütfen şirketimizle irtibata geçiniz.
        </div>
    
        </div>
       </div>     
    </div>
</asp:Content>

