<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div id="reviewMenu">
<div class="menuLinkPlace">
    <a href="#" id="reviewMenuUp"></a>
    </div>
    <div class="menuLinkPlace">
    <%=Html.ActionLink("[IMAGE]", "Index", "Review", new { Area = "" }, new {id="reviewMenuBack" }).ToString().Replace("[IMAGE]", "")%>
    
    </div>
    <div class="menuLinkPlace home">
    <a href="http://listelli.ua" id="reviewMenuHome"></a>
    </div>

</div>