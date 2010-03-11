<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Image>>" %>
<%@ Import Namespace="Oksi.Models" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%= Ajax.Create("ClientLibrary.PhotoSessionExtender", new { id = "PageManager" }, null, "pageExtender")%>

<div id="photoSession">
    <div id="sessionTitle">
        <%= Html.ActionLink((string)ViewData["name"], "Index", "Gallery", null, new { rel = "async" })%>
    </div>
    <div id="sessionSubTitle">
        <%= ViewData["comments"]%>
    </div>
    <div id="photos">
        <% foreach (var item in Model){%>
            <a rel="<%= "images_" + ViewData["galleryId"] %>" href="/GalleryContent/<%= item.Picture %>" class="photoSession">
                <img src="/GalleryContent/<%= item.Preview %>" alt="" style="width:139px" />
            </a>
        <%}%>
    </div>
    <div id="morePhoto">
        <a href="/Gallery" rel="async">еще фото</a>
    </div>
</div>