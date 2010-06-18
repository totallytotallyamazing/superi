<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttribute>>" %>
<% using(Html.BeginForm()){ %>
<% foreach (var item in Model)
   {
       Response.Write("<strong>"+item.Name+"</strong>");
       Html.RenderPartial("ProuctAttributeValue", item.ProductAttributeValue);
   } %>
   <input type="submit" value="Сохранить" />
   <%} %>