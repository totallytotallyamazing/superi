<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary("Вход неудачен.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Данные пользователя</legend>
                <p>
                    <label for="username">Логин:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="password">Пароль:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Запомнить</label>
                </p>
                <p>
                    <input type="submit" value="Вход" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
