<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MBrand.Models.Work>>" %>
<%@ Import Namespace="MBrand.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["workGroupName"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WorkType workType = (WorkType)ViewData["workType"];
        string chapterName = "";
        switch (workType)
        {
            case WorkType.Site:
                chapterName = "Сайты";
                break;
            case WorkType.Vcard:
                chapterName = "Фирменный стиль";
                break;
            case WorkType.Logo:
                chapterName = "Логотипы";
                break;
            case WorkType.Poly:
                chapterName = "Полиграфия";
                break;
            case WorkType.Text:
                chapterName = "Работа с текстом";
                break;
        }
    %>
    <%if(Request.IsAuthenticated){ %>
    <script type="text/javascript">
        $(function() {
            $(".addEditWork").fancybox({hideOnContentClick:false, frameHeight:300, frameWidth: 450});
        })
    </script>
    <%} %>
    <h2>
       » <a href="/See/<%= workType.ToString() %>"><%= chapterName %></a> » <%= ViewData["workGroupName"] %>
    </h2>
    <div style="padding-left:17px;">
        <%if(Request.IsAuthenticated){ %>
        <a href="/Admin/AddEditWork?groupId=<%= ViewData["groupId"] %>" class="adminLink addEditWork">Добавить</a>
        <%} %>
        <%foreach (Work item in Model)
          {%>
              <%if(Request.IsAuthenticated){ %>
                <div>
                    <a class="addEditWork" href="/Admin/AddEditWork?groupId=<%= ViewData["groupId"]%>&id=<%= item.Id %>">
                        <%= Html.Image("~/Content/img/edit.png") %>
                    </a>
                    <a href="/Admin/DeleteWork?id=<%= item.Id %>" onclick="return confirm('Ты уверен?')">
                        <%= Html.Image("~/Content/img/delete.png") %>
                    </a>
                </div>
              <%} %>
              <div class="workDescription">
                <%= item.Description %>
              </div>
              <div class="workImage">
                <%= Html.Image("~/Content/Images/" + workType.ToString() + "/" + item.Image) %>
              </div>
       <% } %>
    </div>
    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
	Посмотреть
</asp:Content>
