<%@ Page Language="C#" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>

<%
    int pageNumber = int.Parse(Request.QueryString["page"]) - 1;
    NewsDataContext context = new NewsDataContext();
    List<NewsItem> news = context.NewsItems.Select(al => al).Where(al => al.Archive.Value == false).OrderByDescending(al => al.Date).ToList();
    news = news.Skip(pageNumber * 4).Take(4).ToList();

    foreach (NewsItem item in news)
    {
        %>
            <div class="newsItem">
<%--                <div class="newsImage">
                    <img alt="<% Response.Write(item.Title);%>" src="makethumbnail.aspx?w=115&h=115&loc=news&file=<% Response.Write(item.Picture); %>" />
                </div>--%>
                <div class="newsContent">
                    <div class="newsBg">
                    </div>
                    <div class="exceptDetails">
                        <div class="newsTitle">
                            <% Response.Write(item.Title); %>
                        </div>
                        <div class="newsDate">
                            <% Response.Write(item.Date.Value.ToString("dd.MM.yy")); %>
                        </div>
                        <div class="newsText">
                            <% Response.Write(item.ShortText); %>
                        </div>
                    </div>
                    <% string visibility = "visible";
                       if (string.IsNullOrEmpty(item.Text))
                       {
                           visibility = "hidden";
                       } %>
                    <div class="newsDetail" style="visibility:<%= visibility %>">
                        <span>подробнее...</span>
                        <span style="display:none" id="newsDetail"> <% Response.Write(item.Text); %></span>
                    </div>
                </div>
            </div>
        <%
    }
%>

