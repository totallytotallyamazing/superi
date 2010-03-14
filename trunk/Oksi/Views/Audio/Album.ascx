<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Album>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<div class="album">
    <div class="cover">
        <%= Html.Image("~/Cover/" + Model.Cover) %>
    </div>
    <div class="albumContent">
        <div class="title">
            <p>
                <%= Model.Title %>
            </p>
            <p class="year">
                <%= Model.Year %>
            </p>
        </div>
        <div class="songs">
            <% foreach (var item in Model.Songs.OrderBy(s=>s.TrackNumber)){%>
                <% Html.RenderPartial("Song", item); %>
            <%} %>
        </div>
    </div>
</div>