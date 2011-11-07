<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Редактирование содержимого
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Редактирование содержимого</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
           
            
            <%=Html.HiddenFor(model=>model.ContentType) %>

            <%=Html.HiddenFor(model=>model.Id) %>
            
            <div class="editor-label">
                Текст
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Text)%>
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
</asp:Content>

