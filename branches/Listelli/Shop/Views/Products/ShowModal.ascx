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
            <%= Model.Name %>    
        </div>
        <div class="attributes">
            <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
        </div>
    </div>

</div>