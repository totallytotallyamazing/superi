<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
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
</script>

<div id="calculationContainer">
    
</div>
