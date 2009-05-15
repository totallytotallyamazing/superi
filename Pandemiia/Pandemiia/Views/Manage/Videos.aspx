<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Views/Manage/PopUp.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    �����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function htmlEncode() {
        var src = $('#source').attr('value');
        $('#source').attr('value', escape(src));
    }
</script>
    <h2>
        �����
    </h2>
    <%if (Model.EntityVideos.Count > 0)
      {%>
    <% using (Html.BeginForm("RemoveVideos", "Manage"))
       { %>
    <table>
        <tr>
            <th>
                ��������
            </th>
            <th>
                �������
            </th>
        </tr>
        <%
            foreach (Pandemiia.Models.EntityVideo video in Model.EntityVideos)
            {
        %>
        <tr>
            <td>
                <%= video.Name %>
            </td>
            <td>
                <%= Html.CheckBox(video.ID.ToString()) %>
            </td>
        </tr>
        <%} %>
        <%} %>
    </table>
    <center>
        <%= Html.Hidden("id", Model.ID) %>
        <input type="submit" value="�������" />
    </center>
    <%} %>
    <fieldset>
        <legend>��������</legend>
        <% using (Html.BeginForm("AddVideo", "Manage"))
           { %>
        <%= Html.Hidden("id", Model.ID) %>
        <input style="width: 270px;" type="text" class="wm" id="name" name="name" /><br />
        <textarea style="width: 270px; margin-top: 5px;" class="wm" id="source" name="source"></textarea>
        <center>
            <input type="submit" value="��������" style="margin-top: 5px;" onclick="htmlEncode()" />
        </center>
        <%} %>
    </fieldset>

    <script type="text/javascript">
        $(function() {
            $("#name").watermark({ watermarkText: '��������', watermarkCssClass: 'watermark' });
            $("#source").watermark({ watermarkText: '��� ����-������', watermarkCssClass: 'watermark' });
        }
        );
    </script>

</asp:Content>
