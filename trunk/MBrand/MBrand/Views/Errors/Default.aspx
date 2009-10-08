<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Щасте	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="txt">
        <p>Поздравляю!</p>
        <span>Вы попали на Щасте.</span><br />
        Отошлите эту страницу десяти своим друзьям, и они тоже попадут на щасте.
    </div>
    
    <div id="mailMe">
        Обязательно <a href="mailto:m@m-brand.com.ua">напишите мне</a>, что поспособствовало появлению этой страницы. Спасибо. 
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
    <style type="text/css">
        #txt{font-size:20px; padding-top:130px;}
        #txt p{font-size:70px;}
        #txt span{font-size:50px;}
        
        #mailMe{padding-top:30px; color:Red;}
        #mailMe a{color:Red;}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    Щасте
</asp:Content>
