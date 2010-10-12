<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Авторизация
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="userInfoWrapper">
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm("Authorize", "Cart", FormMethod.Post, new { id = "authorizeForm" }))
           { %>
        <div id="infoLeft">
            <div class="infoTxt">
                <p class="it1">
                    <b>Полная сумма заказа:</b></p>
            </div>
            <div class="infoTxt">
                <p class="it1">
                    <b>Дата доставки заказа:</b></p>
            </div>
            <div class="infoTxt">
                <p class="it1">
                    <b>Ваш способ оплаты:</b></p>
            </div>
            <div class="infoTxt">
                <p class="it1">
                    <b>Код вашей дисконтной карточки</b> <span class="ort2">(если имеется)<b>:</b></span></p>
            </div>
            <div class="infoTxt">
                <p class="it1">
                    <b>Уведомить о выполнении заказа?</b></p>
            </div>
            <div class="infoTxt">
                <p class="it1">
                    <b>Сообщить ваше имя получателю?</b></p>
            </div>
        </div>
        <div id="infoRight">
            <p class="it1">
                1,400 грн</p>
            <div id="cbDate">
                <%--<input type="text" /> --%>
            </div>
            <div id="cbPayment">
                <%--<input type="text" /> --%>
            </div>
            <div id="codeAbout">
                <a href="#" class="dt3"><b>О дисконтных карточках</b> </a>
            </div>
            <div id="inpCode">
                <input class="textCode" type="text" />
            </div>
            <div id="cbReport">
                <input type="checkbox" name="ch1" />
            </div>
            <div id="cbReportName">
                <input type="checkbox" name="ch2" />
            </div>
            <div id="crossAuthorize">
                <img src="../../Content/UnMomentoStyles/img/cross.gif" alt="разделитель" />
            </div>
        </div>
        <div>
            <p class="au1">
                К подарку обычно прилагается</p>
            <div id="zaebaliNahShrifty">
                <p class="pt1">
                    Открытка</p>
            </div>
            <p class="ort2">
                (Стоимость открытки — 10 грн, автоматически включится в счёт)</p>
        </div>
        <div id="bonus">
            <div id="bonusRight">
                <img src="../../Content/UnMomentoStyles/img/RightArrow.gif" alt="разделитель" />
            </div>
            <div id="bonusLeft">
                <img src="../../Content/UnMomentoStyles/img/LeftArrow.gif" alt="разделитель" />
            </div>
            <div id="bonusCenter">
                <p class="thumb">
                    <img src="../../Content/UnMomentoStyles/img/faxGrey.gif" alt="разделитель" width="80"
                        height="70" />
                    <img src="../../Content/UnMomentoStyles/img/fax.gif" alt="разделитель" width="80"
                        height="70" />
                    <img src="../../Content/UnMomentoStyles/img/fax.gif" alt="разделитель" width="80"
                        height="70" />
                    <img src="../../Content/UnMomentoStyles/img/fax.gif" alt="разделитель" width="80"
                        height="70" />
                    <img src="../../Content/UnMomentoStyles/img/fax.gif" alt="разделитель" width="80"
                        height="70" />
                </p>
            </div>
        </div>
        <div id="greetingsLeft">
            <div class="greetingsInfo">
                <p class="it1">
                    <b>Введите поздравительный текст,</b></p>
                <span class="ort2">или выберите из</span> <a href="#" class="dt3"><b>предлагаемых нами.</b>
                </a>
            </div>
            <div class="greetingsInfo">
                <p class="ort2">
                    Введенный текст будет печататься на обороте открытки.</p>
            </div>
            <div class="greetingsInfo">
                <p class="ort2">
                    Текст вводить не обязательно, можно ограничиться подписью.</p>
            </div>
        </div>
        <div id="greetingsRight">
            <div id="inpGreetings">
                <%--<input class="textGreetings" type="text" />--%>
                <textarea class="textGreetings"></textarea>
            </div>
            <div id="subscribe">
                <p class="au1">
                    &nbsp; Подпишите открытку:</p>
                <div id="inpSubscribe">
                    <input class="textCode" type="text" />
                </div>
            </div>
        </div>
        <div id="autoSelect">
            <div id="cbAutoSelect">
                <input type="checkbox" name="ch3" />
            </div>
            <p class="au2">
                Поставьте галочку, если желаете, чтобы мы подобрали открытку самостоятельно.</p>
        </div>
        <div class="deliveryInfo">
            <p class="pt1">
                Кому и куда доставляем?</p>
            <p class="au1">
                Пожалуйста, заполните все поля.
            </p>
        </div>
        <div class="infoInputLines">
            <div id="inputCity">
                <input class="textCity" type="text" />
            </div>
            <div id="cbSex">
                <%--<input type="text" /> --%>
            </div>
            <div id="inputNameSurname">
                <input class="textNameSurname" type="text" />
            </div>
        </div>
        <div class="infoInputLines">
            <div class="inputFlat">
                <input class="textCode" type="text" />
            </div>
            <div class="inputStreet">
                <input class="textStreet" type="text" />
            </div>
            <div class="inputHomeNum">
                <input class="textStreet" type="text" />
            </div>
        </div>
        <div class="infoInputLines">
            <div class="inputIndex">
                <input class="textCode" type="text" />
            </div>
            <div class="inputMail">
                <input class="textStreet" type="text" />
            </div>
        </div>
        <div class="infoInputLines">
            <div id="inputPhoneNum">
                <input class="textPhoneNum" type="text" />
            </div>
        </div>
        <div class="inputDescription">
            <p class="au3">
                Необходимо указать все возможные номера, по которыми можно связаться с получателем.
                От этого зависит качество доставки.</p>
            <p class="au1">
                Например: (123) 456-78-90, (044) 123-12-22
            </p>
        </div>
        <div id="additionalInfo">
            <p class="it1">
                <b>Дополнительная информация</b></p>
            <p class="au1">
                (пароль для вахтёрши, код домофона, злая собака...)
            </p>
        </div>
        <div id="memoAdditionalInfo">
            <textarea class="textAdditionalInfo"></textarea>
        </div>
        <div class="deliveryInfo">
            <p class="pt1">
                Информация о вас</p>
            <p class="au1">
                Пожалуйста, заполните все поля.
            </p>
        </div>
        <div class="infoInputLines">
            <div id="userNameSurname">
                <input class="textNameSurname" type="text" />
            </div>
            <div id="userCity">
                <input class="textCity" type="text" />
            </div>
            
        </div>
        <div class="infoInputLines">
            <div class="inputFlat">
                <input class="textCode" type="text" />
            </div>
            <div class="inputStreet">
                <input class="textStreet" type="text" />
            </div>
            <div class="inputHomeNum">
                <input class="textStreet" type="text" />
            </div>
        </div>
        <div class="infoInputLines">
            <div id="inputMailIndex">
                <input class="textCode" type="text" />
            </div>            
        </div>
        <div class="infoInputLines">
            <div id="inputPhone">
                <input class="textPhone" type="text" />
            </div>
            <div class="inputMail">
                <input class="textStreet" type="text" />
            </div>
        </div>
        <div class="inputDescription">
            <p class="au3">
                Вводимая информация абсолютно конфеденциальна.</p>
            
        </div>
        <%} %>
    </div>
    <%-- <div id="userInfoWrapper">
        <h2 class="cartPageTitle">Ваши контактные данные</h2>
        <% Html.EnableClientValidation(); %>
        <% using(Html.BeginForm("Authorize", "Cart", FormMethod.Post, new{id="authorizeForm"})){ %>
        <div style="display:none">
            <%= Html.CheckBox("back", false) %>
        </div>
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
                <a href="javascript:history.back();">Вернуться</a>
            </div>
            Все верно, <input type="submit" value="продолжаем!" />
        </div>
        <%} %>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
    <%= Ajax.DynamicCssInclude("/Content/Cart.css") %>
    <link href="/Content/UnMomentoStyles/Authorize.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <div id="contName">
        <div id="pagePic">
            <img src="../../Content/UnMomentoStyles/img/NewsPageImg.gif" alt="Древо" />
        </div>
        <div id="pageName">
            <p class="pt1">
                Последний шаг оформления</p>
        </div>
    </div>
    <%--  <% Html.RenderPartial("CartBreadCrumbs", 1); %>--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
    <div id="pager" style="padding-left: 20px;">
        <p class="pgt1">
            <a href="javascript:history.back();" class="pgt1">« Вернуться</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <%: Html.ActionLink("Продолжить »", "Approve", null, new { @class = "pgt1" })%>
        </p>
    </div>
</asp:Content>
