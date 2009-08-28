<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Product>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%
    bool hasImage = Convert.ToBoolean(ViewData["hasImage"]);
%>
<div class="productDescription">
    <%
        if (hasImage)
        {
            int imageId = Convert.ToInt32(ViewData["imageId"]);
            %>
            <div class="productDescriptionImage">
                <%= Html.Image("~/Image/ProductImageScaled/" + imageId + "/300")%>
            </div>
            <%
        }
    %>
    <%= Model.GetDescription(SystemSettings.CurrentLanguage) %>
</div>