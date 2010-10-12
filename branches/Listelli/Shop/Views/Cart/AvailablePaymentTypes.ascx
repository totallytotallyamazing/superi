<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.PaymentType>>" %>
<h2 class="cartPageTitle">Способ оплаты</h2>
<div class="options">
    <% bool first = true; %>
    <% foreach (var item in Model){%>
        <div>
            <%= Html.RadioButton("paymentType", item.Id, first) %> <%= item.Name %>
        </div>
    <% first = false; %>    
    <%} %>
</div>

<div id="paymentProperties">

</div>

<script type="text/javascript">
    function loadPaymentProperties(value) {
        $.get("/Cart/PaymentProperties/" + value, function(data) { $("#paymentProperties").html(data); });
    }
    function initPaymentTypesSelectros() {
        $("input[name='paymentType']").click(function() { loadPaymentProperties(this.value) });
        loadPaymentProperties($("input[name='paymentType']").get(0).value);
    }
</script>