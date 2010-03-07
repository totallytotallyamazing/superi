<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.Route>>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Маршруты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <% foreach (var item in Model)
           {
               Html.RenderPartial("Route", item);     
           } %>
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
       
<div class="newRoute">
    <label for="fromCityId" title="Откуда">Откуда</label><br />
    <%= Html.DropDownList("fromCityId", fromCities) %><br />
    <label for="toCityId" title="Куда">Куда</label><br />
    <%= Html.DropDownList("toCityId", toCities) %><br />
    <label for="distance" title="Расстояние">Расстояние</label><br />
    <%= Html.TextBox("distance") %><br />
    <label for="priceStandard" title="Цена за стандарт">Цена за стандарт</label><br />
    <%= Html.TextBox("priceStandard")%><br />
    <label for="priceMiddle" title="Цена за средний">Цена за средний</label><br />
    <%= Html.TextBox("priceMiddle")%><br />
    <label for="priceBusiness" title="Цена за бизнес">Цена за бизнес</label><br />
    <%= Html.TextBox("priceBusiness")%><br />
    <label for="priceMinivan" title="Цена за минивен">Цена за минивен</label><br />
    <%= Html.TextBox("priceMinivan")%><br />
    <label for="priceMultivan" title="Цена за мультивен">Цена за мультивен</label><br />
    <%= Html.TextBox("priceMultivan")%><br />
    <div style="display:none">
        <label for="priceLux" title="Цена за люкс">Цена за люкс</label><br />   
        <%= Html.TextBox("priceLux", 0)%>
    </div>
    <div>
        <input type="submit" value="Добавить" />
    </div>
</div>
<% } %>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Admin.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    Маршруты
</asp:Content>
