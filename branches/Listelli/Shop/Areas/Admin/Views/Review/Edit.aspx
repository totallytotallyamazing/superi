<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContent>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Редактирование содержимого
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Редактирование содержимого</h2>

    <% using (Html.BeginForm("Edit", "Review", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            
            
            <%:Html.HiddenFor(model=>model.Id) %>
            
            <div class="editor-label">
                Адрес страницы (должен быть уникальным)
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name)%>
            </div>

            <div class="editor-label">
                Заголовок
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                Описание
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                Изображение
            </div>
            <div class="editor-field">
             <% if (Model != null) %>
                        <%= Html.Image("~/Content/ReviewImages/" +Model.ImageSource, Model.Title, 200)%>
                        <br />
                 <input type="file" name="logo" />
            </div>
            
            <div class="editor-label">
                Порядок отображения
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SortOrder) %>
                <%: Html.ValidationMessageFor(model => model.SortOrder) %>
            </div>
            
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Назад к списку", "Details", "Review", new { Area = "", id = ViewData["reviewContentId"] }, null)%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
      
    <%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
    <%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>

    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace("Description", { toolbar: "Media" });
        })
</script>
</asp:Content>

