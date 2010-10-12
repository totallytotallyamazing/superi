<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="basket">
    <div id="basketText">
        <p class="bt1">
            Чтобы стать Почетным Гостем, необходимо <%= Html.ActionLink("зарегистрироваться", "Register", new { controller = "Account" }, new { @class = "bt3" })%> или <%= Html.ActionLink("войти", "LogOn", new { controller = "Account" }, new { @class = "bt3" })%> под своей учетной записью
        </p>
    </div>
</div>

