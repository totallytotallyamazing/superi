<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="PolialClean.Models" %>
<%@ Import Namespace="PolialClean.Controllers" %>
<% 
    int contentId = Convert.ToInt32(ViewData["contentId"]);    
    string[] subMenuItems = null;
    using (DataStorage context = new DataStorage())
    {
        SiteContent siteContent = Utils.GetText(contentId);
        
        List<SiteContent> items = (from content in context.SiteContent
                                   where (content.ParentId != null && content.ParentId == siteContent.ParentId)
                                    || content.ParentId == contentId
                                    select content).ToList();
        
        subMenuItems = (from content in items
                            select Html.ActionLink(content.Name,
                            "Index",
                            ViewContext.RouteData.Values["controller"].ToString(),
                            new { contentName = content.Name },
                            new { @class = (content.Id == contentId) ? "subMenuActive" : "" })).ToArray();
    }

    string itemsHtml = string.Join("&nbsp;| ", subMenuItems);
%>
<div class="subMenu">
    <%= itemsHtml %>
</div>
