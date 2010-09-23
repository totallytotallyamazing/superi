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
    <a href="#" class="ot6">Цветы</a>
    <br />
    <span class="ot6Selected">Мягкие игрушки</span>
    <br />
    <a href="#" class="ot6">Подарки</a>
    <br />
    <a href="#" class="ot6">Букеты</a>
    <br />
    <a href="#" class="ot6">Фрукты</a>
    <br />
    <a href="#" class="ot6">Напитки</a>
    <div id="txtBlkGift">
        <p class="ot7">
            <a href="#" class="ot7">Комнатные
                <br />
                растения</a>
        </p>
    </div>
</div>



<%--<div id="menuBox">

    <div id="liHeader">
    </div>
    <div id="newsContent">
        <div id="classMenuItems">
        <% 
        string[] listPages = { "index", "search", "tags" };
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
                    actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
                }
                extraClass = " current";
                expandCategory = true;
            }
            else if (item.Categories.Select(c => c.Id).Contains(WebSession.CurrentCategory))
            {
                actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
                extraClass = " current";
                expandCategory = true;
            }
            else
            {
                actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
            }
            %>
            <div class="classMenuItem<%= extraClass %>">
                <p>
                    <%= actionLink %>
                </p>
            </div>
      <%
          if (WebSession.CurrentCategory == item.Id || expandCategory)
              Html.RenderPartial("SubCategories", item.Categories.OrderBy(c=>c.SortOrder));
        }%>
        <% if(Roles.IsUserInRole("Administrators")){ %>    
        <p class="adminLink rootCategoriesAdmin">   
        <%= Html.ActionLink("Добавить категорию (корневую)", "AddEdit", "Categories", new { area="admin" }, null)%>
        </p>
        <%} %>
        </div>
    </div>
    <div id="newsFooter">
    </div>
</div>--%>
