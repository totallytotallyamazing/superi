<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Регистрация завершена
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Спасибо за регистрацию</h2>

    <div style="margin-top: 20px;">
    Адрес созданного пользователя: <a href="http://listelli.ua/to/<%=ViewData["url"]%>">http://listelli.ua/to/<%=ViewData["url"]%></a> 
    <br />
    <span style="color:Red; font-size:11px;">*будет доступен после заполнения информации о дизайнере</span>
    <br/><br/>
    Вход в админку портфолио: <a href="http://www.listelli.ua/to/login">http://www.listelli.ua/to/login</a>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
