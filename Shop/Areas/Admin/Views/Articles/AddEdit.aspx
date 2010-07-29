<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Article>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        <%=Html.Hidden("language")%>
        <fieldset>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Title) %>
                <%= Html.ValidationMessageFor(model => model.Title) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Date) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Date) %>
                <%= Html.ValidationMessageFor(model => model.Date) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Text) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Text)%>
                <%= Html.ValidationMessageFor(model => model.Text) %>
            </div>
        </fieldset>
        
        <fieldset>
            <legend>
                Поисковая оптимизация
            </legend>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Keywords) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Keywords) %>
                <%= Html.ValidationMessageFor(model => model.Keywords) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Description)%>
                <%= Html.ValidationMessageFor(model => model.Description) %>
            </div>
        </fieldset>
            
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">  
<script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
  <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <%= Ajax.ScriptInclude("/Scripts/jquery.ui.js") %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.ui.datepicker-ru.js")%>
    <%= Ajax.DynamicCssInclude("/Content/lady/jquery.css") %>

    <script type="text/javascript">
        $(function() {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
            $("#Text").fck({ toolbar: "Basic", height: 200 });

            if ($("#Date").val() === '') {
                $("#Date").val('<%= DateTime.Now.ToString("dd.MM.yyyy") %>');
            }

            $.datepicker.setDefaults($.datepicker.regional['ru']);
            $("#Date").datepicker({});
        });
    </script>
</asp:Content>

