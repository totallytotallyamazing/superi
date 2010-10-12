<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%@ Import Namespace="Shop.Models" %>
<% if(Roles.IsUserInRole("Administrators")){ %>
<p class="adminLink">
    <%= Html.ActionLink("Редактировать", "EditPartial", new { area = "Admin", controller = "Content", id = Model }, new { @class = "iframe editContentLink" })%>
</p>
<%} %>
<% 
    using (ContentStorage context = new ContentStorage())
    {
        Shop.Models.Content content = context.Contents.First(c => c.Name == Model);
        Response.Write(content.Text);
    }
%>