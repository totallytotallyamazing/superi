<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.DesignerRoom>>" %>
<div style="margin-left:250px;">
<table>
<tr>
<%  using (Html.BeginForm())
    {
        int[] attributesSelected = (int[])ViewData["roomsSelected"];
      
        
          %>
          <td>
          <%
        
        foreach (var item in Model.Where(r=>r.Type==0))
        {%>
            <span style="white-space:nowrap">
                <%= Html.Hidden("id") %>
                <%= Html.CheckBox("room_" + item.Id, attributesSelected.Contains(item.Id))%> <%= item.Name %>
            </span>
            <br />
      <%}%>
      </td>

      <td>
          <%
        
              foreach (var item in Model.Where(r => r.Type == 1))
        {%>
            <span style="white-space:nowrap">
                <%= Html.Hidden("id") %>
                <%= Html.CheckBox("room_" + item.Id, attributesSelected.Contains(item.Id))%> <%= item.Name %>
            </span>
            <br />
      <%}%>
      </td>

  </tr>
</table>

      <div>
        <input type="submit" value="Сохранить" />
      </div>
  <%} %>
  </div>

