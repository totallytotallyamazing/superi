<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.BrandCatalogCategory>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Брендовые каталоги
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Брендовые каталоги</h2>

    <table class="brandCatCategoryTable">
    <% foreach (var item in Model) { %>
        <tr>
        <td class="sep">
        
        </td>
        </tr>
        <tr>
            <td class="title">
            
                <%: item.Title %>
            </td>
            <td>
                <%: Html.ActionLink("Удалить", "DeleteCatalog", new { id = item.Id }, new { onclick = "return confirm('При удалении каталога, удаляются также все с ним связанные файлы. Вы уверены что хотите удалить каталог?')" })%>
            </td>
        </tr>
        <tr>
        <td colspan="2">
            <%Html.RenderPartial("BrandCatalogFiles", item); %>
            
        </td>
        </tr>
        
    <% } %>

    </table>

    <p class="addItem" style="border:1px solid #ccc; padding:5px;">
        <%using (Html.BeginForm("CreateNewCatalog", "Catalogs", FormMethod.Post))
          { %>
          Добавить новый раздел:<br />
          Заголовок:<%=Html.TextBox("Title")%><br />
          <input type="submit" value="Добавить" />
        <%} %>
    </p>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

