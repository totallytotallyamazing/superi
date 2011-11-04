<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContentItemImage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddReviewContentItemImage
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddReviewContentItemImage</h2>

    <% using (Html.BeginForm("AddReviewContentItemImage", "Review", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <%=Html.Hidden("reviewContentId")%>
            <%=Html.Hidden("reviewContentItemId")%>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.ImageSource) %>
            </div>
            <div class="editor-field">
                <input type="file" name="logo" />
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

