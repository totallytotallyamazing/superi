<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="Images" %>
<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>
<%@ Import Namespace="Superi.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/articles.css" %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">   
    <asp:Repeater runat="server" ID="rPictures" 
        onitemdatabound="rPictures_ItemDataBound">
    <ItemTemplate>
        <div class="imageSeq">
            <asp:HyperLink runat="server" ID="hlPicture"></asp:HyperLink><br />
            <asp:HyperLink runat="server" ID="hlTitle"></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="pagerContainer">
    <cc1:Pager CurrentPageCssClass="currentPage" PageCssClass="page" ID="pPages" runat="server" />
</div>
<script type="text/javascript">
    $(document).ready(function() { $(".imageSeq a").fancybox({ 'overlayShow': true }) });
</script>
</asp:Content>

