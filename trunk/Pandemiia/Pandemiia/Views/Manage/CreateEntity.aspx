<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>
<%@ Import Namespace="Pandemiia.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	������� ����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>������� ����</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>����</legend>
            <p>
                <label for="Title">���������:</label>
                <%= Html.TextBox("Title") %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Date">����:</label>
                <%= Html.TextBox("Date", null, new { @class = "dateInput", @readonly = "true"})%>
                <%= Html.ValidationMessage("Date", "*") %>
            </p>
            <script type="text/javascript">
                $(function() {
                $(".dateInput").datepicker();
                $.fck.config = { path: '../Controls/fckeditor/', height: 300, config: { SkinPath: "skins/office2003/", DefaultLanguage: "RU", AutoDetectLanguage: false, HtmlEncodeOutput: true} };
                $('textarea#Description').fck();
                $('textarea#Content').fck();
                });
            </script>
            <p>
                <label for="Description">��������:</label>
                <%= Html.TextArea("Description") %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <p>
                <label for="Content">����������:</label>
                <%= Html.TextArea("Content")%>
                <%= Html.ValidationMessage("Content", "*") %>
            </p>
            <p>
                <label for="TypeID">���:</label>
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
                <label for="SourceID">���:</label>
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
        <%=Html.ActionLink("�����", "Entities") %>
    </div>

</asp:Content>

