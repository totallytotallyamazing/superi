<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Album>>" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%= Ajax.Create("ClientLibrary.AlbumExtender", null, null, "pageExtender")%>

<% foreach (var item in Model)
   {
       Html.RenderPartial("Album", item);
   } %>