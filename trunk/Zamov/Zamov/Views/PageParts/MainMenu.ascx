<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%
    bool authenticated = (bool)ViewData["authenticated"];
    bool dealer = false;
    bool admin = false;
    if (authenticated)
    {
        dealer = (bool)ViewData["dealer"];
        admin = (bool)ViewData["admin"];
    }

    if (authenticated && admin)
        Response.Write(Html.ResourceActionLink("Administration", "Index", "Admin").ToLower() + "&nbsp;|&nbsp;");
    if ((authenticated && dealer) || (authenticated && admin))
        Response.Write(Html.ResourceActionLink("PersonalCabinet", "Index", "DealerCabinet").ToLower() + "&nbsp;|&nbsp;");
%>
                    <%= Html.ResourceString("News").ToLower() %>
                |
                <%= Html.ResourceString("Contacts").ToLower()%>