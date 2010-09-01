<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Article>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<div id="babySay">  
    <div id="sayText">
<% foreach (var item in Model){ %>
        <h3><%= item.Date.Day %> <%= item.Date.GetMonthName() %></h3>
        <h4>    
            <%= Html.ActionLink(item.Title, "Index", "Articles", null, null, item.Id.ToString(), new { Area = "", type = 1 }, null)%>
        </h4>
<% } %>
        <p>
            <%= Html.ActionLink("Все новости »", "Index", "Articles", new { Area="", type=1 }, null)%>
        </p>
    </div>
</div>