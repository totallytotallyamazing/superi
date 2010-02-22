<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<% using(Html.BeginForm()){ %>
    <%= Html.Hidden("id") %>
    <%= Html.TextBox("name") %>
    <br />
    <%= Html.TextArea("comments") %>
    <br />
    <input type="submit" value="Сохранить" />
<%} %>