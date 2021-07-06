<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="CariEkstre.aspx.cs" Inherits="MusteriCariPortal.CariEkstre" EnableEventValidation="false"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
      <style>
.radioboxlist radioboxlistStyle
{
font-size:x-large;
padding-right: 20px;
}
.radioboxlist label {
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
input:checked + label {
color:#0055C4;
background: #D1CFC2;
}
.responsive{
    max-width:100%;
    height:auto;
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
       Cari Ekstre<br />
        <div style=" border: thin outset #CCCCCC"></div>
    </div>
   <br />

                       
                          <asp:RadioButtonList 
             ID="rdbTarih"
             runat="server"
             AutoPostBack="true"           
             BackColor="White"
             ForeColor="#003366"
             RepeatDirection="Horizontal" 
             Font-Size="Medium"
                              CssClass="radioboxlist"
                              OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                             >
                              
             <asp:ListItem  >1 Ay   </asp:ListItem>
                              
             <asp:ListItem  >3 Ay   </asp:ListItem>
                              
             <asp:ListItem  >6 Ay   </asp:ListItem>

             <asp:ListItem  >Son 1 Yıl   </asp:ListItem>


           
        </asp:RadioButtonList>
<br />
                        <asp:ImageButton ID="BtnYazdir" runat="server" Height="27px" ImageUrl="~/image/printer.ico" OnClick="BtnYazdir_Click" Width="42px" style="text-align: right" />
                    <asp:ImageButton ID="BtnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="BtnExcel_Click" />
                  <asp:ImageButton ID="BtnPdf" runat="server" Height="29px" ImageUrl="~/image/pdf.jpg" Width="40px" ToolTip="Pdf" Style="text-align: right" OnClick="BtnPdf_Click" />

          </div>
                    </div>
                        <hr />
        
                <div class="table-responsive">
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" AllowSorting="True" ForeColor="#333333" ShowFooter="True" Width="100%"  style="text-align: right" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand"   >
            
            <AlternatingRowStyle cssclass="AlternateRowStyle" BackColor="White" />   
             <Columns>
                <asp:ButtonField HeaderText="Plaka Dökümü" Text="Plaka Dökümü" />
            </Columns>

            <FooterStyle BackColor="Gainsboro" Font-Bold="True"  ForeColor="Black" />
            <HeaderStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="ActiveCaptionText" />
            <PagerStyle BackColor="WhiteSmoke" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle cssclass="RowStyle" BackColor="WhiteSmoke" ForeColor="#333333" />
            <SelectedRowStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="WhiteSmoke" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
            </div>
        <div style="height: 75px; font-weight: 700; font-size: medium;">
            Veriler Ön Bilgi Mahiyetinde Olup, Hata ve Unutma Müstesnadır.Mütabakat İçin Muhasebe Birimimizle İrtibata Geçmenizi Rica Ederiz.
        </div>
    <div id="uyarı" style=" font-weight: 700; font-size: medium;" class="cont">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="color: #000000">Sistemimizde Değişmesini İstediğiniz Cari Bilgiler için Linkteki Formu İndirip Doldurarak Tarafımıza Ulaştırınız</asp:LinkButton>
    </div>
   
  </div>
</div>

</asp:Content>
