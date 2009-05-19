<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int[]>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Pandemiia.Controllers" %>
<%if (Model.Length > 0)
  {
      string source = ViewData["source"].ToString();
      string typeName = ViewData["typeName"].ToString();
      int pageNumber = Convert.ToInt32(ViewData["pageNumber"]);
      bool homeController = (string.IsNullOrEmpty(source) && string.IsNullOrEmpty(typeName));
%>
<div style="float:left; display:none;">LEFT</div>
<center>
<table>
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
                   if (i > Model.Length / 2)
                       bottomDivClass = "pageNumberSecond";
               }
        %>
        <td>
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
                  else
                  {
                      if (current)
                          Response.Write(Model[i].ToString());
                      else
                      {
                          string response="";
                          switch(source)
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
<div style="float:right; display:none;">RIGHT</div>
<%} %>