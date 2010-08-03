<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>

 <%= Model.First().ProductAttribute.Name %>: <%= Html.DropDownList("attr_" + Model.First().ProductAttribute.Id, new SelectList(Model, "Id", "Value"))%>
