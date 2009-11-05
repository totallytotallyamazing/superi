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
            <span>|</span> <%= Html.Encode(Model.Name) %>
        </td>
        <%if(Request.IsAuthenticated){ %>
            <td style="padding-left:5px;">
                <%= Html.ActionLink("�������������", "AddUpdateClient", "Admin", new {id = Model.Id}, new { @class="adminLink fancy" }) %><br />
                <%= Html.ActionLink("�������", "DeleteClient", "Admin", new {id = Model.Id}, new { @class="adminLink", onclick="return confirm('�� �������?');" }) %>
            </td>
        <%} %>
    </tr>
</table>
<div class="clientMedia">
    <div class="clientObjects">
        <%if (Model.Objects.Count>0){ %>
            ���������� �������:<br />
        <%} %>
        <%if(Request.IsAuthenticated){ %>
            <%if(Model.Objects.Count + Model.Recomendations.Count >=4 ){ %>
                <%= Html.ActionLink("�������� ������", "TooManyObjects", "Admin", null, new { @class = "adminLink fancy" })%><br />
            <%} %>
            <%else{ %>
                <%= Html.ActionLink("�������� ������", "AddObject", "Admin", new {id = Model.Id}, new { @class="adminLink fancy" }) %>&nbsp;&nbsp;<br />
            <%} %>
            
        <%} %>
        <% 
            foreach (Objects item in Model.Objects)
            {
                Html.RenderAction<ClientsController>(cc => cc.Object(item));
            }
        %>
    </div>
    <% if(Model.Recomendations.Count>0 && Model.Objects.Count>0){ %>
        <div class="objectRecomendationSeparator"></div>
    <%} %>
    <div class="clientRecomendations">
        <%if(Request.IsAuthenticated){ %>
            <%if(Model.Objects.Count + Model.Recomendations.Count >=4 ){ %>
                <%= Html.ActionLink("�������� �����", "TooManyObjects", "Admin", null, new { @class = "adminLink fancy" })%><br />
            <%} %>
            <%else{ %>
                <%= Html.ActionLink("�������� �����", "AddRecomendation", "Admin", new {id = Model.Id}, new { @class="adminLink fancy" }) %><br />
            <%} %>
        <%} %>
        
        <%if (Model.Recomendations.Count>0){ %>
            ������:<br />
        <%} %>
        
        <% 
            foreach (Recomendations item in Model.Recomendations)
            {
                Html.RenderAction<ClientsController>(cc => cc.Recomendation(item));
            }
        %>
    </div>

    <div style="clear:both;">
    
    </div>
</div>


