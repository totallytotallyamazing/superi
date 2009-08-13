<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DealerPresentation>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="subHeader">
        <% Html.RenderPartial("CurrentDealer"); %>
    </div>
    
    <div style="margin-top:20px;">
        <%= Model.Description %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/shadows.css")%>
    <%= Html.RegisterJS("dropshadow.js")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
<%
    using(ZamovStorage context = new ZamovStorage())
    {
        string modelId = Model.Id.ToString();

        var items = (from g in context.Groups.Include("Parent")
                     join translation in context.Translations on g.Id equals translation.ItemId
                     where translation.Language == Zamov.Controllers.SystemSettings.CurrentLanguage
                     && translation.TranslationItemTypeId == (int)ItemTypes.Group
                     && g.Enabled
                     && g.Parent == null
                     select new GroupResentation { Name = translation.Text, Id = g.Id }
                     );
        List<SelectListItem> menuItems = new List<SelectListItem>();
        foreach (var item in items)
        {
            menuItems.Add(new SelectListItem { Text = item.Name, Value = "/Products/" + Model.Id + "/" + item.Id });
        }
        Html.RenderAction<Zamov.Controllers.PagePartsController>(ac => ac.LeftMenu(Html.ResourceString("Groups"), menuItems));
    }
%>
</asp:Content>
