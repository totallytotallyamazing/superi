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

    <div id="subscribeContainer">
    <%if (Subscriber.IsSubscribed)

      { %>
      <span class="txtBubbleNew">Вы подписаны на новости!</span>
      &nbsp;<a href="#" id="unSubscribeMe" class="txtBubbleNew">Отписаться</a>
      <% }else{ %>
        <a href="#" id="subscribeMe" class="txtBubbleNew">
            <%: Shop.Resources.Global.KeepInTouch %></a><br /> <span class="txtBubbleNew"><%: Shop.Resources.Global.NewReceipes %></span>
            <% } %>
            </div>


        <div id="favBlock" class="favBlock <%=(favoritesCount == 0?"displayNone":"") %>">
            <%=Html.ActionLink(Favorites.CheckedNames, "Favorites", "Products", null, new { @class = "txtBubbleNew", id="favTextPrefix" })%>
            <span class="txtBubbleNew txtBubbleNewFavorites">
                <br />
                <span id="favCount">
                    <%=favoritesCount%></span> <span id="favTextSufix">
                <%=Favorites.PositionNames%></span></span>
        </div>
    </div>
</div>
