<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<long, IEnumerable<Trips.Mvc.Models.CarAdImage>>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<%@ Import Namespace="Trips.Mvc.Helpers" %>
    <%
    KeyValuePair<long, IEnumerable<Trips.Mvc.Models.CarAdImage>> images = new KeyValuePair<long,IEnumerable<CarAdImage>>();
    foreach (KeyValuePair<long, IEnumerable<Trips.Mvc.Models.CarAdImage>> thing in Model)
	{
            images = thing;
	}
    %>

    <% foreach (var item in images.Value){ %>
        <div class="carAddAdminImage">
            <%= Html.ActionLink("Удалить", "DeleteImage", new {id= item.Id})%>
            <%= Html.Image(GraphicsHelper.GetCachedImage("~/Content/AdImages", item.ImageSource, "thumbnail1")) %>
        </div>    
    <% } %>
    
<% using (Html.BeginForm("AddCarAdImage", "Admin", new { id = images.Key }, FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
    <input type="file" name="image" />
    <input type="submit" value="Добавить" />
<%} %>