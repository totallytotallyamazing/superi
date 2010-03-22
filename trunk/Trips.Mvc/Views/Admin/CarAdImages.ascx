<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<long, IEnumerable<Trips.Mvc.Models.CarAdImage>>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<%@ Import Namespace="Trips.Mvc.Helpers" %>
<fieldset id="images">
    <legend>Фото</legend>
    <%
    KeyValuePair<long, IEnumerable<Trips.Mvc.Models.CarAdImage>> images = new KeyValuePair<long,IEnumerable<CarAdImage>>();
    foreach (KeyValuePair<long, IEnumerable<Trips.Mvc.Models.CarAdImage>> thing in Model)
	{
            images = thing;
	}
    bool isDefault = images.Value.Count() == 0;
    %>
    <%using (Html.BeginForm("SetDefaultImage", "Admin", FormMethod.Post, new { id="imagesForm"}))
      { %>
        <%= Html.Hidden("adId", images.Key)%>
        <% foreach (var item in images.Value)
           { %>
            <div class="carAddAdminImage">
                <%= Html.Image(GraphicsHelper.GetCachedImage("~/Content/AdImages", item.ImageSource, "thumbnail1"))%>
                <%= Html.ActionLink("[IMAGE]", "DeleteImage", new { id = item.Id }, new { @class= "deleteLink", onclick="return confirm('Вы уверены?')"})
                    .Replace("[IMAGE]", "") %>
                <input type="radio" name="defaultImage" value="<%= item.Id %>" <%= (item.Default)?"checked":"" %> />
            </div>    
        <% } %>
        <div class="clearBoth" id="setDefaultImage">
            <input type="submit" value="Установить фото по-умолчанию" />
        </div>
    <%} %>
<% using (Html.BeginForm("AddCarAdImage", "Admin", new { id = images.Key }, FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
    <%= Html.Hidden("carAdId", images.Key)%>
    <%= Html.Hidden("isDefault", isDefault)%>
    <div id="addMore">
        <p>Доббавить еще:</p>
        <input type="file" name="image" />
        <input type="submit" value="Добавить" />
    </div>
<%} %>
</fieldset>