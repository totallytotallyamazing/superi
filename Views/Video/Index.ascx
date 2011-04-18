<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Clip>>" %>
<%@ Import Namespace="Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%
    var clip = Model.First();    
%>

<div id="video">
              <% if(Request.IsAuthenticated){ %>
            <%= Html.ActionLink("Редактировать", "Video", "Admin", null, new { @class = "adminLink" })%>
            <%} %>

    <div id="currentVideo">
        <div id="clipDetails">
            <h1><%= clip.Title %></h1>
            <p><%= clip.Description %></p>
        </div>
        <div id="clip">
  
        </div>
    </div>
    <div id="clipThumbnails">
        <% foreach (var item in Model){%>
            <div class="thumbnail"> 
                <%= Html.Image("http://img.youtube.com/vi/" + TextHelper.GetYoutubeId3(item.Source) + "/default.jpg") %>
                <p class="title"><%= item.Title %></p>
                <p class="clipComment"><%if(!string.IsNullOrEmpty(item.Comment)){ %> (<%= item.Comment %>)<%} %></p>
                <p class="clipYear"><%= item.Year %></p>
                <%= Html.Hidden("source_" + item.Id, item.Source) %>
                <p class="clipDescription" style="display:none">
                    <%= clip.Description %>
                </p>
            </div>
        <% } %>
        <div style="clear:both;"></div>
    </div>
</div>

<%= Ajax.Create("ClientLibrary.VideoExtender", new { id = "VideoManager" }, null, "pageExtender")%>
