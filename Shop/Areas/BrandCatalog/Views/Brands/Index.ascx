<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Areas.BrandCatalog.Models.CatalogueImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<div id="titleBoxBrandCatalog">
    <p>
        <span class="txtPageName"><%= ViewData["brandName"]%></span> &nbsp&nbsp&nbsp&nbsp&nbsp
        <span class="txtDescription"><%= ViewData["brandDescription"]%></span> 
    </p>
</div>
<div id="thumbnails">
    <div id="leftArrow"></div>
    <div id="rightArrow"></div>
    <div id="dockWrapper">
        <div id="dock">
        
            <div class="dock-container">
             
        <% foreach (var item in Model){%>
                    <a href='#' class="dock-item">
                    
                        <span></span>
                        <%= Html.CachedImage("~/Content/CatalogueImages/Brand" + ViewData["brandId"] + "Group" + ViewData["groupId"], item.Image, "catalogueThumb", item.Image)%>
                    </a>
        <%} %>                
            </div>
        </div>
    </div>
</div>    