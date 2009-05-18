<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<Pandemiia.Models.Entity>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Pandemiia.Controllers" %>

<% foreach (var item in Model) { %>
    <% Html.RenderAction<HomeController>(hc => hc.Entity(item)); %>
<% } %>
