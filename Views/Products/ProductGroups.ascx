<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Controllers" %>
<div class="menu">
    <div class="menuHeader">
        <%= Html.ResourceString("Groups") %>
    </div>
    <div class="menuItems">
        <% 
            int dealerId = Convert.ToInt32(ViewData["dealerId"]);
            int groupId = int.MinValue;
            if (ViewData["groupId"] != null)
                groupId = Convert.ToInt32(ViewData["groupId"]);
            using (ZamovStorage context = new ZamovStorage())
            {
                var groups = (from g in context.Groups.Include("Parent").Include("Groups") where g.Parent == null && g.Dealer.Id == dealerId select g);
                foreach (var g in groups)
                {
        %>
        <div class="menuItem">
            <%= Html.ActionLink(g.GetName(SystemSettings.CurrentLanguage), "Index", new {dealerId = dealerId, groupId = g.Id}) %>
        </div>
        <%
            if (g.Id == groupId || g.Groups.Where(gr=>gr.Id == groupId).Count()>0)
            {
                g.Groups.Load();
                foreach (var subGroup in g.Groups)
                {
        %>
        <div class="subMenuItem">
            <%= Html.ActionLink(subGroup.GetName(SystemSettings.CurrentLanguage), "Index", new {dealerId = dealerId, groupId = subGroup.Id}) %>
        </div>
        <%
            }

                }
        %>
        <% 
            }
            } 
        %>
    </div>
    <div class="menuFooter">
    </div>
</div>
