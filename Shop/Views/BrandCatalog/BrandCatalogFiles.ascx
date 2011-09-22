<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.BrandCatalogFile>>" %>

    
    <% foreach (var item in Model) {
           string url = "http://listelli.ua/Content/BrandCatalogFiles/" + item.FileName;
            %>
    <div class="brCatFile">
       <a href="<%=url%>">
        <%: item.Title %>
        </a>
    </div>
    <% } %>
    <div class="brCatFileSeparator">
    </div>
    


