<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Gallery>>" %>
<%@ Import Namespace="Oksi.Models" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>

<%--<%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
<%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js") %>--%>



&nbsp;
<% 
    int itemsCount = Model.Count();
    int i = 0;
    %>

    <% if(Request.IsAuthenticated){ %>
        <div class="adminAction">
            <%= Html.ActionLink("Добавить галерею", "AddEditGallery", "Admin", null, new { @class = "adminLink" })%>
        </div>
    <%} %>
    <% foreach (var item in Model) {
           i++;
    %>
    <div class="gallery">
        <div class="galleryTitle">
            <%= item.Name %>
        </div>
        <% 
            ViewData["galleryId"] = item.Id;
            Html.RenderPartial("Images", item.Images);
        %>
        <div class="galleryComments">
            <%= item.Comments %>
        </div>
        <%if (i < itemsCount - 1){ %>
            <div class="gallerySeparator"></div>
        <%} %>
    </div>
    <% if(Request.IsAuthenticated){ %>
        <div class="adminAction">
            <%= Html.ActionLink("Удалить", "DeleteGallery", "Admin", new { id=item.Id }, new { @class = "adminConfirmLink" })%>
        </div>
    <%} %>
    <% } %>
<%= Ajax.ScriptInclude("/Scripts/jquery.jcarousel.js")%>
<%= Ajax.Create("ClientLibrary.GalleryExtender", new { id = "GalleryManager", serializedIdArray = ViewData["serializedGalleriesId"] }, null, "pageExtender")%>
