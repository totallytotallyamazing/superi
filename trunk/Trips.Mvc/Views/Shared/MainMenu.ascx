<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<% 
    string request, catalogue, conditions, contacts;
    request = catalogue = conditions = contacts = "headerMenuItem";
    contacts += " last";

    string currentItem = ViewContext.RouteData.Values["Controller"].ToString();

    switch (currentItem)
    {
        case "Catalogue":
            catalogue += " current";
            break;
        case "Request":
            request += " current";
            break;
        case "Content":
            string id = ViewContext.RouteData.Values["id"].ToString();
            if (id == "Conditions")
                conditions += " current";
            if (id == "Contacts")
                contacts += " current";
            break;
        case "Feedback":
            contacts += " current";
            break;
        default:
            break;
    }
%>

<div id="box">
    <div class="<%= request %>">
        <a href="/Request" id="order">
        </a>
    </div>
    <div class="<%= catalogue %>">
        <a href="/Catalogue"  id="cars">
        </a>
    </div>
    <div class="<%= conditions %>">
        <a href="/Content/Conditions" id="terms">
        </a>
    </div>
    <div class="<%= contacts %>">
        <a href="/Feedback" id="contact">
        </a>
    </div>
</div>
