<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>
<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	������������� ����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>������������� ����</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>����</legend>
            <p style="display:none">
                <label for="ID">ID:</label>
                <%= Html.TextBox("ID", Model.ID) %>
                <%= Html.ValidationMessage("ID", "*") %>
            </p>
            <p>
                <label for="Title">���������:</label>
                <%= Html.TextBox("Title", Model.Title) %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Date">����:</label>
                <%= Html.TextBox("Date", String.Format("{0:g}", Model.Date), new { @class = "dateInput", @readonly = "true" })%>
                <%= Html.ValidationMessage("Date", "*") %>
            </p>
            <script type="text/javascript">
                $(function() {
                    $(".dateInput").datepicker();
                    $.fck.config = { path: '../../Controls/fckeditor/', height: 300, config: { SkinPath: "skins/office2003/", DefaultLanguage: "RU", AutoDetectLanguage: false, HtmlEncodeOutput: true} };
                    $('textarea#Description').fck();
                    $('textarea#Content').fck();
                });
            </script>
            <p>
                <label for="Description">��������:</label>
                <%= Html.TextArea("Description", Model.Description) %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <p>
            
                <label for="Content">����������:</label>
                <%= Html.TextArea("Content", Model.Content)%>
                <%= Html.ValidationMessage("Content", "*") %>
            </p>
            <p>
                <label for="TypeID">���:</label>
                <%= Html.DropDownList("TypeID", (IEnumerable<SelectListItem>)ViewData["EntytyTypes"], "�������� ���")%>
                <%= Html.ValidationMessage("TypeID", "*") %>
            </p>
            <p>
                <label for="SourceID">���:</label>
                <%= Html.TextBox("SourceID", Model.SourceID) %>
                <%= Html.ValidationMessage("SourceID", "*") %>
            </p>
            <p>
                <input type="submit" value="���������"/>
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("�����", "Entities") %>
    </div>

</asp:Content>

