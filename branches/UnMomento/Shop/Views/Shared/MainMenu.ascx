<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="topInfoMenu">
    <%
        string controllerName = ViewContext.RouteData.Values["controller"].ToString().ToLowerInvariant();
        string action = ViewContext.RouteData.Values["action"].ToString().ToLowerInvariant();
        string currenLocation = controllerName;
        if (currenLocation == "home" && action == "go")
        {
            currenLocation = ViewContext.RouteData.Values["id"].ToString().ToLowerInvariant();
        }

        Func<string, string> isCurrent = (location) => (location == currenLocation) ? " current" : string.Empty;
    %>
    <p class="ot2 capital">
        
        <a href="/Go/About" class="ot2"><b>О НОВОМ СЕРВИСЕ</b></a>
        <br />
        <a href="/Go/PaymentAndDelivery" class="ot2"><b>ОПЛАТА И ДОСТАВКА</b></a>
        <br />
        <a href="/Go/Partners" class="ot2"><b>ПАРТНЕРАМ</b></a>
        <br />
        <a href="/Go/GiftedGuys" class="ot2"><b>ОДАРЕННЫЕ НАМИ ЛЮДИ</b></a>
    </p>
</div>
<%--<div id="menu">


    <a href="/Go/About" class="menuItem<%= isCurrent("about") %>" id="menuItem1"></a>
    <a href="/Go/Sizes" class="menuItem<%= isCurrent("sizes") %>" id="menuItem2"></a>
    <a href="/Go/PaymentAndDelivery" class="menuItem<%= isCurrent("paymentanddelivery") %>" id="menuItem3"></a>
    <a href="/Go/Brands" class="menuItem<%= isCurrent("brands") %>" id="menuItem4"></a>
    <a href="/Go/Partners" class="menuItem last<%= isCurrent("partners") %>" id="menuItem5"></a>
</div>--%>
