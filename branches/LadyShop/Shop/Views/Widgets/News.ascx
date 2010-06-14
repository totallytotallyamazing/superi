<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Lady.Models.Article>>" %>

<div id="newsBox">
    <div id="newsHeader">
        <p>
            НОВОСТИ
        </p>
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