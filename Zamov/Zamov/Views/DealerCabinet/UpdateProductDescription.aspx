<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>UpdateProductDescription</title>
</head>
<body>
    <table>
        <tr class="adminTable">
            <td><%= Html.ResourceString("Ukr") %></td>
            <td><%= Html.ResourceString("Rus") %></td>
        </tr>
        <tr>
            <td>
                <%= Html.TextArea("descroptionUkr") %>
            </td>
            <td>
                <%= Html.TextArea("descroptionRus") %>
            </td>
        </tr>
    </table>
</body>
</html>
