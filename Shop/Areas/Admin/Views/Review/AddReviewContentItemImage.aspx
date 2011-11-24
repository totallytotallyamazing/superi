<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItemImage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Добавление изображения
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Добавление изображения</h2>
     <div id="selects">
    <% using (Html.BeginForm("AddReviewContentItemImage", "Review", FormMethod.Get /*FormMethod.Post, new { enctype = "multipart/form-data" }*/))
       {%>
        <%: Html.ValidationSummary(true) %>

       
           
            
            <%=Html.Hidden("reviewContentId")%>
            <%=Html.Hidden("reviewContentItemId")%>

           
        

    <% } %>
    </div>
    <div>
            <% Html.RenderPartial("UploadControl"); %>
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

