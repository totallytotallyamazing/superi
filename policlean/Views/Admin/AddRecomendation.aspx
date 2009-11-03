<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% using (Html.BeginForm("AddRecomendation", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <%= Html.Hidden("id") %>
    <table>
        <tr>
            <td>Миниатюра:</td>
            <td><input type="file" name="preview" /></td>
        </tr>
        <tr>
            <td>Изображение:</td>
            <td><input type="file" name="image" /></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" value="Сохранить" /></td>
        </tr>
    </table>
<%} %>
