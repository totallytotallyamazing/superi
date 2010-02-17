<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Gallery>>" %>
<%@ Import Namespace="Oksi.Models" %>

<% 
    int itemsCount = Model.Count();
    int i = 0;
    %>

    <% foreach (var item in Model) {
           i++;
    %>
    <div class="gallery">
        <div class="galleryTitle">
            <%= item.Name %>
        </div>
        <% 
           using(DataStorage context = new DataStorage())
           {
               var images = context.Images.Where(img => img.GalleryId == item.Id).Select(img => img);
               Html.RenderPartial("Images", images);
           }
        %>
        <div class="galleryComments">
            <%= item.Comments %>
        </div>
        <%if (i < itemsCount - 1){ %>
            <div class="gallerySeparator"></div>
        <%} %>
    </div>
    <% } %>
