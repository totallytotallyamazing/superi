<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductImage>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    var mainImage = Model;
    string alt = (mainImage != null) ? mainImage.Product.Name : "";
%>
<%if (mainImage != null)
  { %>
<a id="mi" href="/Content/ProductImages/<%= mainImage.ImageSource %>">
    <% Html.RenderAction("ShowMain", new { controller = "Graphics", area = "", id = mainImage.ImageSource, alt = mainImage.Product.Name }); %>
</a>
<%} %>
<%--<div class="orderButton">
        <a href="#" onclick="$(this).parents('form')[0].submit()" >Добавить в корзину</a>
    </div>--%>
<script type="text/javascript">
    $(function () {
        $("#mainImage a#mi").fancybox({ autoScale: false, titleShow: false, hideOnContentClick: true, hideOnOverlayClick: true });
    });
</script>
