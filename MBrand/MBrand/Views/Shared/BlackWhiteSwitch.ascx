<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="MBrand.Controllers" %>
<%
    bool black = Convert.ToBoolean(ViewData["black"]);
%>

<% if (black)
   { %>
    <%= Html.ActionLink<HomeController>(hc=>hc.White(Request.Url.AbsolutePath), "на белом") %>
    &nbsp;|&nbsp;
    <span class="inactiveBw">
        на черном
    </span>
<%} %>
<% else
    { %>
    <span class="inactiveBw">
        на белом
    </span>
    &nbsp;|&nbsp;
    <%= Html.ActionLink<HomeController>(hc => hc.Black(Request.Url.AbsolutePath), "на черном")%>

<%} %>
