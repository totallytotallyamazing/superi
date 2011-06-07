<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Models" %>
<% 
    string[] ruMonths = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
    string[] enMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    bool expand = (ViewData["expand"] != null) ? (bool)ViewData["expand"] : true;
    
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
            yearMonths.Add(year, articles.Where(a => a.Date.Year == year).OrderByDescending(a => a.Date).Select(a => a.Date.Month).Distinct().ToArray());
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
    var expand = <%= expand.ToString().ToLower() %>;
    var slideDownSpeed = 700;
    
    if(!expand)
        slideDownSpeed = 0;
    
    $(function() {
        initializeLinks();
        $("#menuContent").slideDown(slideDownSpeed);
    })

    var currentCulture = "<%= currentCulture %>";
    var currentYear = <%= ViewData["year"] %>;
    var currentYearControl = null;
    var currentMonth = <%= ViewData["month"] %>;
    var currentMonthControl = null;
    var broadcast = <%= broadcast.ToString().ToLower() %>;
    
    
    function initializeLinks() { 
        currentYearControl = $("a.year[rel='" + currentYear + "']").eq(0);
        currentYearControl.addClass("current");
        $("div.year").not(currentYearControl.next().next()).hide(0);
        $("a.year").not(currentYearControl).attr("href", "#")
        .click(yearClick);
        
        var rel = currentYear + "-" + currentMonth;
        currentMonthControl = $("a.month[rel='" + rel + "']").eq(0);
        currentMonthControl.addClass("current");

        if(broadcast){
            $("div.broadcast").not(currentMonthControl.next().next()).hide(0);
            $("a.month").not(currentMonthControl).attr("href", "#")
            .click(monthClick);
        }
        else{
            $("a.month").not(currentMonthControl).each(function(){
                var href = "/"+currentCulture+"/Notes/" + $(this).attr("rel");
                this.href = href;
            })
        }
    }
    
    function monthClick(){
        if(broadcast){
            currentMonthControl.removeClass("current").attr("href",  "#")
            .click(monthClick)
            .next().next().slideUp();
            
            currentMonthControl = $(this);
            currentMonthControl.addClass("current")
            .unbind("click").next().next().slideDown();
        }
    }
        
    function yearClick(){
        currentYearControl.removeClass("current").attr("href",  "#")
        .click(yearClick)
        .next().next().slideUp();
        
        currentYearControl = $(this);
        currentYearControl.addClass("current")
        .unbind("click").next().next().slideDown();
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
            {%>
                <a class="year" rel="<%= year %>"><%= year %></a><br /> 
                <div class="year">
                    <% 
                        foreach (int month in yearMonths[year])
                        {%>
                        <a class="month" rel="<%= year + "-" + month %>">
                            <%= getMonthName(month) %>
                        </a>
                        <br />
                        <%if(broadcast){ %>
                            <div class="broadcast">
                                <%
                                    bool first = true;
                                  foreach (Article item in monthArticles[year + "-" + month])
                                  {
                                      if(!first){
                                      %>
                                    <div>
                                    </div>
                                    <%} first = false; %>
                                    <%= item.Title %><br />
                                    <a href="/<%= currentCulture %>/Home/Broadcast/<%= item.Name %>">
                                        <%= item.SubTitle %>
                                    </a>
                                <%} %>
                            </div>
                        <%} %>
                      <%}
                    %>
                </div>
          <%}
        %>
    </div>
    <div id="menuBottom">
    </div>
</div>
<%} %>