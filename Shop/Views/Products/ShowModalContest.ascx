<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Models" %>
<div class="productModal">
<input type="hidden" id="showMethod" value="ShowMainContest" />
    <% if (Roles.IsUserInRole("Administrators"))
       { %>
    <div class="adminLink">
        <%= Html.ActionLink("Редактировать", "AddEdit", "Products", new { area = "Admin", id = Model.Id, bId = (Model.Brand != null) ? Model.Brand.Id : 0 }, null).ToString()%>
        |
        <%= Html.ActionLink("Удалить", "Delete", "Products", new { area = "Admin", id = Model.Id }, new { onclick="return confirm('Вы уверены?')" }).ToString()%>
    </div>
    <%} %>
    <div id="imgProduct" style="float:none !important; margin:0 auto !important; width:535px !important">
        <% Shop.Models.ProductImage img = Model.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = Model.Name } }).First();%>
        
        <%
            ViewDataDictionary<string> vdd = new ViewDataDictionary<string>();
            vdd.Add("methodName", "ShowMainContest");
         %>

        <% Html.RenderPartial("ProductImage", img, vdd); %>
        
        <% if (Model.IsNew)
           { %>
        <div id="new1">
        </div>
        <%} %>
        <% Html.RenderPartial("ImagePreviews", Model.ProductImages.OrderByDescending(pi => pi.Default)); %>
    </div>
    <div id="productDescription" style="margin:0 auto !important; width:450px !important;">
        <div class="attributes attributesContest">
            <% Html.RenderPartial("ProductStaticAttributes", Model.ProductAttributeStaticValues); %>
        </div>
    </div>
</div>
