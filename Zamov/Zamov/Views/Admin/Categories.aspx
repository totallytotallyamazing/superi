<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Category>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.ResourceString("Categories") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <%= Html.RegisterJS("common.js") %>
    <script type="text/javascript">
        var changes = {};
    </script>

    <h2><%= Html.ResourceString("Categories") %></h2>

    <table class="adminTable">
        <tr>
            <th style="display:none;">
                Id
            </th>
            <th></th>
            <th>
                Рус
            </th>
            <th>
                Укр
            </th>
            <th></th>
            
        </tr>

    <% foreach (var item in Model) {
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
            <td>
                <%= Html.ResourceActionLink("Delete", "DeleteCategory", new { id = item.Id })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% using (Html.BeginForm("Categories", "Admin", FormMethod.Post)){ %>
    <%= Html.Hidden("updates") %>
    <input type="submit" value="<%= Html.ResourceString("Save") %>" onclick="return collectChanges(changes, 'updates');" />
    <%} %>

    <% using (Html.BeginForm("InsertCategory", "Admin")){ %>
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
        </tr>
        <tr>
            <td>
                <%= Html.TextBox("categoryName") %>
            </td>
            <td>
                <%= Html.TextBox("categoryUkrName")%>
            </td>
            <td>
                <%= Html.TextBox("categoryRusName")%>
            </td>
        </tr>
    </table>
    <input type="submit" value="<%= Html.ResourceString("Add") %>" />
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

