<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%using(Html.BeginForm("AddImage", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
<%= Html.Hidden("galleryId")%>
������:<br />
<input name="preview" type="file" /><br />
����:<br />
<input name="picture" type="file" /><br />
<input type="submit" value="��������"/>
<%} %>