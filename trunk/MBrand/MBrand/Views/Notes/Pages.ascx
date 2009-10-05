<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="MBrand.Models" %>
<div id="pager">
<%
    int currentPage = Convert.ToInt32(ViewData["currentPage"]);
    int totalPages = 1;
    int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
    using (DataStorage context = new DataStorage())
    {
        int notesCount = context.Notes.Count();
        totalPages = notesCount / pageSize;
        if ((notesCount % pageSize) > 0)
            totalPages++;
    }    
%>

<% 
    for(int i = 1; i<=totalPages; i++)
    {
        if (i == currentPage)
        {
            Response.Write("<span>" + i + "</span>");
            if (ViewContext.RouteData.Values["action"].ToString() == "Note")
            {
                Response.Write("&nbsp;");
                Response.Write("<span class=\"pagesArrow\">»</span>");
                Response.Write("&nbsp;");
                Response.Write("<span class=\"pagerDate\">" + ViewData["date"] + "</span>");
            }
        }
        else
        {
            Response.Write(Html.ActionLink(i.ToString(), "Index", "Notes", new { id = i }, new { @class = "pageLink" }));   
        }

        if (i < totalPages)
            Response.Write("&nbsp;..&nbsp;");
    } 
%>
</div>