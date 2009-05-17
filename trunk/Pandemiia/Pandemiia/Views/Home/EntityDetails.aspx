<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
               {%>
            <%} %>
            <%else
                { %>
            <%= Model.Content %>
            <%} %>
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
    <div class="bottomContent">
    </div>
</asp:Content>
