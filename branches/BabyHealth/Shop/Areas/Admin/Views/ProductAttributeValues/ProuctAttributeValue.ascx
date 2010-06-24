<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>
<% foreach (var item in Model)
   {%>
    <div>
    <%
       bool _checked = false;
       string[] x = item.Value.Split(new string[]{"_"}, StringSplitOptions.None);
       item.Value = x[0];
       _checked = x.Length > 1 && x[1] == "Checked";
       
%>
     <%= Html.CheckBox("attr_" + item.Id, _checked)%>  <%= item.Value %>
     </div>
   <%} %>