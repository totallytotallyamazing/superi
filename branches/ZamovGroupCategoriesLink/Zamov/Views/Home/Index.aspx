<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CategoryPresentation>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Title") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%foreach (var item in Model)
      {%>
        <div class="mainCategory">
            <table class="categoryButton" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="left"></td>
                    <td class="middle">
                        <%= item.Name %>
                    </td>
                    <td class="right"></td>
                </tr>
            </table>
            <div class="categoryImage">
                <%= Html.Image("~/Image/CategoryImageByCategoryId/" + item.Id) %>
            </div>
        </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/StartPage.css") %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentTop" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="leftMenu" runat="server">
    <% IEnumerable<SelectListItem> cities = (IEnumerable<SelectListItem>)ViewData["cities"]; %>
    <% Html.RenderAction<PagePartsController>(ac => ac.LeftMenu(Html.ResourceString("City"), cities)); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="dealerLogo" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentBottom" runat="server">
</asp:Content>
