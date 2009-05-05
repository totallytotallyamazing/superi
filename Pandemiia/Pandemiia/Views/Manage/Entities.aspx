<%@ Page Title="" Language="C#" MasterPageFile="Manage.Master" Inherits="System.Web.Mvc.ViewPage<List<Pandemiia.Models.Entity>>" %>
<%@ Import Namespace="Pandemiia.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Посты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Посты</h2>

    <table>
        <tr>
            <th></th>
            <th>
                №
            </th>
            <th>
                Заголовок
            </th>
            <th>
                Дата
            </th>
            <th>
                Тип
            </th>
            <th>
                Чье
            </th>
        </tr>

    <% foreach (Pandemiia.Models.Entity item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Изменить", "EditEntity", new { id=item.ID }) %> | 
                <%= Html.ActionLink("Удалить", "DeleteEntity", new { id = item.ID })%> | 
                <% 
                    switch(item.EntityType.Name)
                    {
                        case "Видео":
                            Response.Write(Html.PopUpWindowAction("Видео", "Videos", "", item.ID, 400, 500));
                            break;
                        case "Музыка":
                            Response.Write(Html.PopUpWindowAction("Музыка", "Music", "", item.ID, 600, 500));
                            break;
                        case "Изображения":
                            Response.Write(Html.PopUpWindowAction("Изображения", "Images", "", item.ID, 600, 500));
                            break;
                    }
           
                %>
            </td>
            <td>
                <%= Html.Encode(item.ID) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Date)) %>
            </td>
            <td>
                <%= Html.Encode(item.EntityType.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.EntitySource.Name) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Создать", "CreateEntity") %>
    </p>

</asp:Content>

