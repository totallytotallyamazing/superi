<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Trips.Mvc.Models" %>

<div id="newsBox">
    <div id="newsHeader">
        <p>
            <asp:Literal runat="server" Text="<%$ Resources:WebResources, News %>"></asp:Literal>
        </p>
    </div>
    <div id="newsContent">
        <% using(ContentStorage context = new ContentStorage())
	    {
               string language = LocaleHelper.GetCultureName();
               var articles = context.Articles
                   .OrderByDescending(a=>a.Date)
                   .Where(a=>a.Language == language)
                   .Take(3)
                   .Select(a=> new
                   {
                        date = a.Date,
                        name = a.Name,
                        title = a.Title
                 });
               foreach (var item in articles)
	            {
               %>
        <p>
            <%= item.date.ToString("dd.MM.yyyy") %>
        </p>
        <h4>
            <a href="/News#<%=item.name %>">
                <%= item.title %>
            </a>
        </h4>
<%             }
	    } %>
        <br />
        <h4>
            <%= Html.ResourceActionLink("AllNews", "Index", "News", null, new { style = "color: #3366ff" }) %>
        </h4>
    </div>
    <div id="newsFooter">
    </div>
</div>
