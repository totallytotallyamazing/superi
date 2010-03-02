<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Article>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Models" %>
<div id="latestNews">
    <%= Html.Image("~/Content/Articles/News/" + Model.Image)%>
    <div id="newsContent">
        <div id="newsHeader">
            <%= Html.ActionLink(Model.Title, "Index", "Articles", new { id = Model.Id }, new { rel = "async" })%>
        </div>
        <div id="newsDate">
            <%= Model.Date.ToString("dd.MM.yyyy") %>
            <hr />
        </div>
        <div id="newsText">
            <%= Model.Description %>
        </div>
    </div>
</div>