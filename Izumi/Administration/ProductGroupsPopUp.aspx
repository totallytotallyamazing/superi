<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductGroupsPopUp.aspx.cs" Inherits="Administration_ProductGroupsPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Выберите группу продуктов</title>
    <script type="text/javascript">
		function returnDataToOpener(id)
		{
			var opener = window.opener;
			close();
			opener.setProductGroupValue(id);
		}
    </script>
    <style type="text/css">
		a{color:grey;}
		a:hover{text-decoration:underline;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView ID="twGroups" runat="server"></asp:TreeView>
    </form>
</body>
</html>
