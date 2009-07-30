<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Dealer>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function() {
        $(".dealerLogo div").dropShadow({ left: 8, top: 8, blur: 3, opacity: 0.8 });
    })
</script>

<%
    foreach (var item in Model)
    {%>
        <div class="dealerLogo">
            <div>
                <a href="/Products/<%= item.Id %>">
                    <%= Html.Image("~/Image/ShowLogo/" + item.Id, new { style="border:1px solid #ccc;" })%>  
                </a>
            </div>
        </div>
    <%}
%>
<div style="clear:both;"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("jquery.dropshadow.js")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
<%
    List<SelectListItem> items = new List<SelectListItem>();
    foreach (var item in Model)
    {
        SelectListItem listItem = new SelectListItem { Text = item.GetName(SystemSettings.CurrentLanguage), Value = "/Products/" + item.Id };
        items.Add(listItem);
    }
    Html.RenderAction<PagePartsController>(ac => ac.LeftMenu(Html.ResourceString("Dealers"), items));
         
%>
</asp:Content>

