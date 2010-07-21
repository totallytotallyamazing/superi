<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.AuthorizeModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Авторизация
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ваши контактные данные</h2>
    <% Html.EnableClientValidation(); %>
    <% using(Html.BeginForm("Authorize", "Cart", FormMethod.Post, new{id="authorizeForm"})){ %>
    <div style="display:none">
        <%= Html.CheckBox("back", false) %>
    </div>
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
                <%= Html.ActionLink("Зарегистрируйте меня как пользователя,", "Register", new {controller="Account", area="", redirectTo = "~/Cart/DeliveryAndPayment"}, new {@class="pleaseRegister"})%> пожалуйста
            </td>
        </tr>
    </table>
    <div class="backAndForward">
        <div class="back">
            <a href="javascript:goBack();">Вернуться</a>
        </div>
        Все верно, <a href="javascript:$('#authorizeForm')[0].submit();">продолжаем!</a>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcValidation.js")%>
    <script type="text/javascript">
        function goBack() {
            document.getElementById("back").checked = true;
            document.getElementById("authorizeForm").submit();
        }
    
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 1); %>
</asp:Content>
