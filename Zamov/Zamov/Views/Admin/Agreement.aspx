<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Agreement</title>
    <%= Html.RegisterJS("jquery.js") %>
    <%= Html.RegisterJS("fckeditorapi.js") %>
    <%= Html.RegisterJS("fckeditor.js") %>
    <%= Html.RegisterJS("fcktools.js") %>
    <%= Html.RegisterJS("jquery.FCKeditor.js") %>

    <script type="text/javascript">
        $(function() {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/"} };
            $('textarea#uaTetx').fck({ toolbar: "NoHyperlinks", height: 400, language: "RU", HTMLEncode: true });
            $('textarea#uaTetx').fck({ toolbar: "NoHyperlinks", height: 400, language: "RU", HTMLEncode: true });
        });

        function updateAgreement() {
            $("#mainForm").submit();
        }
    </script>

</head>
<body>
    <% using (Html.BeginForm("UpdateAgreement", "Admin", FormMethod.Post, new { id="mainForm" }))
       { %>
    <table>
        <tr class="adminTable">
            <td align="center"><%= Html.ResourceString("Ukr")%></td>
            <td align="center"><%= Html.ResourceString("Rus")%></td>
        </tr>
        <tr>
            <td style="width:330px;">
                <%= Html.TextArea("uaTetx")%>
            </td>
            <td style="width:330px;">
                <%= Html.TextArea("ruText")%>
            </td>
        </tr>
    </table>
    <%} %>
</body>
</html>
