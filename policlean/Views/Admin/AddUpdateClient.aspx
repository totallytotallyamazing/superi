<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% using(Html.BeginForm("AddUpdateClient", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <table>
        <tr>
            <td>Название: </td>
            <td><%= Html.TextBox("name") %></td>
        </tr>
        <tr>
            <td>Лого:</td>
            <td><input type="file" name="logo" /></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" value="Сохранить" /></td>
        </tr>
    </table>
    <%= Html.Hidden("id") %>
    
<%} %>