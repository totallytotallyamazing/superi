<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<% bool isAtHome = ViewContext.RouteData.Values["controller"].ToString().ToLower() == "home"; %>
<% bool isIndex = ViewContext.RouteData.Values["action"].ToString().ToLower() == "index"; %>
<% if(!(isAtHome && isIndex)){ %>
<a href="/">
<%} %>
   <img src="/Content/img/logo.jpg" alt="babyHealth" />
<% if(!(isAtHome && isIndex)){ %>   
</a>
<% } %>