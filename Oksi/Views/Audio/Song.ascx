<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Song>" %>

<div class="song">
    <div class="songTitle" rel="<%= Model.Id %>">
        <%= Model.Title %>
    </div>
    <div class="player" rel="<%= Model.Id %>">
        
    </div>
</div>