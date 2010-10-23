<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KeyValuePair<Shop.Models.Product, IEnumerable<Shop.Models.ProductAttribute>>>" %>

<table>
<% 
    Func<Shop.Models.ProductAttributeStaticValue, int> getAttributeId = value =>
        {
            return Convert.ToInt32(value.ProductAttributeReference.EntityKey.EntityKeyValues[0]);
        };
    
    Shop.Models.Product product = Model.Key;
    IEnumerable<Shop.Models.ProductAttribute> attributes = Model.Value;
    
    
    
    foreach (var item in attributes.Where(m=>m.Static)){
        string attributeValue  = null;
        var pasv = product.ProductAttributeStaticValues.FirstOrDefault(p=>getAttributeId(p) == item.Id);
        if(pasv != null)
            attributeValue = pasv.Value;
%>
    <tr>
        <td>
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