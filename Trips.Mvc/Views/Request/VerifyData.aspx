<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    3
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentBoxStep1">
        <br />
        <h2>
            <%= Html.ResourceString("VerifyYourData")%>:
        </h2>
        <br />
        <h3>
            <%= Html.ResourceString("CarsChosed") %>:
        </h3>
        <% Html.RenderPartial("ChosedCars"); %>
        <h3>
            <%= Html.ResourceString("Route") %>:&nbsp;&nbsp;&nbsp;  <span class="smallFont"><%= ViewData["route"] %></span>
        </h3>
        <br />
        <br />
        <h3>
            <%= Html.ResourceString("RouteAnnotation")%>:
        </h3>
        <div class="routeVerificationDetails">
            <%= ViewData["moreDetails"] %>
        </div>
        <h3>
            <%= Html.ResourceString("YourContactData")%>:
        </h3>
        <div class="routeVerificationDetails">
            <%= ViewData["contactsData"] %>
        </div>
    </div>
    
    <div class="doneContainer">
        <a href="/Request" class="startOver"></a>
        <a href="/Request/Send" class="done"></a>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Request.css" />
    <%= Ajax.DynamicCssInclude(string.Format("/Content/LocaleDependent/{0}/Request.css", Dev.Helpers.LocaleHelper.GetCultureName())) %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    3
</asp:Content>
