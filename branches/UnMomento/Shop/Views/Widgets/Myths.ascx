<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Article>>" %>
<div id="preFooterMif">
<%foreach (var item in Model){%>
    <h2>Миф №<%= ViewData["index"] %></h2>          
    <h3>
        <%= Html.ActionLink(item.Title, "Index", "Articles", null, null, item.Id.ToString(), new {Area="", type=2 }, null)%>
     </h3>
<%} %>
    <h4>
        <%= Html.ActionLink("Все мифы", "Index", "Articles", new {Area="", type=2 }, null)%>
    </h4>
</div>