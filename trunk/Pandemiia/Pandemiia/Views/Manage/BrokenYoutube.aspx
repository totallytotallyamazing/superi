<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Pandemiia.Models.EntityVideo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	��������� �����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>��������� �����</h2>

    <% foreach (var item in Model) { %>
        ���� &quot;<%= item.Entity.Title %> &quot; <br />
        ����� &quot;<%= item.Entity.Title %> &quot; 
    <% } %>

</asp:Content>

