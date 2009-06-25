<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Zamov.Models.Group>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%
    int level = Convert.ToInt32(ViewData["level"]);
    string marginLeft = level * 20 + "px";
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
        </tr>
        </table>
                <% 
       if (item.Groups.Count > 0)
           Html.RenderAction<Zamov.Controllers.DealerCabinetController>(a => a.GoupList(dealerId, item.Id, level + 1));
       
       } %>