<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% if(Request.IsAuthenticated){ %>  
    <% Html.RenderPartial("UserStatus"); %>
<%} %>
<%else{ %>

<div id="basket">  
                <div id="basketText">
                    <p class="bt1">
                        В Вашей <a href="#" class="bt1"><b>корзинке</b></a>
                        <br />
                        <b class="bt2">3</b> подарка
                        <br />
                        на сумму <b class="bt2">1,900</b> грн
                        <br />
                        <a href="#" class="bt3"><b>Оформить! »</b></a>
                    </p>
                </div>
            </div>

<%--<div id="guest">
    <p>Чтобы стать Почетным Гостем, необходимо <%= Html.ActionLink("зарегистрироваться", "Register", new { controller="Account"})%> или <%= Html.ActionLink("войти", "LogOn", new { controller="Account"})%> под своей учетной записью</p>
</div>--%>
<%} %>