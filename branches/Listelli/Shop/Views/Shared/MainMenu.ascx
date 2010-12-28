﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="menuMain">
    <%
        string controllerName = ViewContext.RouteData.Values["controller"].ToString().ToLowerInvariant();
        string action = ViewContext.RouteData.Values["action"].ToString().ToLowerInvariant();
        string currenLocation = controllerName;
        if (currenLocation == "home" && action == "go")
            currenLocation = ViewContext.RouteData.Values["id"].ToString().ToLowerInvariant();
        else if (currenLocation == "articles")
            currenLocation = "articles";
        else if (currenLocation == "home" && (action == "feedbackform" || action == "feedbacksent"))
            currenLocation = "feedback";

        Func<string, string> isCurrent = (location) => (location == currenLocation) ? " current" : string.Empty;
    %>

    <div class="mainMenuItem<%= isCurrent("possibilities") %>">
        <a href="/Go/Possibilities" class="txtMenuItem">НАШИ ВОЗМОЖНОСТИ</a>
    </div>
    <div class="mainMenuItem<%= isCurrent("articles")%>">
        <a href="/Articles" class="txtMenuItem">НАШИ СОБЫТИЯ</a>
    </div>
    <div class="mainMenuItem<%= isCurrent("feedback")%>">
        <a href="/Home/FeedbackForm" class="txtMenuItem">ОБРАТНАЯ СВЯЗЬ</a>
    </div>


</div>
