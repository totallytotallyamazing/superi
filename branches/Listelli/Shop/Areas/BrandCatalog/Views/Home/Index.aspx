<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/BrandCatalog/Views/Shared/Base.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Галерея Брендов
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <img src="/Content/LislelliStyles/img/bkgMainContentBrandCatalog.gif" alt="" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
<div id="dockItems">
    <div id="titleBoxBrandCatalog">
        <p>
            <span class="txtPageName">Здравствуйте!</span> &nbsp&nbsp&nbsp&nbsp&nbsp
            <span class="txtDescription">Просмотреть каталог бренда можно, выбрав категорию товаров бренда в меню выше</span> 
        </p>
    </div>
    <div id="thumbnails" style="display:none">
    <div id="leftArrow"></div>
    <div id="rightArrow"></div>
    <div id="dockWrapper">
    
    </div>
    </div>
</div>
</asp:Content>