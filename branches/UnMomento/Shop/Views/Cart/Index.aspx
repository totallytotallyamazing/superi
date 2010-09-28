<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.OrderItem>>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Корзина
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude("/Content/Cart.css") %>
    <%= Ajax.ScriptInclude("/Scripts/start.js") %>
    <%= Ajax.ScriptInclude("/Scripts/extended/ExtendedControls.js")%>

    <script type="text/javascript">
        Sys.require(Sys.components.maskedEdit, function() {
            $("#cartContents td input[type='text']").maskedEdit({
                Mask: "9",
                AcceptNegative: 0,
                MaskType: Sys.Extended.UI.MaskedEditType.Number,
                PromptChararacter: ""
            });
        });

        function bindEvents() {
            $("td input[type='text']").keyup(function(ev) {
                var val = this.value.replace("_", "");
                if (val != "") {
                    var id = this.id.split("_")[1];
                    $.post("/Cart/UpdateQuantity/" + id + "?quantity=" + val, function(data) {
                        updateCartAmounts(data);
                    });
                }
            });
        }

        function updateCartAmounts(data) {
            $("#totalAmount .bg").html(data.totalAmount);
            for (var i in data.items) {
                var item = data.items[i];
                $("#price_" + item.id).html(item.price);
            }
            alignTotal();
        }

        $(function() {
            bindEvents();
            alignTotal();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="OrderItems">
        <% Html.RenderPartial("CartContent", Model); %>
    </div>
    <div id="proceedContainer">
        Все верно,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= Html.ActionLink("оформляем!", "Authorize") %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
<div id="contName">
                <div id="pagePic">
                    <img src="../../Content/UnMomentoStyles/img/bear.gif" alt="Медведь" />     
                </div>  
    <div id="pageName">
        <p class="pt1">У вас в корзинке:</p>            
    </div>
</div>
    <%--<% Html.RenderPartial("CartBreadCrumbs", 0); %>--%>
</asp:Content>


<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager" style="padding-left:20px;">
                <p class="pgt1"><a href="#" class="pgt1">« Вернуться</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" class="pgt1">Продолжить »</a></p>
        </div>
</asp:Content>

