<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>

<table>
    <tr>
        <td>
            <%= Html.ResourceString("City") %><br />
            <%= Html.DropDownList("currentCity", (List<SelectListItem>)ViewData["citiesList"]) %>
        </td>
        <td>
            <%= Html.ResourceString("Category") %><br />
            <%= Html.DropDownList("currentCategory", (List<SelectListItem>)ViewData["categoriesList"]) %>
        </td>
        <% if (Request.Url.Segments.Length==1 && Request.Url.Segments[0] == "/")
           { %>
            <td>
                <input type="button" value="<%= Html.ResourceString("Forward") %>" />
            </td>
        <%} %>
    </tr>
</table>
