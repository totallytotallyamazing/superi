<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>

<script type="text/javascript">
    $(function() {
        $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { DefaultLanguage: "ru", AutoDetectLanguage: false, SkinPath: "/Controls/fckeditor/editor/skins/office2003/"} };
        $("#description").fck({ height: 100, width: 700, toolbar: "Basic" });
        $("#text").fck({ height: 400, width: 700, toolbar: "Default" });
    })
</script>

<div style="padding: 20px;" class="addEditNote">
    <%using (Html.BeginForm()){ %>
        <%= Html.TextBox("title")%><br />
        <%= Html.TextBox("date")%>
        Привью:
        <br />
        <input name="image" type="file" />
        <%= Html.TextArea("description")%>
        <%= Html.TextArea("text")%>
        <input type="submit" value="Сохранить" />
    <%} %>
</div>
