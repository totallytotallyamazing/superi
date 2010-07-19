<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int>" %>

<div class="cartBreadCrumbs"> 
    <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>("Корзина", Model == 0)); %> 
    <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>(@"\ Авторизация", Model == 1)); %> 
    <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>(@"\ Доставка и оплата", Model == 2)); %> 
    <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>(@"\ Подтверждение", Model == 3)); %>
</div>