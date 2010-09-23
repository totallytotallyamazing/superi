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
    <div id="item1">
        <img src="../../Content/UnMomentoStyles/img/sheep.gif" alt="Овца" />
        <div id="item1Txt">
                        
            <a href="#" class="it1"> <b>Овца клонированная,</b></a>   пух и 
                прах. Мех, шах и мат. 
            <p class="it2">1,200 грн.</p>
            <a href="#" class="it3">Заказать »</a>
        </div>    
    </div> 
    <div id="item2">
        <img src="../../Content/UnMomentoStyles/img/elephant.gif" alt="Слон" />
        <div id="item2Txt">
            <a href="#" class="it1"><b>Хоботливый Чак,</b></a>  уход за 
                ним не требует мозгов.
            <p class="it2">от 30 грн.</p>
            <a href="#" class="it3">Заказать »</a> 
        </div>    
    </div>
        <div id="item3">
        <img src="../../Content/UnMomentoStyles/img/bearItem.gif" alt="Медвед" />
        <div id="item3Txt">
            <a href="#" class="it1"> <b>Педо-bear,</b></a>  лучший друг твой
                детко, кИсО. Сосёт только лапу. 
            <p class="it2">1,200 грн.</p>
            <a href="#" class="it3">Заказать »</a>
        </div>    
    </div>
    <div id="item4">
        <img src="../../Content/UnMomentoStyles/img/sheepClone.gif" alt="Овца клонированная" />
        <div id="item4Txt">
                        
            <a href="#" class="it1"> <b>Овца клонированная,</b></a>   пух и 
                прах. Мех, шах и мат. 
            <p class="it2">1,200 грн.</p>
            <a href="#" class="it3">Заказать »</a>
        </div>    
    </div> 
    <div style="clear:both"></div>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
                <p class="pgt1">1 ... <a href="#" class="pgt1">2</a> ... <a href="#" class="pgt1">3</a></p>
    </div>
</asp:Content>
