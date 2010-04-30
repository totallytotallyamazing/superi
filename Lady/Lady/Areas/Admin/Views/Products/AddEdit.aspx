<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lady.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddEdit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Description) %>
                <%= Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Id) %>
                <%= Html.ValidationMessageFor(model => model.Id) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.OldPrice) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.OldPrice) %>
                <%= Html.ValidationMessageFor(model => model.OldPrice) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Price) %>
                <%= Html.ValidationMessageFor(model => model.Price) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoDescription) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoDescription) %>
                <%= Html.ValidationMessageFor(model => model.SeoDescription) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoKeywords) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoKeywords) %>
                <%= Html.ValidationMessageFor(model => model.SeoKeywords) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ShortDescription) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ShortDescription) %>
                <%= Html.ValidationMessageFor(model => model.ShortDescription) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.PartNumber) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.PartNumber) %>
                <%= Html.ValidationMessageFor(model => model.PartNumber) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

