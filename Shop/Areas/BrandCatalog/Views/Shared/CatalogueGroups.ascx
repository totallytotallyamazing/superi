<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Shop.Areas.BrandCatalog.Models" %>
<% using(BrandCatalogue context = new BrandCatalogue()){
       var groups = context.CatalogueGroups.Select(cg => new { Name = cg.Name, Id = cg.Id });
%>

<div id="cbBrandBox">
    <p class="txtLeftMenu">
        Группа каталогов:</p>
    <div id="cbBrand">
        <select id="selectBrand">
            <% foreach (var item in groups){
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", item.Id, item.Name));
            } %>
        </select>                        
    </div>
</div>
<%} %>

<div id="topMenu">

</div>