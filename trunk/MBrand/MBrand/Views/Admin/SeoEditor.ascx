<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<table>
 <tr>
    <td>
        Title
    </td>
    <td>
        <%= Html.TextBox("title", ViewData["title"], new { style="width:600px" })%>
    </td>
 </tr>
 <tr>
    <td>
        Keywords
    </td>
    <td>
        <%= Html.TextBox("seoKeywords", ViewData["seoKeywords"], new { style = "width:600px" })%>
    </td>
 </tr>
 <tr>
    <td>
        Description
    </td>
    <td>
        <%= Html.TextBox("seoDescription", ViewData["seoDescription"], new { style = "width:600px" })%>
    </td>
 </tr>
</table>