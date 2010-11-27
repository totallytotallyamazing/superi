<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.LogOnModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
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
    <%= Ajax.ScriptInclude("/Scripts/jquery.watermark.js")%>
    <script type="text/javascript">
        $(function () {
            $("#UserName").watermark({ html: "Логин", cls: "watermark" });
            $("#Password").watermark({ html: "Пароль", cls: "watermark" });
        })
    </script>
</asp:Content>
