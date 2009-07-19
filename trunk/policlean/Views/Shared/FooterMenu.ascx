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

<%= Html.ActionLink("� ��������", "Index", "Home", null, new { @class = menuClasses[0] })%>
<%= Html.ActionLink("�������", "Index", "Clients", null, new { @class = menuClasses[1] })%>
<%= Html.ActionLink("������", "Index", "Services", null, new { @class = menuClasses[2] })%>
<%= Html.ActionLink("��������", "Index", "Contacts", null, new { @class = menuClasses[3] })%>