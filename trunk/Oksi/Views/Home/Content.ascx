<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% if(Request.IsAuthenticated){ %>
    <div class="adminLink">
        <%= Html.ActionLink("Редактировать", "EditText", "Admin", new { id = "bio" }, new {@class = "contentEdit iframe" })%>
    </div>
    
    <script type="text/javascript">
        $(function() {
            $(".contentEdit").fancybox({
                modal: true,
                hideOnOverlayClick: false,
                hideOnContentClick: false,
                width: 700,
                height: 460,
                autoDimensions: false,
                autoScale: false,
                showCloseButton: true
            });
        });
    </script>
<%} %>

<%= ViewData["text"] %>