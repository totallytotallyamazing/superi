<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Pandemiia.Models.Entity>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<% string className="";
   switch (Model.EntitySource.Name)
   { 
       case "наше":
           className = "ours";
           break;
       case "ваше":
           className = "yours";
           break;
       case "ихнее":
           className = "theirs";
           break;
   } %>
<div class="entity <%= className %>">
    <div class="entityImage">
        <%
            if (Model.EntityType.Name == "Изображения" && Model.EntityPictures.Count == 1)
            {%>
              <a class="entitySingleImage" href="<%= VirtualPathUtility.ToAbsolute("~/EntityImages/" + Model.EntityPictures[0].Picture) %>">
                <%= Html.Image("~/EntityImages/" + Model.Image, "")%>
              </a>  
            <%}
            else
            {
                string link = Url.Action("EntityDetails", new { id = Model.ID });
                %>
                <a href="<%= link%>">
                    <%= Html.Image("~/EntityImages/" + Model.Image, "") %>
                </a>
            <%}
        %>
        
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
        <% if (!string.IsNullOrEmpty(Model.Content) || Model.EntityPictures.Count > 1 || Model.EntityVideos.Count > 0 || Model.EntityMusics.Count>0)
           { %>
           <div class="detailsLink">
            <%= Html.ActionLink("тут есть еще>>>", "EntityDetails", new { id = Model.ID })%> 
           </div>
        <%} %>
    </div>
    <script type="text/javascript">
        $(".entitySingleImage").fancybox({ 'overlayShow': true, 'padding': 0, 'imageScale': true });
    </script>
</div>


