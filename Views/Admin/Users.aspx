<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUserCollection>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.ResourceString("Users") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.ResourceString("Users") %></h2>
    <br />
    
    <table class="adminTable">
        <tr>
            <th><%= Html.ResourceString("Username")%></th>
            <th><%= Html.ResourceString("FirstName")%></th>
            <th><%= Html.ResourceString("LastName")%></th>
            <th><%= Html.ResourceString("Manager") %></th>
            <th><%= Html.ResourceString("Dealer") %></th>
            <th></th>
        </tr>
        <tr>
            <%
                foreach (MembershipUser user in Model)
                {
                    Html.RenderAction<AdminController>(ac=>ac.UserDetails(user));
                }    
            %>
        </tr>
    </table>
        
</asp:Content>