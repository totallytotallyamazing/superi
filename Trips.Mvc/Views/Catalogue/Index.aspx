<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trips.Mvc.Models.Content>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%if(Request.IsAuthenticated){ %>  
        <table>
            <tr>
                <td>
                    <%= Html.ActionLink("Марки машин", "Brands", "Admin") %>
                </td>
                <td>
                    <%= Html.ActionLink("Добавить машину", "AddEditCarAd", "Admin") %>
                </td>
            </tr>
        </table>
        <div class="adminLink">
            <%= Html.ActionLink("Редактировать", "UpdateContent", "Admin", new { id=ViewData["id"]}, null)%>
        </div>
    <%} %>
    <% if (Model != null) Response.Write(Model.Text); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%if (Model != null) Response.Write(Model.Title); %>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="leftSide">
    <% Html.RenderPartial("AdsNavigator", ViewData["brandClasses"]); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <% if(Model != null){%>
        <meta name="Keywords" content="<%= Model.Keywords %>" />
        <meta name="Description" content="<%= Model.Description %>" />
    <%} %>
</asp:Content>