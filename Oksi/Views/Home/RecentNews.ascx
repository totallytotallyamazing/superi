<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Article>>" %>
<%@ Import Namespace="Oksi.Models" %>
<div id="recentNews">
    <%foreach (var item in Model)
      {%>
        <div>
            <p class="title"><%= item.Title %></p>
            <p class="date"><%= item.Date.ToString("dd.MM.yyyy") %>  <%= Html.ActionLink("вся новость>>>", "Index", "Articles", new { id = item.Id }, new { rel = "async" })%>
            <p class="detailsLink">
                
            </p>
        </div>
    <%} %>
    <div id="allNews">
        <a href="/Articles" rel="async">все новости</a>
    </div>
</div>