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
            <fieldset>
                <p>
                    <label for="currentPassword"><%=Html.ResourceString("CurrentPassword")%>:</label>
                    <%= Html.Password("currentPassword") %>
                    <%= Html.ValidationMessage("currentPassword") %>
                </p>
                <p>
                    <label for="newPassword"><%=Html.ResourceString("NewPassword")%>:</label>
                    <%= Html.Password("newPassword") %>
                    <%= Html.ValidationMessage("newPassword") %>
                </p>
                <p>
                    <label for="confirmPassword"><%=Html.ResourceString("ConfirmNewPassword")%>:</label>
                    <%= Html.Password("confirmPassword") %>
                    <%= Html.ValidationMessage("confirmPassword") %>
                </p>
                <p>
                    <input type="submit" value="Change Password" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
