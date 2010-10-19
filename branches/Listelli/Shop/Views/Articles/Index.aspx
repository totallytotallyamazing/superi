<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Article>>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["title"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="newsContent">
    <% if(Model != null)
       foreach (var item in Model)
       {
           Html.RenderPartial("Article", item);
       } %>
</div>
<% if(Roles.IsUserInRole("Administrators")){ %>
    <div class="adminLink">
        <%= Html.ActionLink("Создать", "AddEdit", "Articles", new { area = "Admin", type = ViewData["type"] }, null)%>
    </div>
<%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <div id="contName">
       <%-- <div id="pagePic">
            <img src="../../Content/UnMomentoStyles/img/NewsPageImg.gif" alt="Лого странички новостей" />
        </div>--%>
        <div id="pageName">
            <p class="pt1">
                Новости, <span class="pt2">страница 1</span>
            </p>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
        <p class="pgt1">
            1 ... <a href="#" class="pgt1">2</a> ... <a href="#" class="pgt1">3</a></p>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude((string)ViewData["css"]) %>
</asp:Content>
