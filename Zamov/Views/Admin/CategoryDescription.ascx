<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>

<% using(Html.BeginForm()){ %>    
<table>
    <tr>
        <td>
            <%= Html.TextArea("uaDescription") %>
        </td>
        <td>
            <%= Html.TextArea("ruDescription")%>
        </td>
    </tr>
</table>
<input type="submit" value="Сохранить" />
<%} %>
