<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="System.Globalization" %>
<% 
    Func<string, string> getLangLink = lang =>
    {
        string uri = Request.Url.AbsoluteUri;
        string langSegment;
        Regex langEx = new Regex("lang=[a-z]{2}-[A-Z]{2}");
        
        if (langEx.IsMatch(uri))
        {
            langSegment = "lang=" + lang;
            return langEx.Replace(uri, langSegment);
        }

        if (uri.Contains("?"))
            langSegment = "&lang=" + lang;
        else
            langSegment = "?lang=" + lang;

        
        if (uri.Contains("#"))
            return uri.Insert(uri.IndexOf("#"), langSegment);
        return uri + langSegment;
    };
%>

<div class="languageSwitch">
    <% if (CultureInfo.CurrentUICulture.Name == "ru-RU") {  %>
        <span>РУС</span>
    <%} else { %>
        <a href="<%= getLangLink("ru-RU") %>">РУС</a>
    <%} %>
    &nbsp;|&nbsp;
    <% if (CultureInfo.CurrentUICulture.Name == "en-US") {  %>
        <span>ENG</span>
    <%} else { %>
        <a href="<%= getLangLink("en-US") %>">ENG</a>
    <%} %>
</div>

