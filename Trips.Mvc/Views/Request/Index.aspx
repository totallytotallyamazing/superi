<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    1
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentBoxStep1">
        <br>
        <h2>
            О поездке:</h2>
        <br>
        <h3>
            Автомобиль:</h3>
        <br>
        <h4>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="#">Выбрать</a> (при
            переходе в каталог введенные Вами данные сохранятся)</h4>
        <br>
        <h3>
            Откуда <span class="lessFont">(название города): </span>
        </h3>
        <form name="form2" method="post" action="">
        <label>
            <input type="text" name="way" id="punktA" value="Киев" class="forma">
        </label>
        </form>
        <br>
        <h3>
            Куда <span class="lessFont">(название города): </span>
        </h3>
        <form name="form2" method="post" action="">
        <label>
            <input type="text" name="way" id="punktB" value="Борисполь" class="forma">
        </label>
        </form>
        <br>
        <h3>
            Просчитано:</h3>
        <div id="raschetBox">
            <div id="raschetBoxLeft">
            </div>
            <div id="raschetBoxRight">
            </div>
            <div id="raschetBoxContent">
                <h5>
                    Маршрут: <span class="lessFont2">Киев—Борисполь </span>
                </h5>
                <h5>
                    Расстояние: <span class="lessFont2">37 км </span>
                </h5>
                <h5>
                    Стоимость: <span class="lessFont2">200 грн </span>
                </h5>
            </div>
        </div>
        <p>
            (Пересчитать в <a href="#">евро</a>, <a href="#">рублях</a> или <a href="#">долларах</a>)</p>
        <br>
        <h3>
            Детальнее о маршруте:</h3>
        <form name="form3" method="post" action="">
        <label>
            <input type="text" name="opusMarsh" id="opusMarsh" class="forma">
        </label>
        </form>
        <h6>
            Например, места, куда планируете заезжать по пути</h6>
    </div>
    <div id="daliButton" align="center">
        <input type="image" src="/Content/img/Dali.jpg" />
    </div>
    <div class="clearBoth">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    1
</asp:Content>
