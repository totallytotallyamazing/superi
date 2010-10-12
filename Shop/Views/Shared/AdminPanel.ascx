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
        <%= Html.ActionLink("Теги", "Index", new {controller="Tags", Area="Admin"}) %> | 
        <%= Html.ActionLink("Бренды", "Index", new { controller = "Brands", Area = "Admin", id = 2 })%> |
        <%= Html.ActionLink("Заказы", "Index", new { controller = "Orders", Area = "Admin", id = 2 })%> |
        <%= Html.ActionLink("Выход", "LogOff", new {controller="Account", Area=""}) %> 
    </div>
    <div class="handle">
        Администрирование
    </div>
</div>
