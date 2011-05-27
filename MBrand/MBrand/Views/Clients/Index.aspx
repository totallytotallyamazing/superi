<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Common.Master" Inherits="System.Web.Mvc.ViewPage<MBrand.Models.Text>" %>
<%@ Import Namespace="MBrand.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Title%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("Редактировать", "Clients", "Admin", null, new { @class = "adminLink" })%>
            <br /><br />
        </LoggedInTemplate>
    </asp:LoginView>
    
    <%= Model.Content%>
   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	Клиенты
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SeoCustomTextContainer" runat="server">
<% Html.RenderPartial("SeoText", Model.SeoCustomText ?? ""); %>
</asp:Content>

