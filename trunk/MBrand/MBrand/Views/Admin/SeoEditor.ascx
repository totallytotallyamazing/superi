<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<table>
 <tr>
    <td>
        Keywords
    </td>
    <td>
        <%= Html.TextBox("seoKeywords")%>
    </td>
 </tr>
 <tr>
    <td>
        Description
    </td>
    <td>
        <%= Html.TextBox("seoDescription")%>
    </td>
 </tr>
</table>