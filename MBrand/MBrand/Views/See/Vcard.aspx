<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MBrand.Models.SeoContent>" %>
<%@ Import Namespace="MBrand.Models" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        » Фирменный стиль
    </h2>

    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("Редактировать SEO контент", "EditSeoContent", "Admin", new { worktype = (int)WorkType.Vcard, returnUrl = "Vcard" }, new { @class = "adminLink" })%>
            <br /><br />
        </LoggedInTemplate>
    </asp:LoginView>

    <div style="height:38px;"></div>
    <% Html.RenderPartial("Thumbnails"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    Портфолио
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="SeoCustomTextContainer" runat="server">
<% Html.RenderPartial("SeoText", Model.SeoCustomText ?? ""); %>
</asp:Content>
