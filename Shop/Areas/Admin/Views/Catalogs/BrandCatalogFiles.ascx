<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.BrandCatalogCategory>" %>
<table class="brandCatalogFilesTable">
    <tr>
        <th>
            Название
        </th>
        <th>
            Имя файла
        </th>
        <th></th>
    </tr>
    <%
        foreach (var item in Model.BrandCatalogFile)
        {
    %>
    <tr>
        <td>
            <%=item.Title %>
        </td>
        <td>
            <%=item.FileName %>
        </td>
        <td>
            <%: Html.ActionLink("Удалить", "DeleteCatalogFile", new { id = item.Id }, new { onclick = "return confirm('Удалить файл?')" })%>
        </td>
    </tr>
    <%
        }
    %>
    <tr>
    <td colspan="3">
    
     <p>
        <%using (Html.BeginForm("AddFileToCatalog", "Catalogs", new { catalogId = Model.Id }, FormMethod.Post, new { enctype = "multipart/form-data" }))
          { %>
          Добавить файл:<br />
          Заголовок: <%=Html.TextBox("FileTitle")%><br />
          Файл: <input type="file" name="logo" /><br />
          <input type="submit" value="Добавить" />
        <%} %>
    </p>

    </td>
    </tr>
</table>
