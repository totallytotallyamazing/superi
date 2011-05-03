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
            <%= Html.Image("~/Content/Articles/News/" + ((!string.IsNullOrEmpty(item.Image)) ? item.Image : "oksiSiteDefaultArticleImage.jpg"))%>
            <%= item.Text.Replace("\r", "<br />") %>
        </div>
        <div style="clear:both;"></div>
        <div class="shareButtons">
        <%string url = "http://oksi.com.ua/#url=%2FArticles%2FIndex%2F"+item.Id; %>
            <div>
                <a href="<%=url%>"  target="_blank" rel="nofollow" onclick="ODKL.Share(this);return false;" title="Поделиться в Одноклассниках" class="shareButton odnoklassnikiButton"></a>
            </div>
            <div>
                <a href="http://www.facebook.com/sharer.php?u=<%=url%>" title="Поделиться в Facebook" rel="nofollow" target="blank" class="shareButton fbButton"></a>
            </div>  
            <div>
                <a href="http://twitter.com/home?status=<%=HttpUtility.UrlPathEncode(item.Title.Trim())%> <%=HttpUtility.UrlEncode(url)%>"  target="_blank" rel="nofollow" class="shareButton twitterButton"></a>
            </div>                      
            <div>
                <a href="http://vkontakte.ru/share.php?url=<%=url%>" target="_blank" rel="nofollow" class="shareButton vkButton"></a>
            </div>
        </div>
        <div style="clear:both;"></div>
    </div>
<%} %>
