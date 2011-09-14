<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Common.Master" Inherits="System.Web.Mvc.ViewPage<MBrand.Models2.Text>" %>
<%@ Import Namespace="MBrand.Helpers" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Title%>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $("#logo a").css("cursor", "default").click(function() { return false; });
    </script>
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("Редактировать", "Index", "Admin", null, new { @class = "adminLink" })%>
            <br /><br />
        </LoggedInTemplate>
    </asp:LoginView>
    

    <%= Model.Content%>
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	    <div class="millerStudio">
        <span class="studio">Студия рекламы и дизайна</span>
        <span class="ofMiller">Евгения Миллера</span>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="SeoCustomTextContainer" runat="server">
<% Html.RenderPartial("SeoText", Model.SeoCustomText ?? ""); %>
</asp:Content>
