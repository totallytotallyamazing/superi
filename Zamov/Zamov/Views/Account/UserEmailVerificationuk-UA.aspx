<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>³����!</h2>
    ��������� ����� ���������.<br />
    ���� �����, �������� ���� ������� �������� <%= ViewData["email"] %> � ������� �� ����, ���� �������� � ����. <br />
    � ������� ������� ����� ��������� �������� ���� �������, ��� ������ ��� ����� ������� �� 10 ������.
</asp:Content>