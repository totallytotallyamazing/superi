<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    
    string chapter = ViewContext.RouteData.Values["controller"].ToString();

    if (chapter == "Admin")
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
        case "Note":
            notesClass += " bold";
            break;
        case "Contacts":
            contactsClass += " bold";
            break;
        default:
            break;
    }
%>
<script type="text/javascript">
    $(function() {

        $("#seeLink").click(function(){
        $(this).addClass("bold");
        $(this).parent().addClass("bold");
        });

        <%if (chapter == "See"){ %>
        $("#seeLink").click(hideSeeMenu);
        $("#seeMenuReplacer").css("display", "none");
        $("#seeMenu").css("display", "block");
        <%} %>
        <%else{ %>
        $("#seeLink").click(showSeeMenu);
        <%} %>
    })

    function showSeeMenu() {
        $("#seeLink").unbind("click").click(hideSeeMenu);
        $("#seeMenuReplacer").css("display", "none");
        $("#seeMenu").show(500);
    }

    function hideSeeMenu() {
        $("#seeLink").unbind("click").click(showSeeMenu);
        $("#seeMenu").hide(500);
        window.setTimeout( function(){$("#seeMenuReplacer").css("display", "block");}, 430);
    }
    
</script>
<div id="mainMenu">
    <div class="<%= seeClass %>">
        <a id="seeLink" href="#">Наши работы </a>
    </div>
    <div class="mainMenuItemSplitter" id="seeMenuReplacer">
    </div>
    <% Html.RenderPartial("SeeMenu"); %>
    <div class="<%= eugeneClass %>">
        <%= Html.ActionLink("Студия", "Index", "Eugene") %>
    </div>
    <div class="mainMenuItemSplitter">
    </div>
    <div class="<%= clientsClass %>">
        <%= Html.ActionLink("Клиенты", "Index", "Clients")%>
    </div>
    <%--    <div class="mainMenuItemSplitter"></div>
    <div class="<%= notesClass %>">
        <%= Html.ActionLink("Заметки", "Index", "Notes")%>
    </div>--%>
    <div class="mainMenuItemSplitter">
    </div>
    <div class="<%= contactsClass %>">
        <%= Html.ActionLink("Связаться", "Index", "Contacts")%>
    </div>
</div>
