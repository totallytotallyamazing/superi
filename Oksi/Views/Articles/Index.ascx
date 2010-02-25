<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Article>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Models" %>

<% foreach (var item in Model){%>
    <div class="news">
        <div class="newsTitle">
            <%= item.Title %> / <span class="newsDate"><%= item.Date.ToString("dd.MM.yyyy") %></span>
        </div>
        <div class="newsContent">
            <%= Html.Image("~/Content/Artiles/News" + item.Image) %>
            <%= item.Text %>
        </div>
    </div>
<%} %>
