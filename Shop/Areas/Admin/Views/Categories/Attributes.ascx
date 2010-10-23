<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttribute>>" %>
<%  using (Html.BeginForm())
    {
        int[] attributesSelected = (int[])ViewData["attributesSelected"];
        foreach (var item in Model)
        {%>
            <span style="white-space:nowrap">
                <%= Html.Hidden("id") %>
                <%= Html.CheckBox("attribute_" + item.Id, attributesSelected.Contains(item.Id))%> <%= item.Name %>
            </span>
      <%}%>
      <div>
        <input type="submit" value="Сохранить" />
      </div>
  <%} %>