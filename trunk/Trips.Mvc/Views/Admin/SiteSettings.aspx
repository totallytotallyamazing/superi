<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	��������� �����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using(Html.BeginForm()){ %>
        <h6>
            <label for="euroRate">
               ���� �� ������:
            </label>
        </h6>
        <%= Html.TextBox("euroRate") %>
        <br />
        <h6>
            <label for="dollarRate">
               �������� �� ������:
            </label>
        </h6>
        <%= Html.TextBox("dollarRate")%>
        <br />
        <h6>
            <label for="rubleRate">
               ������ �� ������:
            </label>
        </h6>
        <%= Html.TextBox("rubleRate")%>
        <br />
        <h6>
            <label for="receiverMail">
               ��. ����� ���������� �����������:
            </label>
        </h6>
        <%= Html.TextBox("receiverMail")%>
        <br />
        <h6>
            <label for="pageSize">
               ����� �� ��������:
            </label>
        </h6>
        <%= Html.TextBox("pageSize")%>
        <br />
        <input type="submit" value="���������" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    ��������� �����
</asp:Content>
