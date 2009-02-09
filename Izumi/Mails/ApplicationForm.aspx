<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationForm.aspx.cs" Inherits="Mails_ApplicationForm" %>
<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Controls:TextWriter runat="server" TextName="mailForm"></Controls:TextWriter>
    </div>
    </form>
</body>
</html>
