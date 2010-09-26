<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductVariant>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Id) %>
                <%: Html.ValidationMessageFor(model => model.Id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Price) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.OldPrice) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.OldPrice) %>
                <%: Html.ValidationMessageFor(model => model.OldPrice) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Published) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Published) %>
                <%: Html.ValidationMessageFor(model => model.Published) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ShortDescripton) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ShortDescripton) %>
                <%: Html.ValidationMessageFor(model => model.ShortDescripton) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SortOrder) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SortOrder) %>
                <%: Html.ValidationMessageFor(model => model.SortOrder) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Image) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Image) %>
                <%: Html.ValidationMessageFor(model => model.Image) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


