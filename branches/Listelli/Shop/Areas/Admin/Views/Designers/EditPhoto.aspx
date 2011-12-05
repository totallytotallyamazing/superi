<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master"
    Inherits="System.Web.Mvc.ViewPage<Shop.Models.DesignerContentImages>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EditPhoto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        EditPhoto</h2>
    <% using (Html.BeginForm("EditPhoto", "Designers", new { area = "Admin" }, FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>

       <%=Html.HiddenFor(model=>model.Id) %>
       <%=Html.Hidden("roomId")%>
       <%=Html.Hidden("designerId")%>

    <%: Html.ValidationSummary(true) %>
    <table class="adminTable">
        <tr>
            <td colspan="2">
            <%=Html.CachedImage("~/Content/DesignerPhotos/", Model.ImageSource, "designerPhotosThumb", Model.ImageSource, true)%>
            </td>
        </tr>
        <tr>
            <td class="title">
                Загрузить новую фотографию:
            </td>
            <td>
                <input type="file" name="logo" />
            </td>
        </tr>
        <tr>
            <td class="title">
                Описание:
            </td>
            <td>
                <%=Html.TextAreaFor(model=>model.Description,5,60,null) %>
            </td>
        </tr>
        <tr>
            <td class="title">
               Порядок отображения:
            </td>
            <td>
                <%=Html.TextBoxFor(model=>model.SortOrder) %>
            </td>
        </tr>
    </table>
     <p>
            <input type="submit" value="Сохранить" />
        </p>
    
    <% } %>
    <div>
        <%: Html.ActionLink("Назад к списку", "Gallery") %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
