<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="menuItem">
    <%= Html.ActionLink("Аудио", "Index", "Audio", null, new { rel="async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Видео", "Index", "Video", null, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Фотогалерея", "Index", "Gallery", null, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Новости", "Index", "Articles", null, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Биография", "Content", "Home", new { contentName = "bio" }, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Пресса", "Press", "Articles", null, new { rel = "async" })%>
</div>
