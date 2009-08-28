<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<DealerPresentation>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function() {
        applyDropShadows(".dealerLogo a", "shadow3");
    })
</script>

<%
    foreach (var item in Model)
    {%>
        <div class="dealerLogo">
            <%if(item.OnLine){ %>
            <div class="dalerOnline"></div>
            <%} %>
            <a href="/Dealers/SelectDealer/<%= item.Id %>">
                <%= Html.Image("~/Image/ShowLogo/" + item.Id, new { style="border:1px solid #ccc;" })%>  
            </a>
        </div>
    <%}
%>
<div style="clear:both;"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/shadows.css")%>
    <%= Html.RegisterJS("dropshadow.js")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
<%
    List<SelectListItem> items = new List<SelectListItem>();
    foreach (var item in Model)
    {
        SelectListItem listItem = new SelectListItem { Text = item.Name, Value = "/Dealers/SelectDealer/" + item.Id };
        items.Add(listItem);
    }
    Html.RenderAction<PagePartsController>(ac => ac.LeftMenu(Html.ResourceString("Dealers"), items));
         
%>
</asp:Content>

