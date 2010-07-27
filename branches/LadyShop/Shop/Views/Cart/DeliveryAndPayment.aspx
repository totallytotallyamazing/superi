<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Доставка и оплата
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ваши контактные данные</h2>
    
        <% Html.EnableClientValidation(); %>
    <% using(Html.BeginForm("DeliveryAndPayment", "Cart", FormMethod.Post, new{id="deliveryForm"})){ %>
    <div style="display:none">
        <%= Html.CheckBox("back", false) %>
    </div>
    <table>
        <tr>
            <td>
                Имя, фамилия получателя:
            </td>
            <td>
                <%= Html.TextBoxFor(model=>model.Name) %>
            </td>
            <td>
                <%= Html.ValidationMessageFor(model=>model.Name) %>
            </td>
        </tr>
        <tr>
            <td>
                Контактный телефон:
            </td>
            <td>
                <%= Html.TextBoxFor(model=>model.Phone) %>
            </td>
            <td>
                <%= Html.ValidationMessageFor(model => model.Phone)%>
            </td>
        </tr>
        <tr>
            <td>
                Адрес доставки:
            </td>
            <td colspan="2">
                <%= Html.TextAreaFor(model=>model.DeliveryAddress) %>
            </td>
        </tr>
        <tr>
            <td>
                Дополнительная информация:
            </td>
            <td colspan="2">
                <%= Html.TextAreaFor(model=>model.AdditionalDeliveryInfo) %>
            </td>
        </tr>
    </table>
    <div class="backAndForward">
        <div class="back">
            <a href="javascript:goBack();">Вернуться</a>
        </div>
        Все верно, <a href="javascript:$('#deliveryForm')[0].submit();">продолжаем!</a>
    </div>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 2); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
</asp:Content>
