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
      {
          string single = (item.Children.Count == 0) ? " single" : "";
          %>
        <div class="mainCategory<%= single %>">
            <div class="categoryButton">
                 <%= Html.ActionLink(item.Name, "Index", "Dealers", new { id = item.Id }, null)%>
            </div>
            <div class="categoryImage">
                <%= Html.ActionLink("IMAGE", "Index", "Dealers", new { id = item.Id }, null).Replace("IMAGE",
                    Html.Image("~/Image/CategoryImageByCategoryId/" + item.Id)) %>
            </div>
            <div class="subCategories">
                <% bool first = true;
                   foreach (var subCategory in item.Children.Take(5))
                   {%>
                    <%if (!first)Response.Write("&nbsp;/&nbsp;"); first = false;%>
                    <%= Html.ActionLink(subCategory.Name, "Index", "Dealers", new {id=subCategory.Id }, null)%>
                    
                 <%} %>
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
