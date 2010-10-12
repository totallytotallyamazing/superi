<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Category>>" %>

<% using(Html.BeginForm()){ %>
<%=Html.Hidden("id",ViewData["ProductId"])%>

<%
    var productCategoriesSelected = (int[])ViewData["productCategoriesSelected"]; 
foreach (var item in Model){%>
    <div>
        <%= Html.CheckBox("category_" + (int)item.Id, productCategoriesSelected.Contains((int)(object)item.Id))%>  <%= item.Name %>
    </div>
<%} %>

   <input type="submit" value="Сохранить" />
   <%} %>