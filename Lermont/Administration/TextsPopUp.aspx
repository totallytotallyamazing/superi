<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TextsPopUp.aspx.cs" Inherits="Administration_TextsPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Выберите текст</title>
    <script type="text/javascript">
		function returnDataToOpener(id)
		{
			var opener = window.opener;
			close();
			opener.setValue(id);
		}
    </script>
    <style type="text/css">
		a{color:grey;}
		a:hover{text-decoration:underline;}
		td{border:1px solid grey;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
		<table style="border-collapse:collapse; width:100%;">
			<tr>
				<td>
					<b>ID</b>
				</td>
				<td><b>Заглавие</b></td>
			</tr>
			<asp:Repeater runat="server" ID="rTexts">
				<ItemTemplate>
					<tr>
						<td>
						    <% if (Mode.ToLower() == "alias")
             {%>
							<a href= "javascript:returnDataToOpener('<%# Eval("Alias") %>', '<%# Eval("Title") %>')"><%# Eval("Alias")%></a>
							<%} %>
							<%else
                                {%> 
                            <a href= "javascript:returnDataToOpener(<%# Eval("ID") %>, '<%# Eval("Title") %>')"><%# Eval("ID")%></a>
							<%} %>
						</td>
						<td>
							<%# Eval("Name") %>
						</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
		</table>
    </form>
</body>
</html>
