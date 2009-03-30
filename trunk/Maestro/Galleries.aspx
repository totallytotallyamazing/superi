<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="Galleries" %>
<%@ Import Namespace="Superi.Common" %>
<%@ Register TagName="MediaMenu" TagPrefix="maestro" Src="~/Controls/MediaMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/articles.css" %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">   
    <div class="mediaMenu">
        <maestro:MediaMenu CurrentIndex="0" runat="server" />
    </div>
    <asp:Repeater runat="server" ID="rPictures" 
        onitemdatabound="rPictures_ItemDataBound">
    <ItemTemplate>
        <div class="imageSeq">
            <asp:HyperLink runat="server" ID="hlPicture"></asp:HyperLink><br />
            <asp:HyperLink runat="server" ID="hlTitle"></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
