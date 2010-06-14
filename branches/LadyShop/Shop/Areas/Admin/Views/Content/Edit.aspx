<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lady.Models.Content>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using(Html.BeginForm()){ %>
    <%= Html.HiddenFor(m=>m.Name) %>
    <%= Html.HiddenFor(m=>m.Title) %>
    <%= Html.HiddenFor(m=>m.Language) %>

    <div>
    <p>Текст:</p>
    <%= Html.TextAreaFor(m=>m.Text)  %>
    </div>

    <div>
    <p>Keywords:</p>
    <%= Html.TextBoxFor(m=>m.Keywords)  %>
    </div>

    <div>
    <p>Description:</p>
    <%= Html.TextAreaFor(m=>m.Description)  %>
    </div>
    <input type="submit" value="Сохранить" />   
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    
    <script type="text/javascript">
            $(function() {
                $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
                $("#Text").fck({ toolbar: "Common", height: 400 });
            });
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Title %>
</asp:Content>
