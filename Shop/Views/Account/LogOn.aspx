<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.LogOnModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Вход
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
    
    <div id="contName">
                <%--<div id="pagePic">
                    <img src="../../Content/UnMomentoStyles/img/bear.gif" alt="Медведь" />     
                </div>        --%>    
                <div id="pageName">
                    <p class="pt1">Вход</p>            
                </div>
            </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <link rel="Stylesheet" href="/Content/LogOn.css" />
<%--    <script type="text/javascript">
        Sys.require(Sys.components.watermark, function() {
            $("#UserName").watermark("Логин", "watermark");
            $("#Password").watermark("Пароль", "watermark");
        });   
    </script>--%>
</asp:Content>
