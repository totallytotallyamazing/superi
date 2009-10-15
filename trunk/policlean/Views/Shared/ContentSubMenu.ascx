<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="PolialClean.Models" %>
<%@ Import Namespace="PolialClean.Controllers" %>
<% 
    int contentId = Convert.ToInt32(ViewData["contentId"]);    
    string[] subMenuItems = null;
    string thirdLevelMenu = null;
    using (DataStorage context = new DataStorage())
    {
        SiteContent siteContent = context.SiteContent.Where(c => c.Id == contentId).Select(c => c).FirstOrDefault();
        siteContent.ParentReference.Load();

        bool rootElement = siteContent.Parent == null;
        bool secondLevel = false;
        bool thirdLevel = false;
        
        if(!rootElement)
        {
            siteContent.Parent.ParentReference.Load();
            secondLevel = siteContent.Parent.Parent == null;
            thirdLevel = !secondLevel;
        }
        
        int? parentId = (siteContent.Parent != null) ? (int?)siteContent.Parent.Id : null;
        
        List<SiteContent> items = (from content in context.SiteContent.Include("Parent")
                                   where (rootElement && content.Parent.Id == contentId)
                                   || (secondLevel && content.Parent.Id == parentId)
                                   select content).ToList();
        
        if(thirdLevel)
        {
            siteContent.Parent.Parent.Children.Load();
            items = siteContent.Parent.Parent.Children.OrderBy(c=>c.Id).ToList();
        }
        
        subMenuItems = (from content in items
                            select Html.ActionLink(content.Name,
                            "Index",
                            ViewContext.RouteData.Values["controller"].ToString(),
                            new { contentName = content.Name },
                            new { @class = (content.Id == contentId || (thirdLevel && content.Id==siteContent.Parent.Id )) ? "subMenuActive" : "" })).ToArray();

        if (!rootElement)
        {
            string[] thirdLevelItems = null;
            siteContent.Children.Load();
            if (siteContent.Children.Count > 0)
            {
                thirdLevelItems = (from item in siteContent.Children.OrderBy(c=>c.Id)
                                            select Html.ActionLink(
                                            item.Name,
                                            "Index",
                                            ViewContext.RouteData.Values["controller"].ToString(),
                                            new { contentName = item.Name },
                                            new { @class = (item.Id == contentId) ? "thirdLevelMenuActive" : "" })).ToArray();
                thirdLevelMenu = string.Join("<br />", thirdLevelItems);
            }
            else if (thirdLevel)
            {
                siteContent.Parent.Children.Load();
                thirdLevelItems = siteContent.Parent.Children.OrderBy(c=>c.Id).Select(item => Html.ActionLink(
                                            item.Name,
                                            "Index",
                                            ViewContext.RouteData.Values["controller"].ToString(),
                                            new { contentName = item.Name },
                                            new { @class = (item.Id == contentId) ? "thirdLevelMenuActive" : "" })).ToArray();
                thirdLevelMenu = string.Join("<br />", thirdLevelItems);
            }
        }
    }

    string itemsHtml = string.Join("&nbsp;| ", subMenuItems);
%>

<%if(!string.IsNullOrEmpty(itemsHtml)){%>
<div class="subMenu">
    <%= itemsHtml %>
</div>
<%} %>
<% if(!string.IsNullOrEmpty(thirdLevelMenu)){ %>
    <div class="thirdLevelMenu">
        <%= thirdLevelMenu %>
    </div>
<%} %>