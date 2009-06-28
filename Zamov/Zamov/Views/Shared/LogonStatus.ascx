<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div id="masterLogin">
<%
    if (Request.IsAuthenticated)
        Html.RenderPartial("LogOnName");
    else
        Html.RenderPartial("MasterLogOn");
%>
</div>