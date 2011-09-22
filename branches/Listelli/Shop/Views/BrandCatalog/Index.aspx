<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.BrandCatalogCategory>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Брендовые каталоги 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <% foreach (var item in Model) { %>
    <div class="brCatName">
                <%: item.Title %>
    </div>

            <%Html.RenderPartial("BrandCatalogFiles", item.BrandCatalogFile); %>
        
    <% } %>

    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
<link href="/Content/LislelliStyles/Designers.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" runat="server">
 <div id="headerTitle">
 <span class="sign1">Брендовые каталоги</span>
 
 </div>

 
 <div class="brandCatalogViewHeader">
 Все каталоги в pdf-формате
 </div>
 
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
