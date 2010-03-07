<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.Route>>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Маршруты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>Откуда</th>
            <th>Куда</th>
            <th>Расстояние</th>
            <th>Стандарт</th>
            <th>Средний</th>
            <th>Бизнес</th>
            <th>Минивен</th>
            <th>Мультивен</th>
            <th style="display:none">Люкс</th>
            <th></th>
            <th></th>
        </tr>
        <% foreach (var item in Model)
           {
               Html.RenderPartial("Routes", item);     
           } %>
    </table>
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
    <table>
        <tr>
            <th>Откуда</th>
            <th>Куда</th>
            <th>Расстояние</th>
            <th>Стандарт</th>
            <th>Средний</th>
            <th>Бизнес</th>
            <th>Минивен</th>
            <th>Мультивен</th>
            <th style="display:none">Люкс</th>
            <th></th>
        </tr>
        <tr>
            <td>
                <%= Html.DropDownList("fromCityId", fromCities) %>
            </td>
            <td>
                <%= Html.DropDownList("toCityId", toCities) %>
            </td>
            <td>
                <%= Html.TextBox("distance") %>
            </td>
            <td>
                <%= Html.TextBox("priceStandard")%>
            </td>
            <td>
                <%= Html.TextBox("priceMiddle")%>
            </td>
            <td>
                <%= Html.TextBox("priceBusiness")%>
            </td>
            <td>
                <%= Html.TextBox("priceMinivan")%>
            </td>
            <td>
                <%= Html.TextBox("priceMultivan")%>
            </td>
            <td style="display:none">
                <%= Html.TextBox("priceLux")%>
            </td>
            <td>
                <input type="submit" value="Добавить" />
            </td>
        </tr>
    </table>
<% } %>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    Маршруты
</asp:Content>
