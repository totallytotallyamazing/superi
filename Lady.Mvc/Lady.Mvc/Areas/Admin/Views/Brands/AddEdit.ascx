<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Lady.Mvc.Models.Brand>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            
             <%= Html.HiddenFor(model => model.Id) %>
            <div>
                <div style="float:left; width:100px;">
                    <div class="editor-label">
                        <%= Html.LabelFor(model => model.Name) %>
                    </div>
                    <div class="editor-field">
                        <%= Html.TextBoxFor(model => model.Name) %>
                        <%= Html.ValidationMessageFor(model => model.Name) %>
                    </div>
                    <div class="editor-label">
                        <%= Html.LabelFor(model => model.Logo) %>
                    </div>
                    <div class="editor-field">
                        <input type="file" name="logo" />
                    </div>
                </div>
                <div style="margin-left:101px">
                    <% if(Model!=null) %>
                        <%= Html.Image("~/Content/BrandLogos/" + Model.Logo, Model.Name); %>
                </div>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Description) %>
                <%= Html.ValidationMessageFor(model => model.Description) %>
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
            
            <div>
                <input type="submit" value="Сохранить" />
            </div>
        </fieldset>

    <% } %>

