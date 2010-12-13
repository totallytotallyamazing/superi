<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<% 
    Func<int, string, string> getEnding = (i, word) =>
        {
            if (i == 1) return word;
            else if (i > 1 && i < 5) return word + "а";
            else return word + "ов";
        };
%>
<div id="basket">
    <p>
        В <%= Html.ActionLink("корзинке", "Index", new { controller = "Cart" }) %> 
        <%if(WebSession.OrderItems.Count > 0){ %>
        <%= WebSession.OrderItems.Count %> <%= getEnding(WebSession.OrderItems.Count(), "товар")%> на <%= Html.RenderPrice(WebSession.TotalAmount, WebSession.Currency, 0, ",") %>
        <%}else{ %>
            пусто
        <%} %>
    </p>
</div>`