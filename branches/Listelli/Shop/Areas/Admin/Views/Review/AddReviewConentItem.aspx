<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddReviewConentItem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddReviewConentItem</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <%=Html.Hidden("reviewContentId")%>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ContentType) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownList("ContentType", new List<SelectListItem>() { new SelectListItem { Text = "cont1", Value = "1" }, new SelectListItem { Text = "cont2", Value = "2" } })%>
            </div>

          
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Text) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Text) %>
                <%: Html.ValidationMessageFor(model => model.Text) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SortOrder) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SortOrder) %>
                <%: Html.ValidationMessageFor(model => model.SortOrder) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

