<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Content>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<%= Ajax.ScriptInclude("/Scripts/jquery.js")%>
<%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
<%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>

<script type="text/javascript">
    $(function () {
        //$("#Text").ckeditor(null, {toolbar: "Media"})
        CKEDITOR.replace("Text", { toolbar: "Media" });
        CKEDITOR.on("instanceReady", function (e) {
            
        })
    })
</script>

<% using (Html.BeginForm())
   { %>
    <%: Html.TextAreaFor(model=>model.Text) %>
    
    <%: Html.HiddenFor(model=>model.Name) %>
    <input type="submit" value="Сохранить" />
<%} %>