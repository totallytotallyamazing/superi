<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Pandemiia.Models.Entity>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<% string className="";
   switch (Model.EntitySource.Name)
   { 
       case "����":
           className = "ours";
           break;
       case "����":
           className = "yours";
           break;
       case "�����":
           className = "theirs";
           break;
   } %>
<div class="entity <%= className %>">
    <div class="entityImage">
        <%= Html.Image("~/EntityImages/" + Model.Image, "") %>
    </div>
    <div class="entityText">
        <div class="entityTitle">
            <%= Model.Title %>
        </div>
        <div class="entityDate">
            <%= Model.Date.Value.ToString("dd.MM.yyyy") %>
        </div>
        <div class="entityDescription">
            <%= Model.Description %>
        </div>
        <% if (!string.IsNullOrEmpty(Model.Content) || Model.EntityPictures.Count > 0 || Model.EntityVideos.Count > 0)
           { %>
           <div class="detailsLink">
            <%= Html.ActionLink("��� ���� ���>>>", "EntityDetails", new { id = Model.ID })%> 
           </div>
        <%} %>
    </div>
</div>


