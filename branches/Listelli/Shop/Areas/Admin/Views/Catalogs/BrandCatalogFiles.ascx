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
        <td class="catTitle">
            <%=item.Title %>
        </td>
        <td>
            <%=item.FileName %>
        </td>
        <td>
            <%: Html.ActionLink("Удалить", "DeleteCatalogFile", new { id = item.Id }, new { onclick = "return confirm('Удалить файл?')", @class = "adminLink" })%>
        </td>
    </tr>
    <%
        }
    %>
    <tr>
    <td colspan="3">
    
     <div class="addItem">
        <%using (Html.BeginForm("AddFileToCatalog", "Catalogs", new { catalogId = Model.Id }, FormMethod.Post, new { enctype = "multipart/form-data" }))
          { %>
          <table>
          <tr>
            <td>Имя ссылки-текста на pdf:</td>
            <td><%=Html.TextBox("FileTitle","",new{style="width:230px;"})%></td>
          </tr>
          <tr>
            <td>Выберите файл:</td>
            <td><input type="file" name="logo" /></td>
          </tr>
          <tr>
            <td></td>
            <td><input type="submit" value="Добавить" /></td>
          </tr>
          </table>
        <%} %>
    </div>

    </td>
    </tr>
</table>
