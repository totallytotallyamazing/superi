<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<% 
    string ruClass = "languageSwitch ru-RU";
    string enClass = "languageSwitch en-US";
    
    string ruLink = "<span class=\"languageSwitch ru-RU\"></span>";
    string enLink = "<span class=\"languageSwitch en-US\"></span>";
    
    RouteValueDictionary routeValues = ViewContext.RouteData.Values;
    string action = routeValues["action"].ToString();
    string controller = routeValues["controller"].ToString();
    if(controller.ToLower()!="account")
    {
    string contentName = routeValues["contentName"].ToString();
    string culture = LocaleHelper.GetCultureName();
    switch (culture)
	{
        case "ru-RU":
            enLink = Html.ActionLink("[empty]", action, controller, new { culture = "en-US", contentName = contentName }, new { @class = ruClass }).Replace("[empty]", string.Empty);
            break;
        case "en-US":
            ruLink = Html.ActionLink("[empty]", action, controller, new { culture = "ru-RU", contentName = contentName }, new { @class = enClass }).Replace("[empty]", string.Empty);
            break;
	} 
%>
<div id="languageBar">
    <table>
        <tr>
            <td align="center">
                ÐÓÑ
            </td>
            <td align="center">
                ENG
            </td>
        </tr>
        <tr>
            <td align="center">
                <%= ruLink %>
            </td>
            <td align="center">
                <%= enLink %>
            </td>
        </tr>
    </table>
</div>
<%} %>