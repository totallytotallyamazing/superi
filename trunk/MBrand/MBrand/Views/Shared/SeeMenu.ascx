<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%
    
    string chapter = ViewContext.RouteData.Values["action"].ToString();
    
    if(chapter == "See")
        chapter = ViewContext.RouteData.Values["type"].ToString();

    string sitesClass, vcardsClass, logoClass, polyClass, textClass;
    sitesClass = vcardsClass = logoClass = polyClass = textClass = "seeMenuItem";

    switch (chapter)
    {
        case "Sites":
        case "Site":
            sitesClass += " bold";
            break;
        case "Vcards":
        case "Vcard":
            vcardsClass += " bold";
            break;
        case "Logo":
        case "Logos":
            logoClass += " bold";
            break;
        case "Poly":
            polyClass += " bold";
            break;
        case "Text":
            textClass += " bold";
            break;
        default:
            break;
    }
%>
<div id="seeMenu">
    <div class="<%= sitesClass %>">
        <%= Html.ActionLink("�����", "Sites", "See")%>
    </div>
    <div class="<%= vcardsClass %>">
        <%= Html.ActionLink("�������", "Vcards", "See")%>
    </div>
    <div class="<%= logoClass %>">
        <%= Html.ActionLink("��������", "Logos", "See")%>
    </div>
    <div class="<%= polyClass %>">
        <%= Html.ActionLink("����������", "Poly", "See")%>
    </div>
    <div class="<%= textClass %>">
        <%= Html.ActionLink("������ � �������", "Text", "See")%>
    </div>
</div>