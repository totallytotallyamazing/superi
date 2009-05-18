<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Pandemiia.Models.Entity>" %>
<%@ Import Namespace="Pandemiia.Models" %>
<% foreach(EntityVideo video in Model.EntityVideos){ %>
    <div class="video">
        <%= video.Source %><br />
        <%= video.Name %>
    </div>
<%} %>