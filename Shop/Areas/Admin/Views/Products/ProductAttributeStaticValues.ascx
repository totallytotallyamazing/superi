<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KeyValuePair<Shop.Models.Product, IEnumerable<Shop.Models.ProductAttribute>>>" %>
<%@ Import Namespace="Shop.Models" %>
<table>
<% 
    Product product = Model.Key;
    IEnumerable<ProductAttribute> attributes = Model.Value;
    
    foreach (var item in attributes.Where(m=>m.Static)){
        string attributeValue  = null;
        if (product != null)
        {
            var pasv = product.ProductAttributeStaticValues.FirstOrDefault(p => p.ProductAttributeReference.GetReferenceId() == item.Id);
            if (pasv != null)
                attributeValue = pasv.Value;
        }
%>
    <tr>
        <td class="labelCell">
            <%= item.Name %>
        </td>
        <td>
<%switch(item.ValueType){
      case "TEXT":
          %><%= Html.TextBox("pa_" + item.Id, attributeValue)%><%
          break;
      case "DROPDOWN":
          %><%= Html.DropDownList("pa_" + item.Id, new SelectList(item.ProductAttributeValues.OrderBy(pav => pav.SortOrder), "Value", "Value"), attributeValue)%><%
          break;
} %>
        </td>
    </tr>
<%} %>
</table>