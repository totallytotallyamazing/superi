<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Pandemiia.Models.Entity>" %>
<%@ Import Namespace="Pandemiia.Helpers" %>
<%@ Import Namespace="Pandemiia.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
<%= Html.RegisterJS("jquery.fancybox.js")%>
<%= Html.RegisterJS("jquery.easing.js")%>
<script type="text/javascript">
    $(function() {
    $(".image a").fancybox({ 'overlayShow': true, 'padding': 0, 'imageScale': true })
    })
</script>
<div class="imagesContainer">
    <% foreach (EntityPicture image in Model.EntityPictures)
       {
           string imagePath = VirtualPathUtility.ToAbsolute("~/EntityImages/" + image.Picture);
           string previewPath = VirtualPathUtility.ToAbsolute("~/EntityImages/" + image.Preview);
           %>
       <div class="image">
        <a rel="group" href="<%= imagePath %>">
            <img src="<%= previewPath %>" alt="" style="width:240px; height:318px; border:1px solid #2f2f2f;" />
        </a>
       </div>
    <%} %>
    <div style="clear:both"></div>
</div>