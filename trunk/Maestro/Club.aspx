<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Club.aspx.cs" Inherits="Club" %>
<%@ Register TagPrefix="m" TagName="Articles" Src="~/Controls/Articles.ascx" %>
<%@ Import Namespace="Superi.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/articles.css" %>" />
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/fancy.css" %>" />
    <script type="text/javascript" src="<%= WebSession.BaseUrl %>js/jquery.fancybox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <m:Articles ID="Articles1" runat="server" 
        ArticleScopeId="2" 
        BodyAsDescription="false" 
        DefaultImageUrl="~/Images/DefaultArticle.jpg" 
        ZoomImage="true"
        DisplayDate="false" MaxPictureDimension="96" />
</asp:Content>

