<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Clip>>" %>
<%@ Import Namespace="Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%
    var clip = Model.First();    
%>
<div id="video">
    <div id="currentVideo">
        <div id="clipDetails">
            <h1><%= clip.Title %></h1>
            <p><%= clip.Description %></p>
        </div>
        <div id="clip">
            <%= clip.Source %>
        </div>
    </div>
    <div id="clipThumbnails">
        <% foreach (var item in Model.Skip(1)){%>
            <div class="thumbnail"> 
                <%= Html.Image("http://img.youtube.com/vi/" + TextHelper.GetYoutubeId(item.Source) + "/default.jpg") %>
                <p><%= item.Title %></p>
                <p>(<%= item.Comment %>)</p>
                <p><%= item.Year %></p>
            </div>
        <% } %>
    </div>
</div>

<%= Ajax.Create("ClientLibrary.VideoExtender", new { id = "VideoManager" }, null, "pageExtender")%>
