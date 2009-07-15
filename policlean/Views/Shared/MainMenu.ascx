<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="mainMenuItem">
    <%= Html.ActionLink("О компании", "Index", "Home") %>
</div>
<div class="mainMenuItem">
    <%= Html.ActionLink("Клиенты", "Index", "Clients")%>
</div>
<div class="mainMenuItem">
    <%= Html.ActionLink("Услуги", "Index", "Services") %>
</div>
<div class="mainMenuItem">
    <%= Html.ActionLink("Контакты", "Index", "Contacts")%>
</div>