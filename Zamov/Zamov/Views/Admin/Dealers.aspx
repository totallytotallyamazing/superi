<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Dealer>>" %>

<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Dealers") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.ResourceString("Dealers") %></h2>
    <table class="adminTable">
        <tr>
            <th>
                ID
            </th>
            <th>
                <%= Html.ResourceString("Name") %>
            </th>
            <th>
            </th>
            <th></th>
            <th></th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.GetName(ToolsController.CurrentLanguage)) %>
            </td>
            <td>
                <% 
                    if (!item.Enabled)
                        Response.Write(Html.ResourceActionLink("On", "EnableDealer", new { id=item.Id }));
                    else
                        Response.Write(Html.ResourceActionLink("Off", "DisableDealer", new { id = item.Id }));
                %>
            </td>
            <td>
                <%= Html.ResourceActionLink("Edit", "AddUpdateDealer", new { id=item.Id }) %>
            </td>
            <td>
                <%= Html.ResourceActionLink("Delete", "DeleteDealer", new { id = item.Id })%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ResourceActionLink("CreateDealer", "AddUpdateDealer", new { id = int.MinValue })%>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>
