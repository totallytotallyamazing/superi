<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Album>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
    <table>
        <tr>
            <th>
                Номер трека
            </th>
            <th>
                Название
            </th>
             <th></th>
        </tr>

    <% foreach (var item in Model.Songs) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.TrackNumber) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
             <td>
                <%= Html.ActionLink("Редактировать", "EditSong", new { id=item.Id }) %> |
                <%= Html.ActionLink("Удалить", "DeleteSong", new { id = item.Id }, new { onclick = "return confirm('Вы уверены?')" })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% using (Html.BeginForm("AddSong", "Admin", new{albumId=Model.Id}, FormMethod.Post,  new { enctype = "multipart/form-data" }))
       {
           %>
           <p>
        Добавить трек
    </p>
          Номер трека <%=Html.TextBox("TrackNumber")%><br/>
          Название <%=Html.TextBox("SongTitle")%><br/>
          Трек <input type="file" name="song" /><br/>
          <input type="submit" value="Загрузить"/>
           <%
       } %>

    


