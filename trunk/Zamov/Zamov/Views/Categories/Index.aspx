<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Zamov.Models.Category>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
    <%
        List<SelectListItem> leftMenuItems = (List<SelectListItem>)ViewData["leftMenuItems"];
        List<SelectListItem> items=  new List<SelectListItem>();
        foreach (var item in leftMenuItems)
        {
            SelectListItem listItem = new SelectListItem { Text = item.Text, Value = "/Categories/SelectCategory/" + item.Value };
            items.Add(listItem);
        }
        Html.RenderAction<Zamov.Controllers.PagePartsController>(ac => ac.LeftMenu(Html.ResourceString("SubCategories"), items)); 
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
            <div class="categoryImage">
                <%= Html.Image("~/Image/CategoryImageByCategoryId/" + item.Value)%>
            </div>
            <%= Html.ActionLink(item.Text, "SelectCategory", new { id = int.Parse(item.Value) }, new { @class = "categoryLink" })%>
        </div>
    <%
    }
%>
    <div style="clear:both;"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

