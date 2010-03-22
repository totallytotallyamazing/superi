<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.Route>>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Маршруты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table cellspacing="10">
        <tr>
            <th align="center">Откуда:</th>
            <th align="center"></th>
            <th align="center">Куда:</th>
            <th align="center">Что делаем:</th>
        </tr>
        <% foreach (var item in Model)
           {
               Html.RenderPartial("Route", item);     
           } %>    
    </table>

<div style="clear:both">


</div>
<% using (Html.BeginForm("AddRoute", "Admin"))
   {
           
    List<SelectListItem> fromCities;
    List<SelectListItem> toCities;
    
    using (RouteStorage context = new RouteStorage())
    {
        List<City> cities = context.Cities.Include("CityNames").ToList();

        fromCities = cities
            .Select(c => new SelectListItem
            {
                Text = c.CityNames.ToDictionary(cn => cn.Language, cn => cn.Name)["ru-RU"],
                Value = c.Id.ToString(),
            }).ToList();

        toCities = cities
            .Select(c => new SelectListItem
            {
                Text = c.CityNames.ToDictionary(cn => cn.Language, cn => cn.Name)["ru-RU"],
                Value = c.Id.ToString(),
            }).ToList();
    }
       %>

<div id="addRouteLabel">Добавить маршрут</div>
       
<div class="newRoute">  
    <div id="addRouteProperties">
        <div>
            <label for="fromCityId" title="Откуда">Откуда</label><br />
            <%= Html.DropDownList("fromCityId", fromCities) %><br />
        </div>
        <div>
            <label for="toCityId" title="Куда">Куда</label><br />
            <%= Html.DropDownList("toCityId", toCities) %><br />
        </div>
        <div>
            <label for="distance" title="Расстояние">Расстояние</label><br />
            <%= Html.TextBox("distance") %><br />
        </div> 
    </div>
    <div id="addRoutePricesLabel">Цены</div>
    <div id= "addRoutePrices">
        <div>
            <label for="priceStandard" title="Cтандарт">Стандарт</label><br />
            <%= Html.TextBox("priceStandard")%>
        </div>
        <div>
            <label for="priceMiddle" title="Cредний">Средний</label><br />
            <%= Html.TextBox("priceMiddle")%>
        </div>
        <div>
            <label for="priceBusiness" title="Бизнес">Бизнес</label><br />
            <%= Html.TextBox("priceBusiness")%>
        </div>
        <div>
            <label for="priceMinivan" title="Минивен">Минивен</label><br />
            <%= Html.TextBox("priceMinivan")%>
        </div>
        <div>
            <label for="priceMultivan" title="Мультивен">Мультивен</label><br />
            <%= Html.TextBox("priceMultivan")%>
        </div>
        <div style="display:none">
            <label for="priceLux" title="Люкс">Люкс</label><br />   
            <%= Html.TextBox("priceLux", 0)%>
        </div>
    </div>
    <div style="text-align:center; clear:both; padding-top:10px;">
        <input type="submit" value="Добавить" />
    </div>
</div>
<% } %>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Admin.css" />
    <script src="/Scripts/jquery.ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $(".routeContainer").dialog({ autoOpen: false, resizable: false, modal: true });
        });
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    Маршруты
</asp:Content>
