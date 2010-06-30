<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Tag>>" %>

<% using(Html.BeginForm()){ %>
<%=Html.Hidden("id",ViewData["productId"])%>

<%
   var productTagsSelected = (int[])ViewData["productTagsSelected"]; 
foreach (var item in Model){%>
    <div>
        <%= Html.CheckBox("tag_" + item.Id, productTagsSelected.Contains(item.Id))%>  <%= item.Value %>
    </div>
<%} %>

   <input type="submit" value="Сохранить" />
   <%} %>