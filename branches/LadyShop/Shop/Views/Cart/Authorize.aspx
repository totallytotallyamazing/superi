﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Авторизация
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 1); %>
    <div id="basketH"><h1>Ваши контактные данные:</h1></div>

    <div id="userInfoWrapper">
        <h2 class="cartPageTitle">Ваши контактные данные</h2>
        <% Html.EnableClientValidation(); %>
        <% using(Html.BeginForm("Authorize", "Cart", FormMethod.Post, new{id="authorizeForm"})){ %>
        <table class="userInfo">
            <tr>
                <td class="labelCell">
                    Адрес элентропочты:<br />
                    <span class="comments">
                        (при регистрации является вашим логином)
                    </span>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Email) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model=>model.Email) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    Имя, фамилия:
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Name) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model => model.Name)%>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    Номер телефона
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Phone) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model => model.Phone)%>
                </td>
            </tr>
            <% if(!Request.IsAuthenticated){ %>
            <tr>
                <td class="registerMePlease" colspan="3">
                    <%= Html.ActionLink("Зарегистрируйте меня как пользователя,", "Register", new {controller="Account", area="", redirectTo = "~/Cart/DeliveryAndPayment"}, new {@class="pleaseRegister"})%> пожалуйста
                </td>
            </tr>
            <%} %>
        </table>
        <div class="backAndForward">
            <div class="back">
                <a href="javascript:goBack();">Вернуться</a>
            </div>
            Все верно, <input type="submit" value="продолжаем!" />
        </div>
        <%} %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
    <%= Ajax.DynamicCssInclude("/Content/Cart.css") %>
    <script type="text/javascript">
        function goBack() {
            history.back();
        }
    
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
