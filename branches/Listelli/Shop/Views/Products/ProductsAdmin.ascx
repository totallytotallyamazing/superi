<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<p class="adminLink">
    <%= Html.ActionLink("Добавить товар", "AddEdit", "Products", new { area = "Admin"})%>
</p>