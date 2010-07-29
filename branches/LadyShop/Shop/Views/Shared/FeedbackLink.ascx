<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
<%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js")%>
    <script type="text/javascript">
        $(function() {
            $("#feedbackForm").fancybox(
            {
                hideOnContentClick: false,
                hideOnOverlayClick: false,
                showCloseButton: true
            });
        });
    </script>
<div id="write">
    <p>
        <%= Html.ActionLink("Напишите нам", "FeedbackForm", new { area = "", controller = "home" }, new { id = "feedbackForm", @class = "iframe" })%>  
    </p>
</div>