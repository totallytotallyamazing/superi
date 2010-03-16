<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Dev.Helpers" %>
<% 
    bool isHome = (ViewContext.RouteData.Values["action"] == "Index" && ViewContext.RouteData.Values["controller"] == "Home");
    string logoUrl = "/Content/LocaleDependent/" + LocaleHelper.GetCultureName() + "/img/logo.jpg";
%>
<div id="headerLogo">   
    <%if(!isHome){ %>
        <%= Html.ActionLink("[IMAGE]", "Index", "Home", null, null)
                        .Replace("[IMAGE]", Html.Image(logoUrl))%>
    <%} %>
    <%else{ %>
        <%= Html.Image(logoUrl)%>
    <%} %>
</div>