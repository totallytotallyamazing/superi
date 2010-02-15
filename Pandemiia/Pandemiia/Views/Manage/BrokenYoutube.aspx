<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ��������� �����
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
            var rowTemlpate = '<tr><td>EntityTitle</td><td>Title</td><td><a class="video" href="/Manage/UpdateVideo/VideoId">��������</a></td></tr>';
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

    <h2>��������� �����</h2>
    
    <div id="processing">
        ���������...
        <div id="progressbar"></div>
    </div>
    
    <div id="results" style="display:none">
        <table id="resultsTable">
            <tr>
                <th>����</th>
                <th>�����</th>
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
        ���� &quot;<%= item.Entity.Title%> &quot; �� <%= item.Entity.Date.Value.ToString("dd.MM.yyyy")%> <br />
        ����� &quot;<%= item.Entity.Title%> &quot; <br />
        ��� ������:<br />
        <%= Html.TextArea("source", item.Source, new { style = "width:270px;" })%><br />
        <input type="submit" value="��������" onclick="htmlEncode()" />
    <% }
       } %>--%>
</asp:Content>