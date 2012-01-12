<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<p class="slogan">
    <%
        string currentUrl = Request.Url.ToString().ToLower();
        if (currentUrl.Contains("konkurs") || currentUrl.Contains("conditions") || currentUrl.Contains("fond"))
        {
    %>
    конкурс дизайнеров
    <%
                            }
                            else
                            {
    %>
    оформление интерьеров паркетом и мрамором
    <%
                        }%>
</p>
