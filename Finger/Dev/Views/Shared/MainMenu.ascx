<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>

<%
    string contentName = ViewContext.RouteData.Values["contentName"].ToString();
    
    string culture = LocaleHelper.GetCultureName();

    string span = Html.ActionLink("[empty]", "Index", new { culture = "myCulture", contentName = "myName" }, new { id="myId", @class = "myCulture" }).Replace("[empty]", string.Empty); 
    string lsText, elenaText, notesText, contactsText;
    lsText = span.Replace("myCulture", culture).Replace("myName", "LifeStyle").Replace("myId", "lifeStyle");
    elenaText = span.Replace("myCulture", culture).Replace("myName", "Elena").Replace("myId", "elena");
    notesText = span.Replace("myCulture", culture).Replace("myName", "Notes").Replace("myId", "notes");
    contactsText = span.Replace("myCulture", culture).Replace("myName", "Contacts").Replace("myId", "contacts");

    switch (contentName)
	{
        case "LifeStyle":
            lsText = "<span id=\"lifeStyle\" class=\"" + culture + "\"></span>";
            break;
        case "Elena":
            elenaText = "<span id=\"elena\" class=\"" + culture + "\"></span>";
            break;
        case "Notes":
            notesText = "<span id=\"notes\" class=\"" + culture + "\"></span>";
            break;
        case "Contacts":
            contactsText = "<span id=\"contacts\" class=\"" + culture + "\"></span>";
            break;
    }   
%>
<div id="mainMenu">
    <div class="mainMenuItem">
        <%= lsText %>
    </div>
    <div class="mainMenuItem">
        <%= elenaText %>
    </div>
    <div class="mainMenuItem">
        <%= notesText %>
    </div>
    <div class="mainMenuItem">
        <%= contactsText %>
    </div>
</div>