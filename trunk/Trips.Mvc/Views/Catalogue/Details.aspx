<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trips.Mvc.Models.CarAd>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Trips.Mvc.Helpers" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["title"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="bigPhoto">
        <div id="bigPhotoBox">  
            <% 
                string imageSource = null;
                CarAdImage image = Model.Images.Where(i => i.Default).FirstOrDefault();
                if (image != null)
                { %>
                    <a href="/Content/AdImages/<%= image.ImageSource %>">
                        <%= Html.Image(GraphicsHelper.GetCachedImage("~/Content/AdImages", image.ImageSource, "mainView"))%>
                    </a>                 
            <%  }
                List<CarAdImage> images = Model.Images.OrderByDescending(i=>i.Default).ToList();
            %>
           <%-- <img src="img/carBigPhoto.jpg" alt="car">--%>
        </div>
        <div id="carPhotoViews">
            <%foreach (var item in images)
              {%>
                <div class="carPhoto">
                    <%= Html.Image(GraphicsHelper.GetCachedImage("~/Content/AdImages", item.ImageSource, "thumbnail2"))%>
                    <div class="fadeImage"></div>
                </div>
            <%} %>
        </div>
        <div id="carText">
            <h4>
                <%= Model.Descriptions.Where(d=>d.Language == LocaleHelper.GetCultureName()).Select(d=>d).First().Text %>
            </h4>
        </div>
        <p>
            <a href="#">Добавить в заявку</a></p>
    </div>
    <div class="clearBoth">
    </div>
    <div class="line">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">  
    <%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
    <%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js")%>
    <%= Ajax.ScriptInclude("/Scripts/jquery.easing.js")%>
    
    <script type="text/javascript">

        function calculateDimensions() {
            $(".fadeImage").each(function() {
                var width = $(this).prev("img").width();
                var height = $(this).prev("img").height() + 5;
                this.style.width = width + "px";
                this.style.height = height + "px";
                this.style.position = "relative";
                this.style.left = 0 + "px";
                this.style.top = - height + "px";
                $(this).fadeTo(0.3);
                this.style.background = "White";
                this.style.display = "none";

            });

            $(".fadeImage").eq(0).fadeTo(0, 0.5);
            
        }

        $(function() {
            $("#bigPhotoBox a").fancybox();

            $(".carPhoto img").click(function(ev, elem) {
                var src = this.src.substring(this.src.lastIndexOf("/"));
                src = "/ImageCache/mainView/" + src;
                $(".fadeImage").fadeOut(0);
                $(this).next("div").css("display", "block").fadeTo(0, 0.5);
            });

            window.setTimeout(calculateDimensions, 500);
            
        })
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= ViewData["title"] %>
</asp:Content>
