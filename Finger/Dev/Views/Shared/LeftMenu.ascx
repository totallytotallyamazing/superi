<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Models" %>
<% 
    string[] ruMonths = { "Январь", "Фавраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
    string[] enMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    Dictionary<string, string[]> months = new Dictionary<string, string[]> { { "ru-RU", ruMonths }, { "en-US", enMonths } };
    using (DataStorage context = new DataStorage())
    {
        bool broadcast = (ViewContext.RouteData.Values.ContainsKey("contentName") && ViewContext.RouteData.Values["contentName"].ToString().ToLower() == "lifestyle");

        List<Article> articles = context.Articles.Where
            (
                a => (broadcast) ? a.Type == (int)ArticleType.LifeStyle
                    : a.Type == (int)ArticleType.Note
            ).OrderByDescending(a => a.Date).ToList();
    
%>
<div id="leftMenu">
    <div id="top">
    </div>
    <div id="content">
        <% 
            int year = 0;
            int month = 0;
            foreach (var item in articles)
            {
                if (item.Date.Year != year)
                {
                    %>
                    <div class="year">
                        <a class="year">
                            <%= item.Date.Year%>
                        </a>
              <%}
                if (item.Date.Month != month)
                {
                    month = item.Date.Month;
                    %>
                    <div class="month">
                        <a class="month">
                            <%= item.Date.Month %>
                        </a>
              <%}
                if (broadcast)
                { %>
                    <div class="broadcast">
                        <%= item.Title %>
                        <%= Html.ActionLink(item.SubTitle, "Broadcast", new {culture = System.Globalization.CultureInfo.CurrentUICulture, contentName = item.Name}) %>
                    </div>    
              <%}
                if (item.Date.Month != month)
                {
                    month = item.Date.Month;
                    %>
                   </div>                     
              <%}
                if (item.Date.Year != year)
                {
                    year = item.Date.Year;
                    %>
                   </div>                     
              <%}
            }
        %>
    </div>
    <div id="bottom">
    </div>
</div>
<%} %>