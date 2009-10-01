<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Админка    
</asp:Content>

<asp:Content ContentPlaceHolderID="HeaderTitle" runat="server">
    Админка
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Введите имя и пароль
    </p>
    <%= Html.ValidationSummary("Вход не выполнен") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Персональные данные</legend>
                <p>
                    <label for="username">Имя:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="password">Пароль:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Запомнить меня?</label>
                </p>
                <p>
                    <input type="submit" value="Войти" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
