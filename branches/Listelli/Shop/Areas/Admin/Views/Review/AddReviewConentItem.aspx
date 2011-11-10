<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItem>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Добавление содержимого
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Добавление содержимого</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            
            
            <%=Html.Hidden("reviewContentId")%>
            
            <div class="editor-label">
                Тип содержимого
            </div>
            <div class="editor-field">
                <%=Html.DropDownList("ContentType", new List<SelectListItem>() { new SelectListItem { Text = "Текстовый блок", Value = "1" }, new SelectListItem { Text = "Заметка", Value = "2" } })%>
            </div>

          
            <div class="editor-label">
                Текст
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Text) %>
                <%: Html.ValidationMessageFor(model => model.Text) %>
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
        <%: Html.ActionLink("Назад к списку", "Details", "Review", new { Area = "", id = ViewData["reviewContentName"] }, null)%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
<script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
      
    <%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
    <%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>

    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace("Text", { toolbar: "Media" });
        })
</script>
</asp:Content>

