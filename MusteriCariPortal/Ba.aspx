<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="True" CodeBehind="Ba.aspx.cs" Inherits="MusteriCariPortal.Ba" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 800px" class="auto-style18">
        <style type="text/css">
            .container {
                margin-left: auto;
                margin-right: auto;
                /*height: 167px;
                width: 584px;*/
            }

            .auto-style18 {
                width: 514px;
                text-align: center;
                margin-left: auto;
                margin-right: auto;
            }
        </style>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        BA MUTABAKAT FORM SORGULAMA<br/>
        <br/>        
    </div>
    <table style="width: 800px" class="container">
        <tr>
            <td style="width: 308px" class="dxflHARSys">Dönem :</td>
            <td>
                
                <asp:dropdownlist ID="cmbDonem" runat="server"></asp:dropdownlist>
                <asp:Button ID="btnSorgula" runat="server" Height="28px" Text="Sorgula" Width="170px" OnClick="btnSorgula_Click" OnClientClick="form1.target='_blank';" /></td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div style="width: 800px" class="container">
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        
    </div>
</asp:Content>

