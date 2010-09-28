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
        <%= Html.ActionLink("Редактировать", "AddEdit", "Products", new { area = "Admin", id = Model.Id, bId = (Model.Brand != null) ? Model.Brand.Id : 0 }, null).ToString()%>
        |
        <%= Html.ActionLink("Удалить", "Delete", "Products", new { area = "Admin", id = Model.Id }, new { onclick="return confirm('Вы уверены?')" }).ToString()%>
    </div>
    <%} %>
    <% using (Html.BeginForm(new { controller = "Cart", action = "Add", id = Model.Id }))
       { %>
    <div id="imgProduct">
        <% Shop.Models.ProductImage img = Model.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = Model.Name } }).First();
        %>
        <% Html.RenderPartial("ProductImage", img); %>
        <% if (Model.IsNew)
           { %>
        <div id="new1">
        </div>
        <%} %>
        <% Html.RenderPartial("ImagePreviews", Model.ProductImages.OrderByDescending(pi => pi.Default)); %>
    </div>
    <div id="productMenu">
        <div id="smalProduct">
            <p class="pmt1">
                <a href="#" class="pmt1">Эконом </a>
            </p>
            <p class="pmt3">
                70 грн.
            </p>
        </div>
        <div id="bigProduct">
            <p class="pmt2">
                Большой
            </p>
            <div class="priceNonBlock">
            <p class="pmt3">
                <% Html.RenderPartial("Price", Model); %>
            </p>
            </div>
        </div>
        <div id="midProduct">
            <p class="pmt1">
                <a href="#" class="pmt1">Средний </a>
            </p>
            <p class="pmt3">
                100 грн.
            </p>
        </div>
    </div>
    <div id="productDescr">
        <p class="dt1">
            <%= Model.Description %></p>
        <br />
        <p class="it1">
            <b>Описание:</b> <%= Model.ShortDescription %>
            <br />
            <b>Цвет:</b> <%= Model.Color %>
            <br />
            <b>Артикул:</b> <%= Model.PartNumber %>
        </p>
        <br />
        <p class="dt2">
            <a href="#" onclick="$(this).parents('form')[0].submit()" class="dt2"><b>Заказать »</b></a></p>
    </div>
    <div id="individual">
        <p class="dt3">
            P.S. Если хочется чего-то оригинального, мы всегда готовы предложить
            <br />
            &ensp;&ensp;&ensp;&nbsp;&nbsp;Вам <a href="#" class="dt3"><b>индивидуальный заказ!</b></a></p>
    </div>
    <%} %>
    <div style="clear: both">
    </div>
    <%--<div id="linksBoxC">
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
        </div>
        <%} %>
        <div style="clear:both"></div>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <div id="contName">
        <div id="pagePic">
            <img src="../../Content/UnMomentoStyles/img/tree.gif" alt="Древо" />
        </div>
        <div id="pageName">
            <p class="pt1">
                <%= Model.Name %></p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/tovar.css" />
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <div id="pager">
        <p class="pgt1">
            <a href="#" class="pgt1">« В каталог</a></p>
    </div>
</asp:Content>
