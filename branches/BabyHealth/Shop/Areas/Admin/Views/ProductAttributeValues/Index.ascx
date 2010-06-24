<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttribute>>" %>
<% using(Html.BeginForm()){ %>
<%=Html.Hidden("productId",ViewData["productId"])%>
<%=Html.Hidden("cId",ViewData["cId"])%>
<% foreach (var item in Model)
   {
       %>
       <div>
       <strong><%=item.Name%></strong>
       <%
           Html.RenderPartial("ProuctAttributeValue", item.ProductAttributeValue);
       %>
       </div>
       <%
   } %>
   <input type="submit" value="Сохранить" />
   <%} %>