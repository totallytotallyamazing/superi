<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int[]>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Pandemiia.Controllers" %>
<%if (Model.Length > 1)
  {
      string source = ViewData["source"].ToString();
      string typeName = ViewData["typeName"].ToString();
      int pageNumber = Convert.ToInt32(ViewData["pageNumber"]);
      bool homeController = (string.IsNullOrEmpty(source) && string.IsNullOrEmpty(typeName));
      string tagName = (ViewData["tagName"] as string);
      
      RouteValueDictionary routeValues = new RouteValueDictionary();
      routeValues["controller"] = "Home";
      routeValues["action"] = "Page";
      string thereUrl = "#";
      string hereUrl = "#";
      if (pageNumber > 1)
      {
          routeValues["id"] = pageNumber - 1;
          thereUrl = Url.RouteUrl(routeValues);
      }
      if (pageNumber < Model.Length)
      {
          routeValues["id"] = pageNumber + 1;
          hereUrl = Url.RouteUrl(routeValues);
      }
      
%>
<div class="there">
    <div class="thereImage">
        <a href= "<%= thereUrl %>">
            <%= Html.Image("~/Content/img/there.jpg")%>
        </a>
    </div>
    <div class="thereLink">
        <a href="<%= thereUrl %>">
            туды
        </a>
    </div>
</div>
<center>
<table class="pagerTable">
    <tr>
        <td>
        </td>
        <% for (int i = 0; i < Model.Length; i++)
           {
               string topDivClass = "blankIndicator";
               string bottomDivClass = "pageNumber";
               bool current = false;
               if (Model[i] == pageNumber)
               {
                   topDivClass = "currentIndicator";
                   bottomDivClass = "currentPageNumber";
                   current = true;
               }
               else
               {
                   if (i >= Model.Length / 2)
                       bottomDivClass = "pageNumberSecond";
               }
        %>
        <td align="center">
            <div class="<%= topDivClass %>">
            </div>
            <div class="<%= bottomDivClass %>">
                <%if (homeController)
                  {
                      if (current)
                          Response.Write(Model[i].ToString());
                      else
                          Response.Write(Html.ActionLink<HomeController>(ac => ac.Page(Model[i]), Model[i].ToString()));
                  }
                  else if (!string.IsNullOrEmpty(tagName))
                  {
                      if(current)
                          Response.Write(Model[i].ToString());
                      else
                        Response.Write(Html.ActionLink<FilterController>(ac => ac.Tags(tagName, Model[i]), Model[i].ToString()));
                  }
                  else
                  {
                      if (current)
                          Response.Write(Model[i].ToString());
                      else
                      {
                          string response = "";
                          switch (source)
                          {
                              case "All":
                                  response = Html.ActionLink<FilterController>(ac => ac.All(typeName, Model[i]), Model[i].ToString());
                                  break;
                              case "Ours":
                                  response = Html.ActionLink<FilterController>(ac => ac.Ours(typeName, Model[i]), Model[i].ToString());
                                  break;
                              case "Yours":
                                  response = Html.ActionLink<FilterController>(ac => ac.Yours(typeName, Model[i]), Model[i].ToString());
                                  break;
                              case "Theirs":
                                  response = Html.ActionLink<FilterController>(ac => ac.Theirs(typeName, Model[i]), Model[i].ToString());
                                  break;
                          }

                          Response.Write(response);
                      }
                  } %>
            </div>
        </td>
        <% } %>
        <td>
        </td>
    </tr>
</table>
</center>
<div class="here">    
    <div class="hereLink">
        <a href="<%= hereUrl %>">
            сюды
        </a>
    </div>
    <div class="hereImage">
        <a href="<%= hereUrl %>">
            <%= Html.Image("~/Content/img/here.jpg")%>
        </a>
    </div>
</div>
<%} %>