<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Brand>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	О брендах
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% if(Roles.IsUserInRole("Administrators")){ %>
    <p class="adminLink">
        <%= Html.ActionLink("адмнистрирование брендов", "Index", new {conteoller="Brands", area="admin"}) %>
    </p>
<%} %>
<% foreach (var item in Model){%>
<div id="contentItem">
    <div id="contentItemFoto">
        <img src="/Content/BrandLogos/<%= item.Logo %>" alt="jeans" />
    </div>
    <div id="contentItemText">
        <p>
            <%= item.Description %>
        </p>
    </div>
</div>
<%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    О брендах
</asp:Content>
