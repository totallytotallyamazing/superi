<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Areas.BrandCatalog.Models.CatalogueImage>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Управление каталогом
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="selects">
        <% using(Html.BeginForm()){ %>
            Бренды:<%= Html.DropDownList("brandId", (IEnumerable<SelectListItem>)ViewData["brands"]) %>
            Группы:<%= Html.DropDownList("groupId", (IEnumerable<SelectListItem>)ViewData["groups"]) %>
        <%} %>
    </div>
    <% Html.RenderPartial("UploadControl"); %>
    <div id="images">
        
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

