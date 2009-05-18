<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Вход
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Вход</h2>
    <p>
        Введите имя пользователя и пароль.
    </p>
    <%= Html.ValidationSummary("Невозможно войти") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Пользователь</legend>
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
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Запомнить?</label>
                </p>
                <p>
                    <input type="submit" value="Вход" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
