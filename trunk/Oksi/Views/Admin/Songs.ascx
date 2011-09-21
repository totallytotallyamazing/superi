<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Album>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
    <table>
        <tr>
            <th>
                ����� �����
            </th>
            <th>
                ��������
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
                <%= Html.ActionLink("�������������", "EditSong", new { id=item.Id }) %> |
                <%= Html.ActionLink("�������", "DeleteSong", new { id = item.Id }, new { onclick = "return confirm('�� �������?')" })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% using (Html.BeginForm("AddSong", "Admin", new{albumId=Model.Id}, FormMethod.Post,  new { enctype = "multipart/form-data" }))
       {
           %>
           <p>
        �������� ����
    </p>
          ����� ����� <%=Html.TextBox("TrackNumber")%><br/>
          �������� <%=Html.TextBox("SongTitle")%><br/>
          ���� <input type="file" name="song" /><br/>
          <input type="submit" value="���������"/>
           <%
       } %>

    


