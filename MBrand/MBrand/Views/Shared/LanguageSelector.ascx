<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%
    bool english = false;
    if (ViewData["english"] != null)
        english = true;
%>

<div id="languageSwitch">
<%if(!english){ %>   
    <a href="/Home/English?redirectUrl=<%= Request.Url.AbsoluteUri %>">eng</a>&nbsp;|&nbsp;<span>ru</span>
<%} %>
<%else{ %>
    <span>eng</span>&nbsp;|&nbsp;<a href="<%= ViewData["redirectUrl"] %>">ru</a>
<%} %>
</div>

