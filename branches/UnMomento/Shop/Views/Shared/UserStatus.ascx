<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%= Ajax.DynamicCssInclude("/Content/UserStatus.css") %>
<% 
    Func<int, string, string> getEnding = (i, word) =>
        {
            if (i == 1) return word;
            else if (i > 1 && i < 5) return word + "а";
            else return word + "ов";
        };
%>
<div id="guest1">
    <h2>
        <a href="#"><%= Profile.Name %>,</a></h2>
    <p>
        в Вашей&nbsp;<a href="/Cart">корзинке</a> <strong><%= WebSession.OrderItems.Count %></strong> <%= getEnding(WebSession.OrderItems.Count, "товар")%> на сумму 
        <%= Html.RenderPrice(WebSession.TotalAmount, WebSession.Currency, 0, ",") %></p>
</div>

