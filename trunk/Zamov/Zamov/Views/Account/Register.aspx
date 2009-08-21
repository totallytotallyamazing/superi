<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Register") %>
</asp:Content>
<asp:Content ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/register.css") %>
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.ResourceString("Register") %></h2>
    <%= Html.ValidationSummary(Html.ResourceString("AccountCreationFailed")) %>
    <% using (Html.BeginForm())
       { %>
    <div>
        <fieldset>
            <legend>
                <%= Html.ResourceString("NewUser")%>
            </legend>
            <table class="registrationTable">
                <tr>
                    <td>
                        <label style="width: 300px" for="email">
                            <%= Html.ResourceString("Email") %>:</label>
                        <%= Html.ValidationMessage("email", "*", new { @class="validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextBox("email") %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="password">
                            <%= Html.ResourceString("Password") %>:</label>
                        <%= Html.ValidationMessage("password", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.Password("password") %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="confirmPassword">
                            <%= Html.ResourceString("ConfirmPassword") %>:</label>
                        <%= Html.ValidationMessage("confirmPassword") %>
                    </td>
                    <td>
                        <%= Html.Password("confirmPassword") %>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset style="margin-top: 20px;">
            <legend>
                <%= Html.ResourceString("YourDetails")%></legend>
            <table class="registrationTable">
                <tr>
                    <td>
                        <label for="firstName">
                            <%= Html.ResourceString("FirstName") %>:</label>
                        <%= Html.ValidationMessage("firstName", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextBox("firstName")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="lastName">
                            <%= Html.ResourceString("LastName") %>:</label>
                        <%= Html.ValidationMessage("lastName", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextBox("lastName")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="deliveryAddress">
                            <%= Html.ResourceString("DeliveryAddress") %>:</label>
                        <%= Html.ValidationMessage("deliveryAddress", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextArea("deliveryAddress")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="mobilePhone">
                            <%= Html.ResourceString("Phone") %>:</label>
                        <%= Html.ValidationMessage("mobilePhone", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextBox("mobilePhone")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="phone">
                            <%= Html.ResourceString("Phone") %>:</label>
                    </td>
                    <td>
                        <%= Html.TextBox("phone")%>
                    </td>
                </tr>
            </table>
        </fieldset>
        <table class="captchaTable">
            <tr>
                <td valign="middle">
                    <label for="captcha">
                        <%= Html.ResourceString("InputCaptcha") %>
                    </label>
                    <%= Html.ValidationMessage("captchaCheck", "*", new { @class = "validationError" })%>
                </td>
                <td valign="middle">
                    <%= Html.CaptchaImage(50, 150)%><br />
                </td>
                <td valign="middle">
                    <%= Html.TextBox("captcha", null, new { style="width:60px; text-align:center;"})%>
                </td>
            </tr>
        </table>
        <%= Html.CheckBox("rememberMe") %>&nbsp;<%= Html.ResourceString("RememberMe") %><br />
        <input type="submit" value="<%= Html.ResourceString("Register") %>" />
    </div>
    <% } %>
</asp:Content>
