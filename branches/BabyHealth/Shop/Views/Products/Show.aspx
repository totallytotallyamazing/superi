<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Roles.IsUserInRole("Administrators"))
       { %>
    <div class="adminLink">
        <%= Html.ActionLink("Редактировать", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = Model.Category.Id, bId = (Model.Brand != null) ? Model.Brand.Id : 0 }, null).ToString()%> | 
        <%= Html.ActionLink("Удалить", "Delete", "Products", new { area = "Admin", id = Model.Id }, new { onclick="return confirm('Вы уверены?')" }).ToString()%>
    </div>
    <%} %>
    <div id="linksBoxC">
        <div class="productTitle">
            <h2>
                <%= Model.Name %>
            </h2>
        </div>
        <% using(Html.BeginForm(new {controller="Cart", action="Add", id=Model.Id})){ %>
            <div id="tovar">
            <% Shop.Models.ProductImage img = Model.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = Model.Name } }).First();
               %>
                <% Html.RenderPartial("ProductImage", img); %>
                <% if(Model.IsNew){ %>
                    <div id="new1">
                    </div>
                <%} %>
                <% Html.RenderPartial("ImagePreviews", Model.ProductImages.OrderByDescending(pi=>pi.Default)); %>
            </div>
        <div id="tovarDesk">    
            <p>
                <%= Model.Description %>
            </p>
            <br />
            <p>Артикул: <strong><%= Model.PartNumber %></strong></p>
            <br />
            <%if (!string.IsNullOrEmpty(Model.Color)){ %>
                <p>Цвет: <strong><%= Model.Color %></strong></p>
                <br />
            <%} %>
            <p><% Html.RenderPartial("ProductAttributesSelector", Model.ProductAttributeValues); %></p>
            <br />
            <p>
                <%= Model.ShortDescription %>
            </p>
            <br />
            <p>Цена: <% Html.RenderPartial("Price", Model); %></p>

            <% if (Model.PersonalExperienceSet)
                   Html.RenderPartial("PersonalExperience", Model.PersonalExperience); %>
        </div>
        <%} %>
        <div style="clear:both"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Name %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/tovar.css" />
</asp:Content>
