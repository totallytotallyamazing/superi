<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Ошибка
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function() { $(".filterTop").html(""); $(".filterBottom").html(""); })        
    </script>
    <%= Html.Image("~/Content/img/fatalError.jpg")%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalStylesContent" runat="server">
</asp:Content>
