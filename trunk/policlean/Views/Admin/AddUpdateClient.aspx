<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% using(Html.BeginForm("AddUpdateClient", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
<%= Html.Hidden("id") %>
Название: <%= Html.TextBox("name") %>
Лого: <input type="file" name="logo" />
<input type="submit" value="Сохранить" />
<%} %>