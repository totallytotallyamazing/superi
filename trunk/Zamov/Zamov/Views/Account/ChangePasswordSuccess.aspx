<%@Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Html.ResourceString("PasswordChange")%>
</asp:Content>

<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%=Html.ResourceString("PasswordChange")%></h2>
    <p>
        <%=Html.ResourceString("PasswordHasBeenChanged")%>
    </p>
</asp:Content>
