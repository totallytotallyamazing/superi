<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>

<script type="text/javascript">
    if (!showOrdershadowsDeclared) {
        $(function() {
            applyDropShadows("img.dealerLogoTop", "shadow3");
        })
        showOrdershadowsDeclared = true;
    }

    if (!fancyboxAttached) {
        $(function() {
            $(".dealerDeliveryDetails").fancybox({ frameWidth: 700, hideOnContentClick: false });
            $(".feedback").fancybox({ frameWidth: 700, hideOnContentClick: false });
        })
        fancyboxAttached = true;
    }
</script>

<div class="subHeaderCurrentDealer">
    <%= Html.Image("~/Image/ShowLogo/" + ViewData["dealerId"], new { @class = "dealerLogoTop" })%>
    <div style="clear: both">
        <%= Html.ResourceActionLink("Delivery", "DealerDeliveryDetails", "Dealer", new { id = ViewData["dealerId"] }, new { @class="dealerDeliveryDetails" })%>
        &nbsp;
        <%= Html.ResourceActionLink("Feedback", "Index", "Feedback", new { id = ViewData["dealerId"] }, new { @class="feedback" })%>
    </div>
</div>
