<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Доставка и оплата
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 2); %>

    <div id="basketH"><h1>Ваши контактные данные:</h1></div>
    
        <% Html.EnableClientValidation(); %>
    <% using(Html.BeginForm("DeliveryAndPayment", "Cart", FormMethod.Post, new{id="deliveryForm"})){ %>
    <div style="display:none">
        <%= Html.CheckBox("back", false) %>
    </div>
    <div id="basketBox">
        <table class="userInfo" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td class="labelCell">
                    Имя, фамилия получателя:
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Name) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model=>model.Name) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    Контактный телефон:
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Phone) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model => model.Phone)%>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    Адрес доставки:
                </td>
                <td colspan="2">
                    <%= Html.TextAreaFor(model=>model.DeliveryAddress) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    Дополнительная информация:
                </td>
                <td colspan="2">
                    <%= Html.TextAreaFor(model=>model.AdditionalDeliveryInfo) %>
                </td>
            </tr>
        </table>
    </div>

    
    <div id="nextPreviews">
        <div id="backBox">
            <div id="back">
                <input alt="Вернуться" src="/Content/img/back.jpg" onclick="history.back(); return false;" type="image" /></div>
        </div>
        <div id="allrightBox2">
            <div id="allright2">
                <input alt="Все правильно" src="/Content/img/allright.jpg" type="image" />
                <div id="heartBasket2">
                    <p>
                        <img alt="heart" src="/Content/img/heart.jpg" /></p>
                </div>
            </div>
        </div>
    </div>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
    <%= Ajax.DynamicCssInclude("/Content/Cart.css") %>
</asp:Content>
