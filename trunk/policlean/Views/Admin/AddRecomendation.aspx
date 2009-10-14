<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% using (Html.BeginForm("AddRecomendation", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <%= Html.Hidden("id") %>
    <input type="file" name="image" /><br />
    <input type="submit" value="Сохранить" />
<%} %>
