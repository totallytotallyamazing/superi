<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="menu">

<%
    string controllerName = ViewContext.RouteData.Values["controller"].ToString().ToLowerInvariant();
     %>
    <a href="#" class="menuItem" id="menuItem1"></a>
    <a href="#" class="menuItem hover" id="menuItem2"></a>
    <a href="/go/erter" class="menuItem" id="menuItem3"></a>
    <a href="/Brands" class="menuItem <%=(controllerName == "brands" ? "current" : "") %>" id="menuItem4"></a>
    <a href="#" class="menuItem last" id="menuItem5"></a>
</div>

