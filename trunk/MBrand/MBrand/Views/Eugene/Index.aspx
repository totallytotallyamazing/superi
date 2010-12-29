<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Common.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MBrand.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Студия
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("Редактировать", "Eugene", "Admin", null, new { @class = "adminLink" })%>
            <br /><br />
        </LoggedInTemplate>
    </asp:LoginView>
    
    <%= Html.WriteText("Eugene")%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	Студия
</asp:Content>
