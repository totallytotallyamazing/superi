<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MBrand.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	�������
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("�������������", "Clients", "Admin") %>
            <br /><br />
        </LoggedInTemplate>
    </asp:LoginView>
    
    <%= Html.WriteText("Clients") %>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	�������
</asp:Content>
