<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Tag>" %>

<div>
    <% using (Html.BeginForm("Edit", "Tags", FormMethod.Post, new {area=""})){ %>
    <%= Html.TextBoxFor(model=>model.Value) %>&nbsp;&nbsp;
    <%= Html.TextBoxFor(model=>model.Top) %>&nbsp;&nbsp;
    <%= Html.TextBoxFor(model=>model.Left) %>&nbsp;&nbsp;
    <%= Html.TextBoxFor(model=>model.Url) %>&nbsp;&nbsp;
    <input type="submit" value="Сохранить" />
    <%= Html.ActionLink("X", "Delete", new { id = Model.Id })%>
    <%} %>
</div>
