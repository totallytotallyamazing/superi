<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<GroupResentation>>" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Controllers" %>
<% 
    int dealerId = Convert.ToInt32(ViewData["dealerId"]);
    int groupToExpand = Convert.ToInt32(ViewData["groupToExpand"]);
    int groupId = (ViewData["groupId"] != null) ? Convert.ToInt32(ViewData["groupId"]) : int.MinValue;
%>
<div class="menu">
    <div class="menuHeader">
        <%= Html.ResourceString("Groups") %>
    </div>
    <div class="menuItems">
        <% foreach (GroupResentation item in Model)
           {%>
        <div class="menuItem">
            <%= Html.ActionLink(item.Name, "Index", new { dealerId = dealerId, groupId = item.Id }, new { @class = (item.Id == groupId || item.Id == groupToExpand) ? "active" : string.Empty })%>
        </div>
        <%      if (item.Id == groupToExpand)
                {
                    List<GroupResentation> subGroups = item.Children;
                    if (subGroups.Count > 0)
                        Response.Write(
                            Html.TreeView("productGroups", subGroups, sg => sg.Children, sg =>
                            {
                                string format = "<div class=\"subMenuItem\">{0}</div>";
                                
                                return string.Format(
                                    format, 
                                    Html.ActionLink(
                                    sg.Name, 
                                    "Index", new 
                                    { 
                                        dealerId = dealerId, 
                                        groupId = sg.Id 
                                    }, 
                                    new 
                                    { 
                                        @class = (sg.Id == groupId || sg.Id == groupToExpand) ? "active" : string.Empty 
                                    }));
                            })
                            );
                }
        %>
        <% } %>
    </div>
    <div class="menuFooter">
    </div>
</div>