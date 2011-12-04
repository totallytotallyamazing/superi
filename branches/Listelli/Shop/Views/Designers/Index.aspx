<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master"
    Inherits="System.Web.Mvc.ViewPage<List<Shop.Models.DesignerContent>>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Портфолио дизайнера <%=((Designer)ViewData["designer"]).NameF%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">



        $(function () {

            function formatTitle(title, currentArray, currentIndex, currentOpts) {
                return (title == '' || title == null || title == ' ') ? '' : '<div id="fancy-title">' + title + '</div>';
            };

            $(".fancy").fancybox({ titlePosition: 'inside', titleFormat: formatTitle, titleShow: true, showCloseButton: true, cyclic: true, showNavArrows: true, padding: 0, margin: 0, centerOnScroll: true });

            $("#livingRoom").click(function () {
                $("#livingRoom").addClass("selected");
                $("#notLivingRoom").removeClass("selected");
                $(".designerInfoContainer").css("display", "none");
                $("#accordion1").css("display", "block");
                $("#accordion2").css("display", "none");
                $("#designerNameLink").css("text-decoration", "underline");
                $("#designerNameLink").css("cursor", "pointer");
                this.blur();
            });

            $("#notLivingRoom").click(function () {
                $("#livingRoom").removeClass("selected");
                $("#notLivingRoom").addClass("selected");
                $(".designerInfoContainer").css("display", "none");
                $("#accordion2").css("display", "block");
                $("#accordion1").css("display", "none");
                $("#designerNameLink").css("text-decoration", "underline");
                $("#designerNameLink").css("cursor", "pointer");
                this.blur();
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
                    //ui.newHeader.css("text-decoration", "none");
                    ui.oldHeader.css("color", "#a3a3a3");
                    //ui.oldHeader.css("text-decoration", "underline");
                }


            });

            $("#accordion1 h3, #accordion2 h3").click(function () {

                this.blur();
            });


            //$("#accordion1, #accordion2").bind("accordionchange", function (event, ui) {
            // $(".accordion h3 a").each(function () {
            //alert(this.href);
            //this.blur();
            // });
            //$(".accordion h3 a").blur();
            //});


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
                } 
                
               
               foreach (var item in dc.DesignerContentImages)
               {
            %>
            <div class="photoContainer">
            <a title="<%=item.Description%>" rel="group<%=dc.Id%>" href="../../Content/DesignerPhotos/<%=item.ImageSource%>" class="fancy">
            <%=Html.CachedImage("~/Content/DesignerPhotos/", item.ImageSource, "designerPhotosThumb", item.ImageSource,true)%>
            </a>
           <div class="description">
            <%=item.Description %>
            </div>
                   </div>
                   <%
               }

                %>
                 <div style="clear:both;">
                </div>
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
            <div class="designerContentSummaryTop"></div>
                <div class="designerContentSummaryContainer">
                <%=dc.Summary%>
                </div>
            <div class="designerContentSummaryBottom"></div>
            </div>
            <%
                }
                
               foreach (var item in dc.DesignerContentImages)
               {
            %>
            <div class="photoContainer">
            <a title="<%=item.Description%>" rel="group<%=dc.Id%>" href="../../Content/DesignerPhotos/<%=item.ImageSource%>" class="fancy iframe">
            <%=Html.CachedImage("~/Content/DesignerPhotos/", item.ImageSource, "designerPhotosThumb", item.ImageSource,true)%>
            </a>
            <div class="description">
            <%=item.Description %>
            </div>
                   </div>
                   <%
               }

                %>
                 <div style="clear:both;">
                </div>
                
        </div>
        <%
            }
        
        %>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentHeader" runat="server">
    <div id="headerTitle">
        <span class="sign1">Портфолио дизайнера</span>
        <br />
        <a href="#" id="designerNameLink" class="sign2">
            <%=((Designer)ViewData["designer"]).NameF%></a>
    </div>
    <div id="roomsType">
        <a href="#" id="livingRoom"><%=((Designer)ViewData["designer"]).Room0%></a> <a href="#" id="notLivingRoom"><%=((Designer)ViewData["designer"]).Room1%></a>
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
