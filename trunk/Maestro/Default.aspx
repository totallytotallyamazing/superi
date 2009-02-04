<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="m" TagName="Articles" Src="~/Controls/Articles.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <m:Articles runat="server" 
        ArticleScopeId="1" 
        BodyAsDescription="true" 
        DefaultImageUrl="~/Images/DefaultArticle.jpg" 
        MaxDescriptionChars="300" 
        SeparateFirstArticle="true" 
        MaxDescriptionCharsFirst="600" />
</asp:Content>

