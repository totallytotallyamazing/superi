<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Models" %>
<% 
    string path = Request.Url.PathAndQuery;
    string description, keywords;
    keywords = description = string.Empty;
    using(SeoStorage context = new SeoStorage())
	{
		Seo seo = context.Seo.Where(s=>s.Language == Zamov.Controllers.SystemSettings.CurrentLanguage).Where(s=>s.Url == path).FirstOrDefault();
        if(seo!=null)
        {
            keywords = seo.Keywords;
            description = seo.Description;
        }
	}
%>

 <meta name="Keywords" content="<%= keywords %>" />
 <meta name="Description" content="<%= description %>" />
