<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DealerCategoryMappings</title>
        <script type="text/javascript">
        function updateCategoryMappings() {
            document.getElementById("form1").submit();
        }
    </script>
</head>
<body>
    <%
        using (Html.BeginForm("DealerCategoryMappings", "DealerCabinet", FormMethod.Post, new { id = "form1" }))
        {
            List<SelectListItem> items = (List<SelectListItem>)ViewData["items"];
            foreach (var item in items)
            {
                Response.Write(Html.CheckBox(item.Value, item.Selected));
                Response.Write(item.Text);
                Response.Write("&nbsp;&nbsp;");
            }
        }
    %>
</body>
</html>
