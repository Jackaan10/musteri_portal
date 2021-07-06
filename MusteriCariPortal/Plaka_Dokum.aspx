<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Plaka_Dokum.aspx.cs" Inherits="MusteriCariPortal.Plaka_Dokum" runat="server" %>

<!DOCTYPE html>

<html>
<head runat="server">
         <meta charset="utf-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densityDpi=device-dpi" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
     <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
     <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="css/style.css" />
    <script src="js/jsmenu.js"></script>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <script src="script.js"></script>
    <title></title>

    <style>

        .footer{
            overflow: hidden;    
            background-color: #ffffff;
            margin-top:10px;
        }
       
       
       
       </style>
</head>
<body>
    <form id="form1" runat="server">
        
    <div id="mainContainer" class="container">               
                <div class="page-container">  
                    <div class="container"> 
   
          <div style="font-weight: 700; font-size: large; color: #0055C4">
        <br/>
     
      Plaka Dökümü<br />
        <div style="border: thin outset #CCCCCC"></div>
    </div>
   <br />
        <div>
            <asp:ImageButton ID="btnYazdir" runat="server" Height="27px" ImageUrl="~/image/printer.ico" OnClick="BtnYazdir_Click" Width="42px" style="text-align: right" />
                    <asp:ImageButton ID="btnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="BtnExcel_Click" />
                  <asp:ImageButton ID="btnPdf" runat="server" Height="29px" ImageUrl="~/image/pdf.jpg" Width="40px" ToolTip="Pdf" Style="text-align: right" OnClick="BtnPdf_Click" />
            <br />
            </div>
             <div class="table-responsive">
        <asp:GridView ID="grdFatura" runat="server" CellPadding="2" ForeColor="#333333"  style="text-align:right" ShowFooter="True" Width="100%" BorderStyle="None">
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
             

 <hr />
<footer class="footer">
		<div class="footer_content">
			<div class="container">
				
				<div class="row footer_row">
					<div class="col-lg-4 footer_col">
						<div class="footer_item text-center">
                            <div class="footer_icon d-flex flex-column align-items-center justify-content-center ml-auto mr-auto">
                                <img src="image/logo_beken.png" width="200" height="30" />
                                <p>
                                    <a>
                                        <img src="image/shell_logo.png" width="30" height="30" />
                                    </a>
                                    |
                                    <a>
                                        <img src="image/luk-logo.jpg" width="30" height="30" />
                                    </a>
                                    |
                                    <a>
                                        <img src="image/total-logo.png" width="30" height="30" />
                                    </a>
                                    |
                                    <a>
                                        <img src="image/opet%20logo.jpg" width="40" height="40" />
                                    </a>
                                </p>
                            </div>
							
						</div>
					</div>
                    <div class="col-lg-4 footer_col">
				
					</div>
					
					<div class="col-lg-4 footer_col">
						<div class="footer_item text-center">
                            <div class="footer_icon d-flex flex-column align-items-center justify-content-center ml-auto mr-auto">


                                <div class="footer_title" style="font-weight: bold">İLETİŞİM</div>
                                <div class="footer_list">
                                    <p> <i class="fa fa-home mr-3"></i> Altınkale Mh. Akdeniz Bulv. No: 168-170, Döşemealtı/ANTALYA - 07192</p>
                                    <p> <i class="fa fa-envelope mr-3"></i> info@hilmibeken.com</p>
                                    <p> <i class="fa fa-phone mr-3"></i> 0(242) 443 30 10</p>
                                    <p> <i class="fa fa-print mr-3"></i> 0(242) 443 30 20</p>
                                </div>
                            </div>
						</div>
					</div>
				</div>
			</div>
	      </div>
		<div class="footer_bar d-flex flex-row align-items-center justify-content-center">
			<div class="copyright">
Copyright &copy;<script>document.write(new Date().getFullYear());</script> All rights reserved | <a href="http://www.hilmibeken.com/tr" target="_blank">Hilmi Beken</a>
</div>
		</div>
    
	</footer>  
    </div>
   </div>
  </div>
    </form>
</body>
</html>
