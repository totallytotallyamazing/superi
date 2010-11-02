<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/BrandCatalog/Views/Shared/Base.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <img src="/Content/LislelliStyles/img/BrandCatalogItem.png" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
<div id="titleBoxBrandCatalog">
<p><span class="txtPageName">KREOO</span> &nbsp&nbsp&nbsp&nbsp&nbsp<span class="txtDescription">Нидерландская компания, владелец одной из крупнейших в мире торговых сетей по продаже мебели</span> </p>
</div>
<div id="dock">
    <div class="dock-container">
        <a href='#' class="dock-item">
            <img src="/Content/LislelliStyles/img/dockItem1.gif" alt="dockItem1" />
        </a>
        <a href='#' class="dock-item">
            <img src="/Content/LislelliStyles/img/dockItem2.gif" alt="dockItem2" />
        </a>
        <a href='#' class="dock-item">
            <img src="/Content/LislelliStyles/img/dockItem3.gif" alt="dockItem3" />
        </a>
        <a href='#' class="dock-item">
            <img src="/Content/LislelliStyles/img/dockItem4.gif" alt="dockItem4" />
        </a>
        <a href='#' class="dock-item">
            <img src="/Content/LislelliStyles/img/dockItem5.gif" alt="dockItem5" />
        </a>
        <a href='#' class="dock-item">
            <img src="/Content/LislelliStyles/img/dockItem6.gif" alt="dockItem6" />
        </a>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
