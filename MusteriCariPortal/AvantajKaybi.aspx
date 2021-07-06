<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="AvantajKaybi.aspx.cs" Inherits="MusteriCariPortal.AvantajKaybi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
   <style>
       .radioboxlist radioboxlistStyle
       {
           font-size:x-large;
           padding-right: 20px;
       }
       .radioboxlist label 
       {
           color: #3E3928;
           background-color:#ffffff;
           padding-left: 6px;
           padding-right: 16px;
           padding-top: 2px;
           padding-bottom: 2px;
           white-space: nowrap;
           clear: left;
           margin-right: 10px;
           margin-left: 10px;
       }
       .radioboxlist label:hover
       {
           color: #0055C4;
           background: #D1CFC2;
       }
       input:checked + label 
       {
           color: #0055C4;
           background: #D1CFC2;
       }

   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="mainContainer" class="container">  
            <div class="shadowBox">  
                <div class="page-container" style="align-items:center">  
                    <div class="container" style="align-items:center">         
                       <div style="font-weight: 700; font-size: large; color: #0055C4">
       
        <br/>
       Avantaj Kaybı<br />
        <div style="border: thin outset #CCCCCC"></div>
    </div>
<br />
    <table>
        <tr>
            <td style="text-align: left;  " class="auto-style1">Başlangıç Tarihi :</td>
            <td style="width: 169px">
                <asp:TextBox  ID="txtFromDate" runat="server" ></asp:TextBox>
            </td>
            <td style="text-align: left; " class="auto-style2">Bitiş Tarihi :</td>
            <td style="width: 178px">
                <asp:TextBox ID="txtToDate" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 172px">
                <div style="text-align: left">
                    <asp:Button ID="ASPxButton1" runat="server" Height="27px" OnClick="ASPxButton1_Click" Text="Sorgula" Width="168px" >
                    </asp:Button>
                </div>
            </td>         
        </tr>
    </table>
<br/>
  
 
             <asp:RadioButtonList 
             ID="rdbTarih"
             runat="server"
             AutoPostBack="true"           
             BackColor="White"
             ForeColor="#003366"
             RepeatDirection="Horizontal" 
             Font-Size="Medium"
                              CssClass="radioboxlist"
                              OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" EnableViewState="True"
                             >
                              
             <asp:ListItem  >1 Ay   </asp:ListItem>
                              
             <asp:ListItem  >3 Ay   </asp:ListItem>
                              
             <asp:ListItem  >6 Ay   </asp:ListItem>
                              
             <asp:ListItem  >Son 1 Yıl   </asp:ListItem>

             <asp:ListItem  >Tümü   </asp:ListItem>
           
             </asp:RadioButtonList>
     <br />
                        <asp:ImageButton ID="btnYazdir" runat="server" Height="27px" ImageUrl="~/image/printer.ico" OnClick="BtnYazdir_Click" Width="42px" style="text-align: right" />
                    <asp:ImageButton ID="btnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="BtnExcel_Click" />
                  <asp:ImageButton ID="btnPdf" runat="server" Height="29px" ImageUrl="~/image/pdf.jpg" Width="40px" ToolTip="Pdf" Style="text-align: right" OnClick="BtnPdf_Click" />

          </div>
                    </div>
                 <div>
       <br/>
        <h5>Toplam Avantaj Kaybınız&nbsp;&nbsp;&nbsp; :
        <asp:Label ID="toplam" runat="server" style="font-size:medium;" Text="-" ForeColor="Red"></asp:Label>
        </h5>
    </div>
                        <hr />
        <div class="table-responsive">
        <asp:GridView ID="grdVeri" runat="server" CellPadding="2" ForeColor="#333333" ShowFooter="True" Width="100%"  style="text-align: right" GridLines="None" >
            
            <AlternatingRowStyle BackColor="White" />           
            <FooterStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Black" />
            <HeaderStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="ActiveCaptionText" />
            <PagerStyle BackColor="WhiteSmoke" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="WhiteSmoke" ForeColor="#333333" />
            <SelectedRowStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="WhiteSmoke" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
            </div>
       
   
  </div>
</div>
</asp:Content>
