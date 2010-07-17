<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Авторизация
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ваши контактные данные</h2>
    <% Html.EnableClientValidation(); %>
    <% using(Html.BeginForm()){ %>
    <table>
        <tr>
            <td>
                Адрес элентропочты:<br />
                <span class="comments">
                    (при регистрации является вашим логином)
                </span>
            </td>
            <td>
                <%= Html.TextBoxFor(model=>model.Email) %>
            </td>
            <td>
                <%= Html.ValidationMessageFor(model=>model.Email) %>
            </td>
        </tr>
        <tr>
            <td>
                Имя, фамилия:
            </td>
            <td>
                <%= Html.TextBoxFor(model=>model.Name) %>
            </td>
            <td>
                <%= Html.ValidationMessageFor(model => model.Name)%>
            </td>
        </tr>
        <tr>
            <td>
                Номер телефона
            </td>
            <td>
                <%= Html.TextBoxFor(model=>model.Phone) %>
            </td>
            <td>
                <%= Html.ValidationMessageFor(model => model.Phone)%>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <%= Html.ActionLink("Зарегистрируйте меня как пользователя,", "Register", new { redirectTo = "~/Cart/DeliveryAndPayment"}, new {@class="pleaseRegister"})%> пожалуйста
            </td>
        </tr>
    </table>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 0); %>
</asp:Content>
