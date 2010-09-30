<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Content>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<%= Ajax.ScriptInclude("/Scripts/jquery.js")%>
<%= Ajax.ScriptInclude("/Scripts/jquery.FCKEditor.js")%>


<script type="text/javascript">
    $(function () {
        $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
        $("#Text").fck({ toolbar: "Common", height: 400 });
    })
</script>

<% using (Html.BeginForm())
   { %>
    <%: Html.TextAreaFor(model=>model.Text) %>
    <%: Html.HiddenFor(model=>model.Name) %>
    <input type="submit" value="Сохранить" />
<%} %>