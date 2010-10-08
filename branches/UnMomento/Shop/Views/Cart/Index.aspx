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
        Sys.require(Sys.components.maskedEdit, function () {
            $("#cartContents td input[type='text']").maskedEdit({
                Mask: "9",
                AcceptNegative: 0,
                MaskType: Sys.Extended.UI.MaskedEditType.Number,
                PromptChararacter: ""
            });
        });

        function bindEvents() {
            $("td input[type='text']").keyup(function (ev) {
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
            $("#totalAmount .bg").html(data.totalAmount);
            for (var i in data.items) {
                var item = data.items[i];
                $("#price_" + item.id).html(item.price);
            }
            alignTotal();
        }

        $(function () {
            bindEvents();
            alignTotal();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="OrderItems">
        <% Html.RenderPartial("CartContent", Model); %>
    </div>
    <%--<div id="proceedContainer">
        Все верно,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= Html.ActionLink("оформляем!", "Authorize") %>
    </div>--%>
    <div id="offer">
        <div id="txtOffer">
            <p class="it1">
                Предложения, которые отлично дополнят Ваш заказ:</p>
        </div>
        <div id="bubbleOffer">
            <div id="bubOfferAll">
                <div id="bubOfferTop">
                    <div class="bubOfferTRight">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/invisible.gif" alt="Шапка-невредимка" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Шапка-невредимка</b></a>
                                    <br />
                                    3,300 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="bubOfferTLeft">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/snail.gif" alt="Улитка" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Улитка-шмулитка</b></a>
                                    <br />
                                    500 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="bubOfferTCenter">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/JackSparrow.gif" alt="Джонни Депп" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Джонни Депп</b></a>
                                    <br />
                                    1,340 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="bubOfferCenter">
                    <div class="bubOfferTRight">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/bayan.gif" alt="Коза с баяном" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Коза с баяном</b></a>
                                    <br />
                                    3,875 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="bubOfferTLeft">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/something.gif" alt="Фигня в кулёчке" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Фигня в кулёчке</b></a>
                                    <br />
                                    10 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="bubOfferTCenter">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/wonderingFace.gif" alt="Удивленное лицо" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Удивленное лицо</b></a>
                                    <br />
                                    130 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="bubOfferBottom">
                    <div class="bubOfferTRight">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/crap.gif" alt="Какая-то рень" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Какая-то рень</b></a>
                                    <br />
                                    2,875 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="bubOfferTLeft">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/conception.gif" alt="Непорочное зачатие" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Непорочное зачатие</b></a>
                                    <br />
                                    375 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="bubOfferTCenter">
                        <div class="bubOfferItem">
                            <div class="bubOfferImg">
                                <img src="../../Content/UnMomentoStyles/img/cow.gif" alt="Тёлка без одежды" />
                            </div>
                            <div class="bubOfferName">
                                <p class="obt1">
                                    <a href="#" class="obt1"><b>Тёлка без одежды</b></a>
                                    <br />
                                    2,445 грн.
                                    <br />
                                    <a href="#" class="it3">Добавить в счёт »</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <div id="contName">
        <div id="pagePic">
            <img src="../../Content/UnMomentoStyles/img/bear.gif" alt="Медведь" />
        </div>
        <div id="pageName">
            <p class="pt1">
                У вас в корзинке:</p>
        </div>
    </div>
    <%--<% Html.RenderPartial("CartBreadCrumbs", 0); %>--%>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager" style="padding-left: 20px;">
        <p class="pgt1">
            <a href="#" class="pgt1">« Вернуться</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <%= Html.ActionLink("Продолжить »", "Authorize", new { Area = "", type = 1 }, new { @class = "pgt1" })%>
            <%--<a href="#" class="pgt1">Продолжить »</a>--%>
            </p>
    </div>
</asp:Content>
