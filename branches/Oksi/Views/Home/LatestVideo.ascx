<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Clip>" %>

<div id="latestVideo">
    <div id="videoTitle"> 
        Последняя видео работа.
    </div>
    <div id="videoInfo">
        <%= Model.Title %>
        <%= Model.Description %>
    </div>
    <div id="videoPlayer">
        <%= Model.SmallSource %>
    </div>
</div>