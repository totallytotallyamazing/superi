<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Products/Products.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Product>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="productModal">
     <% if (Roles.IsUserInRole("Administrators"))
       { %>
    <div class="adminLink">
        <%= Html.ActionLink("Редактировать", "AddEdit", "Products", new { area = "Admin", id = Model.Id, bId = (Model.Brand != null) ? Model.Brand.Id : 0 }, null).ToString()%>
        |
        <%= Html.ActionLink("Удалить", "Delete", "Products", new { area = "Admin", id = Model.Id }, new { onclick="return confirm('Вы уверены?')" }).ToString()%>
    </div>
    <%} %>
    <div id="imgProduct">
        <% Shop.Models.ProductImage img = Model.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = Model.Name } }).First();%>
        
        
        <% Html.RenderPartial("ProductImage", img); %>
        
        <% if (Model.IsNew)
           { %>
        <div id="new1">
        </div>
        <%} %>
        <% Html.RenderPartial("ImagePreviews", Model.ProductImages.OrderByDescending(pi => pi.Default)); %>
    </div>
    <div id="productDescription">
        <div class="title">
            <p class="titleLink">
                <b>
                    <%= Model.Name %></b></p>
        </div>
        <div class="attributes">
            <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
        </div>
        <div class="details">
            <p class="txtDetails">
                Узнать подробнее об этом товаре можно, позвонив к нам, или просто сейчас <a id="quickQuestionLink" href='#'
                    class="linkDetails">отправив быстрый вопрос</a></p>
        </div>
        <div class="addToFavorites txtDetails <%=Favorites.FavoritesProductIds.Contains(Model.Id)?"hide":"block"%>">
            <a href="#" id="addToFav" onclick="ProductClientExtensions.addToFavorites(<%=Model.Id%>)">Отметить товар</a>
        </div>
        <div class="removeFromFavorites txtDetails <%=!Favorites.FavoritesProductIds.Contains(Model.Id)?"hide":"block"%>">
            Товар добавлен в "<%=Html.ActionLink("Отмеченные", "Favorites", "Products", null, new { @class = "linkDetails" })%>"<br />
            <a href="#" id="remFromFav" class="removeLink" onclick="ProductClientExtensions.removeFromFavorites(<%=Model.Id%>)">Убрать</a>  из "Отмеченных"
        </div>
        <div style="padding-top:40px;">
            <a href="javascript:history.back();" id="returnToCatalogueLink">&laquo; Вернуться в каталог</a>
        </div>
        <script type="text/javascript">
            $("#remFromFav").click(function () {
                $(".removeFromFavorites").css("display", "none");
                $(".addToFavorites").css("display", "block");
                //$(".mIm").css("border", "none");
            })

            $("#addToFav").click(function () {
                $(".addToFavorites").css("display", "none");
                $(".removeFromFavorites").css("display", "block");
                //$(".mIm").css("border", "3px solid #3399ff");
            })
        </script>
    </div>
    <% Html.RenderPartial("QuickQuestion", ViewData["quickQuestion"]); %>
    <% Html.RenderPartial("SimilarProducts", Model.Tags.SelectMany(t=>t.Products).Where(p=>p.Id != Model.Id)); %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <div id="contName">
        <div id="pageName">
            <p class="txtPageName">
                <%= Model.Name %></p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/tovar.css" />
    <link rel="Stylesheet" href="/Content/catalog.css" />
    <link href="/Content/LislelliStyles/products.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            ImagePreviews.Initialize();
            ProductClientExtensions.initialize();
            ProductClientExtensions.bindFancy();
        })    
    </script>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js") %>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcAjax.js")%>
    <script type="text/javascript">
        function OnCaptchaValidationError() {
            $.get("/Captcha/DrawForFeedback", function (data) { $("#captchaImage").html(data); });
        }
    </script>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
        <p class="pgt1">
            <a href="#" class="pgt1">« В каталог</a></p>
    </div>
</asp:Content>
