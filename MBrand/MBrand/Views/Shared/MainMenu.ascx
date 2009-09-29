<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    
    string chapter = ViewContext.RouteData.Values["controller"].ToString();
    
    if(chapter == "Admin")
        chapter = ViewContext.RouteData.Values["action"].ToString();

    string eugeneClass, seeClass, clientsClass, notesClass, contactsClass;
    eugeneClass = seeClass = clientsClass = notesClass = contactsClass = "mainMenuItem";

    switch (chapter)
    {
        case "Eugene":
            eugeneClass += " bold";
            break;
        case "See":
            seeClass += " bold";
            break;
        case "Clients":
            clientsClass += " bold";
            break;
        case "Notes":
            notesClass += " bold";
            break;
        case "Contacts":
            contactsClass += " bold";
            break;
        default:
            break;
    }
%>

<div id="mainMenu">
    <div class="<%= eugeneClass %>">
        <%= Html.ActionLink("������� ������", "Index", "Eugene") %>
    </div>
    <div class="<%= seeClass %>">
        <%= Html.ActionLink("����������", "Index", "See")%>
    </div>
    <div class="<%= clientsClass %>">
        <%= Html.ActionLink("�������", "Index", "Clients")%>
    </div>
    <div class="<%= notesClass %>">
        <%= Html.ActionLink("�������", "Index", "Notes")%>
    </div>
    <div class="<%= contactsClass %>">
        <%= Html.ActionLink("��������", "Index", "Contacts")%>
    </div>
</div>
