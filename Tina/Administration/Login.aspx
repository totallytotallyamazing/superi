<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administration_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
		<table style="width:100%;">
			<tr>
				<td align="center">
			         <asp:Login ID="Login1" runat="server" LoginButtonText="Вход" PasswordLabelText="Пароль:" RememberMeText="Запомнить меня" TitleText="Вход" UserNameLabelText="Логин:" DisplayRememberMe="False" >
                     </asp:Login>
				</td>
			</tr>
		</table>
    </form>
</body>
</html>
