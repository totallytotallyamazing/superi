<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Album>>" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>

<% foreach (var item in Model)
   {
       Html.RenderPartial("Album", item);
   } %>
   
<%= Ajax.Create("ClientLibrary.AlbumExtender", new { id = "AlbumManager" }, null, "pageExtender")%>
