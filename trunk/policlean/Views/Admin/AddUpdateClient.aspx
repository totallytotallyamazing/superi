<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% using(Html.BeginForm("AddUpdateClient", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <table>
        <tr>
            <td>��������: </td>
            <td><%= Html.TextBox("name") %></td>
        </tr>
        <tr>
            <td>����:</td>
            <td><input type="file" name="logo" /></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" value="���������" /></td>
        </tr>
    </table>
    <%= Html.Hidden("id") %>
    
<%} %>