<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="menuItem">
    <%= Html.ActionLink("�����", "Index", "Audio", null, new { rel="async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("�����", "Index", "Video", null, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("�����������", "Index", "Gallery", null, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("�������", "Index", "Articles", null, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("���������", "Content", "Home", new { contentName = "bio" }, new { rel = "async" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("������", "Press", "Articles", null, new { rel = "async" })%>
</div>
