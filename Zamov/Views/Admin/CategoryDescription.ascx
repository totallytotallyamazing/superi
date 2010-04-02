<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>

<% using(Html.BeginForm()){ %>    
<table>
    <tr>
        <th>Укр</th>
        <th>Рус</th>
    </tr>
    <tr>
        <td>
            <%= Html.TextBox("uaTitle")%>
            <%= Html.TextArea("uaDescription") %>
        </td>
        <td>
            <%= Html.TextBox("ruTitle")%>
            <%= Html.TextArea("ruDescription")%>
        </td>
    </tr>
</table>
<input type="submit" value="Сохранить" />
<%} %>
