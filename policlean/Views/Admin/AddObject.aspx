<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% using (Html.BeginForm("AddObject", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <%= Html.Hidden("id") %>
    Миниатюра:<input type="file" name="preview" /><br />
    Изображение:<input type="file" name="image" /><br />
    <input type="submit" value="Сохранить" />
<%} %>