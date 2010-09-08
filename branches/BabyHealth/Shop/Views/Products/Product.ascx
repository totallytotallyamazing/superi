<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<% bool isAdmin = (bool)(ViewData["isAdmin"] ?? false); %>
<%if (Model.Published || isAdmin)
  { %>
<%
      string additionalClass = string.Empty;
    if(!Model.Published && isAdmin) 
        additionalClass = " translucent";
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id = Model.Id }).ToString();
%>
<div class="tovarBox<%= additionalClass %>">
    <div class="nazva">
        <p>
            <a href="#">™ <%= (Model.Brand!=null)?Model.Brand.Name:""%></a></p>
    </div>
    <div class="item">
        <% 
            Shop.Models.ProductImage img = Model.ProductImages.Where(pi => pi.Default).FirstOrDefault();
            if (img != null)
            {
               %>
        <%= Html.ActionLink("[IMAGE]", "Show", new { id = Model.Id }).ToString()
            .Replace("[IMAGE]",
                        Html.CachedImage("~/Content/ProductImages", img.ImageSource, "thumbnail2", Model.Name)) + "<br />"%>
        <%}
           else
           {
               Response.Write(productClickLink.Replace("[IMAGE]", Model.Name));
           }
        %>
        <%if (Model.IsNew){ %>
            <div class="new">
            </div>
        <%} %>
    </div>
    <div class="itemDesc">
        <div class="productName"><%= productClickLink.Replace("[IMAGE]", Model.Name) %></div>
        <p><%= Model.ShortDescription %></p>
        <h4><% Html.RenderPartial("Price", Model); %></h4>
    </div>
</div>
<%} %>