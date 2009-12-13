<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Удаленное видео
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function queryService() {
            Sys.Net.WebServiceProxy.invoke("/Services/Tools.asmx",
            "YoutubeProgress", false, {}, OnSucceeded,
            OnFailed, "User Context", 1000000);
        }
    
        $(function() { 
            
        })
    
        function htmlEncode() {
            var src = $('#source').attr('value');
            $('#source').attr('value', escape(src));
        }
    </script>
    <h2>Удаленное видео</h2>
    
    
<%--
    <% foreach (var item in Model) {
           using (Html.BeginForm("UpdateVideoSource", "Manage", FormMethod.Post))
           {
           %>
           <%= Html.Hidden("id", item.ID) %>
        Пост &quot;<%= item.Entity.Title%> &quot; за <%= item.Entity.Date.Value.ToString("dd.MM.yyyy")%> <br />
        Видео &quot;<%= item.Entity.Title%> &quot; <br />
        Код плеера:<br />
        <%= Html.TextArea("source", item.Source, new { style = "width:270px;" })%><br />
        <input type="submit" value="Обновить" onclick="htmlEncode()" />
    <% }
       } %>--%>

</asp:Content>

