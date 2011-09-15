<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="MBrand.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<% if(Request.IsAuthenticated){ %>
    <script type="text/javascript">
        $(function() {
            $(".editWorkGroup").fancybox({ hideOnContentClick: false, frameWidth: 700, frameHeight: 250 });
        })
    </script>
<%} %>
<div style="padding-left:17px;">
<%
    WorkType workType = (WorkType)ViewData["workType"];
    int workTypeId = (int)workType;

    using (var context = new DataStorage2())
    {
        var workGroups = context.WorkGroups.Where(wg => wg.Type == workTypeId).OrderByDescending(wg => wg.Date).Select(wg => wg);
        foreach (var item in workGroups)
        {%>
            <div class="workGroupItem">
                <div class="date">
                   <%-- <%= item.Date.ToString("dd.MM.yyyy") %>--%>
                </div>
                <%if(Request.IsAuthenticated){ %>
                <div class="adminLinks">
                    <a class="editWorkGroup" href="/Admin/AddEditWorkGroup?workType=<%= workType%>&id=<%= item.Id %>">
                        <%= Html.Image("~/Content/img/edit.png") %>
                    </a>
                    <a href="/Admin/DeleteWorkGroup/<%= item.Id %>" onclick="return confirm('Ты уверен?')">
                        <%= Html.Image("~/Content/img/delete.png") %>
                    </a>
                </div>
                <%} %>
                
                <a href="/See/<%= workType %>/<%= item.Id %>">
                <%= Html.Image("~/Content/images/" + workType.ToString().ToLower() + "/preview/" + item.Image) %>
                </a>
                <div class="description">
                    <%= item.Description %>
                </div>
            </div>    
      <%}
    }    
%>
</div>