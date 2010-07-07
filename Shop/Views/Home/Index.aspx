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
                <span class="span1"><a href="/Products/Tags/1">Для беременности</a></span> 
                <span class="span2"><a href="/Products/Tags/2">Для родов</a></span> 
                <span class="span3"><a href="/Products/Tags/3">Для бани</a></span><br><br>
                <span class="span1"><a href="/Products/Tags/4">Для кормления</a></span> 
                <span class="span4"><a href="/Products/Tags/5">Для плавания</a> </span>
                <span class="span5"><a href="/Products/Tags/6">Для вещичек</a></span><br><br>
                <span class="span1"><a href="/Products/Tags/8">Для развития и игр</a></span>
                <span class="span6"><a href="/Products/Tags/9">Для сна</a></span> 
                <span class="span7"><a href="/Products/Tags/10">Для гуляния</a></span><br><br>
                <span class="span8"><a href="/Products/Tags/11">Для сидения и ползания</a></span> 
                <span class="span9"><a href="/Products/Tags/12">Для поездок</a></span><br><br>
                <span class="span10"><a href="/Products/Tags/13">Для ношения</a></span>
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
