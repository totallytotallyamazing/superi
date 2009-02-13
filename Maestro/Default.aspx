<%@ Page Title="Новости" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="m" TagName="Articles" Src="~/Controls/Articles.ascx" %>
<%@ Import Namespace="Superi.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/articles.css" %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <m:Articles runat="server" 
        ArticleScopeId="1" 
        BodyAsDescription="true" 
        DefaultImageUrl="~/Images/DefaultArticle.jpg" 
        MaxDescriptionChars="150" 
        SeparateFirstArticle="true" 
        MaxDescriptionCharsFirst="600"
        DisplayDate="true" />
</asp:Content>

