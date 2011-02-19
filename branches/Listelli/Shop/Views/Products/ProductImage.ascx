<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductImage>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    var mainImage = Model;
    string alt = (mainImage != null) ? mainImage.Product.Name : "";

    string methodName = "ShowMain";
    if(ViewData["methodName"]!=null)
         if(!string.IsNullOrEmpty(ViewData["methodName"].ToString())) 
             methodName = ViewData["methodName"].ToString();
    
%>
<%if (mainImage != null){ %>
    <a class="mi">
        <% Html.RenderAction(methodName, new { controller = "Graphics", area = "", id = mainImage.ImageSource, alt = mainImage.Product.Name }); %>
    </a>
<%} %>