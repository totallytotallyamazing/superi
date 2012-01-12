<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Content>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Shop.Models" %>

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

<% 
    ContentStorage context = (ContentStorage)ViewData["context"];
    using (Html.BeginForm())
   { %>
    <%: Html.LocalizedTextAreaFor(m => m.Text, context.ContentLocalResource) %>
    
    <%: Html.HiddenFor(model=>model.Name) %>
    <input type="submit" value="Сохранить" />
<%} %>