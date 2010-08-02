<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttribute>>" %>
    <% using(Html.BeginForm()){ %>
<%=Html.Hidden("productId",ViewData["productId"])%>
<%=Html.Hidden("categoryId", ViewData["categoryId"])%>
<% foreach (var item in Model)
   {
       %>
       <div class="productAttributeValue">
           <strong><%=item.Name%></strong>
           <%if(!item.Static)
               Html.RenderPartial("DynamicValue", item.ProductAttributeValue);
             else
               Html.RenderPartial("StaticValue", item.ProductAttributeValue);
           %>
       </div>
       <%
   } %>
   <input type="submit" value="Сохранить" />
   <%} %>