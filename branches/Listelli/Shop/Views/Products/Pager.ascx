<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Dev.Mvc.Runtime" %>
<% 
    int pageSize = Configurator.LoadSettings().PageSize;
    int totalCount = (int)ViewData["totalCount"];
    int pageCount = totalCount / pageSize;
    int page = (int)ViewData["page"];
    pageCount += ((totalCount % pageSize) > 0) ? 1 : 0;
%>

<div id="pager">
    <p class="txtPager">
    <%for (int i = 0; i < pageCount; i++)
      {
          if (i == page)
              Response.Write(i+1);
          else
          {
              Response.Write(
              Html.ActionLink((i + 1).ToString(), (string)ViewData["action"], new
              {
                  id = ViewData["categoryId"],
                  brandId = ViewData["brandId"],
                  orderBy = ViewData["orderBy"],
                  page = i
              }, new { @class = "txtPager" }));
          }
          if (i + 1 < pageCount)
              Response.Write(" ... ");
      } %>
    </p>
</div>