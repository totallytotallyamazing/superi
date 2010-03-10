<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Установки сайта
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using(Html.BeginForm()){ %>
        <h6>
            <label for="euroRate">
               Евро за гривну:
            </label>
        </h6>
        <%= Html.TextBox("euroRate") %>
        <br />
        <h6>
            <label for="dollarRate">
               Долларов за гривну:
            </label>
        </h6>
        <%= Html.TextBox("dollarRate")%>
        <br />
        <h6>
            <label for="rubleRate">
               Рублей за гривну:
            </label>
        </h6>
        <%= Html.TextBox("rubleRate")%>
        <br />
        <h6>
            <label for="receiverMail">
               Эл. почта получателя уведомлений:
            </label>
        </h6>
        <%= Html.TextBox("receiverMail")%>
        <br />
        <h6>
            <label for="pageSize">
               Машин на странице:
            </label>
        </h6>
        <%= Html.TextBox("pageSize")%>
        <br />
        <input type="submit" value="Сохранить" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    Установки сайта
</asp:Content>
