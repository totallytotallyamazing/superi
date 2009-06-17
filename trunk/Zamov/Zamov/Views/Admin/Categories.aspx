<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Category>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Categories
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Categories</h2>

    <table>
        <tr>
            <th>
                Id
            </th>
            <th>
                Рус
            </th>
            <th>
                Укр
            </th>
            <th></th>
            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.ResourceActionLink("Dealers", "CategoryDealerMappings", new { id=item.Id })%>
            </td>
            <td>
                <%= Html.ResourceActionLink("Delete", "DeleteCategory", new { id=item.Id })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ResourceActionLink("CreateCategory", "CreateCategory")%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

