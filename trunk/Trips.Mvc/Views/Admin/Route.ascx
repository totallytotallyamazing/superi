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
            .Where(c=>c.Id == 1 || c.Id == 3 )
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
    <tr>
        <td align="center">
            <%= fromCities.Where(tc=>tc.Value == Model.FromCityId.ToString()).Select(c=>c.Text).First() %>
        </td>
        <td align="center">
            →
        </td align="center">
        <td align="center">
            <%= toCities.Where(tc=>tc.Value == Model.ToCityId.ToString()).Select(c=>c.Text).First() %>
        </td>
        <td align="center">
            <a href="#" id="show_<%= Model.Id %>">редактируем</a> &nbsp; / &nbsp;  <%= Html.ActionLink("удаляем", "DeleteRoute", "Admin", new {id = Model.Id}, null) %>
            <div style="display:none;" id="routeDetails_<%= Model.Id %>"  class="routeContainer">  
                <% using (Html.BeginForm("UpdateRoute", "Admin", FormMethod.Post)){%>
                    <%= Html.Hidden("id", Model.Id)%>
                    <label for="fromCityId" title="Откуда">Откуда</label><br />
                    <%= Html.DropDownList("fromCityId", fromCities)%><br />
                    <label for="toCityId" title="Куда">Куда</label><br />
                    <%= Html.DropDownList("toCityId", toCities)%><br />
                    <label for="distance" title="Расстояние">Расстояние</label><br />
                    <%= Html.TextBox("distance", distance)%><br />
                    <label for="priceStandard" title="Цена за стандарт">Цена за стандарт</label><br />
                    <%= Html.TextBox("priceStandard", standardPrice)%><br />
                    <label for="priceMiddle" title="Цена за средний">Цена за средний</label><br />
                    <%= Html.TextBox("priceMiddle", middlePrice)%><br />
                    <label for="priceBusiness" title="Цена за бизнес">Цена за бизнес</label><br />
                    <%= Html.TextBox("priceBusiness", businessPrice)%><br />
                    <label for="priceMinivan" title="Цена за минивен">Цена за минивен</label><br />
                    <%= Html.TextBox("priceMinivan", minivanPrice)%><br />
                    <label for="priceMultivan" title="Цена за мультивен">Цена за мультивен</label><br />
                    <%= Html.TextBox("priceMultivan", multivanPrice)%><br />
                    <div style="display:none">
                        <label for="priceLux" title="Цена за люкс">Цена за люкс</label><br />   
                        <%= Html.TextBox("priceLux", luxPrice)%>
                    </div>
                    <div>
                        <input type="submit" value="Сохранить" />
                    </div>
                 <%} %>
            </div>
            <script type="text/javascript">
                $(function() {
                    $("#show_<%= Model.Id %>").click(function() {
                        $("#routeDetails_<%= Model.Id %>").dialog("open");
                    });
                })
                
                function updateSuccess_<%= Model.Id %>(){
                     $("#routeDetails_<%= Model.Id %>").dialog("close");
                }
            </script>

        </td>
    </tr>
    
    
