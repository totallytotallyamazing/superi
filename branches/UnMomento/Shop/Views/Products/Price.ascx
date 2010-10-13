<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%  if(Model.ProductVariants.Count > 0){ %>
    <span class="price single">
        от <%= Html.RenderPrice(Model.ProductVariants.Min(p=>p.Price), WebSession.Currency, 0, ",")%>
    </span>
<%} %>

<%else{ %>
<% if(Model.OldPrice.HasValue && Model.OldPrice > 0){ %>
    <span class="oldPrice">
        <%= Html.RenderPrice(Model.OldPrice.Value, WebSession.Currency, 0, ",") %>
    </span>
    <span class="price">
        <%= Html.RenderPrice(Model.Price, WebSession.Currency, 0, ",")%>
    </span>
<%} %>
<%else{ %>
    <span class="price single">    
        <%= Html.RenderPrice(Model.Price, WebSession.Currency, 0, ",")%>
    </span>
<%} %>
<%} %>