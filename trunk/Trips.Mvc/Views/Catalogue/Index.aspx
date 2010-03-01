<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
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
    <%} %>
    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="leftSide">
    <% Html.RenderPartial("AdsNavigator", ViewData["brandClasses"]); %>
</asp:Content>