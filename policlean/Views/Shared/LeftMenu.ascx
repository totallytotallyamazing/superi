<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("���������� ������", "Index", "Services", new { contentName = "���������� ������" }, null)%>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("����������� ������", "Index", "Services", new { contentName = "����������� ������" }, null)%>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("������ ����� �������������", "Index", "Services", new { contentName = "������ ����� �������������" }, null)%>
    </div>
</div>
<div class="leftMenuItem">
    <div>
        <%= Html.ActionLink("������ �������� ����������", "Index", "Services", new { contentName = "������ �������� ����������" }, null)%>
    </div>
</div>
<div class="leftMenuItem" >
    <div>
        <%= Html.ActionLink("������������ �������", "Index", "Services", new { contentName = "������������ �������" }, null)%>
    </div>
</div>
<div class="leftMenuItem" >
    <div>
        <%= Html.ActionLink("����������", "Index", "Services", new { contentName = "����������" }, null)%>
    </div>
</div>
<script type="text/javascript">

</script>