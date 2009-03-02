<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="Images" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/articles.css" %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">   
    <asp:Repeater runat="server" ID="rPictures">
    <ItemTemplate>
        <div class="player">
            <asp:HyperLink runat="server" ID="hlPicture"></asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlTitle"></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>

