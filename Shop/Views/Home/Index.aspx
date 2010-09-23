<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentTitle">
            <div id="contName">
                <div id="pagePic">
                    <img src="../../Content/UnMomentoStyles/img/bear.gif" alt="Медведь" />     
                </div>            
                <div id="pageName">
                    <p class="pt1">Мягкие игрушки, <span class="pt2" >страница 1</span> </p>            
                </div>
            </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div id="contGoodsTop">
                <div id="item1">
                    <img src="../../Content/UnMomentoStyles/img/sheep.gif" alt="Овца" />
                    <div id="item1Txt">
                        
                        <a href="#" class="it1"> <b>Овца клонированная,</b></a>   пух и                             прах. Мех, шах и мат. 
                        <p class="it2">1,200 грн.</p>
                        <a href="#" class="it3">Заказать »</a>
                    </div>    
                </div> 
                <div id="item2">
                    <img src="../../Content/UnMomentoStyles/img/elephant.gif" alt="Слон" />
                    <div id="item2Txt">
                        <a href="#" class="it1"><b>Хоботливый Чак,</b></a>  уход за                             ним не требует мозгов.
                        <p class="it2">от 30 грн.</p>
                        <a href="#" class="it3">Заказать »</a> 
                    </div>    
                </div>
            </div>
            <div id="contGoodsBottom">
                 <div id="item3">
                    <img src="../../Content/UnMomentoStyles/img/bearItem.gif" alt="Медвед" />
                    <div id="item3Txt">
                        <a href="#" class="it1"> <b>Педо-bear,</b></a>  лучший друг твой                            детко, кИсО. Сосёт только лапу. 
                        <p class="it2">1,200 грн.</p>
                        <a href="#" class="it3">Заказать »</a>
                    </div>    
                </div>
                <div id="item4">
                    <img src="../../Content/UnMomentoStyles/img/sheepClone.gif" alt="Овца клонированная" />
                    <div id="item4Txt">
                        
                        <a href="#" class="it1"> <b>Овца клонированная,</b></a>   пух и                             прах. Мех, шах и мат. 
                        <p class="it2">1,200 грн.</p>
                        <a href="#" class="it3">Заказать »</a>
                    </div>    
                </div> 
            </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
                <p class="pgt1">1 ... <a href="#" class="pgt1">2</a> ... <a href="#" class="pgt1">3</a></p>
            </div>
</asp:Content>





<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
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
</asp:Content>--%>
