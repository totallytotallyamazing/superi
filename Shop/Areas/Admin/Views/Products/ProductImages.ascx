<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<long, IEnumerable<Shop.Models.ProductImage>>>" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
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
        <table style="width:100%">
            <tr>
                <td>
                    <div class="labelCell"> 
                        Фото товара 
                    </div>
                    <br />
                   <span class="comments">поставьте точку возле главного фото</span>
                </td>
            <td class="images">
                <%= Html.Hidden("adId", images.Key)%>
                <% foreach (var item in images.Value)
                   { %>
                    <div class="productImage">
                        <%= Html.Image(GraphicsHelper.GetCachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1"), "")%>
                        <%= Html.ActionLink("[IMAGE]", "DeleteImage", new { productId = images.Key, imageId = item.Id }, new { @class = "deleteLink", onclick = "return confirm('Вы уверены?')" })
                            .ToHtmlString()
                            .Replace("[IMAGE]", "")%>
                        <input type="radio" name="defaultImage" value="<%= item.Id %>" <%= (item.Default)?"checked":"" %> />
                    </div>    
                <% } %>
            </td>
            <td>
                <div class="clearBoth" id="setDefaultImage">
                    <input type="submit" value="Сделать главной" />
                </div>
            </td>
            </tr>
        </table>
    <%} %>
<% using (Html.BeginForm("AddProductImage", "Products", new { id = images.Key }, FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
    <%= Html.Hidden("productId", images.Key)%>
    <%= Html.Hidden("isDefault", isDefault)%>
    <%= Html.Hidden("categoryId", ViewData["cId"])%>
    <div id="addMore">
        <span class="labelCell">Закачать новую фотографию:&nbsp;</span>
        <input type="file" name="image" />
        <input type="submit" value="Закачать!" />
    </div>
<%} %>