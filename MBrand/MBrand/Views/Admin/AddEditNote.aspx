<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AjaxControlToolkitMvc" %>

<script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
<script type="text/javascript" src="/Scripts/jquery.ui.js"></script>
<script type="text/javascript" src="/Scripts/ui.datepicker-ru.js"></script>

<script type="text/javascript">
    $(function() {
        $.datepicker.setDefaults($.extend({ showMonthAfterYear: false }, $.datepicker.regional['']));
        $("#date").datepicker($.datepicker.regional["ru"]);
        $("#date").datepicker();
        $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { DefaultLanguage: "ru", AutoDetectLanguage: false, SkinPath: "/Controls/fckeditor/editor/skins/office2003/"} };
        $("#description").fck({ height: 100, width: 700, toolbar: "Basic" });
        $("#text").fck({ height: 400, width: 700, toolbar: "Default" });
    });

    function imageDeleted() {
        $("#imageCell").html("");
    }
</script>

<div style="padding: 20px;" class="addEditNote">
    <%using (Html.BeginForm("AddEditNote", "Admin", FormMethod.Post, new { enctype="multipart/form-data"}))
      { %>
        <%= Html.Hidden("id") %>
        <table>
            <tr>
                <td>
                    <%= Html.TextBox("title")%><br />
                    <%= Ajax.TextBoxWatermark("title", "Заголовок", "watermark")%>
                    <%= Html.TextBox("date")%><br />
                    <%= Ajax.TextBoxWatermark("date", "Дата", "watermark")%>
                    <span style="color:Black">Превью:</span>
                    <input name="image" type="file" />
                </td>
                <td id="imageCell">
                    <%= ViewData["imageLayout"] %>
                    <%if (ViewData["imageLayout"] != null)
                      { %>
<%--                        <br />
                        <%= Ajax.ActionLink("Удалить картинку", "DeleteNoteImage", "Admin", new AjaxOptions{ LoadingElementId = "shader", OnSuccess="imageDeleted"}) %>--%>
                    <%} %>
                </td>
            </tr>
        </table>
        <%= Html.TextArea("description")%>
        <%= Html.TextArea("text")%>
        <input type="submit" value="Сохранить" />
    <%} %>
</div>
