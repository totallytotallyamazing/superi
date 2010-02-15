<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Удаленное видео
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/fancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <script type="text/javascript">
        var intervalId = null;
    
        function queryService() {
            Sys.Net.WebServiceProxy.invoke("/Services/Tools.asmx",
            "YoutubeProgress", false, {}, function(response) {
                if (response.queried) {
                    $("#processing").hide();
                    $("#results").show();
                    window.clearInterval(intervalId);
                    showResults(response.items);
                }
                else {
                    $('#progressbar').progressbar('option', 'value', response.status);
                }
            },
            function() { });
        }

        $(function() {
            $("#progressbar").progressbar();
            queryService();
            intervalId = window.setInterval(queryService, 10000);
        })

        function htmlEncode() {
            var src = $('#source').attr('value');
            $('#source').attr('value', escape(src));
        }

        function showResults(items) {
            var rowTemlpate = '<tr><td>EntityTitle</td><td>Title</td><td><a class="video" href="/Manage/UpdateVideo/VideoId">Обновить</a></td></tr>';
            for (var i in items) { 
                var rowLayout = rowTemlpate
                .replace("EntityTitle", items[i].entityTitle)
                .replace("Title", items[i].title)
                .replace("VideoId", items[i].id);
                $(rowLayout).appendTo("#resultsTable");
            }
        }

        function bindEvents() { 
                
        }
    </script>

    <h2>Удаленное видео</h2>
    
    <div id="processing">
        Проверяем...
        <div id="progressbar"></div>
    </div>
    
    <div id="results" style="display:none">
        <table id="resultsTable">
            <tr>
                <th>Пост</th>
                <th>Видео</th>
                <th></th>
            </tr>
        </table>
    </div>
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