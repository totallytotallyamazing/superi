<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Designer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Портфолио дизайнеров
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2>Портфолио дизайнеров</h2>
    <table>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%=Html.ActionLink(item.Url, "EditDesignersUrl", "Designers", new { area = "Admin", id = item.Id }, new { @class = "adminDesignerLink" })%>
            </td>
            <td>
                <%=Html.ActionLink(item.Name, "Index", "Designers", new { area = "", id = item.Url }, new{@class="adminDesignerLink"})%>
            </td>
            <td>
                <%= Html.ActionLink("Редактировать", "AddEdit", new { id = item.Id }, null)%> |
                <%= Html.ActionLink("Список помещений", "Rooms", new { id = item.Id }, null)%> |
                <%= Html.ActionLink("Удалить", "Delete", new { id = item.Id }, new { onclick = "return confirm('При удалении пользователя, удаляются также все с ним связанные работы. Вы уверены что хотите удалить пользователя?')" })%>
            </td>
            
        </tr>
    
    <% } %>

    </table>

    <%if (Roles.IsUserInRole(User.Identity.Name, "Administrators"))
      { %>
    <p>
      <%:Html.ActionLink("Создать", "AddEdit")%>  
    </p>  
    <% }else if (ViewData["Url"] != null && Model.Count() == 0)
      { %>
      <p>
      <%:Html.ActionLink("Создать", "AddEdit", new { url = ViewData["Url"] })%>
      </p>
     
    <% }%>
    <p>
      <%:Html.ActionLink("Выйти из режима администрирования", "LogOff", "Account", new { area=""},null)%>
      </p>
    
   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

