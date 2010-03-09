<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    function loadCalculationData() {
        var fromCityId = $("#fromCityId").val();
        var toCityId = $("#toCityId").val();
        debugger;
        var requestPath = "/Request/RouteData?fromCityId=" + fromCityId + "&toCityId=" + toCityId;
        $("#calculationContainer").load(requestPath);
    }

    $(function() {
    $("#toCity").change(function() {
            window.setTimeout(loadCalculationData, 200);
        })
    })
</script>

<div id="calculationContainer">
    
</div>
