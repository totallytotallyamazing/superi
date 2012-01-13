<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.FeedbackFormModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%: Shop.Resources.Global.Feedback %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% Html.EnableClientValidation(); %>
	<% using (Html.BeginForm()) {%>
		<%= Html.ValidationSummary(true) %>
			<div class="feedbackForm">
				<div class="editor-label">
					<%= Html.LabelFor(model => model.Name) %>
				</div>
				<div class="editor-field">
					<%= Html.TextBoxFor(model => model.Name) %>
					<%= Html.ValidationMessageFor(model => model.Name) %>
				</div>
			
				<div class="editor-label">
					<%= Html.LabelFor(model => model.Email) %>
				</div>
				<div class="editor-field">
					<%= Html.TextBoxFor(model => model.Email) %>
					<%= Html.ValidationMessageFor(model => model.Email) %>
				</div>
			
				<div class="editor-label">
					<%= Html.LabelFor(model => model.Text) %>
					<%= Html.ValidationMessageFor(model => model.Text) %>
				</div>
				<div class="editor-field">
					<%= Html.TextAreaFor(model => model.Text, 5, 80, null) %>
				</div>
				<div id="captchaImage">
					<%= Html.Action("Draw", new {area="", controller="Captcha"})%>
				</div>
			
				<div class="editor-label">
					<%= Html.LabelFor(model => model.Captcha) %>
				</div>
				<div class="editor-field">
					<%= Html.TextBoxFor(model => model.Captcha) %>
					<%= Html.ValidationMessageFor(model => model.Captcha) %>
				</div>
			
				<div>
					<%: Shop.Resources.Global.Ok %>, <input type="submit" value="<%: Shop.Resources.Global.Send %>" />
				</div>
			</div>        
	<% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
	<div id="contName">
		<div id="pageName">
			<p class="txtPageName">
					<%: Shop.Resources.Global.Feedback %>
			</p>
		</div>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
	<%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js") %>
	<%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
	<%= Ajax.ScriptInclude("/Scripts/MvcCaptchaValidation.js")%>
	<script type="text/javascript">
		function OnCaptchaValidationError() {
			$.get("/Captcha/Draw", function (data) { $("#captchaImage").html(data); });
		}
	</script>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
