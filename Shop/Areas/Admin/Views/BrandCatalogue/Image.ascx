<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Areas.BrandCatalog.Models.CatalogueImage>" %>

<div class="catalogueImage">
    <div class="delete">
        <%= Html.CheckBox("imageDelete_" + Model.Id) %>
    </div>
    <div class="sortOrder">
        <%= Html.TextBox("imageSortOrder_" + Model.Id, Model.SortOrder) %>
    </div>

</div>

