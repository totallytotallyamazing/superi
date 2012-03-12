<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% if(ViewData["showSorting"]!=null){ %>
<% 
    Func<string, string, string> generateSortLink = (caption, mode) =>
    {
        string result = "";
        string currentSortOrder = (string)ViewData["orderBy"];
        string resultFormat = @"<div class=""menu"">{0}
                            </div>";
        if (currentSortOrder == mode)
        {
            result = string.Format(@"<p class=""txt current"">{0}</p>", caption);
            resultFormat = @"<div class=""menu bkgCurrent"">{0}
                            </div>";
        }
        else
        {
            result = Html.ActionLink(caption, (string)ViewData["action"], new
            {
                id = ViewData["categoryId"],
                brandId = ViewData["brandId"],
                page = ViewData["page"],
                orderBy = mode
            }, new { @class = "txt" }).ToString();
        }
        
        return string.Format(resultFormat, result);
    };
%>

<div class="sortingBox">
    <p class="txtSortByTitle">
        <%= Shop.Resources.Global.Sorting %>:</p>
    <div id="sortBy">
        <%= generateSortLink(Shop.Resources.Global.ByBrand, "brand")%>
        <%= generateSortLink(Shop.Resources.Global.Dark, "tintdark")%>
        <%= generateSortLink(Shop.Resources.Global.Light, "tintlight")%>
        <%= generateSortLink(Shop.Resources.Global.OnlyNew, "onlynew")%>
    </div>
</div>
<%} %>
