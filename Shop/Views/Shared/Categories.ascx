<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Category>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<div id="menuBox">
    <div id="liHeader">
    </div>
    <div id="newsContent">
        <div id="classMenuItems">
        <% 
        foreach (var item in Model)
        {%>
            <div class="classMenuItem">
                <p>
                    <%= Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null)%>
                </p>
            </div>
      <%
          if (WebSession.CurrentCategory == item.Id)
              Html.RenderPartial("SubCategories", item.Categories);
        }%>
        </div>
    </div>
    <div id="newsFooter">
    </div>
</div>

