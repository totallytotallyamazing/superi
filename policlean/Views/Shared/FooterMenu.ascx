<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%= Html.ActionLink("О компании", "Index", "Home") %>
<%= Html.ActionLink("Клиенты", "Index", "Clients")%>
<%= Html.ActionLink("Услуги", "Index", "Services") %>
<%= Html.ActionLink("Контакты", "Index", "Contacts")%>