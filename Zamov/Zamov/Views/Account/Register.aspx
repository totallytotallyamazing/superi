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
        <fieldset style="margin-top:20px;">
            <legend>
                <%= Html.ResourceString("AccountInformation")%></legend>
            <table class="registrationTable">
                <tr>
                    <td>
                        <label for="confirmPassword">
                            <%= Html.ResourceString("FirstName") %>:</label>
                        <%= Html.ValidationMessage("firstName", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextBox("firstName")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="confirmPassword">
                            <%= Html.ResourceString("LastName") %>:</label>
                        <%= Html.ValidationMessage("lastName", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextBox("lastName")%>
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
                        <label for="confirmPassword">
                            <%= Html.ResourceString("Phone") %>:</label>
                        <%= Html.ValidationMessage("firstName", "*", new { @class = "validationError" })%>
                    </td>
                    <td>
                        <%= Html.TextBox("phone")%>
                    </td>
                </tr>
            </table>
        </fieldset>
        <table>
            <tr>
                <td>
                    <label for="captcha">
                        Введите нижеуказанную надпись
                        <%= Html.ValidationMessage("captchaCheck", "*", new { @class = "validationError" })%>
                        <br />
                        <%= Html.CaptchaImage(50, 170)%></label><br />
                    <%= Html.TextBox("captcha") %>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="submit" value="<%= Html.ResourceString("Register") %>" />
                </td>
            </tr>
        </table>
    </div>
    <% } %>
</asp:Content>
