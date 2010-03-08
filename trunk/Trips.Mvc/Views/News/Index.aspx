<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.Article>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal runat="server" Text="<%$ Resources:WebResources, AllNews %>"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <% if (Request.IsAuthenticated)
           Response.Write(Html.ActionLink("Ñîçäàòü íîâîñòü", "AddEditArticle", "Admin", null, null)); %>
    <div id="newsContainer">
    <% foreach (var item in Model) { %>
        <div class="newsItem" name="<%= item.Name %>" id="<%= item.Name %>">
            <div class="date">
                <%= item.Date.ToString("dd.MM.yyyy") %>
            </div>
            <h3>
                <%= item.Title %>
            </h3>
            <% if (Request.IsAuthenticated){ %>
                <div>
                    <%= Html.ActionLink("Ğåäàêòèğîâàòü", "AddEditArticle", "Admin", new { id = item.Name }, null) %>
                </div>
                <div>
                    <%= Html.ActionLink("Óäàëèòü", "DeleteArticle", "Admin", new { id = item.Name }, null) %>
                </div>
            <%} %>
            <div class="text">
                <%= item.Text %>
            </div>
        </div>
        <div class="line"></div>
    <% } %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/News.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <asp:Literal runat="server" Text="<%$ Resources:WebResources, AllNews %>"></asp:Literal>
</asp:Content>

