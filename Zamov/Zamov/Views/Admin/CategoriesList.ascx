<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Zamov.Models.Category>>" %>
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
            <th style="display:none;">
                Id
            </th>
            <th></th>
            <th>
                Рус
            </th>
            <th>
                Укр
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
                    <%= Html.ResourceString("AddSubCategory") %>
                </a>
            </td>
            <td>
                <%= Html.ActionLink(Html.ResourceString("Delete"), "DeleteCategory", new { id = item.Id }, new { onclick = "return confirm('" + Html.ResourceString("AreYouSure") + "?')" })%>
            </td>
        </tr>
    


    </table>
    
        <% 
       if (item.Categories.Count > 0)
           Html.RenderAction<Zamov.Controllers.AdminController>(a => a.CategoriesList(item.Id, level + 1));
       
       } %>

