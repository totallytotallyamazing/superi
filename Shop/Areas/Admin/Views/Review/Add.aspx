<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContent>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Добавление содержимого
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
	ReviewStorage context = (ReviewStorage)ViewData["context"];
	 %>
	<h2>Добавление содержимого</h2>

	<% using (Html.BeginForm("Add", "Review", FormMethod.Post, new { enctype = "multipart/form-data" }))
	   {%>
		<%: Html.ValidationSummary(true) %>

		<fieldset>
			
			<div class="editor-label">
				Адрес страницы (должен быть уникальным)
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Name)%>
				<%: Html.ValidationMessageFor(model => model.Name)%>
			</div>
			
			<div class="editor-label">
				Заголовок
			</div>
			<div class="editor-field">
				<%: Html.LocalizedTextBoxFor(model => model.Title, context.ReviewLocalResources) %>
				<%: Html.ValidationMessageFor(model => model.Title) %>
			</div>
            
            <div class="editor-label">
				Заголовок в шапке обозревателя
			</div>
			<div class="editor-field">
				<%: Html.LocalizedTextBoxFor(model => model.PageTitle, context.ReviewLocalResources) %>
				<%: Html.ValidationMessageFor(model => model.PageTitle)%>
			</div>
			
			<div class="editor-label">
				Описание
			</div>
			<div class="editor-field">
				<%: Html.LocalizedTextAreaFor(model => model.Description, context.ReviewLocalResources)%>
				<%: Html.ValidationMessageFor(model => model.Description) %>
			</div>
            
            <div class="editor-label">
				Описание для поисковиков
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.SeoDescription)%>
				<%: Html.ValidationMessageFor(model => model.SeoDescription) %>
			</div>
			
			<div class="editor-label">
				Изображение
			</div>
			<div class="editor-field">
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
	   <%: Html.ActionLink("Назад к списку", "Index", "Review", new { Area=""},null)%>
	</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
<script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
	<script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
	  
	<%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
	<%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>
    
	<script type="text/javascript" src="/Scripts/localization.js"></script>

	<script type="text/javascript">
	    $(function () {
	        $("textarea").ckeditor(function () { }, { toolbar: "Media" });
		});

	Localization.bindLocalizationSwitch();
</script>

</asp:Content>

