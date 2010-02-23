<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Image>>" %>
<%@ Import Namespace="Oksi.Models" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%if (Model.Count() > 0){ %>
<% string id = "carousel_" + ViewData["galleryId"]; %>
  <ul id="<%= id %>" class="jcarousel-skin-tango">
<%foreach (var item in Model)
  {%>
    <li>
        <a href="/GalleryContent/<%= item.Picture %>" class="photoSession">
            <img alt="" src="/GalleryContent/<%= item.Preview %>" /> 
        </a>
    </li>  
  <%} %>
  </ul>
  <%} %>
  <% if(Request.IsAuthenticated){ %>
    <%= Html.ActionLink("+", "AddImage", "Admin", new { id = ViewData["galleryId"] }, new { @class="adminLink iframe big" })%>
  <%} %>