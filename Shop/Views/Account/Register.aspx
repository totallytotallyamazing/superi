<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Base.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.RegisterModel>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Регистрация
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="userInfoWrapper">
        <h2 class="cartPageTitle">
            Ваши контактные данные</h2>
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           { %>
           <%= Html.Hidden("redirectTo") %>
        <table class="userInfo">
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model=>model.Email) %>:<br />
                    <span class="comments">(при регистрации является вашим логином) </span>
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
                    <%= Html.LabelFor(model=>model.Name) %>:
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
                    <%= Html.LabelFor(model=>model.Phone) %>:
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Phone) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model => model.Phone)%>
                </td>
            </tr>
            <% if((bool)ViewData["redirect"]){ %>
                <tr>
                    <td class="registerMePlease" colspan="3">
                        <span class="pleaseRegister">Зарегистрируйте меня как пользователя,</span> пожалуйста
                    </td>
                </tr>
            <%} %>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model=>model.DeliveryAddress) %>
                </td>
                <td colspan="2">
                    <%= Html.TextAreaFor(model=>model.DeliveryAddress) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model=>model.Password) %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Password) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model => model.Password)%>
                </td>
            </tr>
        </table>
        <div class="backAndForward">
            <div class="back">
                <a href="javascript:history.back();">Вернуться</a>
            </div>
            Все верно,
            <input type="submit" value="продолжаем!" />
        </div>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 0); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MvcRemoteValidator.js")%>
    <%= Ajax.DynamicCssInclude("/Content/Cart.css")%>
</asp:Content>
