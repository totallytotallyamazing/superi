﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<% bool isAdmin = (bool)(ViewData["isAdmin"] ?? false); %>
<%if (Model.Published || isAdmin)
  { %>
<%
    string additionalClass = string.Empty;
    if (!Model.Published && isAdmin)
        additionalClass = " translucent";
    string title = Model.Categories.First().Name + " " + Model.Name;
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id = Model.Id }, new { @class = "titleLink productFancy", title = title }).ToString();
%>



<div class="productItem">
  <div class="img">
     
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
         <%if (Model.IsNew){ %>
            <div class="newItem">
            </div>
        <%} %>
        <div class="text">
       <span><b>
            <%= productClickLink.Replace("[IMAGE]", Model.Name)%></b></span>
             <div class="itemDescription">
                <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
             </div>
    </div>
    </div>   
</div>
<%} %>