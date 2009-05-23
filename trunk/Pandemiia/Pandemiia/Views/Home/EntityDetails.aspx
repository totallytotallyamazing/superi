<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>
<%@ Import Namespace="Pandemiia.Helpers" %>
<%@ Import Namespace="Pandemiia.Models" %>
<%@ Import Namespace="Pandemiia.Controllers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Title %>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="AdditionalStylesContent">
    <%= Html.RegisterCss("~/Content/entityDetails.css") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function() { $(".filterTop").html(""); $(".filterBottom").html(""); })        
    </script>
    <div class="detailsHeader">
        <div class="entityTitle" style="color: White">
            <%= Model.Title %>
        </div>
        <div class="entityDate">
            <%= Model.Date.Value.ToString("dd.MM.yyyy") %>
        </div>
    </div>
    <div class="topContent">
        <div class="content">
            <% if (Model.HasAdditionalContent())
               {
                   if (Model.EntityType.Name == "Видео")
                       Html.RenderAction("EntityVideos", "Home", new RouteValueDictionary(new { entity = Model }));
                   if (Model.EntityType.Name == "Музыка")
                       Html.RenderAction("EntityMusics", "Home", new RouteValueDictionary(new { entity = Model }));
                   if (Model.EntityType.Name == "Изображения")
                       Html.RenderAction("EntityImages", "Home", new RouteValueDictionary(new { entity = Model }));
               }
               else
               {
                   Response.Write(Model.Content);
            } %>
        </div>
        <div class="tags">
            <%= Html.Image("~/Content/img/tag.jpg") %>
            <% for (int i = 0; i < Model.EntityTagMappings.Count; i++)
               {
                   EntityTagMapping mapping = Model.EntityTagMappings[i];
                   Response.Write(Html.ActionLink<FilterController>(fc => fc.Tags(mapping.Tag.TagName), mapping.Tag.TagName));
                   if (i != Model.EntityTagMappings.Count - 1)
                       Response.Write(", ");
               } %>
        </div>
        <div class="finger">
            <%
                string imageName = "otherFinger.jpg";
                switch (Model.EntityType.Name)
                {
                    case "Видео":
                        imageName = "videoFinger.jpg";
                        break;
                    case "Музыка":
                        imageName = "audioFinger.jpg";
                        break;
                    case "Чтиво":
                        imageName = "readingFinger.jpg";
                        break;
                    case "Изображения":
                        imageName = "imageFinger.jpg";
                        break;
                }
                
            %>
            <%= Html.Image("~/Content/img/" + imageName) %>
        </div>
    </div>
    <% if (Model.HasAdditionalContent())
       {%>
    <div class="bottomContent">
        <%= Model.Content %>
    </div>
    <%} %>
</asp:Content>
