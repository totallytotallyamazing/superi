<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Content>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        ContentStorage context = (ContentStorage)ViewData["context"];
    %>
    <% using (Html.BeginForm())
       { %>
    <%= Html.HiddenFor(m=>m.Name) %>
    <%= Html.HiddenFor(m=>m.Language) %>
    <div>
        <p>
            Заглавие:</p>
        <%= Html.LocalizedTextBoxFor(m=>m.Title, context.ContentLocalResource)  %>
    </div>
    <div class="rich">
        <p>
            Текст:</p>
        <%= Html.LocalizedTextAreaFor(m=>m.Text, context.ContentLocalResource)  %>
    </div>
    <div>
        <p>
            Keywords:</p>
        <%= Html.TextBoxFor(m=>m.Keywords)  %>
    </div>
    <div>
        <p>
            Description:</p>
        <%= Html.TextAreaFor(m=>m.Description)  %>
    </div>
    <input type="submit" value="Сохранить" />
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
    <%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>
    <script type="text/javascript" src="/Scripts/localization.js"></script>
    <script type="text/javascript" src="/Scripts/ck.settings.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".rich textarea").ckeditor(function () { }, { toolbar: "Media" });
            //			CKEDITOR.replace("Text", { toolbar: "Media" });
            CKEDITOR.on("instanceReady", function (e) {

            })
        });
        Localization.bindLocalizationSwitch();
    </script>
    <link rel="Stylesheet" href="/Content/admin.css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Title %>
</asp:Content>
