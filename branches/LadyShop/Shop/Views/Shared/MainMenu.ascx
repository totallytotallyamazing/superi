<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<p>
    <%= Html.ActionLink("О СТУДИИ", "Go", "Home", new { area="", id="about"}, null)%>&nbsp;/&nbsp;
    <a href="/Articles">НОВОСТИ</a>&nbsp;/&nbsp;
    <a href="/Brands">О БРЕНДАХ</a>&nbsp;/&nbsp;
    <%= Html.ActionLink("ЗАКАЗ, ОПЛАТА И ДОСТАВКА", "Go", "Home", new { area = "", id = "order" }, null)%>&nbsp;/&nbsp;
    <%= Html.ActionLink("ТАБЛИЦА РАЗМЕРОВ", "Go", "Home", new { area = "", id = "sizes" }, null)%>&nbsp;/&nbsp;
    <%= Html.ActionLink("ПАРТНЕРАМ", "Go", "Home", new { area = "", id = "partners" }, null)%>&nbsp;/&nbsp;
    <%= Html.ActionLink("ГЛАВНАЯ", "Index", "Home", null, null)%>
</p>

