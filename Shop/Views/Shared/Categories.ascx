<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<% 
    List<Category> categories;
    using (ShopStorage context = new ShopStorage())
    {
        categories = context.Categories.Include("Categories").Where(c => c.Parent == null).OrderBy(c => c.SortOrder).ToList();
    }
%>
<div id="bubGift">
    <p class="ot3">
        Выберите
        <br />
        подарок...</p>
</div>
<div id="giftMenu">
<% 
string[] listPages = { "index", "search", "tags" };
foreach (var item in categories)
{
    bool expandCategory = false;
    string actionLink = "";
    string extraClass = "";
    bool isProductList = listPages.Contains(ViewContext.RouteData.Values["action"].ToString().ToLower());
    if (item.Id == WebSession.CurrentCategory)
    {
        if (isProductList && ViewData["brandId"] == null)
        {
            actionLink = string.Format("<span class=\"ot6Selected\">{0}</span>", item.Name);
        }
        else
        {
            actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, new { @class="ot6"}).ToString();
        }
        extraClass = " current";
        expandCategory = true;
    }
    //else if (item.Categories.Select(c => c.Id).Contains(WebSession.CurrentCategory))
    //{
    //    actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
    //    extraClass = " current";
    //    expandCategory = true;
    //}
    else
    {
        actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, new { @class = "ot6" }).ToString();
    }
    %>
    <%= actionLink %>
    <br />
<%} %>

<% if(Roles.IsUserInRole("Administrators")){ %>    
    <p class="adminLink rootCategoriesAdmin">   
    <%= Html.ActionLink("Добавить категорию", "AddEdit", "Categories", new { area="admin" }, null)%>
    </p>
<%} %>
</div>