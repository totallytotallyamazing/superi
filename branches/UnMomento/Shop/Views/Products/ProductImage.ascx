<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    Shop.Models.ProductImage img = Model.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = Model.Name } }).First();
    var mainImage = img;
    string alt = (mainImage != null) ? mainImage.Product.Name : "";
%>

    <%if(mainImage!=null){ %>
        <a id="mi" href="/Content/ProductImages/<%= mainImage.ImageSource %>">
            <% Html.RenderAction("ShowMain", new { controller = "Graphics", area = "", id = mainImage.ImageSource, alt = mainImage.Product.Name }); %>
        </a>
    <%} %>

<script type="text/javascript">
    $(function() {
        $("#mainImage a#mi").fancybox({ autoScale: false, titleShow: false, hideOnContentClick: true, hideOnOverlayClick: true });
    });
</script>