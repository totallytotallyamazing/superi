<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Areas.BrandCatalog.Models.CatalogueImage>>" %>
<%
    using (Html.BeginForm())
    {
        foreach (var image in Model)
        {
            Html.RenderPartial("Image", image);
        }
    }
%>