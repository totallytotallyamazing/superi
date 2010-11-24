<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Areas.BrandCatalog.Models.CatalogueImage>>" %>
<%
    using (Html.BeginForm())
    {
        %><%= Html.Hidden("brandId") %><%
        %><%= Html.Hidden("groupId") %><%
        foreach (var image in Model)
        {
            Html.RenderPartial("Image", image);
        }
        %>
        <div style="clear:both"></div>
        <input type="submit" value="Сохраниить порядок и удалить отмеченные" /><%
    }
%>