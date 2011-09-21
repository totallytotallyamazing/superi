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
                <%= Html.ActionLink("Редактировать", "EditAlbum", new { id = item.Id })%> |
                <%= Html.ActionLink("Удалить", "DeleteAlbum", new { id = item.Id })%>
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

    <p>
        <%= Html.ActionLink("Добавить альбом", "AddAlbum")%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

