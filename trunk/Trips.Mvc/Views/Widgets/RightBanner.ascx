<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<div id="mapBox">
    <%= Html.ActionLink("[IMAGE]", "Index", "Request", null, null)
                    .Replace("[IMAGE]", Html.Image((string)ViewData["url"]))%>
</div>