<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<div id="leftImageBox">
    <div>
        <%= Html.Image("/Content/decor/decor3Right.jpg")%>
    </div>
    <div style="padding-top:30px;">
        <%= Html.Image("/Content/decor/decor3Left.jpg")%>
    </div>
</div>