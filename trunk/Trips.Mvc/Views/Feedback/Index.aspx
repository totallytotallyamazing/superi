<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Feedback") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentBoxStep1">
        <% using (Ajax.BeginForm("SendMessage", "Feedback", null, new AjaxOptions { OnSuccess="formSubmitted", OnFailure="captchaInvalid" }, new { id = "feedback" }))
           { %>
        <br />
        <h2>
            <%= Html.ResourceString("WriteToUs")%>:
        </h2>
        <br />
        <br />
        <h3>
            <label for="yourName">
                <%= Html.ResourceString("YourName")%>:
            </label>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextBox("name")%>
        </div>
        <h3>
            <label for="phone">
                <%= Html.ResourceString("Email")%>:
            </label>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextBox("email")%>
            <div class="errorHolder" id="emailErrorHolder">
            </div>
        </div>
        <h3>
            <label for="email">
                <%= Html.ResourceString("YourMessage")%>:
            </label>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextArea("message", null, 10, 5, null)%>
        </div>
        <h3>
            <%= Html.ResourceString("EnterCaptcha")%>:
        </h3>
        <div class="captchaBox">
            <div style="width:160px; position:relative; margin:0 auto;">
                <%= Html.CaptchaImage(50, 160)%><br />
                <%= Html.TextBox("captchaBox", null, new { @class = "captcha" })%>
                <div class="errorHolder" id="captchaErrorHolder">
                </div>
            </div>
        </div>
        <div id="daliButton">
            <input type="submit" class="done" value="" />
        </div>
        <%} %>
        <div class="clearBoth">
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Request.css" />
    <%= Ajax.DynamicCssInclude(string.Format("/Content/LocaleDependent/{0}/Request.css", Dev.Helpers.LocaleHelper.GetCultureName())) %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.validate.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcAjax.js")%>
    <script type="text/javascript">
        function formSubmitted() {
            location.href = "/Feedback/MessageSent";
        }

        function captchaInvalid() {
            $("#captchaErrorHolder").html('<%= Html.ResourceString("CaptchaInvalid") %>');
        }

        function updateFormState() {
            if ($("#name").val() != "") {
                $("#email").removeAttr("disabled").removeClass("disabled");
            }
            else {
                $("#message, #email, #captchaBox, .done").attr("disabled", "disabled").addClass("disabled");
            }
            if ($("#name").val() != "" && $("#email").val() != "") {
                $("#message").removeAttr("disabled").removeClass("disabled");
            }
            else {
                $("#message, #captchaBox, .done").attr("disabled", "disabled").addClass("disabled");
            }
            if ($("#name").val() != "" && $("#email").val() != "" && $("#message").val() != "") {
                $("#captchaBox").removeAttr("disabled").removeClass("disabled");
            }
            else {
                $("#captchaBox, .done").attr("disabled", "disabled").addClass("disabled");
            }
            if ($("#name").val() != "" && $("#email").val() != "" && $("#message").val() != "" && $("#captchaBox").val() != "" && $("#feedback").valid()) {
                $(".done").removeAttr("disabled", "disabled").removeClass("disabled");
            }
            else {
                $(".done").attr("disabled", "disabled").addClass("disabled");
            }
        }

        $(function() {
            updateFormState();

            $("#name, #email, #message, #captchaBox").keyup(function() {
                updateFormState();
            });

            $("#feedback").validate({
                errorPlacement: function(error, element) {
                    $("#" + element[0].id + "ErrorHolder").append(error);
                },
                rules:
                {
                    email: { required: true, email: true }
                },
                messages:
                {
                    email: '<%= Html.ResourceString("IncorrectEmail") %>'
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Html.ResourceString("Feedback") %>
</asp:Content>
