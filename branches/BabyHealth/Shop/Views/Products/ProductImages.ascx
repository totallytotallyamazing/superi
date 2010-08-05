<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% 
    var mainImage = Model.Where(m => m.Default).FirstOrDefault();
    var images = Model.ToList();
%>
<div id="mainImage">
    <%if(mainImage!=null){ %>
        <a id="mi" href="/Content/ProductImages/<%= mainImage.ImageSource %>">
            <% Html.RenderAction("ShowMain", new { controller = "Graphics", area = "", id = mainImage.ImageSource, alt = mainImage.Product.Name }); %>
        </a>
    <%} %>
    <div class="orderButton">
        <a href="#" onclick="$(this).parents('form')[0].submit()" >Добавить в корзину</a>
    </div>
</div>
<div id="imagePreviews">
<%foreach (var item in images){%>
    <div class="imageItem">
        <%= Html.CachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1", mainImage.Product.Name) %>
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
            $("#mainImage a#mi").fancybox();

            $(".imageItem img").click(function(ev, elem) {
                var src = this.src.substring(this.src.lastIndexOf("/"));
                var href = "/Content/ProductImages" + src;
                //src = "/ImageCache/mainView" + src;

                $("#mainImage a#mi").load("/Graphics" + src + "?alt=" + this.alt);
                
               // $("#mainImage img").attr("src", src);
                window.setTimeout(function() { $("#mainImage img").attr("src", src); }, 500);
                $("#mainImage a").attr("href", href);

                $(".fadeImage").fadeOut(0);
                $(this).next("div").css("display", "block").fadeTo(0, 0.5);

            });

            window.setTimeout(calculateDimensions, 500);
        })
    </script>