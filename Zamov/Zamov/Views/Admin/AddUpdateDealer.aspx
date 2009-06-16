<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Models" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddUpdateDealer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    Dealer dealer = null;
    if(ViewData["dealer"]!=null)
        dealer = (Dealer)ViewData["dealer"];

    string dealerName = "";
    string logoUrl = VirtualPathUtility.ToAbsolute("~/Comtent/img/noLogo");
    string russianName = "";
    string ukrainianName = "";
    string russianDescription = "";
    string ukrainianDescription = "";
    
    if (dealer != null)
    { 
        
    }
%>
    <h2>AddUpdateDealer</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
        
        <table class="adminTable">
            <tr>
                <th></th>
            </tr>
        </table>


    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

