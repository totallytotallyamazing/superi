<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<script type="text/javascript">
    function cityChanged() {
        var currentCity = document.getElementById("currentCity");
        var cityId = currentCity[currentCity.selectedIndex].value;

        var webRequest = Sys.Net.WebServiceProxy.invoke("/Services/Tools.asmx", "GetCityCategories", false, { id: cityId }, citySuccessCallback, failureCallback);
    }

    function citySuccessCallback(response) {
        for (var i in response) { 
            
        }
    }
</script>

<table>
    <tr>
        <td>
            <%= Html.ResourceString("City") %><br />
            <%= Html.DropDownList("currentCity", (List<SelectListItem>)ViewData["citiesList"], new { onchange = "cityChanged()" })%>
        </td>
        <td>
            <%= Html.ResourceString("Category") %><br />
            <%= Html.DropDownList("currentCategory", (List<SelectListItem>)ViewData["categoriesList"]) %>
        </td>
        <% if (Request.Url.Segments.Length==1 && Request.Url.Segments[0] == "/")
           { %>
            <td>
                <input type="button" value="<%= Html.ResourceString("Forward") %>" style="margin-top:14px;" />
            </td>
        <%} %>
    </tr>
</table>
