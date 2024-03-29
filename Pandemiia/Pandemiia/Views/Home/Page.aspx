<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Pandemiia.Models.Entity>>" %>
<%@ Import Namespace="Pandemiia.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Pandemiia.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pandemic
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalStylesContent" runat="server">
    <%= Html.RegisterCss("~/Content/entityList.css") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderAction<HomeController>(hc => hc.EntityList(Model));%>
    <div class="pages">
        <%  int entityCount = Convert.ToInt32(ViewData["entityCount"]);
            int pageNumber = Convert.ToInt32(ViewData["pageNumber"]);
            %>
        <% Html.RenderAction<PagePartsController>(ac => ac.Pager(entityCount, pageNumber, "", "", null)); %>
    </div>
</asp:Content>


