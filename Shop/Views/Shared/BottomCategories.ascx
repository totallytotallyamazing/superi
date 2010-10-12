<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Dev.Helpers" %>

<div id="bubReason">
    <p class="ot3">...или повод</p>
</div>
<div id="reasonMenu">

<% 
using (ShopStorage context = new ShopStorage())
{
    foreach (var item in context.Tags)
    {
        string extraClass = string.Empty;
        string actionLink = string.Empty;
        bool isProductList = ViewContext.RouteData.Values["action"].ToString().ToLower() == "tags" &&
            ViewContext.RouteData.Values["controller"].ToString().ToLower() == "products"; 
        if (WebSession.CurrentTag == item.Id)
        {
            extraClass = " current";
            if (isProductList)
                actionLink = string.Format("<span class=\"ot6 current\">{0}</span>", item.Value);
            else
                actionLink = Html.ActionLink(item.Value, "Tags", "Products", new { id = item.Id }, new { @class = "ot6" + extraClass }).ToString();
        }
        else
        {
            actionLink = Html.ActionLink(item.Value, "Tags", "Products", new { id = item.Id }, new { @class = "ot6" }).ToString();
        }
%>
    <div>
        <%= actionLink %>
    </div>
<%
    }
} 
    %>

</div>

<div id="bubAndWe">
    <p class="ot3">
        А ещё, мы
        <br />
        принимаем</p>
    <div id="txtBlkAndWe">
        <p class="ot7">
            <a href="#" class="ot7">индивидуальные
                <%--<br />--%>
                заказы</a>
        </p>
    </div>
</div>


