<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.FeedbackFormModel>" %>
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <script type="text/javascript" src="/Scripts/MvcCaptchaValidation.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script type="text/javascript">
        function OnCaptchaValidationError() {
            $("#captchaImage").load("/Captcha/Draw");
        }
    </script>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Email) %>
                <%= Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Text) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Text) %>
                <%= Html.ValidationMessageFor(model => model.Text) %>
            </div>
            <div id="captchaImage">
                <%= Html.Action("Draw", new {area="", controller="Captcha"})%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Captcha) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Captcha) %>
                <%= Html.ValidationMessageFor(model => model.Captcha) %>
            </div>
            
            <div>
                Всё верно, <input type="submit" value="Отправить" />
            </div>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>


