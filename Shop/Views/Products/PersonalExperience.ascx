<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<% if(!string.IsNullOrEmpty(Model.PersonalExperience)){ %>
<div class="personalExperience">
    <div class="header">
        Личный опыт
    </div>
    <div class="text">
        <%= Model %>
    </div>
</div>
<%} %>