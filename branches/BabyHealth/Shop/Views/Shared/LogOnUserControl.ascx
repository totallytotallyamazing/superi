<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% if(Request.IsAuthenticated){ %>
<%} %>
<%else{ %>
<div id="guest">
    <p>Чтобы стать Почетным Гостем, необходимо <%= Html.ActionLink("зарегистрироваться", "Register", new { controller="Account"})%> или <%= Html.ActionLink("войти", "LogOn", new { controller="Account"})%> под своей учетной записью</p>
</div>
<%} %>