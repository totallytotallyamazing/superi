<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PolialClean.Models.Clients>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="PolialClean.Models" %>
<%@ Import Namespace="PolialClean.Controllers" %>
<table>
    <tr>
        <td>
            <%= Html.Image("~/Content/Logos/" + Model.Logo) %>
        </td>
        <td valign="middle" class="clientName">
            <%= Html.Encode(Model.Name) %>
        </td>
        <%if(Request.IsAuthenticated){ %>
            <td style="padding-left:5px;">
                <%= Html.ActionLink("Редактировать", "AddUpdateClient", "Admin", new {id = Model.Id}, new { @class="adminLink fancy" }) %><br />
                <%= Html.ActionLink("Удалить", "DeleteClient", "Admin", new {id = Model.Id}, new { @class="adminLink", onclick="return confirm('Вы уверены?');" }) %>
            </td>
        <%} %>
    </tr>
</table>
<div class="clientRecomendations">
    <%if(Request.IsAuthenticated){ %>
        <%= Html.ActionLink("Добавить отзыв", "AddRecomendation", "Admin", new {id = Model.Id}, new { @class="adminLink fancy" }) %><br />
    <%} %>
    <% 
        int i = 1;
        foreach (Recomendations item in Model.Recomendations)
        {
            Html.RenderAction<ClientsController>(cc => cc.Recomendation(item, Model.Recomendations.Count, i));
            i++;
        }
    %>
</div>
<div class="clientObjects">
    фотографии объекта:<br />
    <%if(Request.IsAuthenticated){ %>
        <%= Html.ActionLink("Добавить объект", "AddObject", "Admin", new {id = Model.Id}, new { @class="adminLink fancy" }) %><br />
    <%} %>
    <% 
        foreach (Objects item in Model.Objects)
        {
            Html.RenderAction<ClientsController>(cc => cc.Object(item));
        }
    %>
</div>

