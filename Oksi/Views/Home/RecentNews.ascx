<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Article>>" %>
<%@ Import Namespace="Oksi.Models" %>
<div id="recentNews">
    <%foreach (var item in Model)
      {%>
        <div>
            <p class="title"><%= item.Title %></p>
            <p class="date"><%= item.Date.ToString("dd.MM.yyyy") %> <a rel="async" href="Articles/<%= item.Id %>">��� �������>>></a></p>
            <p class="detailsLink">
                
            </p>
        </div>
    <%} %>
    <div id="allNews">
        <a href="/Articles" rel="async">��� �������</a>
    </div>
</div>