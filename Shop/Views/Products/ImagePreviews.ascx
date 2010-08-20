<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<div id="imagePreviews">
<%foreach (var item in Model){%>
    <div class="imageItem">
        <%= Html.CachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1", item.Product.Name)%>
        <div class="fadeImage"></div>
    </div>
<%} %>
</div>

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
        $("#mainImage a#mi").fancybox({ autoScale: false, titleShow: false, hideOnContentClick: true, hideOnOverlayClick: true });

        $(".imageItem img").click(function(ev, elem) {
            var src = this.src.substring(this.src.lastIndexOf("/"));
            var href = "/Content/ProductImages" + src;
            $.get("/Graphics/ShowMain" + src + "?alt=" + this.alt, function(data) {
                $("#mainImage a#mi").html(data);
            });
            $("#mainImage a").attr("href", href);

            $(".fadeImage").fadeOut(0);
            $(this).next("div").css("display", "block").fadeTo(0, 0.5);

        });

        window.setTimeout(calculateDimensions, 500);
    })
</script>