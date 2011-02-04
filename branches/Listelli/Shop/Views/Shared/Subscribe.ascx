<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Shop.Models" %>
<script type="text/javascript">
    Subscribe.initialize();
    BasePageExtender.initialize();

</script>

<%
    int favoritesCount = Shop.Models.Favorites.FavoritesProductIds.Count(); %>

<div id="bubbleNew" class="<%=(favoritesCount>0?"bubbleNewWithFavorites":"") %>">
    <div id="bubbleText">
        <span class="txtBubbleNew">Хочу</span> <a href="#" id="subscribeMe" class="txtBubbleNew">быть в курсе</a>
        <span class="txtBubbleNew">новых поступлений!</span>
        <%if (favoritesCount > 0)
          {%>
        <%=Html.ActionLink("Вами "+Favorites.CheckedNames, "Favorites", "Products", null, new { @class = "txtBubbleNew" })%> <span class="txtBubbleNew txtBubbleNewFavorites"><br /> <%=favoritesCount%> <%=Favorites.PositionNames%></span>
        <%
          }%>
    </div>
</div>
