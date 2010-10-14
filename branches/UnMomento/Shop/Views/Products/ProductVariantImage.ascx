<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>      
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<a id="mi" href="/Content/ProductImages/<%= Model %>">
    <% Html.RenderAction("ShowMain", new { controller = "Graphics", area = "", id = Model, alt = Model }); %>
</a>