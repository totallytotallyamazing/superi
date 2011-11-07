<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.ReviewContent>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% if (Roles.IsUserInRole("Administrators"))
       { %>
<%=Html.ActionLink("Добавить", "Add", "Review", new { Area = "Admin" }, new { @class="adminLink"})%>
<%} %>
    <table class="reviewThumbnailsTable">
    <tr>
    <% int cnt = 0;
        foreach (var item in Model.OrderBy(c=>c.SortOrder)) {
            
            if (cnt % 2 == 0)
            {
                %>
                </tr>
                <tr>
                <% 
            } 
            
             %>
    
        <td>
      <div class="reviewContent">
        <div class="image">
            <%=Html.CachedImage("~/Content/ReviewImages/", item.ImageSource, "reviewImagesThumb", item.ImageSource)%>
        </div>
        <div class="content">
        <% if (Roles.IsUserInRole("Administrators"))
       { %>
    <%=Html.ActionLink("Редактировать", "Edit", "Review", new { Area = "Admin",id=item.Id }, new { @class="adminLink"})%>
    <%=Html.ActionLink("Удалить", "Delete", "Review", new { Area = "Admin", id = item.Id }, new { @class = "adminLink", onclick = "return confirm('Удалить раздел?')" })%>
    <%} %>
        <div class="title">
        <%=Html.ActionLink(item.Title, "Details", "Review", new { id=item.Name},null)%>
        </div>
        <div class="description">
        <%=item.Description%>
        </div>
        </div>
        <div style="clear:both;"></div>
      </div>
     
    </td>
    <% cnt++;
        } %>
    </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

