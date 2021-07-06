<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Yonetim.aspx.cs" Inherits="MusteriCariPortal.Yonetim" EnableEventValidation="false" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cari Mütabakat Modülü</title>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <!--Stiller-->
    <%--  <link rel="stylesheet" href="/bootstrap/dist/css/bootstrap.min.css" type="stylesheet" />
    <link rel="stylesheet" href="/bootstrap/dist/css/bootstrap-theme.min.css" type="text/css" />--%><%--  <link rel="stylesheet" href="/Content/Tema/HilmiBeken/css/karayel.css" type="text/css" />

    <!--Animasyon-->
    <link rel="stylesheet" href="/Content/Tema/HilmiBeken/css/animate.css" type="text/css" />--%>
    <style>
        .cuadro_intro_hover a {
            font-size: 12px;
        }
    </style>
    <style type="text/css">
        .cont {
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }

        .auto-style14 {
            height: 65px;
            width: 709px;
        }

        #alt {
            height: 309px;
        }
    </style>
    <style>
        .header {
            width: 1000px;
            height: 200px;
            background-color: #F0FFFF;
            text-align: justify;
        }
        .mb5 {
            float: left;
            height: 62px;
            width: 242px;
            text-align: center;
        }
        .auto-style15 {
            width: 925px;
        }
        .auto-style16 {
            width: 500px;
            height: 75px;
        }
    </style>
</head>
<body runat="server">
    <form id="form1" runat="server">
        <div id="sorgulama" style="width: 1000px" class="cont">
            <div>
                <br />
                <br />
                <table style="width: 1000px">
                    <tr>
                        <td class="auto-style14">
                            <asp:GridView ID="GridView2" runat="server" BackColor="ActiveCaptionText" BorderColor="#CC0000" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="992px" Heigt="auto">
                                <FooterStyle BackColor="Gainsboro" ForeColor="ActiveCaptionText" />
                                <HeaderStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="ActiveCaptionText" HorizontalAlign="Center" VerticalAlign="Top" />
                                <PagerStyle ForeColor="ActiveCaptionText" HorizontalAlign="Left" BackColor="#99CCCC" />
                                <RowStyle BackColor="White" ForeColor="ActiveCaptionText" />
                                <SelectedRowStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>
                        </td>

                    </tr>
                </table>
            </div>
            <div style="height: 87px">
                <table style="width: 1000px">
                    <tr>
                        <td class="auto-style15">
                            <div style="text-align: left">
                                Tarih Aralığı</div>
                          
          <div class="container">
        Başlangıç Tarihi : <input type="text" id="dtBaslangic" width="276" runat="server" />
        Bitiş Tarihi: <input type="text" id="dtBitis" width="276" runat="server" />
    </div>
    <script>
        var today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate());
        $('#dtBaslangic').datepicker({
            uiLibrary: 'bootstrap4',
            iconsLibrary: 'fontawesome',
            minDate: today,
            maxDate: function () {
                return $('#dtBitis').val();
            }
        });
        $('#dtBitis').datepicker({
            uiLibrary: 'bootstrap4',
            iconsLibrary: 'fontawesome',
            minDate: function () {
                return $('#dtBaslangic').val();
            }
        });
    </script>
                         
                            <asp:button ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Sorgula" Height="16px" Width="170px">
                            </asp:button>

                        </td>
                        <td>

                            <asp:ImageButton ID="btnYazdir" runat="server" Height="58px" ImageUrl="~/image/printer.ico" OnClick="btnYazdir_Click" Width="62px" />

                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="GridView1" runat="server" CellPadding="2" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="1000px" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField HeaderText="DETAY" Text="DETAY"/>
                </Columns>
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
            <div style="height: 75px; font-weight: 700; font-size: medium;">
                Veriler Ön Bilgi Mahiyetinde Olup, Hata ve Unutma Müstesnadır.Mütabakat İçin Muhasebe Birimimizle İrtibata Geçmenizi Rica Ederiz.</div>
            <div class="header">
                <div class="cont">
                    &nbsp;<img alt="" class="auto-style16" src="image/logo_beken.png" /><br />
                    <br />
                    <div>
                        &nbsp;<a href="http://www.hilmibeken.com.tr/tr/m/subeler" style="text-align: right"><img class="img-responsive" src="http://www.hilmibeken.com.tr/Resim/Upload/logo-shell-copy.png"/><img class="img-responsive" src="http://www.hilmibeken.com.tr/Resim/Upload/logo-ukoil-copy.png"/></a>
                        <a href="http://www.hilmibeken.com.tr/tr/m/subeler">
                            <img class="img-responsive" src="http://www.hilmibeken.com.tr/Resim/Upload/logo-total-copy.png"/></a>
                    </div>

                </div>
            </div>
        </div>
        <div id="uyarı" style="width: 1000px; font-weight: 700; font-size: large;" class="cont">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="color: #000000">Sistemimizde Değişmesini İstediğiniz Cari Bilgiler için Linkteki Formu İndirip Doldurarak Tarafımıza Ulaştırınız</asp:LinkButton>
        </div>
    </form>
</body>
<%--  <table style="height: 67px; width: 900px" align="center">
        <tr>
            <td>
                <div id="header" align="center"></div>
            </td>
        </tr>
    </table>--%>
</html>
