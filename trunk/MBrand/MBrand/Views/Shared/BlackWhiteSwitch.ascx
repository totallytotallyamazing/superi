<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="MBrand.Controllers" %>
<%
    bool black = Convert.ToBoolean(ViewData["black"]);
%>

<% if (black)
   { %>
    <%= Html.ActionLink<HomeController>(hc=>hc.White(Request.Url.AbsolutePath), "�� �����") %>
    &nbsp;|&nbsp;
    <span class="inactiveBw">
        �� ������
    </span>
<%} %>
<% else
    { %>
    <span class="inactiveBw">
        �� �����
    </span>
    &nbsp;|&nbsp;
    <%= Html.ActionLink<HomeController>(hc => hc.Black(Request.Url.AbsolutePath), "�� ������")%>

<%} %>
