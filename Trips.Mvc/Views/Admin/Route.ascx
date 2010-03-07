<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trips.Mvc.Models.Route>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<% 
    List<SelectListItem> fromCities;
    List<SelectListItem> toCities;
    float standardPrice, middlePrice, businessPrice, minivanPrice, multivanPrice, luxPrice;
    float distance;
    
    using (RouteStorage context = new RouteStorage())
    {
        List<City> cities = context.Cities.Include("CityNames").ToList();

        fromCities = cities
            .Select(c => new SelectListItem 
            { 
                Text = c.CityNames.ToDictionary(cn=>cn.Language, cn=>cn.Name)["ru-RU"], 
                Value = c.Id.ToString(), 
                Selected = c.Id == Model.FromCityId 
            }).ToList();

        toCities = cities
            .Select(c => new SelectListItem
            {
                Text = c.CityNames.ToDictionary(cn => cn.Language, cn => cn.Name)["ru-RU"],
                Value = c.Id.ToString(),
                Selected = c.Id == Model.ToCityId
            }).ToList();

        distance = Model.Distance;

        Dictionary<long, float> prices = Model.RoutePrices.ToDictionary(rp => rp.ClassId, rp => rp.Price);

        standardPrice = prices[(long)CarAdClasses.Standard];
        middlePrice = prices[(long)CarAdClasses.Middle];
        businessPrice = prices[(long)CarAdClasses.Business];
        minivanPrice = prices[(long)CarAdClasses.Minivan];
        multivanPrice = prices[(long)CarAdClasses.Multivan];
        luxPrice = prices[(long)CarAdClasses.Lux];
    }    
%>
        <% using (Html.BeginForm("UpdateRoute", "Admin", FormMethod.Post)){%>
            <tr>
                <td>
                    <%= Html.Hidden("id", Model.Id) %>
                    <%= Html.DropDownList("fromCityId", fromCities) %>
                </td>
                <td>
                    <%= Html.DropDownList("toCityId", toCities) %>
                </td>
                <td>
                    <%= Html.TextBox("distance", distance) %>
                </td>
                <td>
                    <%= Html.TextBox("priceStandard", standardPrice)%>
                </td>
                <td>
                    <%= Html.TextBox("priceMiddle", middlePrice)%>
                </td>
                <td>
                    <%= Html.TextBox("priceBusiness", businessPrice)%>
                </td>
                <td>
                    <%= Html.TextBox("priceMinivan", minivanPrice)%>
                </td>
                <td>
                    <%= Html.TextBox("priceMultivan", multivanPrice)%>
                </td>
                <td style="display:none">
                    <%= Html.TextBox("priceLux", luxPrice)%>
                </td>
                <td>
                    <input type="submit" value="Сохранить" />
                </td>
                <td>
                    <%= Html.ActionLink("Удалить", "DeleteRoute", "Admin", new {id = Model.Id}, null) %>
                </td>
            </tr>   
         <%} %>