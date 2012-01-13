<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Article>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["title"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        ContentStorage context = (ContentStorage)ViewData["context"];
    %>

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <%=Html.Hidden("language")%>
    <%=Html.Hidden("type")%>
    <fieldset>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Title) %>
        </div>
        <div class="editor-field">
            <%= Html.LocalizedTextBoxFor(m=>m.Title, context.ContentLocalResource)  %>
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
        <div class="editor-field rich">
            <%= Html.LocalizedTextAreaFor(m=>m.Text, context.ContentLocalResource)  %>
            <%= Html.ValidationMessageFor(model => model.Text) %>
        </div>
        <div>
            Отправить подписчикам
            <%= Html.CheckBox("send") %></div>
    </fieldset>
    <fieldset>
        <legend>Поисковая оптимизация </legend>
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
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <%= Ajax.ScriptInclude("/Scripts/jquery.ui.js") %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.ui.datepicker-ru.js")%>
    <%= Ajax.DynamicCssInclude("/Content/blitzer/jquery.css")%>
    <%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
    <%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>

    <script type="text/javascript" src="/Scripts/localization.js"></script>

    <script type="text/javascript">
        $(function () {

            $(".rich textarea").ckeditor(function () { }, { toolbar: "Media" });

            if ($("#Date").val() === '') {
                $("#Date").val('<%= DateTime.Now.ToString("dd.MM.yyyy") %>');
            }

            $.datepicker.setDefaults($.datepicker.regional['ru']);
            $("#Date").datepicker({});
        });

        Localization.bindLocalizationSwitch();
    </script>
</asp:Content>
