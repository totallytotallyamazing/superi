<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Areas.BrandCatalog.Models.CatalogueImage>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<div class="catalogueImage">
    <div class="delete">
        <%= Html.CheckBox("imageDelete_" + Model.Id) %>
    </div>
    <div class="sortOrder">
        <%= Html.TextBox("imageSortOrder_" + Model.Id, Model.SortOrder) %>
    </div>
    <%= Html.CachedImage("~/Content/CatalogueImages/Brand" + ViewData["brandId"] + "Group" + ViewData["groupId"], Model.Image, "catalogueThumb", "") %>
</div>

