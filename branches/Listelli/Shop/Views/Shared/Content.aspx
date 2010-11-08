<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["title"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Roles.IsUserInRole("Administrators"))
       { %>
    <p class="adminLink">
        <%= Html.ActionLink("редактировать", "Edit", "Content", new { area="Admin", id=ViewData["contentName"] }, null)%>
    </p>
    <%} %>
    <%= ViewData["text"] %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <div id="contName">
        <div id="pageName">
            <p class="txtPageName">
                <%= ViewData["title"] %>
            </p>
        </div>
    </div>
</asp:Content>
