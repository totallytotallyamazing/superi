<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<script type="text/javascript">
    $(function() { applyDropShadows("img.dealerLogoTop", "shadow3"); })
</script>
<div class="subHeaderCurrentDealer">
    <%= Html.Image("~/Image/ShowLogo/" + ViewData["dealerId"], new { @class = "dealerLogoTop" })%>
    <div style="clear:both">
        <%= Html.ResourceActionLink("PickAnotherDealer", "Index", "Dealers") %>
    </div>
</div>