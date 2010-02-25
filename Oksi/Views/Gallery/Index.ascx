<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Gallery>>" %>
<%@ Import Namespace="Oksi.Models" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>

<%--<%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
<%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js") %>--%>

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
           Html.RenderPartial("Gallery", item);
        if (i < itemsCount){
            Response.Write("<div class=\"gallerySeparator\"></div>");
        } 
     } %>
<%= Ajax.Create("ClientLibrary.GalleryExtender", new { id = "GalleryManager", serializedIdArray = ViewData["serializedGalleriesId"] }, null, "pageExtender")%>
