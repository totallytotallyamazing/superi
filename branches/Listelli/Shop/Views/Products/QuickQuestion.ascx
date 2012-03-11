<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.QuickQuestionModel>" %>


<div id="quickQuestion" style="display:none">
    <div class="similarItems">
        <p class="txtSimilarItems">
            Быстрый запрос:</p>
    </div>
    <% using (Ajax.BeginForm("QuickQuestion", new AjaxOptions { OnSuccess = "ProductClientExtensions.questionSend", OnBegin = "ProductClientExtensions.validateQuestion" }))
       { %>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <%= Html.LabelFor(model=>model.Name) %>
            </td>
            <td>
                <%= Html.TextBoxFor(model=> model.Name) %>
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.LabelFor(model=>model.Email) %>
            </td>
            <td>
                <%= Html.TextBoxFor(model => model.Email)%>
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.LabelFor(model=>model.Text) %>
            </td>
            <td>
                <%= Html.TextAreaFor(model => model.Text)%>
            </td>
        </tr>
    </table>
    <div class="sendLabel">
        <%= Shop.Resources.Global.EnterImageText %>
    </div>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="captchaImage">
                <%= Html.Action("DrawForFeedback", new { area = "", controller = "Captcha" })%>
            </td>
            <td>
                <%= Html.TextBoxFor(model => model.Captcha) %>
            </td>
        </tr>
    </table>
    <input type="submit" value="<%= Shop.Resources.Global.Send %>" />
    <% } %>
</div>