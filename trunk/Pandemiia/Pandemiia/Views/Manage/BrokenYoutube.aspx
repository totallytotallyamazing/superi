<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Pandemiia.Models.EntityVideo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	��������� �����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>��������� �����</h2>

    <% foreach (var item in Model) {
           using (Html.BeginForm("UpdateVideoSource", "Manage", FormMethod.Post))
           {
           %>
           <%= Html.Hidden("id", item.ID) %>
        ���� &quot;<%= item.Entity.Title%> &quot; �� <%= item.Entity.Date.Value.ToString("dd.MM.yyyy")%> <br />
        ����� &quot;<%= item.Entity.Title%> &quot; <br />
        ��� ������:<br />
        <%= Html.TextArea("source", item.Source, new { style = "width:270px;" })%><br />
        <input type="submit" value="��������" />
    <% }
       } %>

</asp:Content>

