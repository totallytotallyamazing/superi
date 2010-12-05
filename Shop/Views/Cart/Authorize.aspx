<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Авторизация
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 1); %>
    <div id="basketH"><h1>Ваши контактные данные:</h1></div>

    <% Html.EnableClientValidation(); %>
    <% using(Html.BeginForm("Authorize", "Cart", FormMethod.Post, new{id="authorizeForm"})){ %>
    <div id="basketBox">
        <% if(!Request.IsAuthenticated){ %>
            <div class="labelCell" style="padding-left:3px;">
                Уже регистрировались? <%= Html.ActionLink("Войдите", "LogOn", "Account", new { id="~/Cart/Authorize"})%>
            </div>
        <%} %>
        <table class="userInfo" cellpadding="0" cellspacing="0" border="0">
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
    </div>


        <div id="nextPreviews">
            <div id="backBox">
                <div id="back">
                    <input alt="Вернуться" src="/Content/img/back.jpg" type="image" onclick="goBack(); return false;" /></div>
            </div>
            <div id="allrightBox2">
                <div id="allright2">
                    <input alt="Все правильно" src="/Content/img/allright.jpg" type="image" />
                    <div id="heartBasket2">
                        <p><img alt="heart" src="/Content/img/heart.jpg" /></p>
                    </div>
                </div>
            </div>
        </div>
        <%} %>
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
