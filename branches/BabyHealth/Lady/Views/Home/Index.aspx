<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Самая Главная страница
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="textUnderLine">
        <p>
            которая помогает простыми словами сориентироваться в категориях товаров. Просто
            выберите близкий Вам по теме пункт, и все товары, имеющие к нему отношение, появятся
            перед вами.</p>
    </div>
    <div id="linksBox">
        <div class="linksBoxString">
            <p>
                <span class="span1"><a href="#">Для беременности</a></span> <span class="span2"><a
                    href="#">Для родов</a></span> <span class="span3"><a href="#">Для бани</a></span><br>
                <br>
                <span class="span1"><a href="#">Для кормления</a></span> <span class="span4"><a href="#">
                    Для плавания</a> </span><span class="span5"><a href="#">Для вещичек</a></span><br>
                <br>
                <span class="span1"><a href="#">Для развития и игр</a></span> <span class="span6"><a
                    href="#">Для сна</a></span> <span class="span7"><a href="#">Для гуляния</a></span><br>
                <br>
                <span class="span8"><a href="#">Для сидения и ползания</a></span> <span class="span9">
                    <a href="#">Для поездок</a></span><br>
                <br>
                <span class="span10"><a href="#">Для ношения</a></span>
            </p>
        </div>
    </div>
    <div id="textUnderLinks">
        <p>
            Так же, можно воспользоваться поиском (вверху справа), или традиционным каталогом
            слева.
        </p>
    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentTitle">
    Самая Главная страница,
</asp:Content>