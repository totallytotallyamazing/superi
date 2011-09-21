<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Oksi.Models.Article>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["pageTitle"] %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm("ProcessArticle", "Admin", new { id = 0, news = ViewData["news"] }))
       {%>
        <%= Html.Hidden("Id")%>
        <fieldset>
            <legend><%= ViewData["pageTitle"]%></legend>
            <p>
                <label for="Title">Заголовок:</label>
                <%= Html.TextBoxFor(m => m.Title, new { style="width:90%" })%>
            </p>
            <p>
                <label for="Date">Дата:</label>
                <%= Html.TextBoxFor(m => m.Date)%>
            </p>
            <p>
                <label for="Description">Описание:</label>
                <%= Html.TextAreaFor(m => m.Description)%>
            </p>
            <p>
                <label for="Text">Текст:</label>
                <%= Html.TextAreaFor(t=>t.Text)%>
            </p>
            <div id="invisible" style="display:none">
                <p style="display:none">
                    <label for="Type">Type:</label>
                    <%= Html.TextBox("Type")%>
                    <%= Html.ValidationMessage("Type", "*")%>
                </p>
                <p style="display:none">
                    <label for="Image">Image:</label>
                    <%= Html.TextBox("Image")%>
                    <%= Html.ValidationMessage("Image", "*")%>
                </p>
                <p style="display:none">
                    <label for="Language">Language:</label>
                    <%= Html.TextBox("Language", "ru-RU")%>
                    <%= Html.ValidationMessage("Language", "*")%>
                </p>
                <p style="display:none">
                    <label for="Name">Name:</label>
                    <%= Html.TextBox("Name")%>
                    <%= Html.ValidationMessage("Name", "*")%>
                </p>
                <p style="display:none">
                    <label for="SubTitle">SubTitle:</label>
                    <%= Html.TextBox("SubTitle")%>
                    <%= Html.ValidationMessage("SubTitle", "*")%>
                </p>
            </div>
            <p>
                <input type="submit" value="Далее" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Назад", "Articles", new { id=ViewData["type"]})%>
    </div>

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <%= Ajax.DynamicCssInclude("/Content/ui/jquery.ui.css") %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.ui.js") %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.ui.datepicker-ru.js")%>
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#Date").datepicker($.datepicker.regional['ru']);

            /*$.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config:
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
            
            $("#Text, #Description").fck({ toolbar: "Basic", height: 200 });
*/
        });
    </script>
</asp:Content>