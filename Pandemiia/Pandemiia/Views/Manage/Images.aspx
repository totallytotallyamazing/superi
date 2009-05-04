<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/PopUp.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Images
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Изображения</h2>
    <div class="imagesPreview">
        <%foreach (Pandemiia.Models.EntityPicture picture in Model.EntityPictures)
          {%>
        <div class="entityPicture">
            <img alt="" src="../EntityImages/<%= picture.Preview %>" />
        </div>
        <%} %>
    </div>
    <% using (Html.BeginForm("UploadFilePairs", "Tools", FormMethod.Post, new { enctype = "multipart/form-data" }))
       { %>
       <%= Html.Hidden("entityId", Model.ID)%>
       <%= Html.Hidden("caller", "Manage")%>
       <%= Html.Hidden("returnAction", "SaveImages")%>
       <%= Html.Hidden("uploadFolder", "EntityImages")%>
       <%= Html.Hidden("fileKey", "picture")%>
       <%= Html.Hidden("previewKey", "preview")%>
    <center>
        <table>
            <tr>
                <th>
                    Превью
                </th>
                <th>
                    Изображения
                </th>
            </tr>
            <tr>
                <td>
                    <input type="file" name="picture1" />
                </td>
                <td>
                    <input type="file" name="preview1" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="file" name="picture2" />
                </td>
                <td>
                    <input type="file" name="preview2" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="file" name="picture3" />
                </td>
                <td>
                    <input type="file" name="preview3" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="file" name="picture4" />
                </td>
                <td>
                    <input type="file" name="preview4" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="file" name="picture5" />
                </td>
                <td>
                    <input type="file" name="preview5" />
                </td>
            </tr>
        </table>
        <input type="submit" value="Сохранить" style="margin-top:5px;" />
    </center>
    <% } %>
</asp:Content>
