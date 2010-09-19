<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Tag>" %>
<div>
    <% using (Html.BeginForm("Edit", "Tags", FormMethod.Post, new {area=""})){ %>
    <%= Html.HiddenFor(model=>model.Id) %>
    <%= Html.TextBoxFor(model=>model.Value) %>&nbsp;&nbsp;
    <%= Html.TextBoxFor(model=>model.Left) %>&nbsp;&nbsp;
    <input type="submit" value="Сохранить" />
    <%= Html.ActionLink("X", "Delete", new { id = Model.Id })%>
    <%} %>
</div>
