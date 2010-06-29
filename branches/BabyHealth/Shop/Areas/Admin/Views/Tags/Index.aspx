<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Tag>>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                Тег
            </th>
            <th></th>
        </tr>
    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%= Html.Encode(item.Value) %>
            </td>
            <td>
                <%= Html.ActionLink("X", "Delete", new { id=item.Id })%>
            </td>
        </tr>
    
    <% } %>
    </table>
    <%using (Html.BeginForm("Add", "Tags", FormMethod.Post, new { id="addTagForm" })){ %>
        <div>
            <%= Html.TextBox("Value")%>
        </div>
        <input type="submit" value="Добавить" />
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/jquery.validate.js") %>
    <script type="text/javascript">
        $(function() {
            $("#addTagForm").validate(
            {
                rules: { Value: {required:true} }, 
                messages: {Value: "*"}
            });
        })
    </script>
</asp:Content>

