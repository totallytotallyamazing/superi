<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<div id="leftImageBox">
    <div style="padding-top:130px;">
        <%= Html.Image("/Content/Decor/decor1Right.jpg")%>
    </div>
    <div>
        <%= Html.Image("/Content/Decor/decor1Left.jpg")%>
    </div>
</div>