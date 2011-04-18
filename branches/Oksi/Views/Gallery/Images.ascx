<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Image>>" %>
<%@ Import Namespace="Oksi.Models" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%if (Model.Count() > 0){ %>
<% string id = "carousel_" + ViewData["galleryId"]; %>
  <ul class="jcarousel-skin-tango" id="<%= id %>" >
<%foreach (var item in Model)
  {%>
    <li>
        <a href="/GalleryContent/<%= item.Picture %>" rel="<%= "images_" + ViewData["galleryId"] %>" class="photoSession">
            <img rel="<%= item.Id %>" alt="" src="/GalleryContent/<%= item.Preview %>" /> 
        </a>
    </li>  
  <%} %>
  </ul>
  <%} %>
  <% if(Request.IsAuthenticated){ %>
    <%= Html.ActionLink("+", "AddImage", "Admin", new { id = ViewData["galleryId"] }, new { @class="adminLink iframe big" })%>
    
    <div id="imageDeleteFrame">
        <a href="/Admin/DeleteImage/[id]" class="adminConfirmLink">Удалить</a>
    </div>
  <%} %>