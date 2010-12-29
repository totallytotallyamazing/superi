<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Common.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MBrand.Helpers" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Студия рекламы и дизайна Евгения Миллера
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
    
    <%= Html.WriteText("Index")%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	    <div class="millerStudio">
        <span class="studio">Студия рекламы и дизайна</span>
        <span class="ofMiller">Евгения Миллера</span>
    </div>
</asp:Content>
