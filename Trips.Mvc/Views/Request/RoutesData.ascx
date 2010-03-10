<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<CarAdClasses, float>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<% foreach (var item in Model)
   {%>
<div class="calc">
    <h3>
        <%= Html.ResourceString(string.Format("Class{0}Calculation", item.Key)) %>:
    </h3>
    <div class="raschetBox">
        <div class="raschetBoxLeft">
        </div>
        <div class="raschetBoxRight">
        </div>
        <div class="raschetBoxContent">
            <h5>
                <%= Html.ResourceString("ApproximatePrice")%>: 
                <span id="priceLabel_<%= item.Key %>" class="lessFont2">
                    <%= item.Value.ToString("#0.0") %>
                </span>
                <%= Html.Hidden("price_" + item.Key, item.Value.ToString(System.Globalization.CultureInfo.CurrentUICulture)) %>
            </h5>
            <p>
                (<%= Html.ResourceString("RecountIn") %>
                <a href="javascript:recalculateIn(currency.euro, 'price_<%= item.Key %>', 'priceLabel_<%= item.Key %>')">
                    <%= Html.ResourceString("Euro") %>
                </a>, <a href="javascript:recalculateIn(currency.ruble, 'price_<%= item.Key %>', 'priceLabel_<%= item.Key %>')">
                    <%= Html.ResourceString("Ruble") %>
                </a>
                <%= Html.ResourceString("Or").ToLower() %>
                <a href="javascript:recalculateIn(currency.dollar, 'price_<%= item.Key %>', 'priceLabel_<%= item.Key %>')">
                    <%= Html.ResourceString("Dollars") %>
                </a>)
            </p>
        </div>
    </div>
</div>
<%} %>
