<%@ Page Language="C#" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<div id="archiveContainer">
<%
    NewsDataContext context = new NewsDataContext();
    List<NewsItem> news = context.NewsItems.Select(al => al).Where(al => al.Archive.Value == true).OrderByDescending(al => al.Date).ToList();
 //   news = news.Skip(pageNumber * 4).Take(4).ToList();

    foreach (NewsItem item in news)
    {
        %>
            <a>
                <span>
                    <% Response.Write(item.Date.Value.ToString("dd.MM.yyyy")); %>&nbsp;
                </span>
                &nbsp;<% Response.Write(item.Title);%>
            </a>
            <div>
                <div>
                    <% Response.Write(item.Text); %>
                </div>
            </div>
        <%
    }
%>
</div>