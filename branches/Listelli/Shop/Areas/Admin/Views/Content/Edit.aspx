﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Content>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
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
    <%= Ajax.CkEditor("Text", "null", "mySettings"); %>
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
    <script type="text/javascript" src="/Scripts/ck.settings.js"></script>
    <script type="text/javascript">
        /// <reference path="ck.settings.js"
        var mySettings = new ck();
        settings.settings.extend({ toolbar: ck.toolbars.media });
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Title %>
</asp:Content>
