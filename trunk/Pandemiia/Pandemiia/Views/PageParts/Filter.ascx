<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Pandemiia.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<%
    string source = ViewData["source"].ToString();
    string typeName = ViewData["typeName"].ToString();
%>

<div class="filterTop">
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("Ours", typeName) %>">
            <%= Html.Image("~/Content/img/ours.jpg", "наше")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (source == "Ours")
          {
              Response.Write("наше");
          }
          else
          {%>
        
        <a href="<%= Utils.GetFilterPath("Ours", typeName) %>">
            наше
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("Yours", typeName) %>">
            <%= Html.Image("~/Content/img/yours.jpg", "ваше")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (source == "Yours")
          {
              Response.Write("ваше");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath("Yours", typeName) %>">
            ваше
        </a>
<%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("Theirs", typeName) %>">
            <%= Html.Image("~/Content/img/theirs.jpg", "ихнее")%>
        </a>    
    </div>
    <div class="filterLabel">
          <%if (source == "Theirs")
          {
              Response.Write("ихнее");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath("Theirs", typeName) %>">
            ихнее
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("All", typeName) %>">
            <%= Html.Image("~/Content/img/allSources.jpg", "все")%>
        </a>
    </div>
    <div class="filterLabel">
          <%if (source == "All")
            {
                Response.Write("все");
            }
            else
            {%>
        <a href="<%= Utils.GetFilterPath("All", typeName) %>">
            все
        </a>
        <%} %>
    </div>
</div>
<div class="filterBottom">
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Image") %>">
            <%= Html.Image("~/Content/img/imageFilter.jpg", "изображения")%>
        </a>
    </div>
    <div class="filterLabel">
            <%if (typeName == "Image")
              {
                  Response.Write("изображения");
              }
              else
              {%>
        <a href="<%= Utils.GetFilterPath(source, "Image") %>">
            изображения
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Video") %>">
            <%= Html.Image("~/Content/img/videoFilter.jpg", "видео")%>
        </a>
    </div>
    <div class="filterLabel">
                <%if (typeName == "Video")
                  {
                      Response.Write("видео");
                  }
                  else
                  {%>
        <a href="<%= Utils.GetFilterPath(source, "Video") %>">
            видео
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Reading") %>">
            <%= Html.Image("~/Content/img/readingFilter.jpg", "чтиво")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (typeName == "Reading")
          {
              Response.Write("чтиво");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath(source, "Reading") %>">
            чтиво
        </a>
        <%} %>
    </div>
        <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Reading") %>">
            <%= Html.Image("~/Content/img/musicFilter.jpg", "чтиво")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (typeName == "Music")
          {
              Response.Write("музыка");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath(source, "Music") %>">
            музыка
        </a>
        <%} %>
    </div>

    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Other") %>">
            <%= Html.Image("~/Content/img/miscFilter.jpg", "разное")%>
        </a>
    </div>
    <div class="filterLabel">
          <%if (typeName == "Other")
          {
              Response.Write("разное");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath(source, "Other") %>">
            разное
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "All") %>">
            <%= Html.Image("~/Content/img/allTypesFilter.jpg", "все")%>
        </a>
    </div>
    <div class="filterLabel">
          <%if (typeName == "All")
            {
                Response.Write("все");
            }
            else
            {%>
        <a href="<%= Utils.GetFilterPath(source, "All") %>">
            все
        </a>
        <%} %>
    </div>
</div>