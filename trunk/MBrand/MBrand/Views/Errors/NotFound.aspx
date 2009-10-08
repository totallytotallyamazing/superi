<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Такой страницы нет
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="txt">
        <p>
            Стоп.
        </p>
        <span>
            Такой страницы нет.
        </span><br />
        Попробуйте нажать на одну из ссылок внизу слева.
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
    <style type="text/css">
        #txt{font-size:18px; padding-top:130px;}
        #txt span{font-size:50px;}
        #txt p{font-size:75px;}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    404
</asp:Content>
