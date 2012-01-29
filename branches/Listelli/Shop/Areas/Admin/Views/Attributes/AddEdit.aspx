<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ProductAttribute>" %>
<%@ Import  Namespace="Shop.Models" %>
<%@ Import  Namespace="Shop.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% var context = ViewData["Context"] as ShopStorage; %>

	<% Html.EnableClientValidation(); %>
	<% using (Html.BeginForm()) {%>
		<%= Html.ValidationSummary(true) %>
		
		<%= Html.HiddenFor(model => model.Id) %>
		
		<div class="editor-label">
			<%= Html.LabelFor(model => model.Name) %>
		</div>
		<div class="editor-field">
			<%= Html.LocalizedTextBoxFor(model => model.Name, context.ShopLocalResources) %>
			<%= Html.ValidationMessageFor(model => model.Name) %>
		</div>
		<div class="editor-label">
			<%= Html.LabelFor(model => model.SortOrder) %>
		</div>
		<div class="editor-field">
			<%= Html.TextBoxFor(model => model.SortOrder) %>
			<%= Html.ValidationMessageFor(model => model.SortOrder)%>
		</div>
		<div>
			<%= Html.RadioButtonFor(model=> model.ValueType, "TEXT") %> Текстовое значение
			<%= Html.RadioButtonFor(model=> model.ValueType, "DROPDOWN") %> Выпадающий список
			<%= Html.ValidationMessageFor(model => model.ValueType)%>
		</div>
		<div style="display:none";>
			<%= Html.CheckBoxFor(model=>model.Static) %><%= Html.LabelFor(model => model.Static) %>
		</div>
		<input type="submit" value="Сохранить" />
	<% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
  <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
  <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <script type="text/javascript" src="/Scripts/localization.js"></script>
    <script type="text/javascript">
        Localization.bindLocalizationSwitch();
    </script>
</asp:Content>

