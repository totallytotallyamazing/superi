<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="wellcome">
    <p>
    <%if (Request.IsAuthenticated) {%>
        Добро пожаловать, <span><%= Profile.Name %></span>
    <%}else {%> 
        <%= Html.ActionLink("Зарегистрируйтесь", "Register", new { area="", controller="Account"})%> или <%= Html.ActionLink("войдите", "LogOn", new { area = "", controller = "Account" })%><br />
        (знакомым - привилегии)
    <%}%>
    </p>
</div>

