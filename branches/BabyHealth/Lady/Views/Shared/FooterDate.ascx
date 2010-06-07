<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="System.Globalization" %>
<% 
    int currentMonth = DateTime.Now.Month - 1;
    string monthName = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[currentMonth];
    monthName = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(monthName);
    
%>

<div id="footerDate">
    <p><%= monthName+", "+DateTime.Now.Day %></p>
</div>
