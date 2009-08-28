<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("LogOn") %>
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.ResourceString("LogOn") %></h2>
    <p>
        <%= Html.ResourceString("LoginHeader") %>
    </p>
    <%= Html.ValidationSummary(Html.ResourceString("LoginUnsucsessful"))%>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend><%= Html.ResourceString("AccountInfo") %></legend>
                <p>
                    <label for="username"><%= Html.ResourceString("Username") %>:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="password"><%= Html.ResourceString("Password") %>:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe"><%= Html.ResourceString("RememberMe") %>?</label>
                </p>
                <p>
                    <input type="submit" value="<%= Html.ResourceString("LogOn") %>" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
