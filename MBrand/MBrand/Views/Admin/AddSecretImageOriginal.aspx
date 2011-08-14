<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddSecretImageOriginal
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using (Html.BeginForm("AddSecretImageOriginal", "Admin", FormMethod.Post, new { enctype = "multipart/form-data", id=ViewData["id"] }))
               { %>

               <%=Html.Hidden("id")%>
    <span style="color:Black">Добавить оригинал изображения:</span> <input type="file" name="image" />
    <br />
    <input type="submit" value="Сохранить" />
<%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="SeoCustomTextContainer" runat="server">
</asp:Content>
