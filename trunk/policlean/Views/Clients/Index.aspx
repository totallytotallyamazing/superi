<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PolialClean.Models.Clients>>" %>
<%@ Import Namespace="PolialClean.Models" %>
<%@ Import Namespace="PolialClean.Controllers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Клиенты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%if(Request.IsAuthenticated){ %>
    <div class="adminEditLink">
        <%= Html.ActionLink("Добавить клиента", "AddUpdateClient", "Admin", null, new { @class="fancy" })%>
    </div>
    <%} %>
    <%foreach (Clients client in Model)
      {
          Html.RenderAction<ClientsController>(ac => ac.Client(client));
      } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Клиенты
</asp:Content>

<asp:Content ContentPlaceHolderID="Includes" runat="server">
    <link rel="Stylesheet" href="/Content/fancy/jquery.fancybox.css" />
    <script type="text/javascript" src="/Scripts/jquery.fancybox.js"></script> 
    <%if(Request.IsAuthenticated){ %>
        <link rel="Stylesheet" href="/Content/Admin.css" />
        <script type="text/javascript">
            $(function() {
                $(".fancy").fancybox({ hideOnContentClick: false, frameHeight:80, frameWidth:310 });
            })
        </script>
    <%} %>
</asp:Content>