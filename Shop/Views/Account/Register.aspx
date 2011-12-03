<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.RegisterModel>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Регистрация аккаунта дизайнеров
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="userInfoWrapper">
        <h2>
            Регистрация аккаунта дизайнеров</h2>
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           { %>
           <%= Html.Hidden("redirectTo") %>
        <table>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model=>model.Email) %>:<br />
                    <span class="comments">(он же является логином) </span>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Email) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model=>model.Email) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model=>model.Name) %>:
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Name) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model => model.Name)%>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model=>model.Password) %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Password) %>
                </td>
                <td class="validationError">
                    <%= Html.ValidationMessageFor(model => model.Password)%>
                </td>
            </tr>
        </table>
        <div>
            <input type="submit" value="Зарегистрировать" />
        </div>
        <p>
            <%=Html.ActionLink("К списку аккаунтов","Accounts","Designers",new{Area="Admin"},null) %>
        </p>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MvcRemoteValidator.js")%>
    <%= Ajax.DynamicCssInclude("/Content/Cart.css")%>
</asp:Content>
