<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="menuItem">
    <%= Html.ActionLink("�����", "Index", "Audio") %>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("�����", "Index", "Video")%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("�����������", "Index", "Photo")%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("�������", "Index", "Articles") %>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("���������", "Content", "Home", new {contentName = "bio" })%>
</div>
<div>|</div>
<div class="menuItem">
    <%= Html.ActionLink("������", "Press", "Articles") %>
</div>
