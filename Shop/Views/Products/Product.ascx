<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<% bool isAdmin = (bool)(ViewData["isAdmin"] ?? false); %>
<%if (Model.Published || isAdmin)
  { %>
<%
    string additionalClass = string.Empty;
    if (!Model.Published && isAdmin)
        additionalClass = " translucent";
    string title = Model.Categories.First().Name + " " + Model.Name;
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id = Model.Id }, new { @class = "titleLink productFancy", title = title }).ToString();


      int[] favorites = Favorites.FavoritesProductIds;
%>
<div class="productItem">
    
    <div class="img <%=favorites.Contains(Model.Id) ? "addedToFavorites" : "removedFromFavorites"%>" productId="<%= Model.Id %>">
    <%//if (favorites.Contains(Model.Id))
    //{%>
        <a href="#" title="Удалить из отмеченных" id="hideItemLink<%=Model.Id%>" class="removeButtonLink <%=(favorites.Contains(Model.Id))?"displayBlock":"displayNone" %>" onclick="ProductClientExtensions.removeFromFavorites(<%=Model.Id%>); ProductClientExtensions.hideRemoveFromFavoritesButton(this)"></a>
    <%
//    }%>

        <% 
            Shop.Models.ProductImage img = Model.ProductImages.Where(pi => pi.Default).FirstOrDefault();
            if (img != null)
            {
        %>
        <%= productClickLink.Replace("titleLink ", string.Empty)
            .Replace("[IMAGE]",
                        Html.CachedImage("~/Content/ProductImages", img.ImageSource, "thumbnail2", Model.Name)) + "<br />"%>
        <%}
            else
            {
                Response.Write(productClickLink.Replace("[IMAGE]", Model.Name));
            }
        %>
        <%if (Model.IsNew)
          { %>
        <div class="newItem">
        </div>
        <%} %>
        
    </div>
    <div class="text">
            <span><b>
                <%= productClickLink.Replace("[IMAGE]", Model.Name)%></b></span>
            <div class="itemDescription" >
                <% if(!string.IsNullOrWhiteSpace(Model.Color)){ %>
                <p>
                    <span class="attributeLabel">Цвет:</span>
                    <span class="attributeValue"><%= Model.Color %></span>
                </p>
                <%} %>
                <%if(!string.IsNullOrWhiteSpace(Model.Tint)){ %>
                <p>
                    <span class="attributeLabel">Оттенок:</span>
                    <span class="attributeValue"><%= Model.Tint %></span>
                </p>
                <%} %>
                <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
            </div>
        </div>
</div>
<%} %>