<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Oksi.Models.Clip>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	�������� �����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>�������� �����</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend></legend>
            <p>
                <label>����� �� Youtube</label>
                <%=Html.TextBox("newUrl")%>
            </p>
            <p>
                <label for="Comment">�����������:</label>
                <%= Html.TextBox("Comment") %>
                <%= Html.ValidationMessage("Comment", "*") %>
            </p>
            <p>
                <label for="Title">���������:</label>
                <%= Html.TextBox("Title") %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Year">���:</label>
                <%= Html.TextBox("Year") %>
                <%= Html.ValidationMessage("Year", "*") %>
            </p>
            <p>
                <label for="SortOrder">������� �����������:</label>
                <%= Html.TextBox("SortOrder") %>
                <%= Html.ValidationMessage("SortOrder", "*") %>
            </p>
            <p>
                <label for="Description">��������:</label>
                <%= Html.TextBox("Description") %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            
            <p>
                <input type="submit" value="���������" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("����� � ������", "Video") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

