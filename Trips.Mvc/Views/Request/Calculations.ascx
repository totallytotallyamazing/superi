<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    var currency = { euro:0, dollar:1, ruble:2 };

    var requestTimeOut;

    function loadCalculationData() {
        var fromCityId = $("#fromCityId").val();
        var toCityId = $("#toCityId").val();
        var requestPath = "/Request/RoutesData?fromCityId=" + fromCityId + "&toCityId=" + toCityId;
        $("#calculationContainer").load(requestPath);
    }

    $(function() {
        $("#toCity").keyup(function() {
            requestTimeOut = window.setTimeout(loadCalculationData, 2000);
        })

        $("#toCity").change(function() {
            $("#toCityId").val("");
            window.clearTimeout(requestTimeOut);
            window.setTimeout(loadCalculationData, 200);
        })
        $("#fromCityId").change(function() {
            loadCalculationData();
        });
    })

    function recalculateIn(curr, priceId, placeholder) {
        var price = $("#" + priceId).val() * 1;
        var rate = 0;
        switch (curr) {
            case currency.euro:
                rate = euroRate;
                break;
            case currency.dollar:
                rate = dollarRate;
                break;
            case currency.ruble:
                rate = rubleRate;
                break;
        }
        var result = price * rate;
        $("#" + placeholder).html(result);
    }
</script>

<%= ViewData["script"] %>

<div id="calculationContainer">
    
</div>
