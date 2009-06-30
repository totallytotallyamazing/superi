<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Zamov.Models.Group>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%
    int level = Convert.ToInt32(ViewData["level"]);
    string marginLeft = level * 20 + "px";
    int dealerId = Convert.ToInt32(ViewData["dealerId"]);
%>
    <% foreach (var item in Model) {
           item.LoadNames();
    %>
    <table class="adminTable" style="margin-left:<%= marginLeft %>">
        <%if (level == 0 && ViewData["firstDisplayed"]==null){
              ViewData["firstDisplayed"] = true;
              %>
        <tr>
                <th style="display:none">
                    ID
                </th>
                <th>
                    Укр
                </th>
                <th>
                    Рус
                </th>
                <th>
                    <%= Html.ResourceString("ActiveF") %>
                </th>
            <th></th>
            <th></th>
        </tr>
        <%} %>
        <tr>
            <td style="display:none">
                <%= Html.Hidden("itemId_" + item.Id, item.Id)%>
            </td>  
            <td>
                <div style="width:200px;">
                    <%= Html.Encode(item.Name) %>
                </div>
            </td>
            <td>
                <%= Html.TextBox("uk-UA_" + item.Id, item.GetName("uk-UA", false), new { onblur = "tableChanged(changes, this)", style="width:200px;" })%>
            </td>
            <td>
                <%= Html.TextBox("ru-RU_" + item.Id, item.GetName("ru-RU", false), new { onblur = "tableChanged(changes, this)", style = "width:200px;" })%>
            </td>
            <td>
                <a href="#" onclick="insertCategory(this, <%= item.Id %>)">
                    <%= Html.ResourceString("AddSubGroup") %>
                </a>
            </td>
            <td>
                <%= Html.ActionLink(Html.ResourceString("Delete"), "DeleteGroup", new { id = item.Id }, new { onclick = "return confirm('" + Html.ResourceString("AreYouSure") + "?')" })%>
            </td>          
        </tr>
        </table>
                <% 
       if (item.Groups.Count > 0)
           Html.RenderAction<Zamov.Controllers.DealerCabinetController>(a => a.GoupList(dealerId, item.Id, level + 1));
       
       } %>