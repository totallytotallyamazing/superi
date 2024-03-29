﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lady.Models.Category>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <%= Html.Hidden("parentId") %>
            <%= Html.HiddenFor(model=>model.Id) %>
        
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoDescription)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoDescription)%>
                <%= Html.ValidationMessageFor(model => model.SeoDescription)%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoKeywords)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoKeywords)%>
                <%= Html.ValidationMessageFor(model => model.SeoKeywords)%>
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
</asp:Content>

