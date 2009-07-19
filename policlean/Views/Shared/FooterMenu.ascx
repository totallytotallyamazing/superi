<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%
    string[] menuClasses = { "footerLink", "footerLink", "footerLink", "footerLink" };

    switch (ViewContext.RouteData.Values["controller"].ToString().ToUpperInvariant())
    { 
        case "HOME":
            menuClasses[0] = "footerLinkActive";
            break;
        case "CLIENTS":
            menuClasses[1] = "footerLinkActive";
            break;
        case "SERVICES":
            menuClasses[2] = "footerLinkActive";
            break;
        case "CONTACTS":
            menuClasses[3] = "footerLinkActive";
            break;
    }
%>

<%= Html.ActionLink("О компании", "Index", "Home", null, new { @class = menuClasses[0] })%>
<%= Html.ActionLink("Клиенты", "Index", "Clients", null, new { @class = menuClasses[1] })%>
<%= Html.ActionLink("Услуги", "Index", "Services", null, new { @class = menuClasses[2] })%>
<%= Html.ActionLink("Контакты", "Index", "Contacts", null, new { @class = menuClasses[3] })%>