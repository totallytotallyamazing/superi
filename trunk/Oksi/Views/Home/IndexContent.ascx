<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%= Ajax.DynamicCssInclude("/Content/StartPage.css")%>

<% Html.RenderPartial("LatestVideo"); %>