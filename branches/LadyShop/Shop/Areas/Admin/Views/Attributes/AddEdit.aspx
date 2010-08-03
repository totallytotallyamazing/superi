<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ProductAttribute>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <%= Html.HiddenFor(model => model.Id) %>
        
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Name) %>
            <%= Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.ListName) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.ListName)%>
            <%= Html.ValidationMessageFor(model => model.ListName)%>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.SortOrder) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.SortOrder)%>
            <%= Html.ValidationMessageFor(model => model.SortOrder)%>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Static) %>
        </div>
        <div class="editor-field">
            <%= Html.CheckBoxFor(model => model.Static) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.ShowInCommonView) %>
        </div>
        <div class="editor-field">
            <%= Html.CheckBoxFor(model => model.ShowInCommonView)%>
        </div>
        <input type="submit" value="Сохранить" />
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

