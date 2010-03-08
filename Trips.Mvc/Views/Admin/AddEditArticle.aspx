<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["cTitle"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentEditor">
    <% using (Html.BeginForm("AddEditArticle", "Admin", FormMethod.Post, new { id = "AddEditArticle" })){ %>
        <%= Html.Hidden("isNew") %>
        <p>
            Адрессная строка:<span id="idErrorHolder"></span> <br />
            <%if((bool)ViewData["isNew"]){ %>
                <%= Html.TextBox("id") %>
            <%} %>
            <%else{ %>
                <strong><%= ViewData["id"] %></strong>
            <%} %>
        </p>
        <p>
            Заглавие:<span id="titleErrorHolder"></span> <br />
            <%= Html.TextBox("title") %>
        </p>
        <p>
            Дата: <span id="dateErrorHolder"></span> <br />
            <%= Html.TextBox("date") %>
        </p>
        <p>
            Текст: <span id="textErrorHolder"></span> <br />
            <%= Html.TextArea("text") %>
        </p>
        <p>
            Description:<br />
            <%= Html.TextBox("description") %>
        </p>
        <p>
            Keywords:<br />
            <%= Html.TextBox("keywords") %>
        </p>
        <input type="submit" value="Сохранить" />
    <%} %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude("/Content/Admin.css") %>
    <%= Ajax.DynamicCssInclude("/Content/ui/jquery.ui.css") %>
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.ui.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.ui.datepicker-ru.js"></script>

    <script type="text/javascript">
        $(function() {
            $("#date").datepicker($.datepicker.regional['ru']);
            $("#AddEditArticle").validate({
                errorPlacement: function(error, element) {
                    $("#" + element[0].id + "ErrorHolder").append(error);
                },
                messages: {
                    id: "*",
                    title: "*",
                    date: "*",
                    text: "*"
                },
                rules: {
                    id: { required: true },
                    title: { required: true },
                    date: { required: true },
                    text: { required: true }
                }
            });

            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config:
            {
                SkinPath: "skins/office2003/",
                DefaultLanguage: "ru",
                AutoDetectLanguage: false,
                EnterMode: "br",
                ShiftEnterMode: "p",
                HtmlEncodeOutput: true,
                _FileBrowserLanguage: "aspx"
}
            };
            $("#text").fck({ toolbar: "Default", height: 400 });
        });
    </script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= ViewData["cTitle"] %>
</asp:Content>
