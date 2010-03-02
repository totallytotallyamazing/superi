<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Админка
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary("Вы стратили") %>

    <% using (Html.BeginForm()) { %>
        <div>
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
                    <input type="submit" value="Войти" />
                </p>
        </div>
    <% } %>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentTitle">
    Админка
</asp:Content>