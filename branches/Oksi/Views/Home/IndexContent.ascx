<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%= Ajax.DynamicCssInclude("/Content/StartPage.css")%>

<% Html.RenderAction<Oksi.Controllers.HomeController>(ac=>ac.LatestVideo()); %>
<% Html.RenderAction<Oksi.Controllers.HomeController>(ac => ac.LatestNews()); %>
<% Html.RenderAction<Oksi.Controllers.HomeController>(ac => ac.PhotoSession()); %>
<% Html.RenderAction<Oksi.Controllers.HomeController>(ac => ac.RecentNews()); %>
