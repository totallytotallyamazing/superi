<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Ежедневная уборка", "Index", "Services", new { contentName = "Ежедневная уборка" }, null)%>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Генеральная уборка", "Index", "Services", new { contentName = "Генеральная уборка" }, null)%>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Уборка после строительства", "Index", "Services", new { contentName = "Уборка после строительства" }, null)%>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Уборка наружной территории", "Index", "Services", new { contentName = "Уборка наружной территории" }, null)%>
    </div>
</div>
<div class="leftMenuItem" >
    <div>
        <%= Html.ActionLink("Промышленный клининг", "Index", "Services", new { contentName = "Промышленный клининг" }, null)%>
    </div>
</div>
<div class="leftMenuItem" >
    <div>
        <%= Html.ActionLink("Спецуслуги", "Index", "Services", new { contentName = "Спецуслуги" }, null)%>
    </div>
</div>
<script type="text/javascript">

</script>