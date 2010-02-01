<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="menuItem">
    <%= Html.ActionLink("Аудио", "Index", "Audio") %>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Видео", "Index", "Video")%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Фотогалерея", "Index", "Photo")%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Новости", "Index", "Articles") %>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Биография", "Content", "Home", new {contentName = "bio" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("Пресса", "Press", "Articles") %>
</div>
