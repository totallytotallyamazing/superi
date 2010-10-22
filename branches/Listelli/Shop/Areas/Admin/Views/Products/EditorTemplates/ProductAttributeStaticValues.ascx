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
<%if(item.ValueType == "TEXT"){%>      
            <%= Html.TextBox("pa_" + item.Id, attributeValue) %>
        </td>
    </tr>
<%} %>
</table>