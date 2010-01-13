<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
<script type="text/javascript">

    function ajaxValidate() {
        return $("#feedback").validate({
            errorPlacement: function(error, element) {
                if (element[0].id == "captchaBox") {
                    error.appendTo($("#captchaLabel"));
                }
                else if (element[0].id == "message") {
                error.appendTo(element.parent().parent().children().eq(0));
                }
                else {
                    error.appendTo(element.parent().next());
                }
            },
            rules: {
                email: { required: true, email: true }
            },
            messages: {
                "name": "*",
                email: { required: "*", email: '<%= Html.ResourceString("InvalidEmail")%>' },
                "message": "*",
                "captchaBox": "*"
            }
        }).form();
    }


    function dialogOk() {
        $(this).dialog("close");
        location.href = location.href;
    }

    function messageSent(response) {
        var result = response.get_response().get_object();
        if (!result) {
            $("#captchaInvalid").dialog("open");
        }
        else {
            $("#messageSentOk").dialog("open");
        }
    }
</script>
<%= Ajax.DynamicCssInclude("/Content/feedback.css")%>
<%= Ajax.UiScriptInclude("pepper-grinder")%>

<div title="<%= Html.ResourceString("Error") %>" id="captchaInvalid">
    <%= Html.ResourceString("CaptchaInvalid")%>
</div>
<%= Ajax.Dialog("#captchaInvalid", new { autoOpen = false, modal = true, draggable = false, resizable = false }, new Dictionary<string, string> { { "Ok", "dialogOk" } })%>

<div title="<%= Html.ResourceString("Elena") %>" id="messageSentOk">
    <%= Html.ResourceString("MessageSent")%>
</div>
<%= Ajax.Dialog("#messageSentOk", 
    new { 
        autoOpen = false, 
        modal = true, 
        draggable = false, 
        resizable = false 
    },
    new Dictionary<string, string> { { "Ok", "dialogOk" } })%>

<%= Ajax.IncludeMvcAjax("/Scripts") %>
<% using (Ajax.BeginForm("SendMail", "Tools", null, new AjaxOptions { HttpMethod = "POST", OnSuccess = "messageSent", OnBegin="ajaxValidate" }, new { id = "feedback" }))
   { %>
<div id="feedbackForm">
<table>
    <tr>
        <td class="label">
            <%= Html.ResourceString("YourName")%>:
        </td>
        <td>
            <%= Html.TextBox("name", null, new { @class = "required" })%>    
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="label">
            <%= Html.ResourceString("Email")%>:    
        </td>
        <td>
            <%= Html.TextBox("email", null, new { @class = "required" })%>    
        </td>
        <td></td>
    </tr>    
</table>

<div>
    <div class="label">
        <%= Html.ResourceString("YouWhantToSay")%>:
    </div>
    <div>
        <%= Html.TextArea("message", null, new { style="width:400px; height:200px;", @class = "required" })%>
    </div>
</div>
<div>
    <div id="captchaLabel" class="label">
        <%= Html.ResourceString("EnterCaptcha")%>:
    </div>
    <table>
        <tr>
            <td>
                <%= Html.CaptchaImage(50, 160)%>
            </td>
            <td>
                <%= Html.TextBox("captchaBox", null, new { @class = "required" })%>
            </td>
        </tr>
    </table>
</div>
<div>
    <input value="<%= Html.ResourceString("Send") %>" type="submit" />
</div>
</div>
<%} %>