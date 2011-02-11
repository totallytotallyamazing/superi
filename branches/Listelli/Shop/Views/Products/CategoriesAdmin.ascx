<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<p class="adminLink">
<%= Html.ActionLink("Изменить категорию", "AddEdit", "Categories", new { area = "Admin", id= ViewData["categoryId"]}, null) %>&nbsp;/&nbsp;
<%= Html.ActionLink("Удалить категорию", "Delete", "Categories", new { area = "Admin", id = ViewData["categoryId"] }, new { onclick = "return confirm('При удалении категории также удаляются все товары в ней. Вы уверены что хотите удалить категорию?')"})%>&nbsp;/&nbsp;
<%= Html.ActionLink("Атрибуты", "Attributes", "Categories", new { area = "Admin", id = ViewData["categoryId"] }, new { @class = "fancyAdmin iframe"})%>
</p>
<%if(ViewData["showAdminLinks"] != null && (bool)ViewData["showAdminLinks"]){ %>
<p class="adminLink">
    <%= Html.ActionLink("Добавить продукт", "AddEdit", "Products", new { area = "Admin", cId = ViewData["categoryId"], bId=ViewData["brandId"] }, null)%>
</p>
<%} %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js")  %>
    <%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
<script type="text/javascript">
    $(function () {
        $(".fancyAdmin").fancybox({hideOnOverlayClick:false, hideOnContentClick:false});
    })
</script>