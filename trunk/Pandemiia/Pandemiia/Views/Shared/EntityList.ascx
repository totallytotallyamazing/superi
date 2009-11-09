<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<Pandemiia.Models.Entity>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Pandemiia.Controllers" %>
<div class="goBottomContainer" id="topContainer">
    <center>
        <a href="#bottomContainer" class="goBottom">
        </a>
    </center>
</div>
<% foreach (var item in Model) { %>
    <% Html.RenderAction<HomeController>(hc => hc.Entity(item)); %>
<% } %>
<div class="goTopContainer" id="bottomContainer">
    <center>
        <a href="#header" class="goTop">
        </a>
    </center>
</div>