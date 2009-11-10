<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Common.Master" Inherits="System.Web.Mvc.ViewPage<List<MBrand.Models.Note>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Заметки
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function() 
        {
            $("#addNote").fancybox({ frameWidth: 750, frameHeight: 670, hideOnContentClick: false })
            $(".editNote").fancybox({ frameWidth: 750, frameHeight: 670, hideOnContentClick: false }) 
        });
    </script>
    <div id="notesHolder">
        <asp:LoginView runat="server">
            <AnonymousTemplate></AnonymousTemplate>
            <LoggedInTemplate>
                <%= Html.ActionLink("Добавить", "AddEditNote", "Admin", new {id = int.MinValue}, new {id = "addNote", @class="adminLink"}) %>
                <br /><br />
            </LoggedInTemplate>
        </asp:LoginView>
        
        <%foreach (MBrand.Models.Note item in Model){%>
            <div class="note">
                <%if (Request.IsAuthenticated){ %>
                    <div style="float:right;">
                        <%= Html.ActionLink("Редактировать", "AddEditNote", "Admin", new { id = item.Id }, new { @class = "editNote adminLink" })%>
                        &nbsp;
                        <%= Html.ActionLink("Удалить", "DeleteNote", "Admin", new { id = item.Id }, new { onclick = "return confirm('Ты уверен?')", @class="adminLink" })%>
                    </div>
                <%} %>
            
                <%if (!string.IsNullOrEmpty(item.Image)){ %>
                    <img alt="" src="/Content/images/notes/<%= item.Image %>" />
                <%} %>
                <%= item.Date.ToString("dd.MM.yyyy") %>
                <br />
                <%= Html.ActionLink(item.Title, "Note", new {id=item.Id, currentPage=ViewData["currentPage"] })%>
                <br /><br />
                <%= item.Description %>
                <div style="clear:both"></div>
            </div>
          <%} %>
      </div>
    <% Html.RenderPartial("Pages"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	Заметки
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Includes">
    <script type="text/javascript" src="/Scripts/jquery.fancybox.js"></script>
    <link rel="Stylesheet" href="/Content/fancy/jquery.fancybox.css" />
</asp:Content>