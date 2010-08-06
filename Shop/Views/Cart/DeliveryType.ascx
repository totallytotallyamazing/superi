<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>

<div id="deliveryTypes">
<% using(OrdersStorage context = new OrdersStorage()){
       var types = context.DeliveryTypes;
       bool first = true;
       foreach (var item in types)
           
       {%>
           <%= Html.RadioButton("deliveryType", item.Id, first) %> <%= item.Name %>
       <%
           first = false;
       }%>
<%} %>
</div>

<div id="paymentTypes">
</div>

<script type="text/javascript">
    $(function() {
        $("#deliveryTypes input[type='tadio']").click(function() {
            $.get("")
        });
    })
</script>