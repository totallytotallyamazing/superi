<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("���������� ������", "Daily", "Services") %>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("����������� ������", "General", "Services") %>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("������ ����� �������������", "Building", "Services") %>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("������ �������� ����������", "Outer", "Services") %>
    </div>
</div>
<div class="leftMenuItem" >
    <div>
        <%= Html.ActionLink("����������", "Special", "Services") %>
    </div>
</div>
<script type="text/javascript">

</script>