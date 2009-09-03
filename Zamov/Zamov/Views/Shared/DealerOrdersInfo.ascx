<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
        $(function() {
            //queryOrders();
            setInterval(queryOrders, 30000);
        });



        function queryOrders() {
            var lastRequestTime = new Date();
            var webRequest = Sys.Net.WebServiceProxy.invoke(
            "/Services/Tools.asmx",
            "GetNewOrders",
            false,
            { requestTime: lastRequestTime },
            function(response) {
                if (response && response.length > 0) {
                    alert('<%= Html.ResourceString("YouHaveNewOrder") %>');
                }
                if (typeof (updateOrdersTable) !== "undefined")
                    updateOrdersTable(response);
            },
            failureCallback);
        }
</script>