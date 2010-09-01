<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Доставка и оплата
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="userInfoWrapper">
        <h2 class="cartPageTitle">Ваши контактные данные</h2>
        
            <% Html.EnableClientValidation(); %>
        <% using(Html.BeginForm("DeliveryAndPayment", "Cart", FormMethod.Post, new{id="deliveryForm"})){ %>
        <div style="display:none">
            <%= Html.CheckBox("back", false) %>
        </div>
        <table>
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
        <% Html.RenderPartial("DeliveryType"); %>
        <div class="backAndForward">
            <div class="back">
                <a href="javascript:goBack();">Вернуться</a>
            </div>
            Все верно, <input type="submit" value="продолжаем!" />
        </div>
        <%} %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 2); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
    <%= Ajax.DynamicCssInclude("/Content/Cart.css") %>
</asp:Content>
