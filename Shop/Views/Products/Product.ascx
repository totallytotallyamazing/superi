<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<% bool isAdmin = (bool)(ViewData["isAdmin"] ?? false); %>
<%if (Model.Published || isAdmin)
  { %>
<%
    string additionalClass = string.Empty;
    if (!Model.Published && isAdmin)
        additionalClass = " translucent";
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id = Model.Id }).ToString();
%>
<div class="productItem">
    <img src="../../Content/UnMomentoStyles/img/sheep.gif" alt="Овца" />
    <div id="item1Txt">
        <span class="it1"><b>
            <%= productClickLink.Replace("[IMAGE]", Model.Name)%>,</b></span>
        <%= Model.ShortDescription %>
        <div class="priceNonBlock">
            <p class="it2">
            
                <% Html.RenderPartial("Price", Model); %>
                 
                </p>
       </div>
        <a href="#" class="it3">Заказать »</a>
    </div>
</div>
<%--<div class="tovarBox<%= additionalClass %>">


    <div class="nazva">
        <p>
            <%= Html.ActionLink("™" + ((Model.Brand != null) ? Model.Brand.Name : string.Empty), "Index", new { controller = "Products", area = "", id = WebSession.CurrentCategory, brandId = (Model.Brand != null) ? Model.Brand.Id : (int?)null })%>
        </p>
    </div>
    <div class="item">
        <% 
            Shop.Models.ProductImage img = Model.ProductImages.Where(pi => pi.Default).FirstOrDefault();
            if (img != null)
            {
               %>
               
        <%= Html.ActionLink("[IMAGE]", "Show", new { id = Model.Id }).ToString()
            .Replace("[IMAGE]",
                        Html.CachedImage("~/Content/ProductImages", img.ImageSource, "thumbnail2", Model.Name)) + "<br />"%>
        <%}
           else
           {
               Response.Write(productClickLink.Replace("[IMAGE]", Model.Name));
           }
        %>
        <%if (Model.IsNew){ %>
            <div class="new">
            </div>
        <%} %>
        jg,fhj,fhj,fhj.,fhj.fhk.
    </div>
    <div class="itemDesc">
        <div class="productName"><%= productClickLink.Replace("[IMAGE]", Model.Name) %></div>
        <p><%= Model.ShortDescription %></p>
        <h4><% Html.RenderPartial("Price", Model); %></h4>
    </div>
</div>--%>
<%} %>