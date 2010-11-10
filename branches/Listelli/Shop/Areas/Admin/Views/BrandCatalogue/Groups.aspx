<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Areas.BrandCatalog.Models.CatalogueGroup>>" %>
<%@ Import Namespace="Shop.Areas.BrandCatalog.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Groups
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                Название
            </th>
            <th>
                Порядок вывода        
            </th>
            <th></th>
            <th></th>
        </tr>

    <% foreach (var item in Model) {
           using (Html.BeginForm()){%>
        <tr>
            <td>
                <%= Html.Hidden("Id", item.Id) %>
                <%= Html.TextBox("Name", item.Name) %>
            </td>
            <td>
                <%= Html.TextBox("SortOrder", item.SortOrder) %>
            </td>
            <td>
                <input type="submit" value="Сохранить" />
            </td>
            <td>
                <%= Html.ActionLink("Удалить", "DeleteGroup", new { id = item.Id }, new { onclick = "return confirm('Вы уверены?')" }) %>
            </td>
        </tr>
    <% }} %>
    </table>
<%using (Html.BeginForm()){%>
    <div>   
        <label for="Name">
            Название группы:
        </label>
    </div>  
    <div>
        <%= Html.TextBox("Name") %>
    </div>
    <div>   
        <label for="SortOrder">
            Порядок отображения:
        </label>
    </div>  
    <div>
        <%= Html.TextBox("SortOrder")%>
    </div>
    <input type="submit" value="Добавить" />
<%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

