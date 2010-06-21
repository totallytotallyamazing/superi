<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Article>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    

    <% if(Model!=null)
           foreach (var item in Model)
           {
               Html.RenderPartial("Article", item);
           } %>
<div style="clear:both"></div>

    <p>
        <%= Html.ActionLink("Создать", "AddEdit", "Articles", new { area="Admin"}, null)%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
Новости
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Articles.css" />
</asp:Content>

