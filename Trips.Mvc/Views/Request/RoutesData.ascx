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
                <span class="lessFont2">
                    <%= item.Value.ToString("#0.0") %>
                </span>
            </h5>
            <p>
                (<%= Html.ResourceString("RecountIn") %>
                <a href="#">
                    <%= Html.ResourceString("Euro") %></a>, <a href="#">
                        <%= Html.ResourceString("Ruble") %></a>
                <%= Html.ResourceString("Or").ToLower() %>
                <a href="#">
                    <%= Html.ResourceString("Dollars") %></a>)
            </p>
        </div>
    </div>
</div>
<%} %>
