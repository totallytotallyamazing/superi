<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Dev.Models.Article>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>
<asp:Content ContentPlaceHolderID="HeaderSubTitle" runat="server">
    <%= Html.ResourceString("Thoughts") %>
</asp:Content>
<asp:Content ContentPlaceHolderID="HeadTitle" runat="server">
    <%= Html.ResourceString("Articles") %>,
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (Request.IsAuthenticated)
        {%>
            <div class="adminEditLink">
                <%= Html.ActionLink("Добавить", "Article", "Admin")%>
            </div>
    <%}%>
    <% foreach (var item in Model) { %>
        <div class="article">
            <div class="date">
                <%= item.Date.ToString("MMMM, dd, yyyy", System.Globalization.CultureInfo.GetCultureInfo(Dev.Helpers.LocaleHelper.GetCultureName())) %>
            </div>
            <div class="title">
                <%= item.Title %> <%= item.SubTitle%>
            </div>
            <div class="description">
                <%= Html.ActionLink("{0} »", "Show", new { name = item.Name }).Replace("{0}", item.Description)%>
            </div>
            <%if(Request.IsAuthenticated){ %>
                <div class="adminLink">
                    <a href="/Admin/Article/<%= item.Name %>">Редактировать</a>
                    /
                    <a href="/Admin/DeleteArticle/<%= item.Name %>">Удалить</a>
                </div>
            <%} %>
        </div>
    <% } %>

</asp:Content>

<asp:Content ContentPlaceHolderID="Includes" runat="server">
    <link href="/Content/Articles.css" rel="stylesheet" type="text/css" />
</asp:Content>

