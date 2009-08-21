<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Register") %>
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.ResourceString("Register") %></h2>


    <%= Html.ValidationSummary("Account creation was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend><%= Html.ResourceString("AccountInformation")%> </legend>
                <p>
                    <label for="username"><%= Html.ResourceString("Email") %>:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username", "*", new { @class="validationError" })%>
                </p>
                <p>
                    <label for="password"><%= Html.ResourceString("Password") %>:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password", "*", new { @class = "validationError" })%>
                </p>
                <p>
                    <label for="confirmPassword"><%= Html.ResourceString("ConfirmPassword") %>:</label>
                    <%= Html.Password("confirmPassword") %>
                    <%= Html.ValidationMessage("confirmPassword") %>
                </p>
            </fieldset>
            <fieldset>
                <legend><%= Html.ResourceString("AccountInformation")%></legend>
                <p>
                    <label for="confirmPassword"><%= Html.ResourceString("FirstName") %>:</label>
                    <%= Html.TextBox("firstName")%>
                </p>
                <p>
                    <label for="confirmPassword"><%= Html.ResourceString("LastName") %>:</label>
                    <%= Html.TextBox("lastName")%>
                </p>
                <p>
                    <label for="mobilePhone"><%= Html.ResourceString("Phone") %>:</label>
                    <%= Html.TextBox("mobilePhone")%>
                </p>
                <p>
                    <label for="confirmPassword"><%= Html.ResourceString("Phone") %>:</label>
                    <%= Html.TextBox("phone")%>
                </p>
                <p>
                    <label for="captcha">Введите нижеуказанную надпись
                    <br />
                    <%= Html.CaptchaImage(50, 170)%></label><br />
                    <%= Html.TextBox("captcha") %>
                    <%= Html.ValidationMessage("captcha1")%>
                </p>
                <p>
                    <input type="submit" value="<%= Html.ResourceString("Register") %>" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
