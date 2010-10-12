<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>
<div id="deliveryTypes">
    <h2 class="cartPageTitle">Вид доставки:</h2>
    <div class="options">
        <% using(OrdersStorage context = new OrdersStorage()){
               var types = context.DeliveryTypes;
               bool first = true;
               foreach (var item in types)
                   
               {%>
                    <div>
                        <%= Html.RadioButton("deliveryType", item.Id, first) %> <%= item.Name %>
                    </div>
               <%
                   first = false;
               }%>
        <%} %>
    </div>    
</div>

<div id="paymentTypes">
</div>

<script type="text/javascript">
    function loadPaymentTypes(value) {
        $.get("/Cart/AvailablePaymentTypes/" + value, function(data) { $("#paymentTypes").html(data); initPaymentTypesSelectros(); });
    }
    $(function() {
        $("#deliveryTypes input[type='radio']").click(function() {
            loadPaymentTypes(this.value);
        });
        loadPaymentTypes($("#deliveryTypes input[type='radio']").get(0).value);
    })
</script>