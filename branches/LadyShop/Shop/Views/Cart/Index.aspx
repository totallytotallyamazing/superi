<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.OrderItem>>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Корзина
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude("/Content/Cart.css") %>
    <script type="text/javascript">
        //        Sys.require(Sys.components.maskedEdit, function() {
        //            $("#cartContents td input[type='text']").maskedEdit({
        //                Mask: "9",
        //                AcceptNegative: 0,
        //                MaskType: Sys.Extended.UI.MaskedEditType.Number,
        //                PromptChararacter: ""
        //            });
        //        });

        function bindEvents() {
            $(".basketItemField input[type='text']").keyup(function (ev) {
                var val = this.value.replace("_", "");
                if (val != "") {
                    var id = this.id.split("_")[1];
                    $.post("/Cart/UpdateQuantity/" + id + "?quantity=" + val, function (data) {
                        updateCartAmounts(data);
                    });
                }
            });
        }

        function updateCartAmounts(data) {
            $("#itogiSumm p").html(data.totalAmount);
            for (var i in data.items) {
                var item = data.items[i];
                $("#price_" + item.id).html(item.price);
            }
        }

        $(function () {
            bindEvents();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 0); %>
    <div id="basketH">
        <h1>У Вас в корзинке:</h1>
    </div>
    <% Html.RenderPartial("CartContent", Model); %>
    
    <% using(Html.BeginForm("Authorize", "Cart", FormMethod.Get)) %>
    <div id="allrightBox">
        <div id="allright">
            <input alt="Все правильно" src="/Content/img/allright.jpg" type="image" /></div>
        <div id="heartBasket">
            <p><img alt="heart" src="/Content/img/heart.jpg" /></p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
