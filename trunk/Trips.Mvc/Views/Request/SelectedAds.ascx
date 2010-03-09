<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Trips.Mvc.Controllers" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<h3>
    <%= Html.ResourceString("Car")%>:
</h3>
<br />
<table class="selectedAds" cellpadding="5" cellspacing="15">
    <tr>
        <th>
        </th>
        <th>
        </th>
        <th class="quantity">
            <%= Html.ResourceString("NumberOfCars")%>
        </th>
        <th>
            <%= Html.ResourceString("Delete") %>
        </th>
    </tr>
    <% foreach (var item in WebSession.OrderItems){%>
    <tr>
        <td>
            <%= Html.Image("/ImageCache/thumbnail3/" + item.Value.ImageSource) %>
        </td>
        <td class="carData">
            <%= Html.ActionLink(item.Value.AdModel, "Details", "Catalogue", new { id = item.Value.CarId }, null) %><br />
            <span class="adClass">
                <%= Html.ResourceString(((CarAdClasses)item.Value.Class) + "Class") %>
            </span>
        </td>
        <td>
            <%= Html.TextBox("quantity_" + item.Key, item.Value.Quantity) %>
        </td>
        <td>
            <%= Html.ActionLink("[IMAGE]", "DeleteOrderItem", new { id = item.Key })
                                .Replace("[IMAGE]", Html.Image("/Content/img/delete.jpg"))%>
        </td>
    </tr>
    <%} %>
</table>
