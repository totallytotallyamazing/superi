<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Products/Products.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
 <div id="contName">
                <div id="pageName">
                    <p class="txtPageName"><%= ViewData["title"] %></p>            
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
    <link href="/Content/LislelliStyles/products.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">


        $(function () {
            ProductClientExtensions.bindFancy();
        })    
    </script>
</asp:Content>

<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
                <p class="txtPager">1 ... <a href="#" class="txtPager">2</a> ... <a href="#" class="txtPager">3</a></p>
    </div>
</asp:Content>
