<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/PopUp.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	�����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>�����</h2>
    
    <fieldset>
        <legend>��������</legend>
        <input type="text" class="wm" name="name" />
    </fieldset>
    <script type="text/javascript">
        $(function() {
            $(".wm").watermark({ watermarkText: 'Heey', watermarkCssClass: 'someCSS' });
        }
        );
    </script>
</asp:Content>
