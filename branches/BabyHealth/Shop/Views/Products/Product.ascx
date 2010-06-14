<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id = Model.Id }).ToString();
    if (Roles.IsUserInRole("Administrators"))
    {
        productClickLink = Html.ActionLink("[IMAGE]", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = ViewData["categoryId"], bId = ViewData["brandId"] }, null).ToString();
    }
%>
<div class="tovarBox">
    <div class="nazva">
        <p>
            <a href="#">™ <%= Model.Brand.Name %></a></p>
    </div>
    <div class="item">
        <a href="#">
            <% if (Model.ProductImages.Count > 0){ %>
            <%= productClickLink
                .Replace("[IMAGE]",
                Html.CachedImage("~/Content/ProductImages", Model.ProductImages.Where(pi => pi.Default).First().ImageSource, "thumbnail2", Model.Name))%>
            <%}
               else
               {
                   Response.Write(productClickLink.Replace("[IMAGE]", "редактировать"));
               }
            %>
        </a>
        <div class="new">
        </div>
    </div>
    <div class="itemDesc">
        <h3><%= productClickLink.Replace("[IMAGE]", Model.Name) %></h3>
        <p><%= Model.ShortDescription %></p>
        <h4><%= Model.Price.ToString("#.##") %> <%= Dev.Helpers.WebSession.Currency %></h4>
    </div>
</div>