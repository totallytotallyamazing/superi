<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<NewsPresentation>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("News") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <%= Html.ResourceString("News").ToUpper() %>
    </center>
    
    <div class="newsContainer">
<%
    foreach (NewsPresentation item in Model)
    {%>
        <div class="item">
            <div class="title">
                <%= item.Title %>
            </div>
            <%= item.ShortText %>
            <div class="itemFooter">
                <%= Html.ResourceActionLink("Details", "Details", new { id=item.Id })%>
            </div>
        </div>        
  <%}
%>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="dealerLogo" runat="server">
</asp:Content>
