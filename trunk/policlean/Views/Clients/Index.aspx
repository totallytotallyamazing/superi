<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Клиенты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
                $(".fancy").fancybox({ hideOnContentClick: false });
            })
        </script>
    <%} %>
</asp:Content>