<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<p class="adminLink">
<%= Html.ActionLink("Изменить категорию", "AddEdit", "Categories", new { area = "Admin", id= ViewData["categoryId"]}, null) %>&nbsp;/&nbsp;
<%= Html.ActionLink("Удалить категорию", "Delete", "Categories", new { area = "Admin", id= ViewData["categoryId"]}, null) %>&nbsp;/&nbsp;
<%= Html.ActionLink("Свойства товаров в этой категории", "Attributes", "Categories", new { area = "Admin", id = ViewData["categoryId"] }, new { @class = "fancyAdmin iframe"})%>
</p>
<p class="adminLink">
    <%= Html.ActionLink("Добавить продукт", "AddEdit", "Products", new { area = "Admin", cId = ViewData["categoryId"], bId=ViewData["brandId"] }, null)%>
</p>
<script type="text/javascript">
    $(function() {
        $(".fancyAdmin").fancybox({modal:true});
    })
</script>