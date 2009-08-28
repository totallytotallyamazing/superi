<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<List<CategoryPresentation>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DealerCategoryMappings</title>
        <script type="text/javascript">
        function updateCategoryMappings() {
            document.getElementById("form1").submit();
        }
    </script>
    <%= Html.RegisterJS("jquery.js") %>
    <%= Html.RegisterJS("jquery.treeview.js") %>
    <%= Html.RegisterCss("~/Content/jquery.treeview.css") %>
</head>
<body>
    <%
        using (Html.BeginForm("DealerCategoryMappings", "DealerCabinet", FormMethod.Post, new { id = "form1" }))
        {%>
            <%= Html.TreeView("categories", Model, c=>c.Children, c=>Html.CheckBox(c.Id.ToString(), c.Selected) + c.Name, true) %>
      <%}
    %>
</body>
</html>
