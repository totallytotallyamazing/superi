<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Products/Products.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
 <div id="contName">
                <div id="pagePic">
                    <img src="../../Content/UnMomentoStyles/img/bear.gif" alt="Медведь" />     
                </div>            
                <div id="pageName">
                    <p class="pt1"><%= ViewData["title"] %>, <span class="pt2" >страница 1</span> </p>            
                </div>
            </div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if(Roles.IsUserInRole("Administrators") && ViewData["tags"] == null){ %>
        <% Html.RenderPartial("CategoriesAdmin"); %>
    <%} %>
    <% if(Model!=null)
           foreach (var item in Model)
           {
               Html.RenderPartial("Product", item);
           } %>
           <div style="clear:both"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/catalog.css" />
</asp:Content>

<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
                <p class="pgt1">1 ... <a href="#" class="pgt1">2</a> ... <a href="#" class="pgt1">3</a></p>
            </div>
</asp:Content>
