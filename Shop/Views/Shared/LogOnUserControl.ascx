<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% 
if (Request.IsAuthenticated)
    Html.RenderPartial("UserStatus");
else
    Html.RenderPartial("LogOnOrSignUp");    
%>