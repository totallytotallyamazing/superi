<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Lady.Models.Article>>" %>
<<<<<<< .working

<div id="newsBox">
    <div id="newsHeader">
=======
<%@ Import Namespace="Dev.Helpers" %>
<div id="babySay">  
    <div id="sayText">
<% foreach (var item in Model){ %>
        <h3><%= item.Date.Day %> <%= item.Date.GetMonthName() %></h3>
        <h4>    
            <%= Html.ActionLink(item.Title, "Index", "Articles", null, null, item.Id.ToString(), new { Area = "", type = 1 }, null)%>
        </h4>
<% } %>
>>>>>>> .merge-right.r1453
        <p>
<<<<<<< .working
            НОВОСТИ
        </p>
=======
            <%= Html.ActionLink("Все новости »", "Index", "Articles", new { Area="", type=1 }, null)%>
        </p>
>>>>>>> .merge-right.r1453
    </div>
    <div id="newsContent">
        <% foreach (var item in Model)
           {%>
            <p><%= item.Date.ToString("dd:MMMM") %></p>
            <h4>
                <%= Html.ActionLink(item.Title, "Index", "Articles") %>
            </h4>
        <%} %>
        <br />
        <h4><a href="#" style="color: #3366ff">Все новости</a></h4>
    </div>
    <div id="newsFooter">
    </div>
 </div>