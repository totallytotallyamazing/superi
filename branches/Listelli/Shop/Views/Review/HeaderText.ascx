<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%if (Roles.IsUserInRole("Administrators"))
          { %>
          <div>
<%=Html.ActionLink("Редактировать", "Edit", "Review", new { id = 6, Area = "Admin" }, new { @class="adminLink"})%>
</div>
<%} %>


<%=ViewData["reviewHeaderText"]%>