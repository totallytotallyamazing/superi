<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/PopUp.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Музыка
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Музыка</h2>
    <%if (Model.EntityMusics.Count > 0)
      { %>
    <% using (Html.BeginForm("RemoveMusic", "Manage", FormMethod.Post))
       { %>
        <table>
            <tr>
                <th>Название</th>
                <th>Исполнитель</th>
                <th>Альбом</th>
                <th>Удалить</th>
            </tr>
            <tr>
                <%foreach (Pandemiia.Models.EntityMusic music in Model.EntityMusics)
                  {%>
                    <td><%= music.Name %></td>  
                    <td><%= music.Artist %></td>
                    <td><%= music.Album %></td>
                    <td><%= Html.CheckBox(music.ID.ToString()) %></td>
                  <%} %>
            </tr>
        </table>
    <%} %>
    <%} %>
    <% using (Html.BeginForm("AddMusic", "Manage", FormMethod.Post, new { enctype = "multipart/form-data" }))
       { %>
    <fieldset>
        <legend>Добавить</legend>
        <%= Html.Hidden("id", Model.ID) %>
        <input style="width: 270px;" class="wm" type="file" name="file" /><br />
        <input style="width: 270px;" class="wm" type="text" name="name" id="name" /><br />
        <input style="width: 270px;" class="wm" type="text" name="artist" id="artist" /><br />
        <input style="width: 270px;" class="wm" type="text" name="album" id="album" /><br />
        <textarea style="width: 270px;" class="wm" name="comments" id="comments"></textarea>
        <center>
            <input type="submit" value="Добавить" />
        </center>
    </fieldset>
    <%} %>

    <script type="text/javascript">
        $(function() {
            $("#name").watermark({ watermarkText: 'Название', watermarkCssClass: 'watermark' });
            $("#artist").watermark({ watermarkText: 'Исполнитель', watermarkCssClass: 'watermark' });
            $("#album").watermark({ watermarkText: 'Альбом', watermarkCssClass: 'watermark' });
            $("#comments").watermark({ watermarkText: 'Дополнительная информация', watermarkCssClass: 'watermark' });
        }
        )
    </script>

</asp:Content>
