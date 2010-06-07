<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lady.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Админка
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%= Html.ValidationSummary(true, "Вы стратили.")%>
        <div id="login">
            <p>
                <%= Html.TextBoxFor(m => m.UserName) %>
                <%= Html.ValidationMessageFor(m => m.UserName) %>
            </p>
            <p>
                <%= Html.PasswordFor(m => m.Password) %>
                <%= Html.ValidationMessageFor(m => m.Password) %>
            </p>
            
            <p>
                <%= Html.CheckBoxFor(m => m.RememberMe) %>
                <%= Html.LabelFor(m => m.RememberMe) %>
            </p>
            <p>
                <input type="submit" value="Войти " />
            </p>
        </div>
    <% } %>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentTitle">
    Админка
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <link rel="Stylesheet" href="/Content/LogOn.css" />

    <script src="http://ajax.microsoft.com/ajax/beta/0911/extended/ExtendedControls.js" type="text/javascript"></script>  
    <script type="text/javascript">
        Sys.require(Sys.components.watermark, function() {
            $("#UserName").watermark("Логин", "watermark");
            $("#Password").watermark("Пароль", "watermark");
        });   
    </script>
</asp:Content>
