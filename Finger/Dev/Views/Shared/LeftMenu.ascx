<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Models" %>
<% 
    string[] ruMonths = { "Январь", "Фавраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
    string[] enMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    Dictionary<string, string[]> months = new Dictionary<string, string[]> { { "ru-RU", ruMonths }, { "en-US", enMonths } };
    using (DataStorage context = new DataStorage())
    {
        string action = ViewContext.RouteData.Values["action"].ToString();
        bool broadcast = ((ViewContext.RouteData.Values.ContainsKey("contentName") && ViewContext.RouteData.Values["contentName"].ToString().ToLower() == "lifestyle") || action == "Broadcast");
        
        string currentCulture = Dev.Helpers.LocaleHelper.GetCultureName();
        
        List<Article> articles = context.Articles.Where
            (
                a => (broadcast) ? a.Type == (int)ArticleType.LifeStyle
                    : a.Type == (int)ArticleType.Note
            )
            .Where(a => a.Language == currentCulture)
            .OrderByDescending(a => a.Date).ToList();
        List<int> years = articles.Select(a => a.Date.Year).Distinct().ToList();

        Dictionary<int, int[]> yearMonths = new Dictionary<int, int[]>();
        foreach (int year in years)
        {
            yearMonths.Add(year, articles.Where(a => a.Date.Year == year).OrderByDescending(a => a.Date).Select(a => a.Date.Month).ToArray());
        }
        Dictionary<string, Article[]> monthArticles = new Dictionary<string, Article[]>();
        if (broadcast)
        {
            foreach (var year in years)
            {
                foreach (var month in yearMonths[year])
                {
                    monthArticles.Add(year + "-" + month, articles.Where(a => a.Date.Year == year && a.Date.Month == month).Select(a => a).ToArray());
                }
            }
        }
        
        Func<int, string> getMonthName = (monthNumber) => months[currentCulture][monthNumber - 1];
%>

<script type="text/javascript">
    $(function() {
        initializeLinks();
        $("#menuContent").slideDown();
    })

    var currentYear = <%= DateTime.Now.Year %>;
    var currentYearControl = null;
    var currentMonth = <%= DateTime.Now.Month %>;
    var currentMonthControl = null;
    
    function initializeLinks() { 
        currentYearControl = $("a.year").eq(0);
        currentYearControl.addClass("current");
        $("div.year").not(currentYearControl.next().next()).hide(0);
        $("a.year").not(currentYearControl).attr("href", "#")
        .click(yearClick);
        
        function yearClick()
        {
            currentYearControl.removeClass("current").attr("href",  "#")
            .click(yearClick)
            .next().next().slideUp()
            
            currentYearControl = $(this);
            currentYearControl.addClass("current").unbind("click").next().next().slideDown();
        }
    }
</script>
<div id="leftMenu">
    <div id="menuTop">
    </div>
    <div id="menuContent">
        <%if(Request.IsAuthenticated){ %>
            <div class="adminLink">
                <a href="/Admin/Article/?type=<%= (broadcast) ? ArticleType.LifeStyle  :ArticleType.Note %>">
                    Добавить
                </a>
            </div>
        <%} %>

        <% 
            foreach (int year in years)
            {
                
            }
        %>
    </div>
    <div id="menuBottom">
    </div>
</div>
<%} %>