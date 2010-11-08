<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <link href="/Content/UnMomentoStyles/products.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentTitle">
            <div id="contName">
                <div id="pageName">
                    <p class="txtPageName">
                        <%= ViewData["title"] %>
                    </p>            
                </div>
            </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if(Roles.IsUserInRole("Administrators")){ %>
        <p class="adminLink">
            <%= Html.ActionLink("редактировать", "Edit", "Content", new { area="Admin", id=ViewData["contentName"] }, null)%>
        </p>
    <%} %>
    <%= ViewData["text"] %>
    <div style="clear:both"></div>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="Footer">
<%--    <div id="pager">
                <p class="txtPager">1 ... <a href="#" class="txtPager">2</a> ... <a href="#" class="txtPager">3</a></p>
    </div>--%>
</asp:Content>
