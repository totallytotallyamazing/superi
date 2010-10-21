<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <link href="/Content/UnMomentoStyles/products.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentTitle">
            <div id="contName">
                <%--<div id="pagePic">
                    <img src="../../Content/UnMomentoStyles/img/bear.gif" alt="Медведь" />     
                </div>--%>            
                <div id="pageName">
                    <p class="txtPageName">Listelli <span class="pt2" ><%--страница 1--%></span> </p>            
                </div>
            </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%  Html.RenderPartial("ContentPartial", "MainTop"); %>
    <div style="clear:both"></div>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
                <p class="pgt1">1 ... <a href="#" class="pgt1">2</a> ... <a href="#" class="pgt1">3</a></p>
    </div>
</asp:Content>
