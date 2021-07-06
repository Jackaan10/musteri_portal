<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="MusteriCariPortal.AnaSayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="mainContainer" class="container">               
                <div class="page-container">  
                    <div class="container">
    <div class="container-fluid" style="margin-top:30px;">
    <div class="row">
       
       <asp:Table  runat="server" class="col-sm-10 col-lg-5 col-xl-3 offset-sm-5 mr-auto" style="margin-left:90px;">
            <asp:TableRow runat="server" Font-Bold="True">
                <asp:TableCell style="text-align: left;  font-size:medium;">Bakiye</asp:TableCell>
                <asp:TableCell>&nbsp; : </asp:TableCell>
                <asp:TableCell style="text-align:right;"   >
                    <asp:label ID="txtBakiye" runat="server"   Font-Size="Medium" Text="0" CssClass="bilgiLabel">
                    </asp:label>

                </asp:TableCell>

            </asp:TableRow >
            <asp:TableRow runat="server" Font-Bold="True">
                <asp:TableCell style="text-align:left; font-size:medium;">Limit</asp:TableCell>
                <asp:TableCell>&nbsp; :</asp:TableCell>
                <asp:TableCell style="height: 33px; text-align: right">

                    <asp:label ID="txtLimit" runat="server" Font-Size="Medium" Text="0" CssClass="bilgiLabel">
                    </asp:label>

                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True">
                <asp:TableCell style="text-align: left; font-size:medium;">Faturalanmamış Alım</asp:TableCell>
                <asp:TableCell>&nbsp; : </asp:TableCell>
                <asp:TableCell style="text-align: right">

                    <asp:label ID="txtAlim" runat="server" Font-Size="Medium" Text="0" CssClass="bilgiLabel">
                    </asp:label>

                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Width="100px">
                <asp:TableCell style="text-align: left; font-size:medium;">Kalan Limit</asp:TableCell>
                <asp:TableCell>&nbsp; : </asp:TableCell>
                <asp:TableCell style="text-align: right">
                    <asp:label ID="txtKalanLimit" runat="server" Font-Size="Medium" Text="0" CssClass="bilgiLabel">
                    </asp:label>

                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
            
        <div class="col-12 col-sm-10 col-lg-5 col-xl-3 offset-m-4 offset-lg-4  mt-auto" style="margin-top: 20px; top: 0px; left: 0px; margin-right:50px;">

                <div class="col-md-6 col-lg-4 item" style="margin-top: 0px;"><a href="CariEkstre.aspx"><img class="img-thumbnail" src="image/current-account-icon-trendy-modern-260nw-1227054865.png" style="width: 50px;height: 50px;" /></a>
                    <h6 class="name" style="width: 110px;padding-left: 5px;">Cari Ekstre</h6>
                </div>
                <div class="col-md-6 col-lg-4 item"><a href="FaturalanmayanAlim.aspx"><img class="img-thumbnail" src="image/bill-png-transparent-bill-icon-white-png-png.png" style="width: 50px;" /></a>
                    <h6 class="name" style="width: 80px;">Faturalanmamış Alım</h6>
                </div>
                <div class="col-md-6 col-lg-4 item"><a href="TuketimRapor.aspx"><img class="img-thumbnail" src="image/indir.png" style="width: 50px;" /></a> 
                    <h6 class="name" style="width: 80px;">Plaka Bazlı Döküm</h6>
                </div>
                <div class="col-md-6 col-lg-4 offset-lg-2 offset-xl-2 item"><a href="AvantajKaybi.aspx"><img class="img-thumbnail" src="image/advantage-icon-4.jpg" style="width: 50px;" /></a>
                    <h6 class="name" style="width: 110px;">Avantaj Kaybı</h6>
                </div>
                <div class="col-md-6 col-lg-4 offset-lg-0 offset-xl-0 item"><a href="SanalPos.aspx"><img class="img-thumbnail" src="image/sccpre.cat-payment-icon-png-2138801.png" style="width: 60px;height: 50px;" /></a>
                    <h6 class="name" style="width: 110px;">Online Ödeme</h6>
                </div>
            </div>
        
       </div>
    </div>


             <hr/>

     <div class="container-fluid">
         <div class="row">
        <asp:DataList ID="PlakaList"  HorizontalAlign="Center" class="text-center" runat="server" BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" 

            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="5" RepeatDirection="Horizontal" CommandName="Item"
            Width="650px"  OnItemDataBound="PlakaList_ItemDataBound" OnItemCommand="PlakaList_ItemCommand">
           
            <FooterStyle BackColor="#a9a9a9" ForeColor="#8C4510" />

            <HeaderStyle BackColor="#a9a9a9" Font-Bold="True" Font-Size="Large" ForeColor="White"

                HorizontalAlign="Center" VerticalAlign="Middle" />

            <HeaderTemplate>ŞİRKETİNİZ ADINA SİSTEMİMİZDE KAYITLI ARAÇLARINIZ</HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />

            <ItemTemplate>
         
    <asp:Image  ID="imgEmp"  style=" margin-top:15px;" runat="server"  Width="145px" Height="40px" ImageUrl='<%# Eval("RESIMYOL", "~/image/plaka.png") %>' ImageAlign="Middle"  />
             <asp:linkButton ID="lblPlaka" runat="server" style=" position:relative;  top:-33px; height:14px; text-align:center; z-index:1; width:110px"  Text='<%# Eval("PLAKA") %>' CommandName="liste"></asp:linkButton>
                    <br />               
            </ItemTemplate>
        </asp:DataList>              
         </div>         
   </div>    
     <div style="height: 75px; font-weight: 700; font-size: medium; text-align:center;" >
            ŞİRKETİNİZE AİT OLMADIĞINI DÜŞÜNDÜĞÜNÜZ PLAKA İÇİN,LÜTFEN İLETİŞİME GEÇİNİZ.
        </div>
    </div>
   </div>
  </div>
</asp:Content>
