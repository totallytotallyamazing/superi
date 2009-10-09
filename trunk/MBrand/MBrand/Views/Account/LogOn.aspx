<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Админка
</asp:Content>
<asp:Content ContentPlaceHolderID="HeaderTitle" runat="server">
    Админка
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary("Вход не выполнен") %>
    <% using (Html.BeginForm())
       { %>
    <table style="margin-top:150px;">
        <tr>
            <td style="text-align: right">
                Имя:
            </td>
            <td>
                <%= Html.TextBox("username", null, new { style="width:150px;" })%>
                <%= Html.ValidationMessage("username") %>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Пароль:
            </td>
            <td>
                <%= Html.Password("password", null, new { style = "width:150px;" })%>
                <%= Html.ValidationMessage("password") %>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <%= Html.CheckBox("rememberMe") %>
                <label class="inline" for="rememberMe">
                    Запомнить</label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <input type="submit" value="Войти" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>
