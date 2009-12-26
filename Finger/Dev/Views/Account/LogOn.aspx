<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Админка
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Админка</h2>
    <%= Html.ValidationSummary("Имя пользователя или пароль введены не правильно.") %>

    <% using (Html.BeginForm()) { %>
             <table>
                <tr>
                    <td>Логин:</td>
                    <td>                    
                        <%= Html.TextBox("username") %>
                        <%= Html.ValidationMessage("username", "*")%>
                    </td>
                </tr>
                <tr>
                    <td>Пароль</td>
                    <td>
                        <%= Html.Password("password") %>
                        <%= Html.ValidationMessage("password", "*") %>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Запомнить меня</label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type="submit" value="Вход" />
                    </td>
                </tr>
            </table>
    <% } %>
</asp:Content>
