<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    string[] menuClasses = { "mainMenuItem", "mainMenuItem", "mainMenuItem", "mainMenuItem" };

    string controllerName = ViewContext.RouteData.Values["controller"].ToString().ToUpperInvariant();
    if (controllerName == "ADMIN")
    {
        if (ViewData["controllerName"] != null)
            controllerName = ViewData["controllerName"].ToString().ToUpperInvariant();
    }

    switch (controllerName)
    {
        case "HOME":
            menuClasses[0] += " mainMenuItemActive";
            break;
        case "CLIENTS":
            menuClasses[1] += " mainMenuItemActive";
            break;
        case "SERVICES":
            menuClasses[2] += " mainMenuItemActive";
            break;
        case "CONTACTS":
            menuClasses[3] += " mainMenuItemActive";
            break;
    }
%>
<div class="<%= menuClasses[0] %>">
    <a href="/">
        О компании  
    </a>
</div>
<div class="<%= menuClasses[1] %>">
    <%= Html.ActionLink("Клиенты", "Index", "Clients")%>
</div>
<div class="<%= menuClasses[2] %>">
    <%= Html.ActionLink("Услуги", "Index", "Services") %>
</div>
<div class="<%= menuClasses[3] %>">
    <%= Html.ActionLink("Контакты", "Index", "Contacts")%>
</div>
