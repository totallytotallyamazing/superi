<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Article>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Models" %>

<% if(Request.IsAuthenticated){ %>
    <%= Html.ActionLink("Редактировать", "Articles", "Admin", new { id=ViewData["type"] }, new {@class="adminLink"}) %>
<%} %>

<% foreach (var item in Model){%>
    <div class="news">
        <div class="newsTitle">
            <%= item.Title %> / <span class="newsDate"><%= item.Date.ToString("dd.MM.yyyy") %></span>
        </div>
        <div class="newsContent">
            <%= Html.Image("~/Content/Articles/News/" + item.Image) %>
            <%= item.Text.Replace("\r", "<br />") %>
        </div>
        <div style="clear:both;"></div>
    </div>
<%} %>
