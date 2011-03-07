<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%
    string currentUrl = Request.Url.ToString().ToLower();
                        if (currentUrl.Contains("konkurs") || currentUrl.Contains("conditions") || currentUrl.Contains("fond"))
                        {}else{
     %>
<div id="contestBubble">
    <div class="bubbleText">
    <!--
        <span class="txtBubbleNew">У нас начался</span><br />
        <a href="/Konkurs">конкурс дизайнеров</a>
        -->
        <span class="txtBubbleNew">Скоро начнется</span><br />
        <span class="txtBubbleNew">конкурс дизайнеров</span>
    </div>
</div>
<%} %>