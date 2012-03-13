<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItem>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Редактирование содержимого
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
	ReviewStorage context = (ReviewStorage)ViewData["context"];
	 %>

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
                <%: Html.LocalizedTextAreaFor(model => model.Text, context.ReviewLocalResources)%>
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
    
	<script type="text/javascript" src="/Scripts/localization.js"></script>

	<script type="text/javascript">
	    $(function () {
	        $("textarea").ckeditor(function () { }, { toolbar: "Media" });
	    });

	    Localization.bindLocalizationSwitch();
</script>

</asp:Content>

