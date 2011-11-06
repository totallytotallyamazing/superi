<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ReviewContentItem>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%if (Model.ContentType == 1)
  {
%>
<%if (Roles.IsUserInRole("Administrators"))
  { %>
<div>
    <%=Html.ActionLink("Редактировать", "EditReviewConentItem", "Review", new { id = Model.Id, Area = "Admin" }, new { @class = "adminLink" })%>&nbsp;
    <%=Html.ActionLink("Удалить", "DeleteReviewContentItem", "Review", new { id = Model.Id, contentId = ViewData["reviewContentId"],Area="Admin" }, new { @class = "adminLink", onclick = "return confirm('Удалить блок?')" })%>
</div>
<% } %>
<%=Model.Text%>
<%
  }
  else if (Model.ContentType == 2)
  {
%>
<div class="customBlock">
    <div class="customBlockTop">
    </div>
    <div class="customBlockContent">
        <%if (Roles.IsUserInRole("Administrators"))
          { %>
        <div>
            <%=Html.ActionLink("Редактировать", "EditReviewConentItem", "Review", new { id = Model.Id, Area = "Admin" }, new { @class = "adminLink" })%>&nbsp;
            <%=Html.ActionLink("Удалить", "DeleteReviewContentItem", "Review", new { id = Model.Id, contentId = ViewData["reviewContentId"],Area="Admin" }, new { @class = "adminLink", onclick = "return confirm('Удалить блок?')" })%>
        </div>
        <% } %>
        <%=Model.Text%>
    </div>
    <div class="customBlockBottom">
    </div>
</div>
<%
  }
  else
  {
%>
<%=Html.ActionLink("Добавить изображение", "AddReviewContentItemImage", "Review", new { Area = "Admin", reviewContentId = ViewData["reviewContentId"], reviewContentItemId = Model.Id }, new { @class = "adminLink" })%>
<div class="reviewDetailsImages">
    <%
      
      if (Model.ReviewContentItemImages.Count() > 0)
      {
          foreach (var image in Model.ReviewContentItemImages)
          {
    %>
    <div class="reviewDetailsImage">
        <%if (Roles.IsUserInRole("Administrators"))
          { %>
        <div>
            <%=Html.ActionLink("Удалить", "DeleteReviewContentItemImage", "Review", new { id = image.Id, contentId = ViewData["reviewContentId"],Area="Admin" }, new { @class = "adminLink", onclick = "return confirm('Удалить изображение?')" })%>
        </div>
        <% } %>
        <%= Html.CachedImage("~/Content/ReviewImages/", image.ImageSource, "reviewImagesDetailsThumb", image.ImageSource)%>
    </div>
    <%
          }
      }
    %>
    <div style="clear: both;">
    </div>
</div>
<%
  }
%>
