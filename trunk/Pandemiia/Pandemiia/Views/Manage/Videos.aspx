<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/PopUp.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Видео
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Видео</h2>
    
    <fieldset>
        <legend>Добавить</legend>
        <input type="text" class="wm" name="name" />
    </fieldset>
    <script type="text/javascript">
        $(function() {
            $(".wm").watermark({ watermarkText: 'Heey', watermarkCssClass: 'someCSS' });
        }
        );
    </script>
</asp:Content>
