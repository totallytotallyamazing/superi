<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Oksi.Models.Article>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Article
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Article</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Date">Date:</label>
                <%= Html.TextBox("Date") %>
                <%= Html.ValidationMessage("Date", "*") %>
            </p>
            <p>
                <label for="Description">Description:</label>
                <%= Html.TextBox("Description") %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <p>
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id") %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="Image">Image:</label>
                <%= Html.TextBox("Image") %>
                <%= Html.ValidationMessage("Image", "*") %>
            </p>
            <p>
                <label for="Language">Language:</label>
                <%= Html.TextBox("Language") %>
                <%= Html.ValidationMessage("Language", "*") %>
            </p>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="SubTitle">SubTitle:</label>
                <%= Html.TextBox("SubTitle") %>
                <%= Html.ValidationMessage("SubTitle", "*") %>
            </p>
            <p>
                <label for="Text">Text:</label>
                <%= Html.TextBox("Text") %>
                <%= Html.ValidationMessage("Text", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title") %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Type">Type:</label>
                <%= Html.TextBox("Type") %>
                <%= Html.ValidationMessage("Type", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

