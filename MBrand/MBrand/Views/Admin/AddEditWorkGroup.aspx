<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MBrand.Models.WorkGroup>" %>

<script type="text/javascript" src="/Scripts/jquery.ui.js"></script>
<script type="text/javascript" src="/Scripts/ui.datepicker-ru.js"></script>

<script type="text/javascript">
    $(function() {
        $.datepicker.setDefaults($.extend({ showMonthAfterYear: false }, $.datepicker.regional['']));
        $("#date").datepicker($.datepicker.regional["ru"]);
        $("#date").datepicker();
        $("#date").attr("readonly", "readonly");
    });
</script>

<% using (Html.BeginForm("AddEditWorkGroup", "Admin", FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
<%= Html.Hidden("workType") %>
<%= Html.Hidden("id") %>
<table class="adminTable">
    <tr>
        <td style="width:60px;">
            Название
        </td>
        <td style="width:330px;">
            <%= Html.TextBox("name") %>
        </td>
    </tr>
    <tr>
        <td>
            Дата
        </td>
        <td>
            <%= Html.TextBox("date") %>
        </td>
    </tr>
    <tr>
        <td>
            Превью
        </td>
        <td>
            <input type="file" name="preview" />
        </td>
    </tr>
    <tr>
        <td>
            Описание
        </td>
        <td>
            <%= Html.TextArea("description")%>
        </td>
    </tr>
    <tr>
        <td></td>
        <td><input type="submit" value="Сохранить" /></td>
    </tr>
</table>

<% Html.RenderPartial("SeoEditor"); %>
<%} %>