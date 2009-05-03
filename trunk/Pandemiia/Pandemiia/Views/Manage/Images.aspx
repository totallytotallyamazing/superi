<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/PopUp.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Images
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <h2>Изображения</h2>
            
    
            <% using (Html.BeginForm("UploadFilePairs", "Tools", FormMethod.Post, new { entityId = (int)ViewData["id"], caller = "Manage", returnAction = "SaveImages", uploadFolder="EntityImages", fileKey="picture", previewKey="preview" }))
               { %>
                <table>
                    <tr>
                        <th>Превью</th>
                        <th>Изображения</th>
                    </tr>   
                    <tr>
                        <td><input type="file" name="picture1" /> </td>
                        <td><input type="file" name="preview1" /> </td>
                    </tr>             
                    <tr>
                        <td><input type="file" name="picture2" /> </td>
                        <td><input type="file" name="preview2" /> </td>
                    </tr>             
                    <tr>
                        <td><input type="file" name="picture3" /> </td>
                        <td><input type="file" name="preview3" /> </td>
                    </tr>             
                    <tr>
                        <td><input type="file" name="picture4" /> </td>
                        <td><input type="file" name="preview4" /> </td>
                    </tr>             
                    <tr>
                        <td><input type="file" name="picture5" /> </td>
                        <td><input type="file" name="preview5" /> </td>
                    </tr>             
                </table>
                <center>
                    <input type="submit" value="Сохранить" />
                </center>
                <% } %>>

</asp:Content>
