<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Helpers" %>
<script type="text/javascript">
    function feedbackResponse(response) {
        var result = response.get_response().get_object();
        if (result) {

        }
        else {
            alert("wrong captcha");
        }
    }
</script>
<div id="createFeedback">
<% using (Ajax.BeginForm("CreateFeedback", "Feedback", new AjaxOptions { HttpMethod = "POST", OnBegin = "fadeScreenOut", OnComplete="fadeScreenIn", OnSuccess="feedbackResponse" })){ %>
    <%= Html.TextArea("text", new{@class="feedbackTextInput"}) %>
    <br />
    <%= Html.CaptchaImage(50, 100) %>
    <br />
    <%= Html.TextBox("captcha") %>
<%} %>
</div>