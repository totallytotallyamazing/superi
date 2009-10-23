<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PolialClean.Models.Recomendations>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<% 
    int count = Convert.ToInt32(ViewData["count"]);
    int index = Convert.ToInt32(ViewData["index"]);
    
    string linkText = "Отзыв";
    if (count > 1)
        linkText += " " + index;
%>
<a href="/Content/Recomendations/<%= Model.Image %>" class="fancyNoScale">
    <%= linkText %>
</a>
<%if(Request.IsAuthenticated){ %>
    &nbsp;<%= Html.ActionLink("x", "DeleteRecomendation", "Admin", new {id = Model.Id}, new { @class="adminLink", onclick="return confirm('Вы уверены?');" }) %>
<%} %>
&nbsp;&nbsp;


