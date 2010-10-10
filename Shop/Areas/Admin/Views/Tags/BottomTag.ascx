<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Tag>" %>

<div>
    <% using (Html.BeginForm("EditBottom", "Tags", FormMethod.Post, new {area=""})){ %>
    <%: Html.HiddenFor(model => model.Id) %>
    <%: Html.TextBoxFor(model => model.Value) %>&nbsp;&nbsp;
    <%: Html.TextBoxFor(model => model.Top, new { style="width:30px;" })%>&nbsp;&nbsp;
    <%: Html.TextBoxFor(model => model.Left, new { style = "width:30px;" })%>&nbsp;&nbsp;
    <%: Html.TextBoxFor(model => model.FontSize, new { style = "width:30px;" })%>&nbsp;&nbsp;
    <%: Html.TextBoxFor(model => model.Url) %>&nbsp;&nbsp;
    <input type="submit" value="Сохранить" />
    <%: Html.ActionLink("X", "DeleteBottom", new { id = Model.Id })%>
    <%} %>
</div>
