<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItemImage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Добавление изображения
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Добавление изображения</h2>

    <% using (Html.BeginForm("AddReviewContentItemImage", "Review", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
           
            
            <%=Html.Hidden("reviewContentId")%>
            <%=Html.Hidden("reviewContentItemId")%>

            <div class="editor-label">
                Выберите файл
            </div>
            <div class="editor-field">
                <input type="file" name="logo" />
            </div>
            
            <p>
                <input type="submit" value="Загрузить" />
            </p>
        </fieldset>

    <% } %>

    <div>
       <%: Html.ActionLink("Назад к списку", "Details", "Review", new { Area = "", id = ViewData["reviewContentName"] }, null)%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

