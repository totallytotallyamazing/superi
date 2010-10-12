<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%= Ajax.DynamicCssInclude("/Content/UserStatus.css") %>
<% 
    Func<int, string, string> getEnding = (i, word) =>
        {
            if (i == 1) return word +  "ок";
            else if (i > 1 && i < 5) return word + "ка";
            else return word + "ков";
        };
%>

<div id="basket">
    <div id="basketText">
        <p class="bt1">
            <br />
            В Вашей <a href="/Cart" class="bt1"><b>корзинке</b></a>
            <br />
            <b class="bt2"><%= WebSession.OrderItems.Count %></b> <%= getEnding(WebSession.OrderItems.Count, "подар")%>
            <br />
            на сумму <b class="bt2"><%= Html.RenderPrice(WebSession.TotalAmount, WebSession.Currency, 0, ",") %></b>                    
            <br />
            <a href="#" class="bt3"><b>Оформить! »</b></a>
        </p>
    </div>
</div>
