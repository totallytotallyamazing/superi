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
    <div class="sOrderContaider"> <%=Model.SortOrder %></div>
   
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
           <div class="sOrderContaider"> <%=Model.SortOrder %></div>
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
 <%if (Roles.IsUserInRole("Administrators"))
{ %>
<%=Html.ActionLink("Добавить изображение", "AddReviewContentItemImage", "Review",
                                      new
                                          {
                                              Area = "Admin",
                                              reviewContentId = ViewData["reviewContentId"],
                                              reviewContentItemId = Model.Id
                                          }, new {@class = "adminLink"})%>

<%=Html.ActionLink("Редактировать", "EditReviewConentItem", "Review", new { id = Model.Id, Area = "Admin" }, new { @class = "adminLink" })%>&nbsp;

                                           <div class="sOrderContaider"> <%=Model.SortOrder %></div>

<% } %>
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
        <a rel="group<%=Model.Id%>" href="../../Content/ReviewImages/<%=image.ImageSource%>" class="fancy">
        <%= Html.CachedImage("~/Content/ReviewImages/", image.ImageSource, "reviewImagesDetailsThumb", image.ImageSource)%>
        </a>
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
