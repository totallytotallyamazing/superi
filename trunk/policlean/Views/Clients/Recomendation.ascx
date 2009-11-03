<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PolialClean.Models.Recomendations>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<div class="objectImage">
    <a href="/Content/Recomendations/<%= Model.Image %>" class="fancyNoScale">
        <%= Html.Image("~/COntent/Recomendations/Preview/" + Model.Preview) %>
    </a>
    <%if(Request.IsAuthenticated){ %>
        <br />
        <%= Html.ActionLink("Удалить", "DeleteRecomendation", "Admin", new {id = Model.Id}, new { @class="adminLink", onclick="return confirm('Вы уверены?');" }) %>
    <%} %>
</div>


