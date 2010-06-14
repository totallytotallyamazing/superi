<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Product>" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="linksBoxC">
        <div id="tovar">
            <% Html.RenderPartial("ProductImages", Model.ProductImages); %>
        </div>
        <div id="tovarDesk">
            <p>
                <%= Model.Description %>
            </p>
            <br />
            <p>
                Артикул: <strong><%= Model.PartNumber %></strong>
            </p>
            <br />
            <%= Model.ShortDescription %>
            <br />
            <p>
                <% Html.RenderPartial("ProductAttributes", Model.ProductAttributeValues); %>
            </p>
            <br />
            <p>
                Цена: <strong>1,200 <%= WebSession.Currency %></strong>
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
