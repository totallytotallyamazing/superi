<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>

<script type="text/javascript">
    $(function() {
        $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { DefaultLanguage: "ru", AutoDetectLanguage: false, SkinPath: "/Controls/fckeditor/editor/skins/office2003/"} };
        $("#description").fck({ height: 230, width: 700, toolbar: "Basic" });
    });
</script>

<% using(Html.BeginForm("AddEditWork", "Admin", FormMethod.Post, new {enctype="multipart/form-data"})){ %>
    <%= Html.Hidden("id") %>
    <span style="color:Black">Превью:</span> <input type="file" name="preview" /> &nbsp; <span style="color:Black">Изображение:</span> <input type="file" name="image" />
    <br />
    <%= Html.TextArea("description") %>
    <input type="submit" value="Сохранить" />
<%} %>