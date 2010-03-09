<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Trips.Mvc.Controllers" %>

<h3>
    <%= Html.ResourceString("Car")%>:
</h3>
<br />

<table>
    <% foreach (var item in WebSession.OrderItems)
       {%>
           
     <%} %>
</table>

