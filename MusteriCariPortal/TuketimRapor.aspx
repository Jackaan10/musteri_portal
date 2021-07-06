<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="TuketimRapor.aspx.cs" EnableEventValidation="false" Inherits="MusteriCariPortal.TuketimRapor" %>

<%@ Register Src="UserControl/ucAna.ascx" TagName="ucAna" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#<%=txtFromDate.ClientID %>").datepicker({ dateFormat: "dd-mm-yy",
monthNames: [ "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" ],
dayNamesMin: [ "Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct" ],
firstDay:1 });
             $("#<%=txtToDate.ClientID %>").datepicker({ dateFormat: "dd-mm-yy",
monthNames: [ "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" ],
dayNamesMin: [ "Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct" ],
firstDay:1 });                     
         });

    </script>

     <style type="text/css">
         .auto-style1 {
             width: 110px;
         }
         .auto-style2 {
             width: 83px;
         }

     </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

    <div id="mainContainer" class="container">               
                <div class="page-container">  
                    <div class="container"> 
                         <div>
     
    </div>
    <div style="font-weight: 700; font-size: large; color: #0055C4">
        <br />

        Tüketim Raporu<br />
        <div style=" border: thin outset #CCCCCC"></div>
    </div>
 <br />

  <table>
        <tr>
            <td style="text-align: left;" class="auto-style1"><asp:label ID="txtsonfatura" runat="server"   Font-Size="Medium" Text="Son 10 Fatura:" Font-Bold="True">
                    </asp:label></td>
            <td style="width: 169px">
              <asp:DropDownList ID="dpl1"   runat="server" Font-Size="Small">  
        </asp:DropDownList> 
            </td>
            <td style="width: 172px">
                <div style="text-align: left">
                    <asp:Button ID="Button1" runat="server" Text="Sorgula" OnClick="Button1_Click1" Height="25px" Width="100px" />  
                   
                </div>
            </td>         
        </tr>
    </table>

<br />

    <table>
        <tr>
            <td style="text-align: left;  " class="auto-style1">Başlangıç Tarihi :</td>
            <td style="width: 169px">
                <asp:TextBox  ID="txtFromDate" runat="server" ></asp:TextBox>
            </td>
            <td style="text-align: left; " class="auto-style2">Bitiş Tarihi :</td>
            <td style="width: 150px">
                <asp:TextBox ID="txtToDate" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 150px">
                <div style="text-align: left">
                    <asp:Button ID="ASPxButton1" runat="server" Height="27px" OnClick="ASPxButton1_Click" Text="Sorgula" Width="168px" >
                    </asp:Button>
                </div>
            </td>         
        </tr>
    </table>
<br/>
   <div>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="27px" ImageUrl="~/image/printer.ico" OnClick="BtnYazdir_Click" Width="42px" style="text-align: right" />
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="BtnExcel_Click" />
                  <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" ImageUrl="~/image/pdf.jpg" Width="40px" ToolTip="Pdf" Style="text-align: right" OnClick="BtnPdf_Click" />
            
        <br/>
    </div>
    <div>
       <br/>

        <div class="table-responsive">
        <asp:GridView ID="grdFatura" runat="server"   CellPadding="2" ForeColor="#333333" ShowFooter="True"  style="text-align:right"  Width="100%" BorderStyle="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Black" />
            <HeaderStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="ActiveCaptionText" />
            <PagerStyle BackColor="WhiteSmoke" ForeColor="#333333" />
            <RowStyle  HorizontalAlign="Right" BackColor="WhiteSmoke" ForeColor="#333333" />
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

