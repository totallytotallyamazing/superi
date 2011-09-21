<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Oksi.Models.Album>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Albums
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Albums</h2>

    <table class="adminAlbum">
        <tr>
            
            <th>
                Обложка
            </th>
            <th>
                Название
            </th>
            <th>
                Год
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
          
            <td>
                <%= Html.Image("~/Cover/" + item.Cover) %>
            </td>
            
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.Year) %>
            </td>
              <td>
                 <%= Html.ActionLink("Удалить", "DeleteAlbum", new { id = item.Id }, new { onclick = "return confirm('Удалить альбом? Будут также удалены все треки этого альбома!')" })%>
            </td>
        </tr>
        <tr>
        <td colspan="4">
        
        <% Html.RenderPartial("Songs",item); %>
        
        </td>
        </tr>
    
    
   
    
    <%
       
       } %>

    </table>

    <% using (Html.BeginForm("AddAlbum", "Admin", null, FormMethod.Post,  new { enctype = "multipart/form-data" }))
       {
           %>
           <p>
        Добавить альбом
    </p>
          Год <%=Html.TextBox("AlbumYear")%><br/>
          Название <%=Html.TextBox("AlbumTitle")%><br/>
          Обложка <input type="file" name="cover" /><br/>
          <input type="submit" value="Загрузить"/>
           <%
       } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

