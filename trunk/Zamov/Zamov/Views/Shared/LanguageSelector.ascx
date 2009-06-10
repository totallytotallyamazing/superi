<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Controllers" %>
<% 
    string currentLanguage = ((string)Session["lang"]) ?? "uk-UA";
    if (currentLanguage == "uk-UA")
        Response.Write(Html.ResourceString("Ukr") + "/" + Html.ResourceActionLink<HomeController>("Rus", c=>c.SetRussian()));
    else
        Response.Write(Html.ResourceActionLink<HomeController>("Ukr", c => c.SetUkrainian()) + "/" + Html.ResourceString("Rus"));
%>
