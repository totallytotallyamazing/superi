<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Content>" %>

<% using(Html.BeginForm()){ %>
<%= Html.HiddenFor(m=>m.Name) %>
<%= Html.HiddenFor(m=>m.Title) %>
<%= Html.HiddenFor(m=>m.Language) %>

<div>
<p>Текст:</p>
<%= Html.TextAreaFor(m=>m.Text)  %>
</div>

<div>
<p>Keywords:</p>
<%= Html.TextBoxFor(m=>m.Keywords)  %>
</div>

<div>
<p>Description:</p>
<%= Html.TextAreaFor(m=>m.Description)  %>
</div>
<input type="submit" value="Сохранить" />   
<%} %>