<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>�����������!</h2>
    ����������� ����������� ���������.<br />
    ����������, ��������� ��� �������� ���� <strong><%= ViewData["email"] %></strong> � �������� �� ������, ������� ������� � ������. <br />
    � ����������� ������� ������ �������� � ������� ����� ������, �� ������ ��� ����� ��������� �� 10 �����.
    
</asp:Content>
<asp:Content ContentPlaceHolderID="includes" runat="server">
    <style type="text/css">
        #leftSide{border:none !important;}
    </style>
</asp:Content>