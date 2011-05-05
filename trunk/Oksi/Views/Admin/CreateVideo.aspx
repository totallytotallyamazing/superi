<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Oksi.Models.Clip>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Добавить видео
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Добавить видео</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend></legend>
            <p>
                <label>Адрес на Youtube</label>
                <%=Html.TextBox("newUrl")%>
            </p>
            <p>
                <label for="Comment">Комментарий:</label>
                <%= Html.TextBox("Comment") %>
                <%= Html.ValidationMessage("Comment", "*") %>
            </p>
            <p>
                <label for="Title">Заголовок:</label>
                <%= Html.TextBox("Title") %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Year">Год:</label>
                <%= Html.TextBox("Year") %>
                <%= Html.ValidationMessage("Year", "*") %>
            </p>
            <p>
                <label for="SortOrder">Порядок отображения:</label>
                <%= Html.TextBox("SortOrder") %>
                <%= Html.ValidationMessage("SortOrder", "*") %>
            </p>
            <p>
                <label for="Description">Описание:</label>
                <%= Html.TextBox("Description") %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Назад к списку", "Video") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

