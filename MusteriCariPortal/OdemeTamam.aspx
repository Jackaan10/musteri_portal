<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="OdemeTamam.aspx.cs" Inherits="MusteriCariPortal.OdemeTamam" %>

<%@ Register Src="UserControl/ucAna.ascx" TagName="ucAna" TagPrefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="alert-danger" >

             <asp:Label ID="lblMsj" runat="server" Font-Size="Large"></asp:Label>
        </div>
</asp:Content>
