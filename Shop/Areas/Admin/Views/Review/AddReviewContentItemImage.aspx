<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItem>" %>
<%@ Import Namespace="Shop.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Добавление изображений
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Добавление изображений</h2>
     <div>
            <% Html.RenderPartial("UploadControl"); %>
    </div>
     <div id="selects">
    <% using (Html.BeginForm("AddReviewContentItemImage", "Review", FormMethod.Get /*FormMethod.Post, new { enctype = "multipart/form-data" }*/))
       {%>
        <%: Html.ValidationSummary(true) %>

       
           
            
            <%=Html.Hidden("reviewContentId")%>
            <%=Html.Hidden("reviewContentItemId")%>

           

           <%
           if (ViewData["hasImages"] != null && (bool)ViewData["hasImages"])
           {
               foreach (var image in Model.ReviewContentItemImages)
               {
               %>
    <div style="float: left; margin: 15px;">
        <%= Html.CachedImage1("~/Content/ReviewImages/", image.ImageSource, "reviewImagesDetailsThumb", image.ImageSource)%>
    </div>
    
    <% 
               }
           }
                %>

        

    <% } %>
     <div style="clear: both;">
    </div>
    </div>
   
    <div>
       <%: Html.ActionLink("Назад к списку", "CheckForEmptyEntriesAndDelete", "Review", new { Area = "Admin", id = ViewData["reviewContentItemId"] }, null)%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">

 <script type="text/javascript">
     $(function () {
         $("#selects select").change(function () {
             $("#selects form").get(0).submit();
         });
     });
    </script>
</asp:Content>

