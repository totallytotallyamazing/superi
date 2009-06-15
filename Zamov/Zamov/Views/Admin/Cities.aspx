    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Zamov.Models.City>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.ResourceString("Cities") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <%= Html.RegisterJS("common.js") %>
    <script type="text/javascript">
        var changes = {};
        var enables = {};
        function updateEnables(check, id) {
            if (check.checked) {
                enables[id] = true;
            }
            else {
                enables[id] = false;
            }
        }

        function collectCityChanges() {
            collectChanges(changes, 'updates');
            var enablities = $get("enablities");
            enablities.value = Sys.Serialization.JavaScriptSerializer.serialize(enables);
            return true;
        }
    </script>
    <h2><%= Html.ResourceString("Cities") %></h2>

    
    <table class="adminTable" style="border:1px dotted #ccc" >
        <tr>
            <th style="display:none">
                Id
            </th>
            <th></th>
            <th>
                Укр
            </th>
            <th>
                Рус
            </th>
            <th>
                Показывать
            </th>
            <th></th>
        </tr>
    <% foreach (var item in Model)
       {
           item.LoadNames();
            %>
    
        <tr>
            <td style="display:none">
                <%= Html.Hidden("itemId_" + item.Id, item.Id)%>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.TextBox("uk-UA_" + item.Id, item.GetName("uk-UA", false), new { onblur = "tableChanged(changes, this)" })%>
            </td>
            <td>
                <%= Html.TextBox("ru-RU_" + item.Id, item.GetName("ru-RU", false), new { onblur = "tableChanged(changes, this)" })%>
            </td>
            <td align="center">
                <%= Html.CheckBox("enabled_" + item.Id, item.Enabled, new { onclick = "updateEnables(this, " + item.Id + ")" })%>
            </td>
            <td>
                <%= Html.ResourceActionLink("Delete", "DeleteCity", new { id = item.Id })%>
            </td>
        </tr>
        
    <% } %>

    </table>
    
    <% using (Html.BeginForm("UpdateCities", "Admin")){ %>
    <%= Html.Hidden("updates") %>
    <%= Html.Hidden("enablities") %>
    <input type="submit" value="<%= Html.ResourceString("Save") %>" onclick="return collectCityChanges()" />
    <%} %>
    
    <% using (Html.BeginForm("InsertCity", "Admin")){ %>
    <table class="adminTable">
        <tr>
            <th>
                ID
            </th>
            <th>
                Укр
            </th>
            <th>
                Рус
            </th>
            <th>
                Показывать
            </th>
        </tr>
        <tr>
            <td>
                <%= Html.TextBox("cityName") %>
            </td>
            <td>
                <%= Html.TextBox("cityUkrName") %>
            </td>
            <td>
                <%= Html.TextBox("cityRusName") %>
            </td>
            <td align="center">
                <%= Html.CheckBox("cityEnabled", true) %>
            </td>
        </tr>
    </table>
    <input type="submit" value="<%= Html.ResourceString("Add") %>" />
    <%} %>
    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

