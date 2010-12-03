<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int>" %>

<div id="menu"> 
    <div class="menuBox">
        <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>("Корзина", Model == 0)); %> 
    </div>
    <div class="menuBox">
        <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>(@"» Авторизация", Model == 1)); %> 
    </div>
    <div class="menuBox">
        <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>(@"» Доставка и оплата", Model == 2)); %> 
    </div>
    <div class="menuBox">
        <% Html.RenderPartial("CartBreadCrumb", new KeyValuePair<string, bool>(@"» Подтверждение", Model == 3)); %>
    </div>
</div>