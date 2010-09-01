<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%if(WebSession.PaymentType.HasDocument){  %>
    <input type="button" value="<%= WebSession.PaymentType.DocumentCaption %>" id="printDocument" onclick="printDocument('<%= WebSession.PaymentType.DocumentName %>')" />
    <script type="text/javascript">
        function printDocument(documentName) {
            window.open("/Invoice/Show/" + documentName, "printDocument", "width=920,height=750,resizable=no,scrollbars=yes,status=no,toolbar=no,location=no"); 
        }
    </script>
<%} %>
