<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<List<Shop.Models.DesignerContent>>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#accordion").accordion(
            {
                animated: 'slide',
                /*collapsible: true,*/
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
            <div class="designerLogo">
                <%=Html.Image("~/Content/DesignerLogos/" + designer.Logo, designer.Name,150)%></div>
            <div class="designerInfo">
                <div class="designerSummary"><%=designer.Summary%></div>
            </div>
        </div>
    </div>
    <div id="accordion">
        <%
            foreach (var dc in Model)
            {
        %>
        <h3>
            <a href="#">
                <%=dc.DesignerRoom.Name%></a></h3>
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
            <%=Html.CachedImage("~/Content/DesignerPhotos/", item.ImageSource, "designerPhotosThumb", item.ImageSource)%>
            <%
                }

               if (Roles.IsUserInRole("Administrators"))
                   using (Html.BeginForm("AddPhoto", "Designers", new { area = "Admin", id = dc.Id }, FormMethod.Post, new { enctype = "multipart/form-data" }))
                   {
            %>
            Добавить фото: <input type="file" name="logo" /> <input type="submit" value="Загрузить" />
            <%
                }
                
            %>
        </div>
        <%
            }
        
        %>
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
