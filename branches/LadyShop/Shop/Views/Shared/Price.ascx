<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<% if(Model.OldPrice != null && Model.OldPrice > 0){ %>
    <span class="oldPrice">
        <%= Html.RenderPrice((float)Model.OldPrice, WebSession.Currency, 0, ",") %>
    </span>
    <span class="price">
        <%= Html.RenderPrice((float)Model.Price, WebSession.Currency, 0, ",")%>
    </span>
<%} %>
<%else{ %>
    <span class="price single">    
        <%= Html.RenderPrice((float)Model.Price, WebSession.Currency, 0, ",")%>
    </span>
<%} %>
