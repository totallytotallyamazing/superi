<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="mainMenuItem">
    <%= Html.ActionLink("� ��������", "Index", "Home") %>
</div>
<div class="mainMenuItem">
    <%= Html.ActionLink("�������", "Index", "Clients")%>
</div>
<div class="mainMenuItem">
    <%= Html.ActionLink("������", "Index", "Services") %>
</div>
<div class="mainMenuItem">
    <%= Html.ActionLink("��������", "Index", "Contacts")%>
</div>