<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.Route>>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	��������
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
    <label for="fromCityId" title="������">������</label><br />
    <%= Html.DropDownList("fromCityId", fromCities) %><br />
    <label for="toCityId" title="����">����</label><br />
    <%= Html.DropDownList("toCityId", toCities) %><br />
    <label for="distance" title="����������">����������</label><br />
    <%= Html.TextBox("distance") %><br />
    <label for="priceStandard" title="���� �� ��������">���� �� ��������</label><br />
    <%= Html.TextBox("priceStandard")%><br />
    <label for="priceMiddle" title="���� �� �������">���� �� �������</label><br />
    <%= Html.TextBox("priceMiddle")%><br />
    <label for="priceBusiness" title="���� �� ������">���� �� ������</label><br />
    <%= Html.TextBox("priceBusiness")%><br />
    <label for="priceMinivan" title="���� �� �������">���� �� �������</label><br />
    <%= Html.TextBox("priceMinivan")%><br />
    <label for="priceMultivan" title="���� �� ���������">���� �� ���������</label><br />
    <%= Html.TextBox("priceMultivan")%><br />
    <div style="display:none">
        <label for="priceLux" title="���� �� ����">���� �� ����</label><br />   
        <%= Html.TextBox("priceLux", 0)%>
    </div>
    <div>
        <input type="submit" value="��������" />
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
    ��������
</asp:Content>
