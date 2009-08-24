<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Html.ResourceString("PasswordChange")%>
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%=Html.ResourceString("PasswordChange")%></h2>
    <p>
       <%=Html.ResourceString("NewPasswordsAreRequired")%> <%=Html.Encode(ViewData["PasswordLength"])%>-ти <%=Html.ResourceString("CharactersInLength")%>.
    </p>
    <div style="color:Red">
    <%= Html.ValidationSummary(Html.ResourceString("PasswordChangeWasUnsuccessful"))%>
    </div>

    <% using (Html.BeginForm()) { %>
        <div>
            <table>
            <tr>
                <td><label for="currentPassword"><%=Html.ResourceString("CurrentPassword")%>:</label></td>
                <td><%= Html.Password("currentPassword") %></td>
                <td><%= Html.ValidationMessage("currentPassword") %></td>
            </tr>
            <tr>
                <td><label for="newPassword"><%=Html.ResourceString("NewPassword")%>:</label></td>
                <td><%= Html.Password("newPassword") %></td>
                <td><%= Html.ValidationMessage("newPassword") %></td>
            </tr>
            <tr>
                <td> <label for="confirmPassword"><%=Html.ResourceString("ConfirmNewPassword")%>:</label></td>
                <td><%= Html.Password("confirmPassword") %></td>
                <td><%= Html.ValidationMessage("confirmPassword") %></td>
            </tr>
            </table>
                <input type="submit" value="<%=Html.ResourceString("ChangePassword")%>" />
            
            
        </div>
    <% } %>
</asp:Content>
