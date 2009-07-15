<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Ежедневная уборка", "Daily", "Services") %>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Генеральная уборка", "General", "Services") %>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Уборка после строительства", "Building", "Services") %>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("Уборка наружной территории", "Outer", "Services") %>
    </div>
</div>
<div class="leftMenuItem" >
    <div>
        <%= Html.ActionLink("Спецуслуги", "Special", "Services") %>
    </div>
</div>
<script type="text/javascript">

</script>