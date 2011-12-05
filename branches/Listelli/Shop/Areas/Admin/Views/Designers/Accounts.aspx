<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.DesignerUserPresentation>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Аккаунты дизайнеров
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Аккаунты дизайнеров</h2>

    <table class="designerAccounts">
    <tr>
    <th>Email / Login</th>
    <th>Адрес</th>
    </tr>


    
    <%
        foreach (var item in Model)
        {
                %>
                <tr>
                <td><%=item.Email%></td>
                <td><%=Html.ActionLink(item.Url, "Index", "Designers", new { area = "", id = item.Url }, new{@class="adminDesignerLink"})%></td>
                <td><%=Html.ActionLink("удалить", "DeleteAccount", "Designers", new { id = item.Email }, new { @class = "adminLink", onclick = "return confirm('Удалить аккаунт?')" })%></td>
                </tr>
                <%
        }
         %>
         </table>

         <p>
         <%=Html.ActionLink("Добавить аккаунт","Register","Account",new{area=""},null) %>
         </p>
         <p>
         <%=Html.ActionLink("К списку дизайнеров","Index","Designers",new{area="Admin"},null) %>
         </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
