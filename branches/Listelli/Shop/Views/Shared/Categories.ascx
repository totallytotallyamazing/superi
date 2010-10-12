<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<% 
    List<Category> categories;
    using (ShopStorage context = new ShopStorage())
    {
        context.Categories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
        categories = context.Categories.Include("Categories")
            .Where(c => c.Parent == null)
            .Where(c => c.Published)
            .OrderBy(c => c.SortOrder).ToList();
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
    string actionLink = string.Empty;
    string extraClass = string.Empty;
    bool isProductList = listPages.Contains(ViewContext.RouteData.Values["action"].ToString().ToLower()); 
    if (item.Id == WebSession.CurrentCategory)
    {
        extraClass = " current";
        expandCategory = true;
        if (isProductList && ViewData["brandId"] == null)
            actionLink = string.Format("<span class=\"ot6 current\">{0}</span>", item.Name);
        else
            actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id, area="" }, new { @class = "ot6" + extraClass }).ToString();
    }
    //else if (item.Categories.Select(c => c.Id).Contains(WebSession.CurrentCategory))
    //{
    //    actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
    //    extraClass = " current";
    //    expandCategory = true;
    //}
    else
    {
        actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id, area = "" }, new { @class = "ot6" }).ToString();
    }
    %>
    <div>
        <%= actionLink %>
    </div>
<%} %>

<% if(Roles.IsUserInRole("Administrators")){ %>    
    <p class="adminLink rootCategoriesAdmin">   
    <%= Html.ActionLink("Добавить категорию", "AddEdit", "Categories", new { area="admin" }, null)%>
    </p>
<%} %>
</div>