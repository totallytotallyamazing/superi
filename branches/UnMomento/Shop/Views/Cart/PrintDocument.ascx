<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%if(WebSession.PaymentType.HasDocument){  %>
    <input type="button" value="<%= WebSession.PaymentType.DocumentCaption %>" id="printDocument" onclick="printDocument('<%= WebSession.PaymentType.DocumentName %>', <%= WebSession.Order.Id %>, '<%= WebSession.Order.UniqueId %>')" />
    <script type="text/javascript">
        function printDocument(documentName, id, uniqueId) {
            window.open("/Invoice/Show/" + documentName + "?orderId=" + id + "&uniqueId=" + uniqueId, "printDocument", "width=920,height=750,resizable=no,scrollbars=yes,status=no,toolbar=no,location=no"); 
        }
    </script>
<%} %>