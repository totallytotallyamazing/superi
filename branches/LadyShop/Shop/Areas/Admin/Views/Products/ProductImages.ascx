<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<long, IEnumerable<Shop.Models.ProductImage>>>" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<fieldset id="images">
    <legend>Фото</legend>
    <%
        KeyValuePair<long, IEnumerable<ProductImage>> images = new KeyValuePair<long, IEnumerable<ProductImage>>();
    foreach (KeyValuePair<long, IEnumerable<ProductImage>> thing in Model)
	{
            images = thing;
	}
    bool isDefault = images.Value.Count() == 0;
    %>
    <%using (Html.BeginForm("SetDefaultImage", "Products", FormMethod.Post, new { id="imagesForm"}))
      { %>
        <%= Html.Hidden("adId", images.Key)%>
        <% foreach (var item in images.Value)
           { %>
            <div class="carAddAdminImage">
                <%= Html.Image(GraphicsHelper.GetCachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1"), "")%>
                <%= Html.ActionLink("[IMAGE]", "DeleteImage", new { productId = images.Key, imageId = item.Id }, new { @class = "deleteLink", onclick = "return confirm('Вы уверены?')" })
                    .ToHtmlString()
                    .Replace("[IMAGE]", "") %>
                <input type="radio" name="defaultImage" value="<%= item.Id %>" <%= (item.Default)?"checked":"" %> />
            </div>    
        <% } %>
        <div class="clearBoth" id="setDefaultImage">
            <input type="submit" value="Установить фото по-умолчанию" />
        </div>
    <%} %>
<% using (Html.BeginForm("AddProductImage", "Products", new { id = images.Key }, FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
    <%= Html.Hidden("productId", images.Key)%>
    <%= Html.Hidden("isDefault", isDefault)%>
    <%= Html.Hidden("categoryId", ViewData["cId"])%>
    <div id="addMore">
        <p>Доббавить еще:</p>
        <input type="file" name="image" />
        <input type="submit" value="Добавить" />
    </div>
<%} %>
</fieldset>