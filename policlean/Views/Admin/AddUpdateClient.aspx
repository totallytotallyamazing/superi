<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% using(Html.BeginForm("AddUpdateClient", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <%= Html.Hidden("id") %>
    ��������: <%= Html.TextBox("name") %><br />
    ����: <input type="file" name="logo" /><br />
    <input type="submit" value="���������" />
<%} %>