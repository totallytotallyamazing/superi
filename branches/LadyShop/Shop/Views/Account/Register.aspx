<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Base.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.RegisterModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Регистрация
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ваши контактные данные</h2>
    <% Html.EnableClientValidation(); %>
    <% using(Html.BeginForm()){ %>
    <table>
        <tr>
            <td>
                <%= Html.LabelFor(model=>model.Email) %>:<br />
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
                <%= Html.LabelFor(model=>model.Name) %>:
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
                <%= Html.LabelFor(model=>model.Phone) %>:
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
                <span class="pleaseRegister">Зарегистрируйте меня как пользователя,</span> пожалуйста
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.LabelFor(model=>model.DeliveryAddress) %>
            </td>
            <td colspan="2">
                <%= Html.TextAreaFor(model=>model.DeliveryAddress) %>
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.LabelFor(model=>model.Password) %>
            </td>
            <td>
                <%= Html.TextBoxFor(model=>model.Password) %>
            </td>
            <td>
                <%= Html.ValidationMessageFor(model => model.Password)%>
            </td>
        </tr>
    </table>
    <input type="submit" value="Зарегистрироваться" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 0); %>
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>\
    <%= Ajax.ScriptInclude("/Scripts/MvcRemoteValidator.js")%>
</asp:Content>
