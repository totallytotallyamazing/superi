<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
    <%
        List<SelectListItem> leftMenuItems = (List<SelectListItem>)ViewData["leftMenuItems"];
        Html.RenderAction<Zamov.Controllers.PagePartsController>(ac => ac.LeftMenu(Html.ResourceString("SubCategories"), leftMenuItems)); 
    %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.ResourceString("SubCategories") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    List<SelectListItem> leftMenuItems = (List<SelectListItem>)ViewData["leftMenuItems"];
    foreach (var item in leftMenuItems)
    { 
    %>
        <div class="categoryItem">
            <%= Html.Image("~/Image/CategoryImage/" + item.Value)%>
            <br />
            <%= Html.ActionLink(item.Text, "SelectCategory", new {id = int.Parse(item.Value)}) %>
        </div>
    <%
    }
%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

