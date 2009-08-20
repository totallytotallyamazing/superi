<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.FeedbackPresentation>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<div id="feedbackConteiner">
    <% foreach (var item in Model)
       {%>
    <div class="feedbackItem">
        <div class="itemHeader">
            <a href="mailto:<%= item.Email %>">
                <%= item.FirstName %>
            </a>
        </div>
        <div class="itemText">
            <%= item.Text %>
        </div>
    </div>
    <% } %>
</div>
<% 
    if (Request.IsAuthenticated)
    {
        Html.RenderAction("CreateFeedback");
    } 
%>