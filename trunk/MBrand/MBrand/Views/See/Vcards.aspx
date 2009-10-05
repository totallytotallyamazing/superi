<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Визитки
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="seeContainer">
        <% if(Request.IsAuthenticated){ %>
            <%= Html.ActionLink("Редактировать", "See", "Admin", new { type = "Vcard" }, null)%>
        <%} %>
    </div>
    <% Html.RenderPartial("SeeMenu"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    Посмотреть
</asp:Content>
