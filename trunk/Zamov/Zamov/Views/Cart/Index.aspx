<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="subHeader">
    <% Html.RenderPartial("Cart");  %>
</div>
<%
    if (Model != null)
    {
        foreach (var order in Model)
            Html.RenderAction<UserCabinetController>(ac => ac.ShowOrder(order, true));
    }
%>    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/shadows.css")%>
    <%= Html.RegisterJS("dropshadow.js")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
 <%
     List<Dealer> dealers = (List<Dealer>)ViewData["dealers"];
     List<SelectListItem> items = new List<SelectListItem>();
     foreach (var item in dealers)
     {
         SelectListItem listItem = new SelectListItem { Text = item.GetName(SystemSettings.CurrentLanguage), Value = "/Products/" + item.Id };
         items.Add(listItem);
     }
     Html.RenderAction<PagePartsController>(ac => ac.LeftMenu(Html.ResourceString("Dealers"), items));
 %>

</asp:Content>
