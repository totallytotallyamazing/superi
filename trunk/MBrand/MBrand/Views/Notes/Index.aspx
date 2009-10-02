<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<MBrand.Models.Note>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Заметки
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function() { $("#addNote").fancybox({ frameWidth: 750, frameHeight:670, hideOnContentClick: false }) });
    </script>

    <asp:LoginView runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("Добавить", "AddEditNote", "Admin", new {id = int.MinValue}, new {id = "addNote"}) %>
        </LoggedInTemplate>
    </asp:LoginView>
    
    <%foreach (MBrand.Models.Note item in Model){%>
        <div class="note">
            <%if (!string.IsNullOrEmpty(item.Image)){ %>
                <img alt="" src="/Content/images/notes/<%= item.Image %>" />
            <%} %>
            <%= item.Date.ToString("dd.MM.yyyy") %>
            <br />
            <%= Html.ActionLink(item.Title, "Note", new {id=item.Id })%>
        </div>
      <%} %>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	Заметки
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Includes">
    <script type="text/javascript" src="/Scripts/jquery.fancybox.js"></script>
    <link rel="Stylesheet" href="/Content/fancy/jquery.fancybox.css" />
</asp:Content>
