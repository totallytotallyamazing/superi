<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.DesignerContent>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gallery
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Фотогаллерея помещения "<%=Model.RoomName%>" дизайнера <%=ViewData["designerNameF"]%></h2>
   
    <%=Html.HiddenFor(model => model.Id)%>
            <%=Html.Hidden("designerId")%>           

            <%
           int dId = (int)ViewData["designerId"];
            %>

            <%foreach (var item in Model.DesignerContentImages)
               {
            %>
            <div class="photoContainer">
             <%if (Roles.IsUserInRole("Administrators"))
              { %>
           <div class="deletePhotoLinkContainer">   
                <%= Html.ActionLink("[Удалить фото]", "DeletePhoto", "Designers", new { area = "Admin", id = item.Id, roomId=Model.Id,  designerId = dId }, new { title = "Удалить фото", onclick = "return confirm('Вы уверены что хотите удалить запись?')", @class = "deletePhotoLink adminLink" })%>
           </div>
           <div style="clear:both;"></div>
            <%}
                   %> 
            <a rel="group<%=Model.Id%>" href="../../Content/DesignerPhotos/<%=item.ImageSource%>" class="fancy">
            <%=Html.CachedImage("~/Content/DesignerPhotos/", item.ImageSource, "designerPhotosThumb", item.ImageSource,true)%>
            </a>
           
                   </div>
                   <%
               } %>
               <div style="clear:both;">
                </div>

                <%
                
               if (Roles.IsUserInRole("Administrators"))
                   using (Html.BeginForm("AddPhoto", "Designers", new { area = "Admin", id = Model.Id, designerId = dId }, FormMethod.Post, new { enctype = "multipart/form-data" }))
                   {
            %>
            Добавить фото:
            <input type="file" name="logo" />
            <input type="submit" value="Загрузить" />
            <%
                }
                
            %>


                <div>
        <%: Html.ActionLink("Назад к списку помещений", "Rooms", new { id = dId })%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
