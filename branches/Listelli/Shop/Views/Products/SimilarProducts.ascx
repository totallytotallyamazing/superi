<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Product>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% if (Model.Count() > 0)
   { %>
<div id="similarItems">
    <p class="txtSimilarItems">
        Похожие товары:</p>
</div>
<div id="similarItemsBox">
    <% foreach (var item in Model)
       {
           string title = item.Categories.First().Name + " " + item.Name;
           string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id = item.Id }, new { @class = "titleLink productFancy", title = title }).ToString();
    %>
    <div class="itemBox">
        <a href='#' class="titleLink"><b>
            <%= item.Brand.Name %> <br /></b></a> 
        <div class="similarImg">
            <% Shop.Models.ProductImage img = item.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = item.Name } }).First();%>
            <%= productClickLink.Replace("[IMAGE]", Html.CachedImage("~/Content/ProductImages", img.ImageSource, "thumbnail2", item.Name))
                .Replace("titleLink ", string.Empty)%>
            <%--<span><br /></span>--%>
            <p>
            <div class="similarDescription">
                <div class="title">
                    <b> 
                        <%= productClickLink.Replace("[IMAGE]", item.Name) %>
                    </b>
                </div>
                <% Html.RenderPartial("ProductStaticAttributes", item.ProductAttributeStaticValues); %>
            </div>
            </p>
        </div>
    </div>
    <%} %>
</div>
<%} %>