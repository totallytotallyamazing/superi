<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master"
    Inherits="System.Web.Mvc.ViewPage<List<Shop.Models.DesignerContent>>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=((Designer)ViewData["designer"]).Name%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {

            $(".fancy").fancybox({ showCloseButton: true, cyclic: true, showNavArrows: true, padding: 0, margin: 0,centerOnScroll:true });

            $("#livingRoom").click(function () {
                $("#livingRoom").addClass("selected");
                $("#notLivingRoom").removeClass("selected");
                $(".designerInfoContainer").css("display", "none");
                $("#accordion1").css("display", "block");
                $("#accordion2").css("display", "none");
                $("#designerNameLink").css("text-decoration", "underline");
                $("#designerNameLink").css("cursor", "pointer");
            });

            $("#notLivingRoom").click(function () {
                $("#livingRoom").removeClass("selected");
                $("#notLivingRoom").addClass("selected");
                $(".designerInfoContainer").css("display", "none");
                $("#accordion2").css("display", "block");
                $("#accordion1").css("display", "none");
                $("#designerNameLink").css("text-decoration", "underline");
                $("#designerNameLink").css("cursor", "pointer");
            });

            $("#designerNameLink").click(function () {
                $(".designerInfoContainer").css("display", "block");
                $("#accordion1").css("display", "none");
                $("#accordion2").css("display", "none");
                $("#livingRoom").removeClass("selected");
                $("#notLivingRoom").removeClass("selected");
                $("#designerNameLink").css("text-decoration", "none");
                $("#designerNameLink").css("cursor", "default");
            });


            $("#accordion1, #accordion2").accordion(
            {
                animated: 'slide',
                collapsible: true,
                autoHeight: false,
                active: false,
                change: function (event, ui) {
                    ui.newHeader.css("color", "#cc0000");
                    ui.newHeader.css("text-decoration", "none");
                    ui.oldHeader.css("color", "#a3a3a3");
                    ui.oldHeader.css("text-decoration", "underline");
                }


            });
        });
    </script>
    <%
        
        var designer = (Designer)ViewData["designer"];
    %>
    <div class="designerInfoContainer">
        <div class="degignerName">
            <%=Html.Encode(designer.Name)%></div>
        <div class="designerInfoBlock">
            <div class="designerInfoBlockTop"></div>
            <div class="designerLogo">
                <%=Html.Image("~/Content/DesignerLogos/" + designer.Logo, designer.Name,150)%></div>
            <div class="designerInfo">
                <div class="designerSummary">
                    <%=designer.Summary%>
                </div>
            </div>
            <div class="designerInfoBlockBottom"></div>
        </div>
    </div>
    <div class="accordion" id="accordion1">
        <%
            foreach (var dc in Model.Where(d => d.RoomType == 0))
            {
        %>
        <h3>
            <a href="#">
                <%=dc.RoomName%></a></h3>
        <div>
            <%if (!string.IsNullOrEmpty(dc.Summary))
              {%>
            <div class="designerContentSummary">
            <div class="designerContentSummaryTop"></div>
                <div class="designerContentSummaryContainer">
                <%=dc.Summary%>
                </div>
            <div class="designerContentSummaryBottom"></div>
            </div>

            <%
                }%>
            <% if (Roles.IsUserInRole("Administrators"))
               { %>
            <p class="adminLink">
                <%= Html.ActionLink("Редактировать", "EditContent", "Designers", new { area = "Admin", id = dc.Id }, null)%>
            </p>

            

            <%}
                
                %>
              
                <%
                
               foreach (var item in dc.DesignerContentImages)
               {
            %>
            <div class="photoContainer">
            <a rel="group<%=dc.Id%>" href="../../Content/DesignerPhotos/<%=item.ImageSource%>" class="fancy iframe">
            <%=Html.CachedImage("~/Content/DesignerPhotos/", item.ImageSource, "designerPhotosThumb", item.ImageSource)%>
            </a>
            <%if (Roles.IsUserInRole("Administrators"))
              { %>
              
                <%= Html.ActionLink(".", "DeletePhoto", "Designers", new { area = "Admin", id = item.Id }, new { title = "Удалить фото", onclick = "return confirm('Вы уверены что хотите удалить запись?')", @class = "deletePhotoLink adminLink" })%>
           
            <%}
                   %> 
                   </div>
                   <%
               }

                %>
                 <div style="clear:both;">
                </div>
                <%
                
               if (Roles.IsUserInRole("Administrators"))
                   using (Html.BeginForm("AddPhoto", "Designers", new { area = "Admin", id = dc.Id }, FormMethod.Post, new { enctype = "multipart/form-data" }))
                   {
            %>
            Добавить фото:
            <input type="file" name="logo" />
            <input type="submit" value="Загрузить" />
            <%
                }
                
            %>
        </div>
        <%
            }
        
        %>
    </div>

    <div class="accordion" id="accordion2">
        <%
            foreach (var dc in Model.Where(d => d.RoomType == 1))
            {
        %>
        <h3>
            <a href="#">
                <%=dc.RoomName%></a></h3>
        <div>
            <%if (!string.IsNullOrEmpty(dc.Summary))
              {%>
            <div class="designerContentSummary">
                <%=dc.Summary%>
            </div>
            <%
                }%>
            <% if (Roles.IsUserInRole("Administrators"))
               { %>
            <p class="adminLink">
                <%= Html.ActionLink("Редактировать", "EditContent", "Designers", new { area = "Admin", id = dc.Id }, null)%>
            </p>
            <%}
               foreach (var item in dc.DesignerContentImages)
               {
            %>
            <div class="photoContainer">
            <a rel="group<%=dc.Id%>" href="../../Content/DesignerPhotos/<%=item.ImageSource%>" class="fancy iframe">
            <%=Html.CachedImage("~/Content/DesignerPhotos/", item.ImageSource, "designerPhotosThumb", item.ImageSource)%>
            </a>
            <%if (Roles.IsUserInRole("Administrators"))
              { %>
              <br />
            <span>
                <%= Html.ActionLink("Удалить", "DeletePhoto", "Designers", new { area = "Admin", /*photoId = item.Id, designerContentId=dc.Id*/ id = item.Id }, new { onclick = "return confirm('Вы уверены что хотите удалить запись?')",@class="adminLink" })%>
            </span>
            <%}
                   %> 
                   </div>
                   <%
               }

                %>
                 <div style="clear:both;">
                </div>
                <%

               if (Roles.IsUserInRole("Administrators"))
                   using (Html.BeginForm("AddPhoto", "Designers", new { area = "Admin", id = dc.Id }, FormMethod.Post, new { enctype = "multipart/form-data" }))
                   {
            %>
            Добавить фото:
            <input type="file" name="logo" />
            <input type="submit" value="Загрузить" />
            <%
                }
                
            %>
        </div>
        <%
            }
        
        %>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentHeader" runat="server">
    <div id="headerTitle">
        <span class="sign1">Портфоло дизайнера</span>
        <br />
        <a href="#" id="designerNameLink" class="sign2">
            <%=((Designer)ViewData["designer"]).NameF%></a>
    </div>
    <div id="roomsType">
        <a href="#" id="livingRoom">Жилые помещения</a> <a href="#" id="notLivingRoom">Нежилые
            помещения</a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link href="/Content/LislelliStyles/Designers.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/jquery-ui-1.8.11.custom.min.js"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
