<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<div>
    <%= Html.Image("~/Image/ShowLogo/" + ViewData["dealerId"]) %><br />
    <%= Html.ResourceActionLink("PickAnotherDealer", "Index", "Dealers") %>
</div>