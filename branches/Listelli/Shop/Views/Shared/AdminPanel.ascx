<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
    /// <reference path="jquery.js" />
    var hidePanel = false;

    $(function() {
        $("#adminPanel .links").slideUp(0);

        $("#adminPanel .handle").mouseover(function() {
            hidePanel = false;
            $("#adminPanel .links").slideDown();
        });

        $("#adminPanel, #adminPanel .links").mouseover(function() { hidePanel = false; })

        $("#adminPanel, #adminPanel .links, #adminPanel .handle").mouseout(function() {
            hidePanel = true;
            window.setTimeout(function() {
                if (hidePanel) {
                    $("#adminPanel .links").slideUp();
                }
            }, 1000);
        });
    })
</script>

<div id="adminPanel">
    <div class="links">
        <%= Html.ActionLink("Настройки", "Index", new {controller="Settings", Area="Admin"}) %> | 
        <%= Html.ActionLink("Атрибуты", "Index", new {controller="Attributes", Area="Admin"}) %> | 
        <%= Html.ActionLink("Бренды", "Index", new { controller = "Brands", Area = "Admin", id = 2 })%> |
        <%= Html.ActionLink("Теги", "Index", new { controller = "Tags", Area = "Admin", id = 2 })%> |
        <%= Html.ActionLink("Группы каталога", "Groups", new { controller = "BrandCatalogue", Area = "Admin" })%> |
        <%= Html.ActionLink("Каталог", "ManageImages", new { controller = "BrandCatalogue", Area = "Admin", id = 2 })%> |
        <%= Html.ActionLink("Портфолио дизайнеров", "Index", new { controller = "Designers", Area = "Admin" })%> |
        <%= Html.ActionLink("Аккаунты дизайнеров", "Accounts", new { controller = "Designers", Area = "Admin" })%> |
        <%= Html.ActionLink("Брендовые каталоги", "Index", new { controller = "Catalogs", Area = "Admin" })%> |
        <%= Html.ActionLink("Список адресов рассылки", "Index", new { controller = "Subscribers", Area = "Admin" })%> |
        <%= Html.ActionLink("Выход", "LogOff", new {controller="Account", Area=""}) %> 
    </div>
    <div class="handle">
        Администрирование
    </div>
</div>
