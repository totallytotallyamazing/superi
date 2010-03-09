<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Админка
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary("Вы стратили") %>
    <% using (Html.BeginForm()) { %>
        <div id="login">
            <p>
                <%= Html.TextBox("username") %>
                <%= Html.ValidationMessage("username") %>
            </p>
            <p>
                <%= Html.Password("password") %>
                <%= Html.ValidationMessage("password") %>
            </p>
            <p>
                <%= Html.CheckBox("rememberMe") %> <label for="rememberMe">Запомнить меня</label>
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

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <link rel="Stylesheet" href="/Content/Admin.css" />
    <script src="http://ajax.microsoft.com/ajax/beta/0911/extended/ExtendedControls.js" type="text/javascript"></script>  
    <script type="text/javascript">
        Sys.require(Sys.components.watermark, function() {
            $("#username").watermark("Логин", "watermark");
            $("#password").watermark("Пароль", "watermark");
        });   
    </script>
</asp:Content>