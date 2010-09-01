<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="menu">

<%
    string controllerName = ViewContext.RouteData.Values["controller"].ToString().ToLowerInvariant();
    string action = ViewContext.RouteData.Values["action"].ToString().ToLowerInvariant();
    string currenLocation = controllerName;
    if (currenLocation == "home" && action == "go")
    {
        currenLocation = ViewContext.RouteData.Values["id"].ToString().ToLowerInvariant();
    }

    Func<string, string> isCurrent = (location) => (location == currenLocation) ? " current" : string.Empty;
    
    
     %>
    <a href="/Go/About" class="menuItem<%= isCurrent("about") %>" id="menuItem1"></a>
    <a href="/Go/Sizes" class="menuItem<%= isCurrent("sizes") %>" id="menuItem2"></a>
    <a href="/Go/PaymentAndDelivery" class="menuItem<%= isCurrent("paymentanddelivery") %>" id="menuItem3"></a>
    <a href="/Brands" class="menuItem<%= isCurrent("brands") %>" id="menuItem4"></a>
    <a href="/Go/Partners" class="menuItem last<%= isCurrent("partners") %>" id="menuItem5"></a>
</div>

