<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>
<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<%@ Import Namespace="Pandemiia.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CreateEntity
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>CreateEntity</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Заголовок">Title:</label>
                <%= Html.TextBox("Title") %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Дата">Date:</label>
                <%= Html.TextBox("Date") %>
                <%= Html.ValidationMessage("Date", "*") %>
            </p>
            <p>
                <label for="Описание">Description:</label>
                
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <p>
                <label for="Content">Content:</label>
                <FCKeditor:FCKeditor ID="FCKeditor1" runat="server" BasePath="../../Controls/fckeditor/" SkinPath="skins/office2003/" DefaultLanguage="RU" AutoDetectLanguage="false"></FCKeditor:FCKeditor>
                <%= Html.ValidationMessage("Content", "*") %>
            </p>
            <p>
                <label for="TypeID">Тип:</label>
                <select name="TypeID" id="TypeID">
                <%foreach (EntityType src in (IEnumerable)ViewData["EntityTypes"])%>
                <%{%>
                    <option value="<%= src.ID %>">
                        <%= src.Name %>
                    </option>
                <%}%>
                </select>
                <%= Html.ValidationMessage("TypeID", "*") %>
            </p>
            <p>
                <label for="SourceID">Чье:</label>
                <select name="SourceID" id="SourceID">
                <%foreach (EntitySource src in (IEnumerable)ViewData["EntitySources"])%>
                <%{%>
                    <option value="<%= src.ID %>">
                        <%= src.Name %>
                    </option>
                <%}%>
                
                <%= Html.ValidationMessage("SourceID", "*") %>
                </select>
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

