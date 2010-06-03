<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Lady.Models.ProductAttribute>>" %>
<%  using (Html.BeginForm())
    {
        int[] attributesSelected = (int[])ViewData["attributesSelected"];
        foreach (var item in Model)
        {%>
            <%= Html.Hidden("id") %>
            <%= Html.CheckBox("attribute_" + item.Id, attributesSelected.Contains(item.Id))%> <%= item.Name %>
      <%}%>
      <input type="submit" value="Сохранить" />
  <%} %>