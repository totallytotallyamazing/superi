<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <strong>№ заказа:</strong><%: Model.Id %></div>
    <fieldset>
        <legend>Заказчик </legend>
        <div>
            <strong>Электропочта:</strong> <a href="mailto:<%: Model.BillingEmail %>">
                <%: Model.BillingEmail %></a>
        </div>
        <div>
            <strong>Имя:</strong>
            <%: Model.BillingName %>
        </div>
        <div>
            <strong>Телефон:</strong>
            <%: Model.BillingPhone%>
        </div>
    </fieldset>
    <fieldset>
        <legend>Доставка </legend>
        <div>
            <div>
                <strong>Кому:</strong>
                <%: Model.DeliveryName %>
            </div>
            <div>
                <strong>Телефон:</strong>
                <%: Model.DeliveryPhone %>
            </div>
            <div>
                <strong>Адресс:</strong>
            </div>
            <div>
                <%: Model.DeliveryAddress %>
            </div>
        </div>
    </fieldset>
    <div>
        <strong>Состав:</strong>
    </div>
    <div>
        <% Html.RenderPartial("OrderItems", Model.OrderItems); %>
    </div>
    <fieldset>
        <legend>
            Заказ:
        </legend>
<%--        <div>
            <strong>Тип оплаты:</strong> <%: Model.PaymentType.Name %>
        </div>
        <div>
            <strong>Тип доставки:</strong> <%: Model.DeliveryType.Name %>
        </div>--%>
        <div>
            <strong>Дополнительная информация:</strong>
            <div>
                <%: Model.AdditionalDeliveryInfo %>
            </div>
        </div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Вернуться к списку", "Index") %>
    </p>
    <p>
        <%: Html.ActionLink("Удалить", "Delete", new { id = Model.Id }, new { onclick = "return confirm('Вы уверены?')" })%>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
