<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.DesignerRoom>>" %>
<div style="margin-left:250px;">
<%  using (Html.BeginForm())
    {
        int[] attributesSelected = (int[])ViewData["roomsSelected"];
        foreach (var item in Model)
        {%>
            <span style="white-space:nowrap">
                <%= Html.Hidden("id") %>
                <%= Html.CheckBox("room_" + item.Id, attributesSelected.Contains(item.Id))%> <%= item.Name %>
            </span>
            <br />
      <%}%>
      <div>
        <input type="submit" value="Сохранить" />
      </div>
  <%} %>
  </div>

