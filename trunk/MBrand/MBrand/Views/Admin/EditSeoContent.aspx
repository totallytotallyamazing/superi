<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MBrand.Models2.SeoContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Редактирование SEO контента
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(function () {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { DefaultLanguage: "ru", AutoDetectLanguage: false, SkinPath: "/Controls/fckeditor/editor/skins/office2003/"} };
            $("#seoCustomText").fck({ height: 500, width: 700 });
        })
    </script>

    <% using (Html.BeginForm()) {%>
       

       
        <% Html.RenderPartial("SeoEditor"); %>
        <%= Html.TextArea("seoCustomText")%>


       <input type="submit" value="Сохранить" />

    <% } %>

    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
<script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
Редактирование SEO контента
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="SeoCustomTextContainer" runat="server">
</asp:Content>

