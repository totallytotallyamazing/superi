<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
    $(function() {
        var boxWidth = $("#box").width();
        var containerWidth = $("#header").width();
        var padding = (containerWidth - boxWidth) / 2 - $("#headerLogo").width();
        $("#box").css("padding-left", padding);

        $(".headerMenuItem").blur();
    });

    $(window).resize(function() {
        var boxWidth = $("#box").width();
        var containerWidth = $("#header").width();
        var padding = (containerWidth - boxWidth) / 2 - $("#headerLogo").width();
        $("#box").css("padding-left", padding);
    });
</script>

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
        <a href="/Content/Contacts" id="contact">
        </a>
    </div>
</div>
