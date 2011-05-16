<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Клиенты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        $(function() {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: {DefaultLanguage:"ru", AutoDetectLanguage:false, SkinPath: "/Controls/fckeditor/editor/skins/office2003/"} };
            $("#text").fck({ height: 500, width: 700 });
        })
    </script>
    <% using (Html.BeginForm())
       { %>
       <%= Html.TextArea("text") %>
       <% Html.RenderPartial("SeoEditor"); %>
       <input type="submit" value="Сохранить" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
    Клиенты
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Includes">
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
</asp:Content>
