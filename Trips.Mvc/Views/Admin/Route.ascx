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
            <div title="Редактирование маршрута" style="display:none;" id="routeDetails_<%= Model.Id %>"  class="routeContainer">  
                <% using (Html.BeginForm("UpdateRoute", "Admin", FormMethod.Post)){%>
                    <%= Html.Hidden("id", Model.Id)%>
                    <table cellpadding="5" cellspacing="5">
                        <tr>
                            <th><label for="fromCityId" title="Откуда">Откуда</label></th>
                            <th><label for="toCityId" title="Куда">Куда</label></th>
                        </tr>
                        <tr>
                            <td><%= Html.DropDownList("fromCityId", fromCities)%></td>
                            <td><%= Html.DropDownList("toCityId", toCities)%></td>
                        </tr>
                    </table>
                    <table cellpadding="5" cellspacing="5">
                        <tr>
                            <td><label for="distance" title="Расстояние">Расстояние</label></td>
                            <td><%= Html.TextBox("distance", distance)%></td>
                        </tr>    
                    </table>
                    <div class="descriptionPartHeader">Цены</div>
                    <table cellpadding="5" cellspacing="5">
                        <tr>
                            <td><label for="priceStandard" title="Cтандарт">Cтандарт</label></td>
                            <td><%= Html.TextBox("priceStandard", standardPrice)%></td>
                        </tr>
                        <tr>
                            <td><label for="priceMiddle" title="Средний">Cредний</label></td>
                            <td><%= Html.TextBox("priceMiddle", middlePrice)%></td>
                        </tr>
                        <tr>
                            <td> <label for="priceBusiness" title="Бизнес">Бизнес</label></td>
                            <td><%= Html.TextBox("priceBusiness", businessPrice)%></td>
                        </tr>
                        <tr>
                            <td><label for="priceMinivan" title="Минивен">Минивен</label></td>
                            <td><%= Html.TextBox("priceMinivan", minivanPrice)%></td>
                        </tr>
                        <tr>
                            <td><label for="priceMultivan" title="Мультивен">Мультивен</label></td>
                            <td><%= Html.TextBox("priceMultivan", multivanPrice)%></td>
                        </tr>
                        <tr style="display:none">
                            <td><label for="priceLux" title="Люкс">Люкс</label></td>
                            <td><%= Html.TextBox("priceLux", luxPrice)%></td>
                        </tr>
                    </table>
                    <div style="padding-top:10px;">
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
    
    
