<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%= Ajax.DynamicCssInclude("/Content/StartPage.css")%>

<% Html.RenderPartial("LatestVideo"); %>
<% Html.RenderAction<Oksi.Controllers.HomeController>(ac => ac.LatestNews()); %>
<% Html.RenderAction<Oksi.Controllers.HomeController>(ac=>ac.PhotoSession()); %>
<% Html.RenderPartial("RecentNews"); %>
