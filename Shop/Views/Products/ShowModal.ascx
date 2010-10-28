<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
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
        <% Shop.Models.ProductImage img = Model.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = Model.Name } }).First();
        %>
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
                Узнать подробнее об этом товаре можно, позвонив к нам, или просто сейчас <a href='#'
                    class="linkDetails">отправив быстрый вопрос</a></p>
        </div>
    </div>
    <div id="similarItems">
    <p class="txtSimilarItems">Похожие товары:</p>
    </div>
    <div id ="similarItemsBox">
        <div class="itemBox"> 
            <a href='#' class="titleLink"><b>Terhurne</b></a> 
            <div class="similarImg">
                <img src="../../Content/LislelliStyles/img/imgBeech.gif" alt="Сцуко" />
            </div>
            <a href='#' class="titleLink"><b>Европейский клён</b></a> 
            <div class="similarDescription">
                <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
            </div>
        </div>
        <div class="itemBox"> 
            <a href='#' class="titleLink"><b>Terhurne</b></a> 
            <div class="similarImg">
                <img src="../../Content/LislelliStyles/img/imgBeech.gif" alt="Сцуко" />
            </div>
            <a href='#' class="titleLink"><b>Европейский клён</b></a> 
            <div class="similarDescription">
                <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
            </div>
        </div>
        <div class="itemBox"> 
            <a href='#' class="titleLink"><b>Terhurne</b></a> 
            <div class="similarImg">
                <img src="../../Content/LislelliStyles/img/imgBeech.gif" alt="Сцуко" />
            </div>
            <a href='#' class="titleLink"><b>Европейский клён</b></a> 
            <div class="similarDescription">
                <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
            </div>
        </div>
    </div>
</div>
