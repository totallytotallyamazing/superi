<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Category>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        ShopStorage context = (ShopStorage)ViewData["context"];
    %>
    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("AddEdit", "Categories", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
        <%= Html.ValidationSummary(true)%>

        <fieldset>
            <%= Html.Hidden("parentId")%>
            <%= Html.HiddenFor(model => model.Id)%>
        
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name)%>
            </div>
            <div class="editor-field">
                <%= Html.LocalizedTextBoxFor(model => model.Name, context.ShopLocalResources)%>
                <%= Html.ValidationMessageFor(model => model.Name)%>
            </div>
            
<%--            <div class="labelCell">
                <%= Html.LabelFor(model => model.Image)%>
            </div>
                <div class="editor-field">
                    <input type="file" name="Image" />
                </div>
            <div style="margin-left:101px">
                <% if (Model != null && !string.IsNullOrWhiteSpace(Model.Image)) %>
                <%= Html.Image("~/Content/CategoryImages/" + Model.Image, Model.Name)%>
            </div>--%>
            <div class="editor-label">
                <%= Html.CheckBoxFor(model => model.Published)%> <%= Html.LabelFor(model => model.Published)%>
            </div>
<%--            <div class="editor-label">
                <%= Html.CheckBoxFor(model => model.ShowOnMainPage)%> <%= Html.LabelFor(model => model.ShowOnMainPage)%>
            </div>--%>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SortOrder)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SortOrder)%>
                <%= Html.ValidationMessageFor(model => model.SortOrder)%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoKeywords)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoKeywords)%>
                <%= Html.ValidationMessageFor(model => model.SeoKeywords)%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoDescription)%>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.SeoDescription)%>
                <%= Html.ValidationMessageFor(model => model.SeoDescription)%>
            </div>
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <script type="text/javascript" src="/Scripts/localization.js"></script>
    <script type="text/javascript">
        Localization.bindLocalizationSwitch();
    </script>
</asp:Content>

