<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductAttributeValue>" %>

    <% using (Html.BeginForm(new { attributeId = ViewData["attributeId"] }))
       {%>
        <%= Html.ValidationSummary(true)%>
        
        <fieldset>
            <%= Html.HiddenFor(model => model.Id)%>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Value)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Value)%>
                <%= Html.ValidationMessageFor(model => model.Value)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SortOrder)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SortOrder)%>
                <%= Html.ValidationMessageFor(model => model.SortOrder)%>
            </div>
            
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

