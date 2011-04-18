<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Oksi.Models" %>
<div id="subMenu">
<%
    string contentUrl = ViewContext.RouteData.Values["contentUrl"].ToString();
    
    using (DataStorage context = new DataStorage())
    {
        IEnumerable siteContent = context.SiteContent.Where(sc => sc.Parent != null && sc.Parent.Url == contentUrl);
        foreach (var item in siteContent)
        {
        %>
            <%-- Here comes sub menu layout --%>
        <%
        }
         
    }
%>
</div>