<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Product>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Roles.IsUserInRole("Administrators"))
       { %>
       <p class="adminLink">
    <%= Html.ActionLink("Редактировать", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = Model.Category.Id, bId = Model.Brand.Id }, null).ToString()%>
    |
    <%= Html.ActionLink("Удалить", "Delete", "Products", new { area = "Admin", id = Model.Id }, new { onclick = "return confirm('Вы уверены?')" }).ToString()%>
    </p>
    <%} %>
    <div id="SlotH">
        <h1><%= Model.Name %></h1>
    </div>
    <% using(Html.BeginForm(new {controller="Cart", action="Add", id=Model.Id})){ %>
    <div id="SlotProduct">
        <% Html.RenderPartial("ProductImage", Model.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = Model.Name } }).First()); %>
        <div id="SlotProductText">
            <p>
                <%= Model.Description %>
            </p>
            <p>
                Артикул:<strong><%= Model.PartNumber %></strong>
            </p>
            <% Html.RenderPartial("DetailViewAttributes", Model.ProductAttributeValues); %>    
            <p>
                Цена: <strong><%= Html.RenderPrice(Model.Price, WebSession.Currency, 0, ",") %></strong>
            </p>
        </div>
    </div>
    <% Html.RenderPartial("ImagePreviews", Model.ProductImages.OrderByDescending(m => m.Default)); %>
    <%} %>
    <% Html.RenderPartial("SimilarProducts", Model.Tags.SelectMany(t=>t.Products).Where(p=>p.Id != Model.Id)); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/productSlot.css" />
    <%= Ajax.ScriptInclude("/Scripts.jquery.fancybox.js") %>
    <%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
    <script type="text/javascript">
        $(function () {
            ProductClientExtensions.bindFancy();
        });
    </script>

</asp:Content>
