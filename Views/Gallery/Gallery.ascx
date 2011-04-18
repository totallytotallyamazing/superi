<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Gallery>" %>
<%@ Import Namespace="Oksi.Models" %>

    <div class="gallery">
        <div class="galleryTitle">
            <%= Model.Name %>
                <% if(Request.IsAuthenticated){ %>
            <%= Html.ActionLink("Редактировать", "AddEditGallery", "Admin", new { id = Model.Id }, new { @class = "adminLink" })%>
            <%} %>

        </div>
        <% 
            ViewData["galleryId"] = Model.Id;
            Html.RenderPartial("Images", Model.Images);
        %>
        <div class="galleryComments">
            <%= Model.Comments.Replace(Environment.NewLine, "<br />")%>
        </div>
            <% if(Request.IsAuthenticated){ %>
        <div class="adminAction">
            <%= Html.ActionLink("Удалить", "DeleteGallery", "Admin", new { id = Model.Id }, new { @class = "adminConfirmLink" })%>
        </div>
    <%} %>

    </div>