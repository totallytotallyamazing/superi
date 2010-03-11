<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<% 
    bool isHome = (ViewContext.RouteData.Values["action"] == "Index" && ViewContext.RouteData.Values["controller"] == "Home");
%>
<div id="headerLogo">   
    <%if(!isHome){ %>
        <%= Html.ActionLink("[IMAGE]", "Index", "Home", null, null)
            .Replace("[IMAGE]", Html.Image("/Content/img/logo.jpg"))%>
    <%} %>
    <%else{ %>
        <%= Html.Image("/Content/img/logo.jpg") %>
    <%} %>
</div>