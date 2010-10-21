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
<%--<div id="bubGift">
    <p class="ot3">
        Выберите
        <br />
        подарок...</p>
</div>--%>
<div id="leftMenu">
<%      string[] listPages = { "index", "search", "tags" };
        foreach (var item in categories)
        {
            bool expandCategory = false;
            string actionLink = "";
            string extraClass = "";
            bool isProductList = listPages.Contains(ViewContext.RouteData.Values["action"].ToString().ToLower());
            if (item.Id == WebSession.CurrentCategory )
            {
                if (isProductList && ViewData["brandId"] == null)
                {
                    actionLink = string.Format("<span>{0}</span>", item.Name);
                }
                else
                {
                    actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id, area="" }, null).ToString();
                }
                extraClass = " current";
                expandCategory = true;
            }
            else if (item.Categories.Select(c => c.Id).Contains(WebSession.CurrentCategory))
            {
                actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id, area = "" }, new { @class = "currentMain" }).ToString();
                extraClass = " current";
                expandCategory = true;
            }
            else
            {
                actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id, area = "" }, new { @class = "txtLeftMenu" }).ToString();
            }
            %>
    <div>
    
        <%= actionLink %>


    </div>
    <% if (WebSession.CurrentCategory == item.Id || expandCategory){
        Html.RenderPartial("SubCategories", item.Categories.OrderBy(c=>c.SortOrder));
    }
} %>

<% if(Roles.IsUserInRole("Administrators")){ %>    
    <p class="adminLink rootCategoriesAdmin">   
    <%= Html.ActionLink("Добавить категорию", "AddEdit", "Categories", new { area="admin" }, null)%>
    </p>
<%} %>
</div>