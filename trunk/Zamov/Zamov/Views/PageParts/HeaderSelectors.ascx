<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<script type="text/javascript">

    $(function() { cityChanged(); });
    function cityChanged() {
        var currentCity = document.getElementById("currentCity");
        var cityId = currentCity[currentCity.selectedIndex].value;

        var webRequest = Sys.Net.WebServiceProxy.invoke(
            "/Services/Tools.asmx",
            "GetCityCategories",
            false,
            { id: cityId },
            function(response) {
                var currentCategory = $get("currentCategory");
                currentCategory.options.length = 0;
                var firsOption = document.createElement("option");
                firsOption.value = -1;
                firsOption.text = '--<%= Html.ResourceString("SelectCategory") %>--';
                try {
                    currentCategory.add(firsOption, null);
                }
                catch (ex) {
                    currentCategory.add(firsOption);
                }
                for (var i in response) {
                    var option = document.createElement("option");
                    option.text = response[i].Text;
                    option.value = response[i].Value;
                    option.selected = response[i].Selected;
                    try {
                        currentCategory.add(option, null);
                    }
                    catch (ex) {
                        currentCategory.add(option);
                    }
                }
            },
            failureCallback);
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
                <input type="submit" value="<%= Html.ResourceString("Forward") %>" style="margin-top:14px;" />
            </td>
        <%} %>
    </tr>
</table>
