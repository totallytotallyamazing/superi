<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="basket">
    <div id="basketText">
        <p class="mainAdress">
            <%-- <%= Html.ActionLink("зарегистрироваться", "Register", new { controller = "Account" }, new { @class = "mainAdress" })%> --%>
             <br />
              <%= Html.ActionLink("войти", "LogOn", new { controller = "Account" }, new { @class = "mainAdress" })%> 
        </p>
    </div>
</div>

