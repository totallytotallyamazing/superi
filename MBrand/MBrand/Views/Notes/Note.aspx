<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Common.Master" Inherits="System.Web.Mvc.ViewPage<MBrand.Models.Note>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="notesHolder">
        <div id="noteHeader">
            <span class="date"><%= Model.Date.ToString("dd.MM.yyyy") %></span><br />
            <%= Model.Title %>
        </div>
        <div>
            <%= Model.Text %>
        </div>
    </div>
    <% Html.RenderPartial("Pages"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    Заметки
</asp:Content>
