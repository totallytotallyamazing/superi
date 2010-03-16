<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Trips.Mvc.Controllers" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<table class="selectedAds" cellpadding="5" cellspacing="15">
    <% foreach (var item in WebSession.OrderItems){%>
    <tr>
        <td>
            <%= Html.Image("/ImageCache/thumbnail3/" + item.Value.ImageSource) %>
        </td>
        <td class="carData">
            <%= item.Value.AdModel %>
            (<%= Html.ResourceString(((CarAdClasses)item.Value.Class) + "Class").ToLower() %>) - <%= item.Value.Quantity %>
        </td>
    </tr>
    <%} %>
</table>