<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>

<script type="text/javascript" src="/Scripts/jquery.js"></script>
<script src="/Scripts/jquery.FCKEditor.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function() {
        $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
        $("#text").fck({ toolbar: "Default", height: 400 });
    })
</script>



<% using (Html.BeginForm()){ %>  
    <%= Html.Hidden("contentName") %>
    <%= Html.TextArea("text")%>
    <input type="submit" value="Сохранить" />
<%} %>
